/* ============================================================================
   สร้างใบงานแบบ Draft แทนผู้ใช้งาน  (พร้อมรัน)

   โจทย์ : HR เลือกประเภทฟอร์ม + เลือกกลุ่มพนักงาน แล้วสร้างใบเปล่าไว้ให้
           พนักงานเข้าไปกรอกข้อมูลเองแล้วค่อยกดส่ง

   ไฟล์นี้แก้ 2 อย่าง
     1) up_service_ins            เพิ่ม @status เพื่อสร้างเป็น Draft ได้
     2) fn_service_my_request     ให้เจ้าของใบเปิดใบ Draft ของตัวเองได้

   *** ยังไม่ครบ ต้องทำต่ออีก 3 จุด ดูท้ายไฟล์ ***
       ที่สำคัญที่สุดคือ ServiceStepInfo ถ้าไม่มีแถวของสถานะ Draft
       หน้ารายละเอียดใบงานจะพัง (บทเรียนเดียวกับกรณี Assign)
   ============================================================================ */

USE [EmpHub]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/* ============================================================================
   1) up_service_ins  :  เพิ่ม @status

   @status เป็น optional default 'Request' ของเดิมเรียกยังไงก็ยังทำงานเหมือนเดิม
   จึงไม่ต้อง deploy SQL กับ API พร้อมกันเป๊ะ

   requestBy ยังคงเป็น @userId (เจ้าของใบ) ไม่ใช่ @createBy
   เพราะผู้ขอตัวจริงคือพนักงาน HR เป็นแค่คนตั้งใบให้
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
, @status nvarchar(50) = 'Request'		/* << เพิ่ม : ส่ง 'Draft' เพื่อสร้างใบเปล่า */
, @id nvarchar(50) output
)
as
begin

	set @id = 'service_' + lower(newid())

	/* กันค่าแปลกปลอม รับได้แค่ 2 ค่านี้ */
	set @status = isnull(@status, 'Request')
	if @status not in ('Request', 'Draft')
		set @status = 'Request'

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
		, @status as status					/* << เดิมฮาร์ดโค้ด 'Request' */
		, 1 as is_active
		, @createBy as createBy
		, getdate() createDate
		, @userId as requestBy
	) as r

end
GO


/* ============================================================================
   2) fn_service_my_request  :  ให้เจ้าของใบเปิดใบ Draft ของตัวเองได้

   จงใจผูกเงื่อนไข userId ไว้กับสถานะ Draft เท่านั้น
   เพราะถ้าเปิดกว้างเป็น "userId = @userId ทุกสถานะ" จะกระทบข้อมูลเดิม
   ใบที่ HR เคยสร้างแทนพนักงานไว้ (เช่น แก้ประวัติการศึกษา) จะโผล่ให้พนักงาน
   เห็นย้อนหลังทั้งหมดทันที ซึ่งไม่ใช่สิ่งที่ขอ และอาจมีใบที่ไม่ควรให้เห็น

   ถ้าภายหลังอยากให้เห็นทุกใบที่เกี่ยวกับตัวเอง ค่อยถอด and t.status = 'Draft' ออก
   แต่ต้องรีวิวผลกระทบกับข้อมูลเดิมก่อน
   ============================================================================ */
ALTER function [dbo].[fn_service_my_request]
(
@id nvarchar(50)
, @userId nvarchar(50)
)
returns int
as
begin

	declare @is_allow int = 0

	select top 1 @is_allow = 1
	from ServiceInfo t with(nolock)
	where t.is_active = 1
	and t.id = @id
	and (
		t.createBy = @userId									/* ของเดิม : คนสร้าง */
		or (t.userId = @userId and t.status = 'Draft')		/* << เพิ่ม : เจ้าของใบ Draft */
	)

	return @is_allow

end
GO


/* ============================================================================
   ตรวจผลหลังรัน
   ============================================================================ */
-- 1. proc รับ @status แล้ว (ต้องเจอ 1 แถว)
SELECT  p.name AS [parameter], TYPE_NAME(p.user_type_id) AS [type], p.has_default_value
FROM    sys.parameters p
WHERE   p.object_id = OBJECT_ID('dbo.up_service_ins')
  AND   p.name = '@status';
GO

-- 2. ลองสร้างใบ Draft (แก้ userId / createBy เป็นค่าจริงก่อนรัน)
-- DECLARE @newId NVARCHAR(50)
-- EXEC up_service_ins
--        @userId          = N'<userId ของพนักงาน>'
--      , @categoryId      = N''
--      , @categoryCode    = N''
--      , @categoryDesc    = N''
--      , @subCategoryId   = N''
--      , @subCategoryCode = N'FORM_BUY_UNIFORM'
--      , @subCategoryDesc = N'ขอซื้อเครื่องแบบ'
--      , @title           = N'ขอซื้อเครื่องแบบ'
--      , @detail          = N''
--      , @createBy        = N'<userId ของ HR>'
--      , @status          = N'Draft'
--      , @id              = @newId OUTPUT
-- SELECT id, userId, createBy, requestBy, status FROM ServiceInfo WHERE id = @newId
--
-- 3. พนักงานต้องเปิดใบนั้นได้ (ต้องได้ 1)
-- SELECT dbo.fn_service_my_request(@newId, N'<userId ของพนักงาน>') AS employee_can_open
-- 4. HR ก็ยังเปิดได้ (ต้องได้ 1)
-- SELECT dbo.fn_service_my_request(@newId, N'<userId ของ HR>') AS hr_can_open
GO


/* ============================================================================
   ยังต้องทำต่ออีก 3 จุด  (ยังไม่ได้แก้ในไฟล์นี้)


   [A] ServiceStepInfo  ***ตรวจแล้ว ไม่ต้องทำอะไร***  (2026-08-11)

       เดิมกังวลว่า join ด้วยสถานะจะทำให้หน้ารายละเอียดพัง  ตรวจแล้วไม่ใช่
       คำสั่งนั้นเป็นคำสั่งแยกที่หา @stepIndex อย่างเดียว ไม่ได้คุม select หลัก
       ถ้าไม่เจอแถว @stepIndex ก็เป็น 0 ตามค่าเริ่มต้น หน้าจอยังทำงานปกติ

       ยืนยันอีกชั้นจากข้อมูลจริง สถานะใน ServiceStepInfo มีแค่
           Approve1 .. Approve6 , Work
       ไม่มี 'Request' อยู่ด้วยซ้ำ แปลว่าใบสถานะ Request ทุกใบก็ได้ stepIndex = 0
       อยู่แล้วเป็นปกติ  Draft จึงทำงานเหมือนกันเป๊ะ ไม่ต้อง insert อะไรเพิ่ม

       (ไม่ซ้ำรอยกับดัก 'Assign' เพราะตอนนั้น join คุมผลลัพธ์จริง
        แต่ตรงนี้แค่หาเลข step)


   [B] up_service_detail : can_edit  ***แก้แล้ว***  (2026-08-11)

           , case when @can_approve = 1
                   or (t.createBy = @userBy and t.status = 'Request')
                   or (t.userId  = @userBy and t.status = 'Draft')
                  then 1 else 0 end as can_edit


   [B2] up_service_detail : statusDesc  ***ยังไม่ได้แก้***

       บล็อก case ของ statusDesc ไม่มีสาขาของ 'Draft' จึงตกไปที่ else '-'
       พนักงานจะเห็นสถานะเป็นขีดเดียว ไม่รู้ว่าต้องเข้าไปกรอกข้อมูล

       เพิ่ม 1 บรรทัดก่อน else
           when t.status = 'Draft' then N'รอกรอกข้อมูล'

       ไม่ได้เขียน ALTER เต็มให้ เพราะไฟล์ต้นฉบับเป็น UTF-16
       ตอนอ่านข้อความไทยกลายเป็นอักขระเพี้ยน ถ้าเขียนทับจะทำข้อความสถานะเดิมพัง
       แก้บรรทัดเดียวใน SSMS ปลอดภัยกว่า

       จุดอื่นที่แสดงสถานะก็ต้องเพิ่ม Draft ด้วย ตรวจให้ครบ
           up_service_request_sel / up_service_inquire_sel / up_service_work_sel
           และ statusCss ฝั่งหน้าจอ


   [B3] can_cancel  (ไม่ใช่บั๊ก แต่ควรรู้)

           case when t.status not in ('Cancel','Reject','Complete')
                 and t.createBy = @userBy then 1 else 0 end

       ผูกกับ createBy แปลว่า HR ยกเลิกใบ Draft ที่ตัวเองสร้างได้
       แต่พนักงานยกเลิกใบที่ถูกสั่งมาไม่ได้  ตั้งใจให้เป็นแบบนี้
       ถ้าภายหลังอยากให้พนักงานปฏิเสธได้ ต้องเพิ่มเงื่อนไข userId เข้าไป


   [C] up_service_request_sel  :  ให้ใบ Draft โผล่ในลิสต์ของพนักงาน

       ถ้าลิสต์กรองด้วย createBy อย่างเดียว พนักงานจะไม่เห็นว่ามีใบรอกรอกอยู่
       ฟีเจอร์จะใช้ไม่ได้เลยแม้ข้อ A และ B จะแก้แล้ว
       ขอไฟล์ up_service_request_sel.sql มาด้วยครับ

       ตอน deploy จริงควรแยกแสดงให้ชัด เช่น ป้าย "รอกรอกข้อมูล"
       เพื่อให้พนักงานรู้ว่าต้องทำอะไรต่อ


   ลำดับที่เหลือ :  B2 -> C -> API (Service/CreateBulk) -> หน้าจอเลือกฟอร์ม+กลุ่มผู้ใช้
                    (A กับ B ปิดจบแล้ว)
   ============================================================================ */
