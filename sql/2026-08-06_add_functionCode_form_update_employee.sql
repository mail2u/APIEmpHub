/* ============================================================================
   เพิ่ม functionCode (ด้าน) เข้าเส้นทาง "ใบคำขอแก้ไขข้อมูลพนักงาน"

   ที่มา: หน้า Service/FormCreate/FormUpdateDataEmployee เปลี่ยนเป็นเลือกไล่ระดับ
          ด้าน > สาย > ฝ่าย > ส่วน  (functionCode > divisionCode > departmentCode > sectionCode)

   ตารางพนักงานกับ up_user_employee_save รับ @functionCode อยู่แล้ว
   ขาดแต่ฝั่ง "ตารางใบคำขอ" ซึ่ง up_form_update_employee_ins เขียนลงไป

   ต้องรันสคริปต์นี้ให้เสร็จ "ก่อน" deploy APIEmpHub ตัวใหม่
   เพราะ C# จะส่ง @functionCode เข้า up_form_update_employee_ins
   ถ้า proc ยังไม่รับ SQL Server จะตอบ
       "Procedure or function has too many arguments specified"
   แล้วการส่งใบคำขอแก้ไขข้อมูลพนักงานจะพังทั้งหมด

   ลำดับที่ปลอดภัย
       1) รัน STEP 1-2
       2) deploy APIEmpHub
       3) deploy EmpHub
   ============================================================================ */

/* ----------------------------------------------------------------------------
   STEP 0 : หาชื่อตารางใบคำขอ
   proc อยู่ใน DB ไม่ได้อยู่ใน source control จึงยืนยันชื่อตารางจากโค้ดไม่ได้
   ตารางที่ต้องแก้คือตารางที่ up_form_update_employee_ins เขียนลง
   ---------------------------------------------------------------------------- */
-- 0.1 ดู body ของ proc เพื่อหาชื่อตาราง
SELECT  m.definition
FROM    sys.sql_modules m
        INNER JOIN sys.objects o ON o.object_id = m.object_id
WHERE   o.name = 'up_form_update_employee_ins';
GO

-- 0.2 ตารางที่มี sectionCode แต่ยังไม่มี functionCode (ตัวที่ต้องแก้จะอยู่ในนี้)
SELECT  s.name AS [schema], t.name AS [table]
FROM    sys.tables t
        INNER JOIN sys.schemas s ON s.schema_id = t.schema_id
WHERE   EXISTS (SELECT 1 FROM sys.columns c WHERE c.object_id = t.object_id AND c.name = 'sectionCode')
  AND NOT EXISTS (SELECT 1 FROM sys.columns c WHERE c.object_id = t.object_id AND c.name = 'functionCode')
ORDER BY t.name;
GO

/* ----------------------------------------------------------------------------
   STEP 1 : เพิ่มคอลัมน์ในตารางใบคำขอ
   แทน {{FormUpdateEmployeeTable}} ด้วยชื่อตารางที่ได้จาก STEP 0
   ---------------------------------------------------------------------------- */
IF NOT EXISTS (
        SELECT 1 FROM sys.columns
        WHERE object_id = OBJECT_ID('dbo.{{FormUpdateEmployeeTable}}')
          AND name = 'functionCode'
    )
BEGIN
    ALTER TABLE dbo.{{FormUpdateEmployeeTable}}
        ADD functionCode VARCHAR(50) NULL;
END
GO

/* ----------------------------------------------------------------------------
   STEP 2 : แก้ stored procedure 2 ตัว
   script ออกมาด้วย SSMS (คลิกขวา > Modify) แล้วเพิ่มตามนี้

   1. up_form_update_employee_ins   <- api/Form/FormUpdateEmployeeCreate

       ประกาศพารามิเตอร์ (วางก่อน @divisionCode)
           , @functionCode VARCHAR(50) = NULL

       เพิ่มใน INSERT
           คอลัมน์ :  , functionCode
           ค่า      :  , @functionCode

       *** ประกาศเป็น = NULL เพื่อให้ proc ยังรับ call แบบเดิมได้
           ช่วยให้จังหวะ deploy ไม่ต้องตรงเป๊ะ ***

   2. up_form_update_employee_detail   <- api/Form/FormUpdateEmployeeDetail

       เพิ่มในรายการคอลัมน์ที่ SELECT
           , functionCode

       ตัวนี้ฝั่ง C# อ่านด้วย GetOptionalString จึงไม่ throw ถ้ายังไม่มีคอลัมน์
       แต่ใบงานจะแสดง ด้าน เป็น "-" จนกว่าจะเพิ่ม
   ---------------------------------------------------------------------------- */

/* ----------------------------------------------------------------------------
   STEP 3 : ตั้งค่า master ให้มีระดับที่ 4

   หน้าจอกรองตัวเลือกด้วย condition_4 (ระดับ) + condition_3 (รหัสแม่)
       Business Unit = ด้าน
       Group         = สาย
       Department    = ฝ่าย
       Section       = ส่วน   <-- ระดับใหม่

   ตรวจว่า master มีครบทั้ง 4 ระดับและผูกแม่-ลูกถูกต้อง
   ---------------------------------------------------------------------------- */
-- 3.1 นับจำนวนแต่ละระดับ (ต้องเห็น Section ด้วย)
SELECT  condition_4 AS [level], COUNT(*) AS [rows]
FROM    MasterCode
WHERE   groupName = 'departmentCode'
GROUP BY condition_4
ORDER BY condition_4;
GO

-- 3.2 แถวที่ยังไม่ได้ตั้งระดับ (จะไม่ปรากฏใน dropdown เลย)
SELECT  code, desc_th, condition_3 AS parentCode, condition_4 AS [level]
FROM    MasterCode
WHERE   groupName = 'departmentCode'
  AND   ISNULL(condition_4, '') = ''
ORDER BY desc_th;
GO

-- 3.3 แถวที่ระดับล่างแต่ไม่มีรหัสแม่ (เลือกไม่ได้เพราะไม่รู้ว่าอยู่ใต้ใคร)
SELECT  code, desc_th, condition_4 AS [level]
FROM    MasterCode
WHERE   groupName = 'departmentCode'
  AND   condition_4 IN ('Group', 'Department', 'Section')
  AND   ISNULL(condition_3, '') = ''
ORDER BY condition_4, desc_th;
GO

/* ----------------------------------------------------------------------------
   STEP 4 : ตรวจผลหลังแก้เสร็จ
   ---------------------------------------------------------------------------- */
-- 4.1 คอลัมน์ถูกเพิ่มแล้ว
SELECT  t.name AS [table], c.name AS [column], ty.name AS [type]
FROM    sys.columns c
        INNER JOIN sys.tables t ON t.object_id = c.object_id
        INNER JOIN sys.types ty ON ty.user_type_id = c.user_type_id
WHERE   c.name = 'functionCode';
GO

-- 4.2 proc ทั้ง 2 ตัวอ้างถึงคอลัมน์นี้แล้ว
SELECT  o.name AS [procedure]
FROM    sys.sql_modules m
        INNER JOIN sys.objects o ON o.object_id = m.object_id
WHERE   m.definition LIKE '%functionCode%'
ORDER BY o.name;
GO

/* ----------------------------------------------------------------------------
   STEP 5 : ย้อนกลับ (rollback)
       1) deploy APIEmpHub ตัวเดิมกลับก่อน
       2) คืน proc 2 ตัวเป็นเวอร์ชันก่อนแก้
   คอลัมน์ทิ้งไว้ได้ ถ้าจะลบจริง:
       ALTER TABLE dbo.{{FormUpdateEmployeeTable}} DROP COLUMN functionCode;
   ---------------------------------------------------------------------------- */
