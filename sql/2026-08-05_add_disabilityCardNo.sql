/* ============================================================================
   เพิ่ม "เลขบัตรผู้พิการ" (disabilityCardNo)

   ต้องรันสคริปต์นี้ให้เสร็จ "ก่อน" deploy APIEmpHub ตัวใหม่
   เพราะฝั่ง C# จะส่งพารามิเตอร์ @disabilityCardNo เข้า stored procedure
   ถ้า proc ยังไม่รับพารามิเตอร์นี้ SQL Server จะตอบ
       "Procedure or function has too many arguments specified"
   แล้วการบันทึกข้อมูลส่วนบุคคลจะพังทั้งระบบ

   ลำดับที่ปลอดภัย
       1) รัน STEP 1-2 (เพิ่มคอลัมน์ + แก้ proc)
       2) deploy APIEmpHub
       3) deploy EmpHub
   ย้อนกลับ: ดู STEP 4
   ============================================================================ */

/* ----------------------------------------------------------------------------
   STEP 0 : หาชื่อตารางจริงก่อน
   proc ทั้งหมดอยู่ใน DB ไม่ได้อยู่ใน source control จึงยืนยันชื่อตารางจากโค้ดไม่ได้
   รันคำสั่งนี้เพื่อดูว่าคอลัมน์ disabilityStatus อยู่ในตารางไหน
   ---------------------------------------------------------------------------- */
SELECT  s.name AS [schema]
      , t.name AS [table]
      , c.name AS [column]
FROM    sys.columns c
        INNER JOIN sys.tables t ON t.object_id = c.object_id
        INNER JOIN sys.schemas s ON s.schema_id = t.schema_id
WHERE   c.name = 'disabilityStatus'
ORDER BY t.name;
GO

/* ----------------------------------------------------------------------------
   STEP 1 : เพิ่มคอลัมน์
   แทน {{PersonalTable}} ด้วยชื่อตารางที่ได้จาก STEP 0
   ---------------------------------------------------------------------------- */
IF NOT EXISTS (
        SELECT 1 FROM sys.columns
        WHERE object_id = OBJECT_ID('dbo.{{PersonalTable}}')
          AND name = 'disabilityCardNo'
    )
BEGIN
    ALTER TABLE dbo.{{PersonalTable}}
        ADD disabilityCardNo VARCHAR(20) NULL;
END
GO

/* ----------------------------------------------------------------------------
   STEP 2 : แก้ stored procedure

   ยังไม่มี body ของ proc ใน repo จึงเขียน ALTER PROCEDURE เต็ม ๆ ให้ไม่ได้
   วิธีทำ: script proc ออกมาด้วย SSMS (คลิกขวา > Modify) แล้วเพิ่มตามนี้

   ---- ฝั่งบันทึก (3 ตัว) : เพิ่มพารามิเตอร์ + เพิ่มคอลัมน์ใน INSERT/UPDATE ----

   1. up_user_personal_save          <- Onboarding (api/User/UserPersonalSave)
   2. up_form_update_personal_ins    <- ใบคำขอแก้ข้อมูล (api/Form/FormUpdatePersonalCreate)
   3. up_service_personal_save       <- Employee/Edit (api/ServicePersonal/Save)

       เพิ่มในส่วนประกาศพารามิเตอร์ (วางต่อจาก @disabilityStatus)
           , @disabilityCardNo VARCHAR(20) = NULL

       เพิ่มใน INSERT
           คอลัมน์ :  , disabilityCardNo
           ค่า      :  , @disabilityCardNo

       เพิ่มใน UPDATE
           , disabilityCardNo = @disabilityCardNo

       *** ประกาศเป็น = NULL ไว้ด้วย เพื่อให้ proc ยังรับ call แบบเดิมได้
           ช่วยให้ deploy ไม่ต้องตรงเวลาเป๊ะ ***

   ---- ฝั่งอ่าน (3 ตัว) : เพิ่มคอลัมน์ใน SELECT ----

   4. up_user_personal_detail        <- api/User/UserPersonal
                                        (Onboarding, ฟอร์ม Service, Profile, Employee)
   5. up_form_update_personal_detail <- api/Form/FormUpdatePersonalDetail (ใบงาน)
   6. up_service_personal_detail     <- api/ServicePersonal/Detail

       เพิ่มในรายการคอลัมน์ที่ SELECT ออกมา
           , disabilityCardNo

       *** ต้องคืนคอลัมน์นี้ให้ครบทั้ง 3 ตัว
           ถ้าตัวไหนไม่คืน ฝั่ง C# จะโยน error ตอนอ่าน DataTable ***
   ---------------------------------------------------------------------------- */

/* ----------------------------------------------------------------------------
   STEP 3 : ตรวจผลหลังแก้เสร็จ
   ---------------------------------------------------------------------------- */
-- 3.1 คอลัมน์ถูกเพิ่มแล้ว
SELECT  t.name AS [table], c.name AS [column], ty.name AS [type], c.max_length
FROM    sys.columns c
        INNER JOIN sys.tables t ON t.object_id = c.object_id
        INNER JOIN sys.types ty ON ty.user_type_id = c.user_type_id
WHERE   c.name = 'disabilityCardNo';
GO

-- 3.2 proc ทั้ง 6 ตัวอ้างถึงคอลัมน์นี้แล้ว (ต้องได้ครบ 6 แถว)
SELECT  o.name AS [procedure]
FROM    sys.sql_modules m
        INNER JOIN sys.objects o ON o.object_id = m.object_id
WHERE   m.definition LIKE '%disabilityCardNo%'
ORDER BY o.name;
GO

/* ----------------------------------------------------------------------------
   STEP 4 : ย้อนกลับ (rollback)
   ทำ 2 ข้อนี้ตามลำดับ
       1) deploy APIEmpHub ตัวเดิมกลับก่อน (ไม่งั้น C# จะส่งพารามิเตอร์ที่ proc ไม่รับ)
       2) คืน proc ทั้ง 6 ตัวเป็นเวอร์ชันก่อนแก้
   คอลัมน์ทิ้งไว้ได้ ไม่กระทบอะไร ถ้าจะลบจริง:
       ALTER TABLE dbo.{{PersonalTable}} DROP COLUMN disabilityCardNo;
   ---------------------------------------------------------------------------- */
