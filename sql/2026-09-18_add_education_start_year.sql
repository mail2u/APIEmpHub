/* ============================================================================
   เพิ่มฟิลด์ "ปีที่เริ่มการศึกษา" (startYear) ในข้อมูลการศึกษา
   คู่กับ "ปีที่สำเร็จการศึกษา" (year) เดิม

   เก็บเป็นปี พ.ศ. (int) เหมือน year เดิม ไม่มีการแปลง ค.ศ./พ.ศ. ที่ชั้นข้อมูล

   ขอบเขต: เฉพาะสาย EDIT_EDUCATION (ฟอร์ม FormCreate/FormUpdateDataEducation)
     - ServiceEducationInfo / UserEducationInfo : เพิ่มคอลัมน์ startYear
     - up_service_education_save : รับ/บันทึก @startYear
     - up_service_education_sel  : คืน startYear (หน้ารายละเอียดใบคำขอ)
     - up_user_education_sel     : คืน startYear (โหลดข้อมูลเดิมเข้าฟอร์ม)
     - up_service_work_edit_education : commit เข้า UserEducationInfo ตอนอนุมัติ

   หมายเหตุ: สาย EDIT_PROFILE (up_service_work_education_upd) เป็น path เก่า
     ที่ใช้ levelCode ไม่รองรับ degree/program จึง "ไม่แตะ" ในสคริปต์นี้

   ลำดับ deploy: 1) รัน SQL  2) deploy APIEmpHub  3) deploy EmpHub
   ============================================================================ */

/* ----------------------------------------------------------------------------
   STEP 1 : เพิ่มคอลัมน์ startYear (idempotent)
   ---------------------------------------------------------------------------- */
IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.ServiceEducationInfo') AND name = 'startYear')
    ALTER TABLE dbo.ServiceEducationInfo ADD startYear int NULL;
GO

IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.UserEducationInfo') AND name = 'startYear')
    ALTER TABLE dbo.UserEducationInfo ADD startYear int NULL;
GO


/* ----------------------------------------------------------------------------
   STEP 2 : up_service_education_save  (+ @startYear)
   ---------------------------------------------------------------------------- */
ALTER procedure [dbo].[up_service_education_save]
(
@refId nvarchar(50)
, @educationId nvarchar(50)
, @institution nvarchar(50)
, @degreeCode nvarchar(50)
, @degreeName nvarchar(50)
, @programCode nvarchar(50)
, @programName nvarchar(50)
, @major nvarchar(50)
, @startYear int
, @year int
, @grade decimal(4,2)
, @description nvarchar(4000)
, @create_by nvarchar(50)
, @mode nvarchar(50)
)
as
begin

	if @educationId = ''
	begin

		set @educationId = 'education_' + lower(newid())

	end

	/* Update */
	update t set is_active = 0, update_by = @create_by, update_date = getdate()
	from ServiceEducationInfo t with(nolock)
	where t.is_active = 1
	and t.refId = @refId
	and t.educationId = @educationId

	declare @id nvarchar(50) = 'log_' + lower(newid())

	/* Create */
	insert into ServiceEducationInfo(
	id
	, refId
	, educationId
	, mode
	, institution
	, degreeCode
	, degreeName
	, programCode
	, programName
	, major
	, startYear
	, year
	, grade
	, description
	, is_active
	, create_by
	, create_date
	)
	select @id as id
	, @refId as refId
	, @educationId as educationId
	, @mode as mode
	, @institution as institution
	, @degreeCode as degreeCode
	, @degreeName as degreeName
	, @programCode as programCode
	, @programName as programName
	, @major as major
	, @startYear as startYear
	, @year as year
	, @grade as grade
	, @description as description
	, 1 as is_active
	, @create_by as create_by
	, getdate() as create_date

end
GO


/* ----------------------------------------------------------------------------
   STEP 3 : up_service_education_sel  (+ startYear)
   ---------------------------------------------------------------------------- */
ALTER procedure [dbo].[up_service_education_sel]
(
@refId nvarchar(50)
)
as
begin

	select t.refId
	, t.educationId
	, t.mode
	, t.degreeCode
	, m2.desc_th as degreeName
	, t.programCode
	, t.programName
	, t.major
	, m1.desc_th as institution
	, t.startYear
	, t.year
	, t.grade
	, t.description
	from ServiceEducationInfo t with(nolock)
	left outer join v_institution m1 on t.institution = m1.code and m1.is_active = 1
	left outer join v_degree m2 on t.degreeCode = m2.code and m2.is_active = 1
	where t.is_active = 1
	and t.refId = @refId

end
GO


/* ----------------------------------------------------------------------------
   STEP 4 : up_user_education_sel  (+ startYear)
   ---------------------------------------------------------------------------- */
ALTER procedure [dbo].[up_user_education_sel]
(
@userId nvarchar(50)
, @create_by nvarchar(50)
, @can_edit int output
, @can_view int output
)
as
begin

	declare @admin_view int = dbo.fn_check_authen(@create_by,'Employee')
	set @can_edit = @admin_view
	set @can_view = dbo.fn_user_sub_me(@create_by, @userId)
	set @can_view = case when @userId = @create_by then 1 else @can_view end

	select '' as refId
	, educationId
	, m1.desc_th as institution
	, degreeCode
	, m2.desc_th as degreeName
	, programCode
	, programName
	, major
	, startYear
	, year
	, grade
	, description
	, 'Approve' as status
	, case when t.userId = @create_by then 1 else @can_edit end as can_edit
	, case when t.userId = @create_by then 1 else @can_view end as can_view
	, up.firstname + ' ' + up.lastname as update_by
	, t.update_date
	from UserEducationInfo t with(nolock)
	left outer join UserInfo up with(nolock) on t.update_by = up.userId and up.is_active = 1
	left outer join v_institution m1 on t.institution = m1.code and m1.is_active = 1
	left outer join v_degree m2 on t.degreeCode = m2.code and m2.is_active = 1
	where t.is_active = 1
	and t.userId = @userId
	and (@can_view = 1 or @admin_view = 1)

end
GO


/* ----------------------------------------------------------------------------
   STEP 5 : up_service_work_edit_education  (commit เข้า UserEducationInfo + startYear)
   ---------------------------------------------------------------------------- */
ALTER procedure [dbo].[up_service_work_edit_education]
(
@id nvarchar(50)
)
as
begin

	declare @userId nvarchar(50)
	, @createBy nvarchar(50)

	select top 1 @userId = t.userId, @createBy = t.createBy
	from ServiceInfo t
	where t.is_active = 1
	and t.id = @id

	update t set is_active = 0, update_by = @createBy, update_date = getdate()
	from UserEducationInfo t
	where t.is_active = 1
	and t.userId = @userId

	insert into UserEducationInfo(
	userId
	, educationId
	, institution
	, degreeCode
	, degreeName
	, programCode
	, programName
	, major
	, startYear
	, year
	, grade
	, is_active
	, create_by
	, create_date
	)
	select @userId
	, t.educationId
	, t.institution
	, t.degreeCode
	, t.degreeName
	, t.programCode
	, t.programName
	, t.major
	, t.startYear
	, t.year
	, t.grade
	, 1 as is_active
	, @createBy
	, getdate() create_date
	from ServiceEducationInfo t with(nolock)
	where t.is_active = 1
	and t.refId = @id

end
GO


/* ----------------------------------------------------------------------------
   STEP 6 : ตรวจผล
   ---------------------------------------------------------------------------- */
-- 6.1 คอลัมน์ถูกเพิ่มแล้ว
SELECT t.name AS [table], c.name AS [column], ty.name AS datatype
FROM   sys.columns c
       INNER JOIN sys.tables t ON t.object_id = c.object_id
       INNER JOIN sys.types  ty ON ty.user_type_id = c.user_type_id
WHERE  t.name IN ('ServiceEducationInfo','UserEducationInfo')
  AND  c.name = 'startYear';
GO
