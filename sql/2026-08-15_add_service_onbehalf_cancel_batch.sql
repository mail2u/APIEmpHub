/* ============================================================================
   ยกเลิกใบงานที่สร้างแทนผู้ใช้ ทั้งชุดในครั้งเดียว  (พร้อมรัน)

   ต้องรัน 2026-08-12_add_service_createmode.sql ก่อน  (ต้องมีคอลัมน์ batchId)

   กติกาที่เจ้าของงานกำหนด
     ยกเลิกได้เฉพาะภายในวันที่สร้าง และภายในวันนั้นยกเลิกได้ทุกใบ ไม่จำกัดสถานะ
     เจตนาคือแก้ความผิดพลาดได้ทันทีที่รู้ตัว
     แต่พ้นวันไปแล้วห้ามไปรบกวนงานที่เดินไปแล้ว

   "ภายในวัน" = วันตามปฏิทิน ไม่ใช่ 24 ชั่วโมง
   สร้าง 23:50 แล้วเที่ยงคืนผ่านไปคือหมดสิทธิ์
   ถ้าต้องการเป็น 24 ชั่วโมง เปลี่ยนเงื่อนไขเป็น
       t.createDate >= dateadd(hour,-24,getdate())

   คืนผลเป็น 1 แถว เพื่อให้หน้าจอแจ้งผลตรงความจริง
       total_cancel   ยกเลิกสำเร็จกี่ใบ
       total_expired  หมดสิทธิ์เพราะพ้นวันแล้วกี่ใบ
       total_filled   ในจำนวนที่ยกเลิก มีที่พนักงานกรอกและส่งไปแล้วกี่ใบ
   ============================================================================ */

USE [EmpHub]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('dbo.up_service_onbehalf_cancel_batch', 'P') IS NOT NULL
    DROP PROCEDURE dbo.up_service_onbehalf_cancel_batch
GO

CREATE procedure [dbo].[up_service_onbehalf_cancel_batch]
(
@batchId nvarchar(50)
, @userBy nvarchar(50)
/* @update_by ยังรับไว้เพื่อให้ API ที่ส่งมาแล้วไม่พัง แต่ไม่ได้ใช้
   เพราะ ServiceInfo ไม่มีคอลัมน์เก็บผู้แก้ไข ดูหมายเหตุที่คำสั่ง update */
, @update_by nvarchar(50) = NULL
)
as
begin

    set nocount on

    if isnull(@batchId,'') = ''
    begin
        raiserror(N'ไม่พบรหัสชุดใบงานที่ต้องการยกเลิก', 16, 1)
        return
    end

    declare @total_cancel int = 0
    declare @total_expired int = 0
    declare @total_filled int = 0

    /* ใบทั้งหมดในชุดนี้ที่เป็นของผู้ใช้คนนี้
       บังคับ createBy = @userBy กัน HR คนอื่นมายกเลิกชุดที่ไม่ใช่ของตัวเอง
       และบังคับ createMode กันไปโดนใบแก้ไขข้อมูลพนักงานที่ไม่เกี่ยวกัน */
    select t.id
    , t.status
    , cast(case when cast(t.createDate as date) = cast(getdate() as date)
                then 1 else 0 end as int) as can_cancel
    into #target
    from ServiceInfo t with(nolock)
    where t.is_active = 1
    and t.batchId = @batchId
    and t.createBy = @userBy
    and t.createMode = 'OnBehalfDraft'
    and t.status <> 'Cancel'

    if (select count(*) from #target) = 0
    begin
        drop table #target
        raiserror(N'ไม่พบใบงานในชุดนี้ที่ยกเลิกได้', 16, 1)
        return
    end

    select @total_expired = count(*) from #target where can_cancel = 0

    /* นับใบที่พนักงานกรอกและส่งไปแล้ว เพื่อให้หน้าจอเตือนได้ว่างานหายไปเท่าไร */
    select @total_filled = count(*) from #target where can_cancel = 1 and status <> 'Draft'

    /* ตั้งแค่ status เท่านั้น
       ServiceInfo ไม่มีคอลัมน์ update_by / update_date
       คอลัมน์ที่มีคือ createBy/createDate , requestBy/requestDate ,
       approveBy/approveDate , rejectBy/rejectDate , assignBy
       ถ้าต้องการเก็บว่าใครยกเลิกเมื่อไร ต้องเพิ่มคอลัมน์ใหม่ก่อน
       หรือบันทึกผ่านกลไก track ที่ระบบใช้อยู่ */
    update t set status = 'Cancel'
    from ServiceInfo t
        inner join #target x on t.id = x.id and x.can_cancel = 1
    where t.is_active = 1

    set @total_cancel = @@rowcount

    drop table #target

    select @total_cancel as total_cancel
    , @total_expired as total_expired
    , @total_filled as total_filled

end
GO


/* ============================================================================
   ตรวจผลหลังรัน
   ============================================================================ */
-- 1. ดูชุดที่มีอยู่ พร้อมบอกว่าชุดไหนยังยกเลิกได้
SELECT  t.batchId
      , MIN(t.subCategoryDesc) AS form_name
      , COUNT(*) AS total
      , SUM(CASE WHEN t.status = 'Draft'  THEN 1 ELSE 0 END) AS waiting_fill
      , SUM(CASE WHEN t.status = 'Cancel' THEN 1 ELSE 0 END) AS cancelled
      , MIN(t.createDate) AS created
      , MAX(CASE WHEN CAST(t.createDate AS DATE) = CAST(GETDATE() AS DATE)
                 THEN 1 ELSE 0 END) AS can_cancel_today
FROM    ServiceInfo t WITH(NOLOCK)
WHERE   t.is_active = 1
  AND   t.createMode = 'OnBehalfDraft'
  AND   t.batchId IS NOT NULL
GROUP BY t.batchId
ORDER BY MIN(t.createDate) DESC;
GO

-- 2. ลองยกเลิกทั้งชุด (แทนค่าจริงก่อนรัน)
-- EXEC up_service_onbehalf_cancel_batch
--        @batchId  = N'<batchId จากข้อ 1>'
--      , @userBy   = N'<userId ของ HR ที่สร้างชุดนั้น>'
GO


/* ============================================================================
   ยังต้องทำต่ออีก 2 ชั้น  (ยังไม่ได้ทำ)

   [A] APIEmpHub

       ServiceModels.cs
           เพิ่ม property : total_cancel , total_expired , total_filled
           (batchId มีอยู่แล้วจาก 2026-08-12)

           เพิ่มเมธอด CancelBatch(ServiceModels iProp)
             เรียก up_service_onbehalf_cancel_batch แล้วอ่าน 3 ค่าจาก DataTable
             ใช้ SqlCom_DataAdapterWithDataTable เพราะ proc คืนเป็น result set
             ไม่ใช่ output parameter

       ServiceController.cs
           เพิ่ม endpoint CancelBatch
           *** iProp.userBy = User.UserId() บังคับจาก token เสมอ ***
           ห้ามเชื่อค่าที่หน้าจอส่งมา ไม่งั้นยกเลิกชุดของ HR คนอื่นได้

   [B] EmpHub/Pages/Service/_PartialOnBehalfDataList.cshtml

       จัดกลุ่มรายการตาม batchId แล้วมีปุ่ม "เรียกกลับทั้งชุด" ต่อกลุ่ม
       - ซ่อนหรือ disable ปุ่มเมื่อพ้นวันแล้ว ไม่ใช่ให้กดแล้วค่อยขึ้น error
         ต้องให้ up_service_onbehalf_sel คืน can_cancel_batch มาด้วย
         (เพิ่มคอลัมน์คำนวณจาก cast(createDate as date) = cast(getdate() as date))
       - ก่อนยกเลิกต้องถามยืนยัน และบอกจำนวนใบที่พนักงานกรอกไปแล้ว
         เพราะงานที่เขาทำจะหายไปทั้งหมด
       - หลังยกเลิกให้แจ้งผลจาก 3 ค่าที่ proc คืนมา ไม่ใช่แจ้งว่า "สำเร็จ" ลอย ๆ

       *** การจัดกลุ่มต้องสร้างเป็น array คงที่ใน scope
           ห้ามใช้ฟังก์ชันจัดกลุ่มผูกใน ng-repeat เพราะจะคืน object ใหม่
           ทุกรอบ digest แล้ววนไม่จบ ***
   ============================================================================ */
