/* ============================================================================
   up_service_detail : เปิดใช้ can_assign (ปุ่ม "กำลังดำเนินการ")

   สิ่งที่แก้จากของเดิม
     1. อ่านสถานะใบงานเข้าตัวแปร @service_status  (เดิมไม่มี ต้องใช้ตัดสินปุ่ม)
     2. set @can_assign  ให้เป็น 1 เฉพาะตอนยังไม่ได้รับเรื่อง -> กดได้ครั้งเดียว
     3. บังคับ @can_work ให้ยังเป็น 1 ตอนสถานะ Assign -> ดำเนินการ/ปฏิเสธ ยังกดได้
     4. เพิ่ม statusDesc ของ Assign เป็น 'กำลังดำเนินการ' (เดิมจะตกไป else '-')
     5. ปลดคอมเมนต์บรรทัด fn_service_allow_assign และแก้ t.id -> @id
        (ของเดิมอ้าง t.id ซึ่งไม่มีใน scope ตรงนั้น ถ้าปลดตรง ๆ จะ compile ไม่ผ่าน)

   *** อ่าน 2 ข้อนี้ก่อนรัน ***

   [1] ServiceStepInfo ผูกกับสถานะ
       proc นี้หา stepIndex ด้วย
           inner join ServiceStepInfo s on t.id = s.refId and t.status = s.status
       ถ้าเปลี่ยนสถานะเป็น 'Assign' แล้วไม่มีแถว ServiceStepInfo ที่ status='Assign'
       -> @stepIndex จะเป็น 0 -> can_previous กลายเป็น 0 (ปุ่ม Send Back หาย)
       ตรวจด้วย STEP 0.2 ด้านล่าง ถ้าไม่มีต้องเพิ่มแถว step ให้สถานะนี้ด้วย

   [2] fn_service_allow_work อาจกรองสถานะไว้
       ถ้า function กรอง status='Work' ไว้ข้างใน มันจะคืน 0 เมื่อสถานะเป็น 'Assign'
       ทำให้ปุ่ม "ดำเนินการ" กับ "ปฏิเสธ" หายหลังกดรับเรื่อง ซึ่งผิดจากที่ต้องการ
       สคริปต์นี้กันไว้ให้แล้วด้วยการ fallback (ดู STEP 2 ส่วน @can_work)
       แต่ควรดู body ของ function ก่อนด้วย STEP 0.3
   ============================================================================ */

/* ----------------------------------------------------------------------------
   STEP 0 : ตรวจของเดิมก่อนรัน ALTER
   ---------------------------------------------------------------------------- */
-- 0.1 มี fn_service_allow_assign อยู่จริงไหม (ของเดิมคอมเมนต์ไว้ อาจยังไม่ได้สร้าง)
SELECT  name, type_desc
FROM    sys.objects
WHERE   name IN ('fn_service_allow_assign', 'fn_service_allow_work');
GO

-- 0.2 ServiceStepInfo มีแถวรองรับสถานะ Assign ไหม  (ข้อ [1] ด้านบน)
SELECT  status, COUNT(*) AS [rows]
FROM    ServiceStepInfo WITH(NOLOCK)
WHERE   is_active = 1
GROUP BY status
ORDER BY status;
GO

-- 0.3 body ของ fn_service_allow_work  (ข้อ [2] ด้านบน)
SELECT  m.definition
FROM    sys.sql_modules m
        INNER JOIN sys.objects o ON o.object_id = m.object_id
WHERE   o.name = 'fn_service_allow_work';
GO


/* ----------------------------------------------------------------------------
   STEP 1 : เพิ่มคอลัมน์บันทึกการรับเรื่อง
   ใช้กันกดซ้ำ และเก็บหลักฐานว่าใครรับเมื่อไร
   ---------------------------------------------------------------------------- */
IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.ServiceInfo') AND name = 'assignBy')
BEGIN
    ALTER TABLE dbo.ServiceInfo ADD assignBy NVARCHAR(50) NULL;
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.ServiceInfo') AND name = 'assignDate')
BEGIN
    ALTER TABLE dbo.ServiceInfo ADD assignDate DATETIME NULL;
END
GO


/* ----------------------------------------------------------------------------
   STEP 2 : ALTER up_service_detail
   ---------------------------------------------------------------------------- */
ALTER PROCEDURE [dbo].[up_service_detail]
(
      @id     NVARCHAR(50)
    , @userBy NVARCHAR(50)
)
AS
BEGIN

    DECLARE @is_allow   INT
    DECLARE @can_link   INT = 0
    DECLARE @can_tag    INT = 0
    DECLARE @can_change INT = 0
    DECLARE @can_share  INT = 0
    DECLARE @can_approve INT = 0
    DECLARE @can_work   INT = 0
    DECLARE @can_assign INT = 0
    DECLARE @status     NVARCHAR(50)
    DECLARE @stepIndex  INT = 0
    DECLARE @my_request INT = 0
    DECLARE @my_action  INT = 0
    DECLARE @my_reject  INT = 0

    /* เพิ่มใหม่ : สถานะและคนที่รับเรื่องไว้ ใช้ตัดสินว่าจะโชว์ปุ่มไหน */
    DECLARE @service_status NVARCHAR(50)
    DECLARE @assignBy       NVARCHAR(50)

    SELECT TOP 1
           @service_status = t.status
         , @assignBy       = t.assignBy
    FROM   ServiceInfo t WITH(NOLOCK)
    WHERE  t.is_active = 1
      AND  t.id = @id

    SET @can_approve = dbo.fn_service_allow_approve(@id, @userBy)
    SET @can_work    = dbo.fn_service_allow_work(@id, @userBy)
    SET @my_request  = dbo.fn_service_my_request(@id, @userBy)
    SET @my_action   = dbo.fn_service_my_action(@id, @userBy)
    SET @my_reject   = dbo.fn_service_my_reject(@id, @userBy)

    /* ---------------------------------------------------------------------
       สถานะ Assign = รับเรื่องแล้วแต่ยังไม่ปิดใบงาน
       ต้องยังดำเนินการ/ปฏิเสธ ได้ ตามที่ผู้ใช้ต้องการ

       ถ้า fn_service_allow_work กรอง status='Work' ไว้ข้างใน มันจะคืน 0
       ตอนสถานะเป็น Assign  บรรทัดนี้จึงกู้สิทธิ์คืนให้ "คนที่กดรับเรื่องไว้เอง"
       ทำให้ปุ่มไม่หายไปแม้ยังไม่ได้แก้ตัว function

       ถ้าดู body แล้วพบว่า function ไม่ได้กรองสถานะ บรรทัดนี้จะไม่มีผลอะไร
       (เพราะ @can_work เป็น 1 อยู่แล้ว) ปล่อยไว้ได้อย่างปลอดภัย
       --------------------------------------------------------------------- */
    IF @can_work = 0
       AND @service_status = 'Assign'
       AND @assignBy = @userBy
    BEGIN
        SET @can_work = 1
    END

    /* ---------------------------------------------------------------------
       can_assign : โชว์ปุ่ม "กำลังดำเนินการ"
         - ต้องมีสิทธิ์ดำเนินการ
         - ใบงานยังอยู่ขั้นรอดำเนินการ
         - ยังไม่มีใครรับเรื่อง  -> กดได้ครั้งเดียว
       --------------------------------------------------------------------- */
    SET @can_assign = CASE
                        WHEN @can_work = 1
                         AND @service_status = 'Work'
                         AND ISNULL(@assignBy, '') = ''
                        THEN 1
                        ELSE 0
                      END

    IF @can_approve = 1
    OR @can_work = 1
    OR @can_assign = 1
    OR @my_request = 1
    OR @my_action = 1
    OR @my_reject = 1
    BEGIN

        /* Authen */
        SELECT SUM(CASE WHEN f.funcCode = 'Link' THEN 1 ELSE 0 END) AS can_link
        , SUM(CASE WHEN f.funcCode = 'Work' OR f.funcCode = 'Tag' THEN 1 ELSE 0 END) AS can_tag
        , SUM(CASE WHEN f.funcCode = 'Admin' THEN 1 ELSE 0 END) AS can_change
        , SUM(CASE WHEN f.funcCode = 'Share' THEN 1 ELSE 0 END) AS can_share
        INTO #authen
        FROM UserInRoleInfo ur WITH(NOLOCK)
        INNER JOIN FuncInRoleInfo fr WITH(NOLOCK) ON ur.roleId = fr.roleId AND fr.is_active = 1
        INNER JOIN FunctionInfo f WITH(NOLOCK) ON fr.funcId = f.funcId AND f.is_active = 1
        WHERE ur.is_active = 1
        AND ur.userId = @userBy

        SELECT TOP 1 @can_link = CASE WHEN t.can_link > 0 THEN 1 ELSE 0 END
        , @can_tag = CASE WHEN t.can_tag > 0 THEN 1 ELSE 0 END
        , @can_change = CASE WHEN t.can_change > 0 THEN 1 ELSE 0 END
        , @can_share = CASE WHEN t.can_share > 0 THEN 1 ELSE 0 END
        FROM #authen t

        SELECT TOP 1 @stepIndex = s.stepIndex
        FROM ServiceInfo t WITH(NOLOCK)
        INNER JOIN ServiceStepInfo s WITH(NOLOCK) ON t.id = s.refId AND t.status = s.status AND s.is_active = 1
        WHERE t.is_active = 1
        AND t.id = @id

        SELECT t.id
        , t.userId
        , t.serviceNo
        , t.categoryId
        , t.categoryCode
        , t.categoryDesc
        , t.subCategoryId
        , t.subCategoryCode
        , t.subCategoryDesc
        , t.title
        , t.status
        , '' AS statusCss
        , CASE WHEN t.status LIKE 'Approve%' THEN 'รออนุมัติ'
          WHEN t.status = 'Request' THEN 'รอนำส่ง'
          WHEN t.status = 'Reject' THEN 'ไม่อนุมัติ'
          WHEN t.status = 'Work' THEN 'รอดำเนินการ'
          WHEN t.status = 'Assign' THEN 'กำลังดำเนินการ'      /* เพิ่มใหม่ */
          WHEN t.status = 'Complete' THEN 'สำเร็จ'
          ELSE '-' END AS statusDesc
        , up.firstname_th + ' ' + up.lastname_th AS userName
        , uvp.Desc_TH AS userPosition
        , uvd.Desc_TH AS userDepartment
        , c.firstname + ' ' + c.lastname AS createName
        , vp.Desc_TH AS createPosition
        , vd.Desc_TH AS createDepartment
        , CONVERT(NVARCHAR,t.createDate,103) + ' ' + CONVERT(NVARCHAR,t.createDate,108) AS createDate
        , t.approveBy AS approveName
        , CONVERT(NVARCHAR,t.approveDate,103) + ' ' + CONVERT(NVARCHAR,t.approveDate,108) AS approveDate
        , t.rejectBy AS rejectName
        , CONVERT(NVARCHAR,t.rejectDate,103) + ' ' + CONVERT(NVARCHAR,t.rejectDate,108) AS rejectDate
        , t.rejectDesc
        , CASE WHEN t.status NOT IN ('Cancel','Reject','Complete') AND t.createBy = @userBy THEN 1 ELSE 0 END AS can_cancel
        , @can_approve AS can_approve
        , @can_work AS can_work
        , @can_assign AS can_assign
        , CASE WHEN @can_approve = 1 OR (t.createBy = @userBy AND t.status = 'Request') THEN 1 ELSE 0 END AS can_edit
        , CASE WHEN (@can_approve = 1 OR @can_assign = 1 OR @can_work = 1) AND @stepIndex = 1 THEN 1 ELSE 0 END AS can_previous
        INTO #data
        FROM ServiceInfo t WITH(NOLOCK)
        LEFT OUTER JOIN UserInfo c WITH(NOLOCK) ON t.createBy = c.userId
        LEFT OUTER JOIN v_position vp WITH(NOLOCK) ON c.position = vp.Code
        LEFT OUTER JOIN v_department vd WITH(NOLOCK) ON c.department = vd.Code
        --userInfo
        LEFT OUTER JOIN UserInfo u WITH(NOLOCK) ON t.userId = u.userId
        LEFT OUTER JOIN UserPersonalInfo up WITH(NOLOCK) ON t.userId = up.userId AND up.is_active = 1
        LEFT OUTER JOIN UserEmployeeInfo ue WITH(NOLOCK) ON t.userId = ue.userId AND ue.is_active = 1
        LEFT OUTER JOIN v_position uvp WITH(NOLOCK) ON ue.positionCode = uvp.Code
        LEFT OUTER JOIN v_department uvd WITH(NOLOCK) ON ue.departmentCode = uvd.Code
        WHERE t.is_active = 1
        AND t.id = @id

        UPDATE t SET approveName = cp.firstname_th + ' ' + cp.lastname_th
        FROM #data t
        LEFT OUTER JOIN UserInfo c WITH(NOLOCK) ON t.approveName = c.userId
        LEFT OUTER JOIN UserPersonalInfo cp WITH(NOLOCK) ON c.userId = cp.userId AND cp.is_active = 1

        UPDATE t SET rejectName = cp.firstname_th + ' ' + cp.lastname_th
        FROM #data t
        LEFT OUTER JOIN UserInfo c WITH(NOLOCK) ON t.rejectName = c.userId
        LEFT OUTER JOIN UserPersonalInfo cp WITH(NOLOCK) ON c.userId = cp.userId AND cp.is_active = 1

        SELECT * FROM #data

        DROP TABLE #data

    END
    ELSE
    BEGIN

        RAISERROR('คุณไม่ได้รับอนุญาติในเข้าถึงใบงานนี้', 16, 1)

    END
END
GO


/* ----------------------------------------------------------------------------
   STEP 3 : สร้าง up_service_assign_upd  (ปุ่มเรียก proc นี้)
   ---------------------------------------------------------------------------- */
CREATE OR ALTER PROCEDURE [dbo].[up_service_assign_upd]
(
      @id              NVARCHAR(50)
    , @userBy          NVARCHAR(50)
    , @description     NVARCHAR(MAX) = NULL
    , @status          NVARCHAR(50) OUTPUT
    , @subCategoryCode NVARCHAR(50) OUTPUT
)
AS
BEGIN

    /* กันกดซ้ำ : อัปเดตเฉพาะใบที่ยังรอดำเนินการและยังไม่มีใครรับ */
    UPDATE  ServiceInfo
    SET     status      = 'Assign'
          , assignBy    = @userBy
          , assignDate  = GETDATE()
          , update_by   = @userBy
          , update_date = GETDATE()
    WHERE   id = @id
      AND   is_active = 1
      AND   status = 'Work'
      AND   ISNULL(assignBy, '') = ''

    SELECT TOP 1
           @status          = status
         , @subCategoryCode = subCategoryCode
    FROM   ServiceInfo WITH(NOLOCK)
    WHERE  id = @id

END
GO


/* ----------------------------------------------------------------------------
   STEP 4 : ให้สถานะใหม่โผล่ในรายการและยอดนับ

   ยังต้องแก้ proc เหล่านี้เพิ่ม (หน้าจอรองรับไว้แล้ว ไม่ต้องแก้โค้ด)
     - up_service_work_sel      : คืนใบสถานะ 'Assign' ด้วย ทั้งตอนกรองและตอนดูทั้งหมด
     - up_service_work_summary  : มีแถว status='Assign' พร้อม total / alert_total
     - up_service_inquire_sel / _summary : เช่นกัน (หน้า Inquire นับ Assign ไว้แล้ว)
     - statusDesc ในแต่ละ proc  : เพิ่ม WHEN 'Assign' THEN 'กำลังดำเนินการ'
                                  (แก้ใน up_service_detail แล้วใน STEP 2)

   ถ้ายังไม่แก้ 4 ตัวนี้ ฟีเจอร์ยังใช้ได้ปกติ แต่แท็บ "กำลังดำเนินการ"
   ในหน้า Service/Work จะขึ้นยอด 0 และใบที่รับเรื่องแล้วจะหายจากลิสต์
   ---------------------------------------------------------------------------- */


/* ----------------------------------------------------------------------------
   STEP 5 : ตรวจผล
   ---------------------------------------------------------------------------- */
-- 5.1 คอลัมน์และ proc พร้อมแล้ว
SELECT  c.name AS [column] FROM sys.columns c
WHERE   c.object_id = OBJECT_ID('dbo.ServiceInfo') AND c.name IN ('assignBy','assignDate');
GO

SELECT  name, modify_date FROM sys.objects
WHERE   name IN ('up_service_detail','up_service_assign_upd');
GO

-- 5.2 ทดลองเรียก detail ด้วยใบที่สถานะ Work (แทน id / userBy ให้ตรงของจริง)
-- DECLARE @id NVARCHAR(50) = '<service id>', @userBy NVARCHAR(50) = '<user id>'
-- EXEC up_service_detail @id, @userBy
-- ต้องได้ can_assign = 1, can_work = 1


/* ----------------------------------------------------------------------------
   STEP 6 : ย้อนกลับ
     1) deploy APIEmpHub ตัวเดิมกลับก่อน
     2) คืน up_service_detail เป็นเวอร์ชันก่อนแก้
     3) UPDATE ServiceInfo SET status='Work', assignBy=NULL, assignDate=NULL WHERE status='Assign';
     4) DROP PROCEDURE up_service_assign_upd;
   คอลัมน์ assignBy/assignDate ทิ้งไว้ได้ ไม่กระทบอะไร
   ---------------------------------------------------------------------------- */
