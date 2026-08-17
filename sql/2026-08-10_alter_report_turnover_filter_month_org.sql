/* ============================================================================
   รายงานการลาออก : เพิ่มตัวกรองเดือน และกรองตาม ด้าน > สาย > ฝ่าย > ส่วน  (พร้อมรัน)

   ต้องรันไฟล์เหล่านี้ก่อน
     - 2026-08-08_add_employee_offboard.sql
     - 2026-08-09_alter_report_turnover_attrition.sql

   พารามิเตอร์ที่เพิ่ม (ทุกตัวเป็น optional ส่งค่าว่าง = ไม่กรอง)
       @month          int           0 หรือ 1-12   (0 = ทั้งปี)
       @functionCode   nvarchar(50)  ด้าน
       @divisionCode   nvarchar(50)  สาย
       @departmentCode nvarchar(50)  ฝ่าย
       @sectionCode    nvarchar(50)  ส่วน

   คง @department (ชื่อฝ่ายแบบ LIKE) ของเดิมไว้ เพื่อไม่ให้หน้าจอเดิมพัง
   ระหว่างที่ยังไม่ได้ deploy หน้าใหม่

   *** ส่วน (section) อ่านจาก UserInfo.section ไม่ใช่ UserEmployeeInfo ***
   ยืนยันจาก up_user_sel ที่ใช้ isnull(t.section,'') as sectionCode
   ============================================================================ */

USE [EmpHub]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[up_report_turnover_attrition_sel]
(
      @year           INT
    , @department     NVARCHAR(50)
    , @month          INT = 0
    , @functionCode   NVARCHAR(50) = ''
    , @divisionCode   NVARCHAR(50) = ''
    , @departmentCode NVARCHAR(50) = ''
    , @sectionCode    NVARCHAR(50) = ''
    , @page           INT
    , @row            INT
    , @total          INT OUTPUT
)
AS
BEGIN

    DECLARE @targetYear INT = CASE WHEN @year > 0 THEN @year ELSE YEAR(GETDATE()) END;

    SET @month          = ISNULL(@month, 0);
    SET @functionCode   = ISNULL(@functionCode, '');
    SET @divisionCode   = ISNULL(@divisionCode, '');
    SET @departmentCode = ISNULL(@departmentCode, '');
    SET @sectionCode    = ISNULL(@sectionCode, '');
    SET @department     = ISNULL(@department, '');

    /* ---- คนที่ลาออกในช่วงที่เลือก แยกตามแผนก + เหตุผล ---- */
    SELECT  ISNULL(vd.Desc_TH, ISNULL(ue.departmentCode, N'ไม่ระบุ')) AS departmentName
          , CAST(
              CASE
                WHEN ISNULL(u.offboardReasonOther, '') <> '' THEN u.offboardReasonOther
                WHEN ISNULL(mc.Desc_TH, '') <> ''            THEN mc.Desc_TH
                ELSE N'ไม่ระบุ'
              END AS NVARCHAR(200)) AS resignReason
          , COUNT(*) AS resignCount
          , CAST(0 AS DECIMAL(18,2)) AS averageHeadcount
          , CAST(0 AS DECIMAL(18,2)) AS turnoverRate
    INTO    #data
    FROM    UserInfo u WITH(NOLOCK)
            INNER JOIN UserEmployeeInfo ue WITH(NOLOCK) ON u.userId = ue.userId AND ue.is_active = 1
            LEFT JOIN v_department vd WITH(NOLOCK) ON ue.departmentCode = vd.Code
            LEFT JOIN MasterConfig mc WITH(NOLOCK) ON mc.groupName = 'ResignReason'
                                                  AND mc.Code = u.offboardReason
                                                  AND mc.is_active = 1
    WHERE   u.offboardType = 'Resign'                       -- ไม่รวม Void (บันทึกผิด)
      AND   u.lastWorkingDate IS NOT NULL
      AND   YEAR(u.lastWorkingDate) = @targetYear
      AND   (@month = 0 OR MONTH(u.lastWorkingDate) = @month)
      AND   (@functionCode   = '' OR ISNULL(ue.functionCode, '')   = @functionCode)
      AND   (@divisionCode   = '' OR ISNULL(ue.divisionCode, '')   = @divisionCode)
      AND   (@departmentCode = '' OR ISNULL(ue.departmentCode, '') = @departmentCode)
      AND   (@sectionCode    = '' OR ISNULL(u.section, '')         = @sectionCode)
      AND   (@department = '' OR ISNULL(vd.Desc_TH, ISNULL(ue.departmentCode, N'ไม่ระบุ')) LIKE '%' + @department + '%')
    GROUP BY ISNULL(vd.Desc_TH, ISNULL(ue.departmentCode, N'ไม่ระบุ'))
          , CASE
              WHEN ISNULL(u.offboardReasonOther, '') <> '' THEN u.offboardReasonOther
              WHEN ISNULL(mc.Desc_TH, '') <> ''            THEN mc.Desc_TH
              ELSE N'ไม่ระบุ'
            END;

    /* ---- จำนวนพนักงานเฉลี่ย ----
       ถ้าเลือกเดือน ใช้ยอดปลายเดือนนั้นเดือนเดียว  ไม่งั้นเฉลี่ย 12 เดือน
       ตัวหารต้องอยู่ในขอบเขตหน่วยงานเดียวกับตัวตั้ง ไม่งั้นอัตราจะเพี้ยน
       และตัดคนที่บันทึกผิด (Void) ออกจากฐานด้วย
       กติกา "ยังนับอยู่" ตรงกับ v_user_working คือนับจนถึงวันทำงานวันสุดท้าย   */
    DECLARE @avgHeadcount DECIMAL(18,2);

    ;WITH m AS (
        SELECT 1 AS month_no UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4
        UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8
        UNION ALL SELECT 9 UNION ALL SELECT 10 UNION ALL SELECT 11 UNION ALL SELECT 12
    ),
    mm AS (
        SELECT month_no FROM m WHERE @month = 0 OR month_no = @month
    ),
    hc AS (
        SELECT  mm.month_no
              , COUNT(u.userId) AS headcount
        FROM    mm
                LEFT JOIN UserEmployeeInfo ue WITH(NOLOCK)
                       ON ue.is_active = 1
                      AND ue.join_date <= EOMONTH(DATEFROMPARTS(@targetYear, mm.month_no, 1))
                      AND (@functionCode   = '' OR ISNULL(ue.functionCode, '')   = @functionCode)
                      AND (@divisionCode   = '' OR ISNULL(ue.divisionCode, '')   = @divisionCode)
                      AND (@departmentCode = '' OR ISNULL(ue.departmentCode, '') = @departmentCode)
                LEFT JOIN UserInfo u WITH(NOLOCK)
                       ON u.userId = ue.userId
                      AND ISNULL(u.offboardType, '') <> 'Void'
                      AND (@sectionCode = '' OR ISNULL(u.section, '') = @sectionCode)
                      AND (u.lastWorkingDate IS NULL
                           OR u.lastWorkingDate > EOMONTH(DATEFROMPARTS(@targetYear, mm.month_no, 1)))
        GROUP BY mm.month_no
    )
    SELECT @avgHeadcount = AVG(CAST(headcount AS DECIMAL(18,2))) FROM hc;

    UPDATE  #data
    SET     averageHeadcount = ISNULL(@avgHeadcount, 0)
          , turnoverRate = CASE WHEN ISNULL(@avgHeadcount, 0) = 0 THEN 0
                                ELSE (resignCount * 100.00) / @avgHeadcount END;

    /* ---- Paging ---- */
    SELECT @total = COUNT(*) FROM #data;

    DECLARE @start INT = ((@page - 1) * @row) + 1
    DECLARE @end   INT = @page * @row

    SELECT 0 AS rn, * INTO #sort FROM #data t
    DELETE t FROM #sort t

    INSERT INTO #sort
    SELECT ROW_NUMBER() OVER(ORDER BY t.resignCount DESC, t.departmentName, t.resignReason) AS rn, *
    FROM   #data t

    SELECT *
    FROM   #sort t
    WHERE  t.rn BETWEEN @start AND @end
    ORDER BY t.rn

    DROP TABLE #sort
    DROP TABLE #data

END
GO


/* ============================================================================
   ตรวจผล
   ============================================================================ */
-- ทั้งปี
-- DECLARE @t INT
-- EXEC up_report_turnover_attrition_sel @year=2026, @department='', @month=0,
--      @functionCode='', @divisionCode='', @departmentCode='', @sectionCode='',
--      @page=1, @row=50, @total=@t OUTPUT
-- SELECT @t AS total

-- เฉพาะเดือนสิงหาคม
-- DECLARE @t2 INT
-- EXEC up_report_turnover_attrition_sel @year=2026, @department='', @month=8,
--      @functionCode='', @divisionCode='', @departmentCode='', @sectionCode='',
--      @page=1, @row=50, @total=@t2 OUTPUT
GO

/* ============================================================================
   ยังต้องทำต่ออีก 2 ชั้น (ยังไม่ได้แก้)

   1) APIEmpHub/Models/ReportModels.cs
      - เพิ่ม property : month (int), functionCode, divisionCode, departmentCode, sectionCode
        *** ReportModels มี department อยู่แล้ว ตรวจก่อนว่าชนกับ departmentCode หรือไม่ ***
      - ใน ReportTurnoverAttrition() เพิ่มพารามิเตอร์ 5 ตัว "เรียงตามลำดับใน proc"
            , iSql.SqlCom_Parameter("@month", iProp.month)
            , iSql.SqlCom_Parameter("@functionCode", HelperConvert.ConvertToString(iProp.functionCode))
            , iSql.SqlCom_Parameter("@divisionCode", HelperConvert.ConvertToString(iProp.divisionCode))
            , iSql.SqlCom_Parameter("@departmentCode", HelperConvert.ConvertToString(iProp.departmentCode))
            , iSql.SqlCom_Parameter("@sectionCode", HelperConvert.ConvertToString(iProp.sectionCode))
        (proc ประกาศเป็น = '' ไว้แล้ว จึงยังเรียกแบบเดิมได้ ไม่ต้อง deploy พร้อมกันเป๊ะ)

   2) EmpHub/Pages/Report/turnover-attrition.cshtml
      - dropdown เดือน : ทั้งปี + ม.ค.-ธ.ค.  (value 0-12)
      - dropdown ไล่ระดับ ด้าน > สาย > ฝ่าย > ส่วน
        ใช้แพตเทิร์นเดียวกับ Service/FormCreate/FormUpdateDataEmployee.cshtml
        คือโหลด MasterCode/DataList groupName='departmentCode' ครั้งเดียว
        แล้วแยกด้วย condition_4 (Business Unit / Group / Department / Section)
        และกรองลูกด้วย condition_3 = รหัสแม่
        *** ต้องสร้างรายการเป็น array คงที่ ห้ามผูกฟังก์ชันกรองใน ng-options
            เพราะจะทำให้ digest วนไม่จบ ***
      - ส่ง 5 ค่าใหม่ไปกับ payload ของ LoadData() และ Download()
        (ในหน้ามี 2 จุดที่เรียก endpoint นี้ ต้องแก้ทั้งคู่)
      - เอา filter ชื่อฝ่ายแบบ LIKE ของเดิมออกได้ เมื่อ dropdown ใหม่ใช้งานแล้ว
   ============================================================================ */
