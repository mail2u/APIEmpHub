/* ============================================================================
   เพิ่ม สี (color) และ ไซซ์ (size) ในใบคำขอซื้อชุดยูนิฟอร์ม

   ต้องรันให้เสร็จ "ก่อน" deploy APIEmpHub
   เพราะ C# จะส่ง @color / @size เข้า up_form_buy_uniform_ins
   ถ้า proc ยังไม่รับ SQL Server จะตอบ
       "Procedure or function has too many arguments specified"
   แล้วการส่งใบคำขอซื้อยูนิฟอร์มจะพังทั้งหมด

   ลำดับ: 1) รัน SQL  2) deploy APIEmpHub  3) deploy EmpHub
   ============================================================================ */

/* STEP 0 : หาชื่อตาราง (proc อยู่ใน DB ไม่ได้อยู่ใน source control) */
SELECT  m.definition
FROM    sys.sql_modules m
        INNER JOIN sys.objects o ON o.object_id = m.object_id
WHERE   o.name = 'up_form_buy_uniform_ins';
GO

/* STEP 1 : เพิ่มคอลัมน์
   แทน {{BuyUniformTable}} ด้วยชื่อตารางจาก STEP 0 */
IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.{{BuyUniformTable}}') AND name = 'color')
BEGIN
    ALTER TABLE dbo.{{BuyUniformTable}} ADD color VARCHAR(50) NULL;
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.{{BuyUniformTable}}') AND name = 'size')
BEGIN
    ALTER TABLE dbo.{{BuyUniformTable}} ADD size VARCHAR(20) NULL;
END
GO

/* ----------------------------------------------------------------------------
   STEP 2 : แก้ stored procedure 2 ตัว
   script ออกมาด้วย SSMS (คลิกขวา > Modify) แล้วเพิ่มตามนี้

   1. up_form_buy_uniform_ins      <- api/Form/FormBuyUniformCreate

       ประกาศพารามิเตอร์ (วางต่อจาก @style)
           , @color VARCHAR(50) = NULL
           , @size  VARCHAR(20) = NULL

       เพิ่มใน INSERT
           คอลัมน์ :  , color , size
           ค่า      :  , @color , @size

       *** ประกาศเป็น = NULL เพื่อให้ proc ยังรับ call แบบเดิมได้
           ช่วยให้จังหวะ deploy ไม่ต้องตรงเป๊ะ ***

   2. up_form_buy_uniform_detail   <- api/Form/FormBuyUniformDetail

       เพิ่มในรายการคอลัมน์ที่ SELECT
           , color , size

       ตัวนี้ฝั่ง C# อ่านด้วย GetOptionalString จึงไม่ throw ถ้ายังไม่มีคอลัมน์
       แต่ใบงานจะแสดง สี/ไซซ์ เป็น "-" จนกว่าจะเพิ่ม

   *** size เป็นคำสงวนของ T-SQL ในบางบริบท เวลาเขียน proc ให้ครอบด้วย [size] ***
   ---------------------------------------------------------------------------- */

/* STEP 3 : ตรวจผล */
SELECT  t.name AS [table], c.name AS [column], ty.name AS [type], c.max_length
FROM    sys.columns c
        INNER JOIN sys.tables t ON t.object_id = c.object_id
        INNER JOIN sys.types ty ON ty.user_type_id = c.user_type_id
WHERE   c.name IN ('color', 'size')
  AND   t.name = '{{BuyUniformTable}}';
GO

SELECT  o.name AS [procedure]
FROM    sys.sql_modules m
        INNER JOIN sys.objects o ON o.object_id = m.object_id
WHERE   o.name LIKE 'up_form_buy_uniform%'
  AND   m.definition LIKE '%color%'
ORDER BY o.name;
GO

/* STEP 4 : ย้อนกลับ
       1) deploy APIEmpHub ตัวเดิมกลับก่อน
       2) คืน proc 2 ตัวเป็นเวอร์ชันก่อนแก้
   คอลัมน์ทิ้งไว้ได้ ถ้าจะลบจริง:
       ALTER TABLE dbo.{{BuyUniformTable}} DROP COLUMN color;
       ALTER TABLE dbo.{{BuyUniformTable}} DROP COLUMN [size];
   ---------------------------------------------------------------------------- */
