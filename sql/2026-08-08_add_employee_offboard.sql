/* ============================================================================
   นำพนักงานออกจากระบบ (ลาออก / บันทึกผิด)

   ข้อสรุปที่ใช้ออกแบบ
     1. ปิดสถานะ ไม่ลบข้อมูลจริง  (ข้อมูลถูกอ้างอิงจากใบงาน/ประวัติ/ผังองค์กร)
     2. บันทึกผิด ก็ปิดสถานะเหมือนกัน ลบจริงไม่ได้
     3. เหตุผลเลือกจาก master + มี "อื่น ๆ" ให้ระบุเอง
     4. วันทำงานวันสุดท้ายเป็นวันในอนาคตได้ (แจ้งล่วงหน้า)
     5. ไม่ต้องผ่านการอนุมัติ HR ทำได้เลย
     6. คนที่ออกแล้วเห็นเฉพาะรายงานคนออก และตอนค้นเพื่อรับกลับเข้าทำงาน

   *** จุดสำคัญของข้อ 4 ***
   เพราะวันสุดท้ายเป็นอนาคตได้ จึง "ห้ามใช้ flag เดียวตัดสินว่ายังทำงานอยู่ไหม"
   ต้องเทียบวันที่ทุกครั้ง ไม่งั้นคนที่แจ้งลาออกล่วงหน้า 30 วัน จะหลุดออกจากระบบทันที
   สคริปต์นี้จึงทำ view + function ให้ proc อื่นเรียกใช้ ไม่ต้องเขียนเงื่อนไขซ้ำทุกที่

   ลำดับ: 1) รัน SQL  2) deploy APIEmpHub  3) deploy EmpHub
   ============================================================================ */

/* ----------------------------------------------------------------------------
   STEP 0 : สำรวจของเดิม
   ---------------------------------------------------------------------------- */
-- 0.1 up_user_del ทำอะไรอยู่ (ของเดิมลบแบบไม่มีเหตุผล)
SELECT  m.definition
FROM    sys.sql_modules m
        INNER JOIN sys.objects o ON o.object_id = m.object_id
WHERE   o.name = 'up_user_del';
GO

-- 0.2 ตารางผู้ใช้/พนักงาน มีคอลัมน์อะไรอยู่แล้ว
SELECT  t.name AS [table], c.name AS [column]
FROM    sys.columns c
        INNER JOIN sys.tables t ON t.object_id = c.object_id
WHERE   t.name IN ('UserInfo', 'UserEmployeeInfo')
  AND   c.name IN ('is_active','status','offboardType','lastWorkingDate','offboardReason')
ORDER BY t.name, c.name;
GO


/* ----------------------------------------------------------------------------
   STEP 1 : คอลัมน์เก็บการนำออก
   เก็บที่ UserInfo เพราะเป็นตัวตนของผู้ใช้ ไม่ใช่ข้อมูลการจ้างงาน
   ---------------------------------------------------------------------------- */
IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.UserInfo') AND name = 'offboardType')
BEGIN
    -- 'Resign' = ลาออก , 'Void' = บันทึกผิด
    ALTER TABLE dbo.UserInfo ADD offboardType VARCHAR(20) NULL;
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.UserInfo') AND name = 'lastWorkingDate')
BEGIN
    -- ใช้เฉพาะกรณีลาออก เป็นวันในอนาคตได้
    ALTER TABLE dbo.UserInfo ADD lastWorkingDate DATE NULL;
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.UserInfo') AND name = 'offboardReason')
BEGIN
    -- รหัสเหตุผลจาก MasterCode groupName='ResignReason'
    ALTER TABLE dbo.UserInfo ADD offboardReason VARCHAR(50) NULL;
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.UserInfo') AND name = 'offboardReasonOther')
BEGIN
    -- ข้อความที่พิมพ์เอง ใช้เมื่อเลือก "อื่น ๆ"
    ALTER TABLE dbo.UserInfo ADD offboardReasonOther NVARCHAR(500) NULL;
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.UserInfo') AND name = 'offboardBy')
BEGIN
    ALTER TABLE dbo.UserInfo ADD offboardBy NVARCHAR(50) NULL;
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.UserInfo') AND name = 'offboardDate')
BEGIN
    ALTER TABLE dbo.UserInfo ADD offboardDate DATETIME NULL;
END
GO


/* ----------------------------------------------------------------------------
   STEP 2 : เหตุผลการลาออก (master)
   HR แก้ไขเองได้ที่หน้า Setting  ปรับข้อความ/เพิ่มเหตุผล โดยไม่ต้องแก้โค้ด
   ---------------------------------------------------------------------------- */
/* ตารางชื่อ MasterConfig (ไม่ใช่ MasterCode) และคอลัมน์เป็น Code / Desc_TH / Desc_EN */
IF NOT EXISTS (SELECT 1 FROM MasterConfig WHERE groupName = 'ResignReason')
BEGIN
    INSERT INTO MasterConfig (groupName, Code, Desc_TH, Desc_EN, is_active, orderIndex, create_by, create_date)
    SELECT 'ResignReason', 'R01', N'ได้งานใหม่',          'New job',         1, 1, 'system', GETDATE()
    UNION ALL SELECT 'ResignReason', 'R02', N'ย้ายที่อยู่',        'Relocation',      1, 2, 'system', GETDATE()
    UNION ALL SELECT 'ResignReason', 'R03', N'เหตุผลส่วนตัว',    'Personal',        1, 3, 'system', GETDATE()
    UNION ALL SELECT 'ResignReason', 'R04', N'ปัญหาสุขภาพ',      'Health',          1, 4, 'system', GETDATE()
    UNION ALL SELECT 'ResignReason', 'R05', N'ศึกษาต่อ',          'Further study',   1, 5, 'system', GETDATE()
    UNION ALL SELECT 'ResignReason', 'R06', N'เกษียณอายุ',        'Retirement',      1, 6, 'system', GETDATE()
    UNION ALL SELECT 'ResignReason', 'R99', N'สิ้นสุดสัญญาจ้าง',  'End of contract', 1, 7, 'system', GETDATE();
END
GO

/*  หมายเหตุ : ไม่ต้องเพิ่มแถว "อื่น ๆ" ในตาราง
    หน้าจอเติมตัวเลือก "อื่น ๆ (ระบุ)" ให้เองด้วย MasterOptionListWithOther() ใน site.js
    (ตัวเดียวกับที่ใช้กับสัญชาติและคำนำหน้า) แล้วเก็บข้อความลง offboardReasonOther   */


/* ----------------------------------------------------------------------------
   STEP 3 : ตัวตัดสินว่า "ยังทำงานอยู่ไหม"  <-- หัวใจของข้อ 4

   กติกา
     - ยังไม่ถูกนำออก                       -> ทำงานอยู่
     - Void (บันทึกผิด)                     -> ออกทันทีที่บันทึก
     - Resign และวันสุดท้ายยังไม่ถึง/เป็นวันนี้ -> ยังทำงานอยู่
     - Resign และเลยวันสุดท้ายแล้ว           -> ออกแล้ว
   ---------------------------------------------------------------------------- */
CREATE OR ALTER FUNCTION [dbo].[fn_user_is_working] (@userId NVARCHAR(50))
RETURNS INT
AS
BEGIN
    DECLARE @result INT = 0

    SELECT  @result = CASE
                        WHEN ISNULL(u.offboardType, '') = '' THEN 1
                        WHEN u.offboardType = 'Void' THEN 0
                        WHEN u.lastWorkingDate IS NULL THEN 0
                        WHEN u.lastWorkingDate >= CAST(GETDATE() AS DATE) THEN 1
                        ELSE 0
                      END
    FROM    UserInfo u
    WHERE   u.userId = @userId

    RETURN ISNULL(@result, 0)
END
GO

/* view สำหรับ join ในลิสต์ต่าง ๆ เร็วกว่าเรียก function ทีละแถว */
CREATE OR ALTER VIEW [dbo].[v_user_working]
AS
    SELECT  u.userId
          , u.offboardType
          , u.lastWorkingDate
          , u.offboardReason
          , u.offboardReasonOther
          , u.offboardBy
          , u.offboardDate
          , CAST(CASE
                   WHEN ISNULL(u.offboardType, '') = '' THEN 1
                   WHEN u.offboardType = 'Void' THEN 0
                   WHEN u.lastWorkingDate IS NULL THEN 0
                   WHEN u.lastWorkingDate >= CAST(GETDATE() AS DATE) THEN 1
                   ELSE 0
                 END AS INT) AS is_working
    FROM    UserInfo u
GO


/* ----------------------------------------------------------------------------
   STEP 4 : proc บันทึกการนำออก และการรับกลับ
   ---------------------------------------------------------------------------- */
CREATE OR ALTER PROCEDURE [dbo].[up_user_offboard_upd]
(
      @userId              NVARCHAR(50)
    , @offboardType        VARCHAR(20)          -- 'Resign' | 'Void'
    , @lastWorkingDate     NVARCHAR(20) = NULL  -- รูปแบบ yyyymmdd (C# ส่งมาแบบ 112)
    , @offboardReason      VARCHAR(50)  = NULL
    , @offboardReasonOther NVARCHAR(500) = NULL
    , @update_by           NVARCHAR(50)
)
AS
BEGIN

    /* บันทึกผิด ไม่มีวันทำงานวันสุดท้าย */
    IF @offboardType = 'Void'
    BEGIN
        SET @lastWorkingDate = NULL
    END

    UPDATE  UserInfo
    SET     offboardType        = @offboardType
          , lastWorkingDate     = TRY_CONVERT(DATE, @lastWorkingDate, 112)
          , offboardReason      = @offboardReason
          , offboardReasonOther = @offboardReasonOther
          , offboardBy          = @update_by
          , offboardDate        = GETDATE()
          , update_by           = @update_by
          , update_date         = GETDATE()
    WHERE   userId = @userId

END
GO

/* รับกลับเข้าทำงาน (ข้อ 6) : ล้างข้อมูลการนำออกให้กลับมาเป็นพนักงานปกติ */
CREATE OR ALTER PROCEDURE [dbo].[up_user_offboard_cancel]
(
      @userId    NVARCHAR(50)
    , @update_by NVARCHAR(50)
)
AS
BEGIN

    UPDATE  UserInfo
    SET     offboardType        = NULL
          , lastWorkingDate     = NULL
          , offboardReason      = NULL
          , offboardReasonOther = NULL
          , offboardBy          = NULL
          , offboardDate        = NULL
          , update_by           = @update_by
          , update_date         = GETDATE()
    WHERE   userId = @userId

END
GO


/* ----------------------------------------------------------------------------
   STEP 5 : รายงานคนออก (ข้อ 6)
   ---------------------------------------------------------------------------- */
CREATE OR ALTER PROCEDURE [dbo].[up_user_offboard_sel]
(
      @offboardType VARCHAR(20)  = ''
    , @name         NVARCHAR(100) = ''
    , @dateFrom     NVARCHAR(20)  = ''
    , @dateTo       NVARCHAR(20)  = ''
)
AS
BEGIN

    SELECT  u.userId
          , e.employeeCode
          , p.firstname_th, p.lastname_th
          , vp.Desc_TH AS positionDesc
          , vd.Desc_TH AS departmentDesc
          , w.offboardType
          , CASE w.offboardType WHEN 'Resign' THEN N'ลาออก'
                                WHEN 'Void'   THEN N'บันทึกผิด'
                                ELSE '-' END AS offboardTypeDesc
          , CONVERT(NVARCHAR, w.lastWorkingDate, 103) AS lastWorkingDate
          , w.offboardReason
          , ISNULL(m.Desc_TH, '') AS offboardReasonDesc
          , w.offboardReasonOther
          , CONVERT(NVARCHAR, w.offboardDate, 103) AS offboardDate
          , w.offboardBy
          , w.is_working
    FROM    v_user_working w
            INNER JOIN UserInfo u WITH(NOLOCK) ON w.userId = u.userId
            LEFT OUTER JOIN UserPersonalInfo p WITH(NOLOCK) ON u.userId = p.userId AND p.is_active = 1
            LEFT OUTER JOIN UserEmployeeInfo e WITH(NOLOCK) ON u.userId = e.userId AND e.is_active = 1
            LEFT OUTER JOIN v_position vp WITH(NOLOCK) ON e.positionCode = vp.Code
            LEFT OUTER JOIN v_department vd WITH(NOLOCK) ON e.departmentCode = vd.Code
            LEFT OUTER JOIN MasterConfig m WITH(NOLOCK) ON m.groupName = 'ResignReason' AND m.Code = w.offboardReason AND m.is_active = 1
    WHERE   ISNULL(w.offboardType, '') <> ''
      AND   (@offboardType = '' OR w.offboardType = @offboardType)
      AND   (@name = '' OR p.firstname_th LIKE '%' + @name + '%' OR p.lastname_th LIKE '%' + @name + '%' OR e.employeeCode LIKE '%' + @name + '%')
      AND   (@dateFrom = '' OR w.offboardDate >= TRY_CONVERT(DATE, @dateFrom, 112))
      AND   (@dateTo = '' OR w.offboardDate < DATEADD(DAY, 1, TRY_CONVERT(DATE, @dateTo, 112)))
    ORDER BY w.offboardDate DESC

END
GO


/* ----------------------------------------------------------------------------
   STEP 6 : ซ่อนคนที่ออกแล้วจากที่อื่น  <-- ต้องทำ ไม่งั้นคนลาออกยังโผล่ทุกที่

   ของเดิม up_user_del ปิดด้วย is_active = 0 ซึ่ง proc ทุกตัวกรองอยู่แล้ว
   แต่ใช้วิธีนั้นกับ "ลาออกล่วงหน้า" ไม่ได้ เพราะคนจะหายทันทีที่บันทึก
   จึงต้องคง is_active = 1 ไว้ แล้วกรองด้วย is_working แทน

   แก้ proc เหล่านี้ให้ join v_user_working แล้วกรอง is_working = 1

     - up_user_sel            <- ตัวสำคัญสุด ป้อนทั้งลิสต์พนักงาน, ผังองค์กร
                                 (Team/Company เรียกผ่าน User/DataList) และ dropdown เลือกหัวหน้า
     - up_user_summary        <- ยอดนับพนักงาน

   ตัวอย่างที่เพิ่มใน up_user_sel

       INNER JOIN v_user_working w WITH(NOLOCK) ON u.userId = w.userId
       ...
       AND w.is_working = 1

   ---- แก้ up_user_sel : เพิ่ม 2 บรรทัด ----

   หาบล็อกนี้ (อยู่ท้าย select ... into #data)

       from UserInfo t with(nolock)
       left outer join UserPersonalInfo up with(nolock) on t.userId = up.userId and up.is_active = 1
       left outer join UserEmployeeInfo ue with(nolock) on t.userId = ue.userId and ue.is_active = 1
       left outer join v_department vd with(nolock) on t.department = vd.Code
       left outer join v_section vs with(nolock) on t.section = vs.Code
       left outer join v_position vp with(nolock) on t.position = vp.Code
       where t.is_active = 1

   แก้เป็น (เพิ่มบรรทัด inner join และ and)

       from UserInfo t with(nolock)
       left outer join UserPersonalInfo up with(nolock) on t.userId = up.userId and up.is_active = 1
       left outer join UserEmployeeInfo ue with(nolock) on t.userId = ue.userId and ue.is_active = 1
       left outer join v_department vd with(nolock) on t.department = vd.Code
       left outer join v_section vs with(nolock) on t.section = vs.Code
       left outer join v_position vp with(nolock) on t.position = vp.Code
       inner join v_user_working w with(nolock) on t.userId = w.userId      -- << เพิ่ม
       where t.is_active = 1
       and w.is_working = 1                                                -- << เพิ่ม

   เท่านี้ครบทั้งลิสต์พนักงาน ผังองค์กร (Team/Company) และ dropdown เลือกหัวหน้า
   เพราะทุกหน้าเรียกผ่าน User/DataList ซึ่งใช้ proc ตัวนี้ตัวเดียว

   ---- แก้ up_user_summary : รูปแบบเดียวกัน ----
   หา where ที่มี t.is_active = 1 บน UserInfo แล้วเพิ่ม join + เงื่อนไขแบบเดียวกัน

   *** ห้ามกรองใน proc เหล่านี้ ***
     - up_service_*           ใบงานเก่าต้องแสดงชื่อคนที่ทำไว้ได้ แม้เขาลาออกแล้ว
     - up_user_personal_detail / up_user_employee_detail
                              ต้องเปิดดูประวัติคนที่ออกแล้วได้ (ใช้ตอนรับกลับเข้าทำงาน)
     - up_onboard_exists_by_idcard   ค้นด้วยเลขบัตรตอนรับกลับ ต้องเจอคนที่ออกแล้ว
   ---------------------------------------------------------------------------- */


/* ----------------------------------------------------------------------------
   STEP 7 : ตรวจผล
   ---------------------------------------------------------------------------- */
SELECT  c.name AS [column] FROM sys.columns c
WHERE   c.object_id = OBJECT_ID('dbo.UserInfo')
  AND   c.name LIKE 'offboard%' OR c.name = 'lastWorkingDate';
GO

SELECT  name, type_desc, modify_date FROM sys.objects
WHERE   name IN ('fn_user_is_working','v_user_working','up_user_offboard_upd','up_user_offboard_cancel','up_user_offboard_sel');
GO

SELECT  Code, Desc_TH FROM MasterConfig WHERE groupName = 'ResignReason' ORDER BY orderIndex;
GO

-- ทดสอบกติกาวันที่ (ข้อ 4)
-- 1. บันทึกลาออกโดยใส่วันสุดท้ายเป็นอีก 30 วันข้างหน้า -> is_working ต้องยังเป็น 1
-- 2. แก้ lastWorkingDate ให้เป็นเมื่อวาน                -> is_working ต้องเป็น 0
-- SELECT userId, offboardType, lastWorkingDate, is_working FROM v_user_working WHERE ISNULL(offboardType,'') <> '';


/* ----------------------------------------------------------------------------
   STEP 8 : ย้อนกลับ
     1) deploy APIEmpHub ตัวเดิมกลับก่อน
     2) คืน proc ที่แก้ใน STEP 6 เป็นเวอร์ชันก่อนแก้
     3) DROP PROCEDURE up_user_offboard_upd, up_user_offboard_cancel, up_user_offboard_sel
        DROP VIEW v_user_working
        DROP FUNCTION fn_user_is_working
     คอลัมน์ทิ้งไว้ได้ ไม่กระทบ
   ---------------------------------------------------------------------------- */
