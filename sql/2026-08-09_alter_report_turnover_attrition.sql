/* ============================================================================
   รายงาน Turnover / Attrition : อัตราการลาออกแยกตามแผนกและเหตุผล

   ต้องรัน 2026-08-08_add_employee_offboard.sql ก่อน (ใช้คอลัมน์ offboard* และ MasterConfig)

   สิ่งที่แก้จากของเดิม
     1. เดิมนับคนออกจาก  is_active = 0 + ปีของ update_date
        ซึ่งเป็นการเดา และนับรวมคนที่ถูกลบด้วยเหตุอื่นเข้าไปด้วย
        เปลี่ยนเป็นนับจาก offboardType = 'Resign' และปีของ lastWorkingDate

     2. *** ไม่นับ 'Void' (บันทึกผิด) ***
        คนกลุ่มนี้ไม่เคยเป็นพนักงานจริง ถ้านับจะทำให้อัตราการลาออกสูงเกินจริง
        นี่คือเหตุผลหลักที่แยกสองประเภทออกจากกันตั้งแต่ต้น

     3. เดิม resignReason เป็นค่าตายตัว 'ไม่ระบุ' ทุกแถว (เป็น placeholder)
        เปลี่ยนเป็นเหตุผลจริงจาก MasterConfig groupName='ResignReason'
        กรณีเลือก "อื่น ๆ" จะใช้ข้อความที่ผู้ใช้พิมพ์ใน offboardReasonOther

     4. จำนวนพนักงานเฉลี่ยคิดจากยอดปลายเดือนทั้ง 12 เดือน โดยใช้กติกาเดียวกับ
        v_user_working คือคนยังนับอยู่จนถึงวันทำงานวันสุดท้าย

   ชื่อคอลัมน์ที่คืนออกไปเหมือนเดิมทุกตัว หน้าจอและ C# จึงไม่ต้องแก้
   ============================================================================ */

ALTER PROCEDURE [dbo].[up_report_turnover_attrition_sel]
(
      @year       INT
    , @department NVARCHAR(50)
    , @page       INT
    , @row        INT
    , @total      INT OUTPUT
)
AS
BEGIN

    DECLARE @targetYear INT = CASE WHEN @year > 0 THEN @year ELSE YEAR(GETDATE()) END;

    /* ---- คนที่ลาออกในปีที่เลือก แยกตามแผนก + เหตุผล ---- */
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
      AND   (@department = '' OR ISNULL(vd.Desc_TH, ISNULL(ue.departmentCode, N'ไม่ระบุ')) LIKE '%' + @department + '%')
    GROUP BY ISNULL(vd.Desc_TH, ISNULL(ue.departmentCode, N'ไม่ระบุ'))
          , CASE
              WHEN ISNULL(u.offboardReasonOther, '') <> '' THEN u.offboardReasonOther
              WHEN ISNULL(mc.Desc_TH, '') <> ''            THEN mc.Desc_TH
              ELSE N'ไม่ระบุ'
            END;

    /* ---- จำนวนพนักงานเฉลี่ยทั้งปี (ยอดปลายเดือน 12 เดือนเฉลี่ยกัน) ----
       คนหนึ่งนับอยู่ในเดือนนั้นเมื่อ
         - เข้างานก่อนหรือภายในสิ้นเดือน  และ
         - ยังไม่ออก หรือวันทำงานวันสุดท้ายยังเลยสิ้นเดือนนั้นไป
       ใช้กติกาเดียวกับ v_user_working จึงตรงกับที่หน้าจออื่นเห็น         */
    DECLARE @avgHeadcount DECIMAL(18,2);

    ;WITH m AS (
        SELECT 1 AS month_no UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4
        UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8
        UNION ALL SELECT 9 UNION ALL SELECT 10 UNION ALL SELECT 11 UNION ALL SELECT 12
    ),
    hc AS (
        SELECT  m.month_no
              , COUNT(u.userId) AS headcount
        FROM    m
                LEFT JOIN UserEmployeeInfo ue WITH(NOLOCK)
                       ON ue.is_active = 1
                      AND ue.join_date <= EOMONTH(DATEFROMPARTS(@targetYear, m.month_no, 1))
                LEFT JOIN UserInfo u WITH(NOLOCK)
                       ON u.userId = ue.userId
                      AND ISNULL(u.offboardType, '') <> 'Void'
                      AND (u.lastWorkingDate IS NULL
                           OR u.lastWorkingDate > EOMONTH(DATEFROMPARTS(@targetYear, m.month_no, 1)))
        GROUP BY m.month_no
    )
    SELECT @avgHeadcount = AVG(CAST(headcount AS DECIMAL(18,2))) FROM hc;

    /* อัตราการลาออก = คนออก / พนักงานเฉลี่ย * 100 */
    UPDATE  #data
    SET     averageHeadcount = ISNULL(@avgHeadcount, 0)
          , turnoverRate = CASE WHEN ISNULL(@avgHeadcount, 0) = 0 THEN 0
                                ELSE (resignCount * 100.00) / @avgHeadcount END;

    /* ---- Paging (โครงเดิม) ---- */
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


/* ----------------------------------------------------------------------------
   ตรวจผล
   ---------------------------------------------------------------------------- */
-- 1. ข้อมูลดิบที่ควรถูกนับ (ถ้าว่าง แปลว่ายังไม่มีใครถูกบันทึกลาออกในปีนั้น)
SELECT  u.userId, u.offboardType, u.lastWorkingDate, u.offboardReason, u.offboardReasonOther
FROM    UserInfo u WITH(NOLOCK)
WHERE   u.offboardType IS NOT NULL
ORDER BY u.lastWorkingDate DESC;
GO

-- 2. เรียกรายงาน (แทนปีตามจริง)
-- DECLARE @total INT
-- EXEC up_report_turnover_attrition_sel @year = 2026, @department = '', @page = 1, @row = 50, @total = @total OUTPUT
-- SELECT @total AS total
GO

/* ----------------------------------------------------------------------------
   หมายเหตุสำหรับหน้าจอ (ยังไม่ได้แก้)
     - ตารางในหน้า Report/turnover-attrition ผูกกับ departmentName / resignReason /
       resignCount / averageHeadcount / turnoverRate อยู่แล้ว จึงแสดงได้ทันที
     - ตอนนี้ 1 แถว = 1 คู่ (แผนก + เหตุผล) ถ้าต้องการดูรวมทั้งแผนกโดยไม่แยกเหตุผล
       ให้เพิ่มตัวเลือกสลับมุมมองที่หน้าจอ แล้วส่งพารามิเตอร์เพิ่มเข้ามา
       (ต้องแก้ทั้ง proc / ReportModels / หน้าจอ)
   ---------------------------------------------------------------------------- */
