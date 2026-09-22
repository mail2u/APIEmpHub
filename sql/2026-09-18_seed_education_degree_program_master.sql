/* ============================================================================
   Seed ข้อมูลอ้างอิงการศึกษา: วุฒิการศึกษา (Degree) + หลักสูตร (Educational)
   อ้างอิงกรอบวุฒิการศึกษาของไทย (กระทรวงศึกษาธิการ)

   บริบท
     - ตาราง master กลางคือ MasterConfig (groupName, Code, Desc_TH, Desc_EN,
       is_active, condition_1..4, orderIndex, ...)
     - ฟอร์มการศึกษา (FormCreate/FormUpdate/FormUpdateDataEducation) ใช้
         วุฒิการศึกษา  -> groupName = 'Degree'      (ผูก x.degreeCode)
         หลักสูตร      -> groupName = 'Educational'  (ผูก x.programCode)
       จัดการผ่านหน้า Setting > ProgramCode (groupName = 'Educational')
     - ความสัมพันธ์ "หลักสูตรอ้างอิงวุฒิ" เก็บที่ condition_1 ของแถวหลักสูตร
       โดย condition_1 = Code ของวุฒิ (Degree) ที่หลักสูตรนั้นสังกัด
       (ทำให้ทำ dropdown แบบกรองตามวุฒิได้ในอนาคต)

   *** อ่านก่อนรัน ***
     - สคริปต์นี้ "ไม่ทราบข้อมูลเดิม" ใน MasterConfig (เห็นเฉพาะ schema)
       จึงออกแบบให้ปลอดภัย: รัน STEP 0 สำรวจก่อน แล้วค่อยรัน STEP 1-2
     - ทุก INSERT กันซ้ำด้วย IF NOT EXISTS (groupName + Code) -> รันซ้ำได้
     - ถ้าของเดิมมี 'Degree'/'Educational' อยู่แล้วด้วย "โค้ดคนละชุด"
       ให้ตรวจ STEP 0 แล้วปรับ Code/con dition_1 ให้ตรงกับของจริงก่อน
       ไม่งั้นจะได้รายการซ้ำความหมาย (คนละโค้ด)
     - โค้ด (Code) ในสคริปต์นี้เป็นชุดมาตรฐานที่เสนอไว้ ปรับได้ตามที่ใช้จริง

   ลำดับ deploy: 1) ตรวจ STEP 0  2) รัน STEP 1-2  3) deploy EmpHub (โหลด lProgram)
   ============================================================================ */

/* ----------------------------------------------------------------------------
   STEP 0 : สำรวจของเดิมก่อน (อย่าเพิ่งรัน STEP 1-2 จนกว่าจะดูผลตรงนี้)
   ---------------------------------------------------------------------------- */
-- 0.1 วุฒิการศึกษาที่มีอยู่แล้ว
SELECT Code, Desc_TH, Desc_EN, is_active, condition_1, orderIndex
FROM   MasterConfig WITH (NOLOCK)
WHERE  groupName = 'Degree'
ORDER  BY orderIndex, Code;
GO

-- 0.2 หลักสูตรที่มีอยู่แล้ว
SELECT Code, Desc_TH, Desc_EN, is_active, condition_1, orderIndex
FROM   MasterConfig WITH (NOLOCK)
WHERE  groupName = 'Educational'
ORDER  BY orderIndex, Code;
GO


/* ----------------------------------------------------------------------------
   STEP 1 : วุฒิการศึกษา (groupName = 'Degree') ตามกรอบมาตรฐานไทย
            (insert เฉพาะโค้ดที่ยังไม่มี)
   ---------------------------------------------------------------------------- */
SET NOCOUNT ON;

;WITH seed_degree (Code, Desc_TH, Desc_EN, orderIndex) AS (
    SELECT 'BELOW_PRIMARY'      , N'ต่ำกว่าประถมศึกษา'                    , N'Below Primary'                 , 1  UNION ALL
    SELECT 'PRIMARY'            , N'ประถมศึกษา'                          , N'Primary'                       , 2  UNION ALL
    SELECT 'LOWER_SECONDARY'    , N'มัธยมศึกษาตอนต้น'                     , N'Lower Secondary'               , 3  UNION ALL
    SELECT 'UPPER_SECONDARY'    , N'มัธยมศึกษาตอนปลาย'                    , N'Upper Secondary'               , 4  UNION ALL
    SELECT 'VOC_CERT'           , N'ประกาศนียบัตรวิชาชีพ (ปวช.)'          , N'Vocational Certificate'        , 5  UNION ALL
    SELECT 'HIGH_VOC_CERT'      , N'ประกาศนียบัตรวิชาชีพชั้นสูง (ปวส.)'    , N'High Vocational Certificate'   , 6  UNION ALL
    SELECT 'DIPLOMA'            , N'อนุปริญญา'                           , N'Diploma'                       , 7  UNION ALL
    SELECT 'BACHELOR'           , N'ปริญญาตรี'                           , N'Bachelor''s Degree'            , 8  UNION ALL
    SELECT 'GRAD_DIPLOMA'       , N'ประกาศนียบัตรบัณฑิต'                  , N'Graduate Diploma'              , 9  UNION ALL
    SELECT 'MASTER'             , N'ปริญญาโท'                            , N'Master''s Degree'              , 10 UNION ALL
    SELECT 'HIGHER_GRAD_DIPLOMA', N'ประกาศนียบัตรบัณฑิตชั้นสูง'           , N'Higher Graduate Diploma'       , 11 UNION ALL
    SELECT 'DOCTORATE'          , N'ปริญญาเอก'                           , N'Doctoral Degree'               , 12
)
INSERT INTO MasterConfig (groupName, Code, Desc_TH, Desc_EN, is_active, orderIndex, create_by, create_date)
SELECT 'Degree', s.Code, s.Desc_TH, s.Desc_EN, 1, s.orderIndex, 'system', GETDATE()
FROM   seed_degree s
WHERE  NOT EXISTS (
           SELECT 1 FROM MasterConfig m
           WHERE  m.groupName = 'Degree' AND m.Code = s.Code
       );
GO


/* ----------------------------------------------------------------------------
   STEP 2 : หลักสูตร (groupName = 'Educational') = ชื่อปริญญา/หลักสูตร
            condition_1 = Code ของวุฒิ (Degree) ที่หลักสูตรนั้นสังกัด
            (insert เฉพาะโค้ดที่ยังไม่มี)
   ---------------------------------------------------------------------------- */
;WITH seed_program (Code, Desc_TH, Desc_EN, degreeCode, orderIndex) AS (
    -- ระดับ ปวช. / ปวส. (สายอาชีพ) ---------------------------------------------
    SELECT 'VOC_GENERAL'   , N'สายสามัญ'                          , N'General Program'                       , 'VOC_CERT'     , 1  UNION ALL
    SELECT 'VOC_VOCATION'  , N'สายอาชีพ'                          , N'Vocational Program'                    , 'VOC_CERT'     , 2  UNION ALL
    SELECT 'HVOC_VOCATION' , N'สายอาชีพ (ปวส.)'                    , N'Vocational Program (High)'             , 'HIGH_VOC_CERT', 3  UNION ALL

    -- ปริญญาตรี ---------------------------------------------------------------
    SELECT 'BSC'  , N'วิทยาศาสตรบัณฑิต (วท.บ.)'      , N'Bachelor of Science (B.Sc.)'              , 'BACHELOR', 10 UNION ALL
    SELECT 'BA'   , N'ศิลปศาสตรบัณฑิต (ศศ.บ.)'       , N'Bachelor of Arts (B.A.)'                  , 'BACHELOR', 11 UNION ALL
    SELECT 'BBA'  , N'บริหารธุรกิจบัณฑิต (บธ.บ.)'     , N'Bachelor of Business Administration (B.B.A.)', 'BACHELOR', 12 UNION ALL
    SELECT 'BACC' , N'บัญชีบัณฑิต (บช.บ.)'           , N'Bachelor of Accountancy (B.Acc.)'         , 'BACHELOR', 13 UNION ALL
    SELECT 'BENG' , N'วิศวกรรมศาสตรบัณฑิต (วศ.บ.)'    , N'Bachelor of Engineering (B.Eng.)'         , 'BACHELOR', 14 UNION ALL
    SELECT 'LLB'  , N'นิติศาสตรบัณฑิต (น.บ.)'         , N'Bachelor of Laws (LL.B.)'                 , 'BACHELOR', 15 UNION ALL
    SELECT 'BECON', N'เศรษฐศาสตรบัณฑิต (ศ.บ.)'        , N'Bachelor of Economics (B.Econ.)'          , 'BACHELOR', 16 UNION ALL
    SELECT 'BCA'  , N'นิเทศศาสตรบัณฑิต (นศ.บ.)'       , N'Bachelor of Communication Arts'           , 'BACHELOR', 17 UNION ALL
    SELECT 'BPOL' , N'รัฐศาสตรบัณฑิต (ร.บ.)'          , N'Bachelor of Political Science'            , 'BACHELOR', 18 UNION ALL
    SELECT 'BED'  , N'ศึกษาศาสตรบัณฑิต/ครุศาสตรบัณฑิต' , N'Bachelor of Education (B.Ed.)'            , 'BACHELOR', 19 UNION ALL
    SELECT 'BNS'  , N'พยาบาลศาสตรบัณฑิต (พย.บ.)'      , N'Bachelor of Nursing Science (B.N.S.)'     , 'BACHELOR', 20 UNION ALL
    SELECT 'BPH'  , N'สาธารณสุขศาสตรบัณฑิต (ส.บ.)'    , N'Bachelor of Public Health (B.P.H.)'       , 'BACHELOR', 21 UNION ALL

    -- ปริญญาโท ----------------------------------------------------------------
    SELECT 'MSC'  , N'วิทยาศาสตรมหาบัณฑิต (วท.ม.)'    , N'Master of Science (M.Sc.)'                , 'MASTER'  , 30 UNION ALL
    SELECT 'MA'   , N'ศิลปศาสตรมหาบัณฑิต (ศศ.ม.)'     , N'Master of Arts (M.A.)'                    , 'MASTER'  , 31 UNION ALL
    SELECT 'MBA'  , N'บริหารธุรกิจมหาบัณฑิต (บธ.ม.)'   , N'Master of Business Administration (M.B.A.)', 'MASTER' , 32 UNION ALL
    SELECT 'MACC' , N'บัญชีมหาบัณฑิต (บช.ม.)'         , N'Master of Accountancy (M.Acc.)'           , 'MASTER'  , 33 UNION ALL
    SELECT 'MENG' , N'วิศวกรรมศาสตรมหาบัณฑิต (วศ.ม.)'  , N'Master of Engineering (M.Eng.)'           , 'MASTER'  , 34 UNION ALL
    SELECT 'LLM'  , N'นิติศาสตรมหาบัณฑิต (น.ม.)'       , N'Master of Laws (LL.M.)'                   , 'MASTER'  , 35 UNION ALL
    SELECT 'MPA'  , N'รัฐประศาสนศาสตรมหาบัณฑิต (รป.ม.)', N'Master of Public Administration (M.P.A.)' , 'MASTER'  , 36 UNION ALL

    -- ปริญญาเอก ---------------------------------------------------------------
    SELECT 'PHD'  , N'ปรัชญาดุษฎีบัณฑิต (ปร.ด.)'       , N'Doctor of Philosophy (Ph.D.)'             , 'DOCTORATE', 40 UNION ALL
    SELECT 'DBA'  , N'บริหารธุรกิจดุษฎีบัณฑิต (บธ.ด.)'  , N'Doctor of Business Administration (D.B.A.)', 'DOCTORATE', 41
)
INSERT INTO MasterConfig (groupName, Code, Desc_TH, Desc_EN, is_active, condition_1, orderIndex, create_by, create_date)
SELECT 'Educational', s.Code, s.Desc_TH, s.Desc_EN, 1, s.degreeCode, s.orderIndex, 'system', GETDATE()
FROM   seed_program s
WHERE  NOT EXISTS (
           SELECT 1 FROM MasterConfig m
           WHERE  m.groupName = 'Educational' AND m.Code = s.Code
       );
GO


/* ----------------------------------------------------------------------------
   STEP 3 : ตรวจผลหลังรัน
   ---------------------------------------------------------------------------- */
-- 3.1 หลักสูตรพร้อมวุฒิที่อ้างอิง (ควรเห็น condition_1 ชี้ไปยังวุฒิที่ถูกต้อง)
SELECT p.Code        AS programCode
     , p.Desc_TH     AS programName
     , p.condition_1 AS degreeCode
     , d.Desc_TH     AS degreeName
     , p.orderIndex
FROM   MasterConfig p WITH (NOLOCK)
LEFT   JOIN MasterConfig d WITH (NOLOCK)
       ON d.groupName = 'Degree' AND d.Code = p.condition_1 AND d.is_active = 1
WHERE  p.groupName = 'Educational'
ORDER  BY p.orderIndex, p.Code;
GO
