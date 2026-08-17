/* ============================================================================
   แยกใบ "สร้างใบงานแทนผู้ใช้" ออกจากใบ "HR แก้ไขข้อมูลพนักงาน"  (พร้อมรัน)

   ปัญหา
     ทั้งสองแบบมี userId <> createBy เหมือนกัน แยกจากกันไม่ได้
     หน้า Service/OnBehalf จึงดึงใบแก้ไขข้อมูลพนักงานติดมาด้วยทั้งหมด

     และเดาจากสถานะ 'Draft' แทนไม่ได้ เพราะพอพนักงานกดส่ง
     สถานะเปลี่ยนเป็น Request ทันที ใบนั้นจะแยกไม่ออกอีกเลย
     หน้าติดตามงานจะสูญเสียใบที่ส่งแล้ว ซึ่งเป็นข้อมูลสำคัญที่สุดของหน้า

   วิธีแก้ : บันทึกเจตนาไว้ตอนสร้าง ไม่พยายามอนุมานย้อนหลัง

   *** ไม่ต้อง backfill ***
   ใบเก่าเป็น NULL และจะไม่โผล่ในหน้าใหม่โดยอัตโนมัติ ซึ่งถูกต้องแล้ว

   ต้องรัน 2026-08-11_add_service_draft_onbehalf.sql
   และ 2026-08-11_add_service_onbehalf_proc.sql ก่อน
   ============================================================================ */

USE [EmpHub]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/* ============================================================================
   1) เพิ่มคอลัมน์
   ============================================================================ */
IF NOT EXISTS (SELECT 1 FROM sys.columns
               WHERE object_id = OBJECT_ID('dbo.ServiceInfo') AND name = 'createMode')
BEGIN
    ALTER TABLE dbo.ServiceInfo ADD createMode nvarchar(20) NULL
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.columns
               WHERE object_id = OBJECT_ID('dbo.ServiceInfo') AND name = 'batchId')
BEGIN
    ALTER TABLE dbo.ServiceInfo ADD batchId nvarchar(50) NULL
END
GO

/* ค่าที่ใช้ใน createMode

     NULL            ใบปกติ และใบเก่าทั้งหมดก่อนมีฟีเจอร์นี้
     'OnBehalfDraft' สร้างใบเปล่าให้พนักงานไปกรอกเอง   <- หน้า Service/OnBehalf ดูตัวนี้

   เผื่อไว้ให้ตั้งเพิ่มภายหลังได้ ถ้าอยากแยกใบที่ HR กรอกแทนแล้วส่งเลย
     'OnBehalfEdit'  HR กรอกเนื้อหาเองแล้วส่งทันที (พฤติกรรมเดิมของฟอร์มแก้ไขข้อมูล)
   ตอนนี้ยังไม่ตั้ง เพื่อไม่ให้กระทบของเดิม

   batchId  = การสร้าง 1 ครั้งของ HR ใช้ค่าเดียวกันทุกใบในรอบนั้น
              ทำให้ยกเลิกทั้งชุด หรือดูความคืบหน้ารายรอบได้
              ต้องใส่ตั้งแต่ตอนสร้าง ภายหลัง backfill ไม่ได้ */

CREATE NONCLUSTERED INDEX IX_ServiceInfo_createMode
    ON dbo.ServiceInfo (createMode, createBy) INCLUDE (batchId, status)
    WHERE createMode IS NOT NULL
GO


/* ============================================================================
   2) up_service_ins  :  รับ createMode / batchId
   ============================================================================ */
ALTER procedure [dbo].[up_service_ins]
(
@userId nvarchar(50)
, @categoryId nvarchar(50)
, @categoryCode nvarchar(50)
, @categoryDesc nvarchar(100)
, @subCategoryId nvarchar(50)
, @subCategoryCode nvarchar(50)
, @subCategoryDesc nvarchar(100)
, @title nvarchar(100)
, @detail nvarchar(max)
, @createBy nvarchar(50)
, @status nvarchar(50) = 'Request'
, @createMode nvarchar(20) = NULL		/* << เพิ่ม */
, @batchId nvarchar(50) = NULL			/* << เพิ่ม */
, @id nvarchar(50) output
)
as
begin

	set @id = 'service_' + lower(newid())

	set @status = isnull(@status, 'Request')
	if @status not in ('Request', 'Draft')
		set @status = 'Request'

	/* ว่าง = NULL ให้เท่ากับใบปกติ ไม่ให้เกิดค่า '' ปนกับ NULL */
	if isnull(@createMode, '') = '' set @createMode = NULL
	if isnull(@batchId, '') = ''    set @batchId = NULL

	insert into ServiceInfo(
	id
	, userId
	, categoryId
	, categoryCode
	, categoryDesc
	, subCategoryId
	, subCategoryCode
	, subCategoryDesc
	, title
	, detail
	, status
	, is_active
	, createBy
	, createDate
	, requestBy
	, createMode
	, batchId
	)
	select *
	from (
		select @id as id
		, @userId as userId
		, @categoryId as categoryId
		, @categoryCode as categoryCode
		, @categoryDesc as categoryDesc
		, @subCategoryId as subCategoryId
		, @subCategoryCode as subCategoryCode
		, @subCategoryDesc as subCategoryDesc
		, @title as title
		, @detail as detail
		, @status as status
		, 1 as is_active
		, @createBy as createBy
		, getdate() createDate
		, @userId as requestBy
		, @createMode as createMode
		, @batchId as batchId
	) as r

end
GO


/* ============================================================================
   3) แก้ตัวกรองของ 2 proc ที่เขียนไว้เมื่อวาน

   ของเดิมกรองด้วย  and t.userId <> t.createBy
   ซึ่งจับใบแก้ไขข้อมูลพนักงานติดมาด้วย

   เปลี่ยนเป็น       and t.createMode = 'OnBehalfDraft'

   มี 2 จุดใน up_service_onbehalf_sel และ 1 จุดใน up_service_onbehalf_summary
   แก้ในไฟล์ 2026-08-11_add_service_onbehalf_proc.sql แล้วรันซ้ำได้เลย
   (ไฟล์นั้นใช้ DROP + CREATE จึงรันทับได้ปลอดภัย)
   ============================================================================ */


/* ============================================================================
   ตรวจผลหลังรัน
   ============================================================================ */
-- 1. คอลัมน์ถูกเพิ่มแล้ว (ต้องได้ 2 แถว)
SELECT  c.name, TYPE_NAME(c.user_type_id) AS [type], c.is_nullable
FROM    sys.columns c
WHERE   c.object_id = OBJECT_ID('dbo.ServiceInfo')
  AND   c.name IN ('createMode', 'batchId');
GO

-- 2. proc รับพารามิเตอร์ใหม่แล้ว (ต้องได้ 2 แถว)
SELECT  p.name AS [parameter], p.has_default_value
FROM    sys.parameters p
WHERE   p.object_id = OBJECT_ID('dbo.up_service_ins')
  AND   p.name IN ('@createMode', '@batchId');
GO

-- 3. ดูว่าใบเก่าไม่ถูกแตะต้อง  ทุกแถวต้องเป็น NULL
SELECT  ISNULL(createMode, N'(NULL - ใบเดิม)') AS createMode, COUNT(*) AS total
FROM    ServiceInfo WITH(NOLOCK)
WHERE   is_active = 1
GROUP BY createMode;
GO


/* ============================================================================
   ยังต้องแก้ฝั่ง C#  (ยังไม่ได้ทำในไฟล์นี้)

   [1] APIEmpHub/Models/ServiceModels.cs

       เพิ่ม property
           public string createMode { get; set; }
           public string batchId { get; set; }

       ใน Create() เพิ่มพารามิเตอร์ 2 ตัว ต่อจาก @status
           , iSql.SqlCom_Parameter("@createMode", HelperConvert.ConvertToString(iProp.createMode))
           , iSql.SqlCom_Parameter("@batchId", HelperConvert.ConvertToString(iProp.batchId))

       *** ต้องวางก่อน @id output เสมอ ***

       ใน CreateBulk()
         - สร้าง batchId ครั้งเดียวก่อนเข้าลูป  ให้ทุกใบในรอบนั้นใช้ค่าเดียวกัน
               string batchId = "batch_" + Guid.NewGuid().ToString().ToLower();
         - ส่ง createMode = "OnBehalfDraft" และ batchId ตัวนั้นเข้าไปกับ Create()
         - ตัวเช็คสร้างซ้ำ (hExist) ยังใช้ได้เหมือนเดิม ไม่ต้องแก้

   [2] ไม่ต้องแก้ controller
       CreateBulk บังคับค่าเองทั้งคู่ ไม่รับจากหน้าจอ
       ถ้าปล่อยให้หน้าจอส่ง createMode มาได้ จะปลอมใบให้ดูเหมือนสร้างแทนได้

   [3] ไม่ต้องแก้หน้าจอ
       OnBehalf.cshtml ส่ง status = 'Draft' อยู่แล้ว ที่เหลือ backend ใส่ให้เอง
   ============================================================================ */
