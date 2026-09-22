/* ============================================================================
   แก้หน้า Onboarding/Index แสดงข้อมูลไม่ครบ/ผิด
     1. เพิ่ม nickname (ชื่อเล่น)        — เดิม SP ไม่ได้ select
     2. เพิ่ม employeeType (ประเภทพนักงาน) — เดิม SP ไม่ได้ select (join v_employee_type)
     3. แก้ [function] (สังกัดด้าน)       — เดิมใช้ vd2 (divisionCode) ผิด ทำให้ซ้ำกับสายงาน
                                            ที่ถูกคือ vd3 (functionCode) ซึ่ง join ไว้อยู่แล้วแต่ไม่ได้ใช้
     (ตำแหน่ง: SP คืนคอลัมน์ชื่อ position อยู่แล้ว แก้ที่ฝั่งหน้าจอให้ผูก x.position)

   ลำดับ deploy: 1) รัน SQL  2) deploy APIEmpHub  3) deploy EmpHub
   ============================================================================ */

ALTER procedure [dbo].[up_user_onboard_sel]
(
@employeeCode nvarchar(50)
, @firstname_th nvarchar(50)
, @status nvarchar(50)
, @page int
, @row int
, @total int output
)
as
begin

	select t.userId
	, e.employeeCode
	, vf_th.Desc_TH as prefix_th
	, isnull(p.firstname_th,'') as firstname_th
	, isnull(p.lastname_th,'') as lastname_th
	, isnull(p.nickname,'') as nickname
	, vf_en.Desc_EN as prefix_en
	, isnull(p.firstname_en,'') as firstname_en
	, isnull(p.lastname_en,'') as lastname_en
	, vp.Desc_TH as position
	, vet.Desc_TH as employeeType
	, vd.Desc_TH as department
	, vd2.Desc_TH as division
	, vd3.Desc_TH as [function]
	, e.email
	, e.ext
	, convert(nvarchar,e.join_date,103) as join_date
	, t.status
	, t.create_by
	, t.create_date
	into #data
	from OnboardInfo t with(nolock)
	left outer join UserPersonalInfo p with(nolock) on t.userId = p.userId and p.is_active = 1
	left outer join UserEmployeeInfo e with(nolock) on t.userId = e.userId and e.is_active = 1
	left outer join v_position vp with(nolock) on e.positionCode = vp.Code and vp.is_active = 1
	left outer join v_department vd with(nolock) on e.departmentCode = vd.Code and vd.is_active = 1
	left outer join v_department vd2 with(nolock) on e.divisionCode = vd2.Code and vd2.is_active = 1
	left outer join v_department vd3 with(nolock) on e.functionCode = vd3.Code and vd3.is_active = 1
	left outer join v_employee_type vet with(nolock) on e.employeeType = vet.Code and vet.is_active = 1
	left outer join v_Prefix vf_th with(nolock) on p.prefix_th = vf_th.Code and vf_th.is_active = 1
	left outer join v_Prefix vf_en with(nolock) on p.prefix_en = vf_en.Code and vf_en.is_active = 1
	where t.is_active = 1

	--Condition

	if(@employeeCode != '')
	begin

		delete t from #data t
		where t.employeeCode not like '%' + @employeeCode + '%'

	end

	if(@firstname_th != '')
	begin

		delete t from #data t
		where t.firstname_th not like '%' + @firstname_th + '%'
		and t.lastname_th not like '%' + @firstname_th + '%'
		and t.firstname_en not like '%' + @firstname_th + '%'
		and t.lastname_en not like '%' + @firstname_th + '%'

	end

	if(@status != '')
	begin

		delete t from #data t
		where t.status != @status

	end


	set @total = (select count(*) from #data)

	declare @start int = ((@page - 1) * @row) + 1
	declare @end int = @page * @row

	select 0 as sort_by, * into #sort from #data t
	delete t from #sort t

	insert into #sort
	select row_number() over(order by t.create_date desc) as sort_by, * from #data t

	/* Update */

	update t set create_by = up.firstname_th + ' ' + up.lastname_th
	from #sort t
	inner join UserPersonalInfo up with(nolock) on t.create_by = up.userId and up.is_active = 1

	/* result */

	select *
	into #result
	from #sort t
	where t.sort_by between @start and @end

	select * from #result t
	order by t.sort_by

	drop table #sort
	drop table #data
	drop table #result

end
GO
