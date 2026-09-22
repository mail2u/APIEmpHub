/* ============================================================================
   เพิ่มฟิลด์ "วันบรรจุเป็นพนักงาน" (appointed_date) ในข้อมูลพนักงาน (Onboarding step 4)
   เก็บเป็น date (ค.ศ.) เหมือน join_date / probation_end_date

   ขอบเขต: สาย Onboarding (up_user_employee_save / up_user_employee_detail)
     - UserEmployeeInfo : เพิ่มคอลัมน์ appointed_date
     - up_user_employee_save   : รับ/บันทึก @appointed_date
     - up_user_employee_detail : คืน appointed_date (รูปแบบ 103 = dd/MM/yyyy)

   ลำดับ deploy: 1) รัน SQL  2) deploy APIEmpHub  3) deploy EmpHub
   ============================================================================ */

/* ----------------------------------------------------------------------------
   STEP 1 : เพิ่มคอลัมน์ (idempotent)
   ---------------------------------------------------------------------------- */
IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.UserEmployeeInfo') AND name = 'appointed_date')
    ALTER TABLE dbo.UserEmployeeInfo ADD appointed_date date NULL;
GO


/* ----------------------------------------------------------------------------
   STEP 2 : up_user_employee_detail (+ appointed_date)
   ---------------------------------------------------------------------------- */
ALTER procedure [dbo].[up_user_employee_detail]
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

	select t.userId
	, t.processType
	, t.processReason
	, t.employeeId
	, t.employeeCode
	, t.employeeType
	, case t.employeeType
		when 'permanent' then 'พนักงานประจำ'
		when 'contract' then 'พนักงานสัญญาจ้าง'
		else '' end as employeeDesc
	, t.email
	, t.ext
	, t.phone_office
	, cast(null as nvarchar(100)) as functionDesc
	, t.functionCode
	, cast(null as nvarchar(100)) as divisionDesc
	, t.divisionCode
	, cast(null as nvarchar(100)) as departmentDesc
	, t.departmentCode
	, cast(null as nvarchar(100)) as sectionDesc
	, t.sectionCode
	, cast(null as nvarchar(100)) as positionDesc
	, t.positionCode
	, cast(null as nvarchar(100)) as levelDesc
	, t.levelCode
	, convert(nvarchar,t.join_date,103) as join_date
	, convert(nvarchar,t.probation_end_date,103) as probation_end_date
	, convert(nvarchar,t.appointed_date,103) as appointed_date
	, t.probation_day
	, t.grade
	, t.location
	, '' as locationDesc
	, t.sso
	, '' as ssoDesc
	, t.workMode
	, '' as workModeDesc
	, t.workTime
	, '' as workTimeDesc
	, t.otMode
	, '' as otModeDesc
	, t.supervisorId
	, cast(null as nvarchar(100)) as supervisorName
	, cast(null as nvarchar(100)) as supervisorPosition
	, cast(null as nvarchar(100)) as supervisorDepartment
	, t.employeeMode
	, t.calendarCode
	, t.salary
	, t.paymentChannel
	, t.bankCode
	, t.bookNo
	, 'Approve' as status
	, cast(null as nvarchar(100)) as update_by
	, t.update_date
	into #data
	from UserEmployeeInfo t with(nolock)
	where t.is_active = 1
	and t.userId = @userId
	and (@can_view = 1 or @admin_view = 1)

	update t set positionDesc = v.Desc_TH
	from #data t
	left outer join v_position v with(nolock) on t.positionCode = v.Code and v.is_active = 1

	update t set sectionDesc = v.Desc_TH
	from #data t
	left outer join v_department v with(nolock) on t.sectionCode = v.Code and v.is_active = 1

	update t set departmentDesc = v.Desc_TH
	from #data t
	left outer join v_department v with(nolock) on t.departmentCode = v.Code and v.is_active = 1

	update t set divisionDesc = v.Desc_TH
	from #data t
	left outer join v_department v with(nolock) on t.divisionCode = v.Code and v.is_active = 1

	update t set functionDesc = v.Desc_TH
	from #data t
	left outer join v_department v with(nolock) on t.functionCode = v.Code and v.is_active = 1

	update t set levelDesc = v.Desc_TH
	from #data t
	left outer join v_level v with(nolock) on t.levelCode = v.Code and v.is_active = 1

	update t set supervisorName = sp.firstname_th + ' ' + sp.lastname_th
	, supervisorPosition = sevp.Desc_TH
	, supervisorDepartment = sevd.Desc_TH
	from #data t
	left outer join UserPersonalInfo sp with(nolock) on t.supervisorId = sp.userId and sp.is_active = 1
	left outer join UserEmployeeInfo se with(nolock) on sp.userId = se.userId and se.is_active = 1
	left outer join v_position sevp with(nolock) on se.positionCode = sevp.Code and sevp.is_active = 1
	left outer join v_department sevd with(nolock) on se.departmentCode = sevd.Code and sevd.is_active = 1

	update t set update_by = up.firstname_th + ' ' + up.lastname_th
	from #data t
	left outer join UserPersonalInfo up with(nolock) on t.update_by = up.userId and up.is_active = 1

	select * from #data

	drop table #data

end
GO


/* ----------------------------------------------------------------------------
   STEP 3 : up_user_employee_save (+ @appointed_date)
   ---------------------------------------------------------------------------- */
ALTER procedure [dbo].[up_user_employee_save]
(
@userId nvarchar(50)
, @processType nvarchar(50)
, @processReason nvarchar(50)
, @employeeCode nvarchar(50)
, @employeeType nvarchar(50)
, @email nvarchar(50)
, @ext nvarchar(50)
, @phone_office nvarchar(50)
, @functionCode nvarchar(50)
, @divisionCode nvarchar(50)
, @departmentCode nvarchar(50)
, @sectionCode nvarchar(50)
, @positionCode nvarchar(50)
, @levelCode nvarchar(50)
, @grade nvarchar(50)
, @join_date nvarchar(50)
, @probation_end_date nvarchar(50)
, @appointed_date nvarchar(50)
, @probation_day int
, @supervisorId nvarchar(50)
, @location nvarchar(50)
, @sso nvarchar(50)
, @workMode nvarchar(50)
, @workTime nvarchar(50)
, @otMode nvarchar(50)
, @create_by nvarchar(50)
, @employeeMode nvarchar(50)
, @calendarCode nvarchar(50)
, @salary decimal(18,2)
, @paymentChannel nvarchar(50)
, @bankCode nvarchar(50)
, @bookNo nvarchar(50)
)
as
begin

	update t set is_active = 0, update_by = @create_by, update_date = getdate()
	from UserEmployeeInfo t with(nolock)
	where t.is_active = 1
	and t.userId = @userId

	declare @id nvarchar(50) = 'log_' + lower(newid())

	insert into UserEmployeeInfo(
	userId
	, employeeId
	, processType
	, processReason
	, employeeCode
	, employeeType
	, email
	, ext
	, phone_office
	, functionCode
	, divisionCode
	, departmentCode
	, sectionCode
	, positionCode
	, levelCode
	, grade
	, join_date
	, probation_end_date
	, appointed_date
	, probation_day
	, supervisorId
	, location
	, sso
	, workMode
	, workTime
	, otMode
	, employeeMode
	, calendarCode
	, salary
	, paymentChannel
	, bankCode
	, bookNo
	, is_active
	, create_by
	, create_date
	)
	select @userId as userId
	, 'u_employee_' + lower(newid()) as employeeId
	, @processType
	, @processReason
	, @employeeCode
	, @employeeType
	, @email
	, @ext
	, @phone_office
	, @functionCode
	, @divisionCode
	, @departmentCode
	, @sectionCode
	, @positionCode
	, @levelCode
	, @grade
	, case when isnull(@join_date,'') = '' then null else @join_date end as join_date
	, case when isnull(@probation_end_date,'') = '' then null else @probation_end_date end as probation_end_date
	, case when isnull(@appointed_date,'') = '' then null else @appointed_date end as appointed_date
	, @probation_day
	, @supervisorId
	, @location
	, @sso
	, @workMode
	, @workTime
	, @otMode
	, @employeeMode
	, @calendarCode
	, @salary
	, @paymentChannel
	, @bankCode
	, @bookNo
	, 1 as is_active
	, @create_by as create_by
	, getdate() as create_date

end
GO
