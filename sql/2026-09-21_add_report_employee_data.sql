/* ============================================================================
   2026-09-21  รายงาน "ขอข้อมูลพนักงาน" — ดึงข้อมูลพนักงานครบทุกฟิลด์ตามแบบฟอร์ม FormEmployeeData
   ฟิลด์: คำนำหน้า/ชื่อ-สกุล/ตำแหน่ง/ประเภทพนักงาน/สังกัดฝ่าย/สังกัดสาย/สังกัดด้าน (TH/EN)
          + วันเริ่มงาน + วันที่มีผลลาออก + อีเมล + username
   ขอบเขต: เฉพาะพนักงานที่ยังทำงานอยู่ (v_user_working.is_working = 1)
   mapping: ด้าน=function, สาย=division, ฝ่าย=department (อ้าง v_department ตาม code)

   ลำดับ deploy: 1) รัน SQL  2) deploy APIEmpHub  3) deploy EmpHub
   ============================================================================ */

CREATE OR ALTER procedure [dbo].[up_report_employee_data_sel]
(
  @name           nvarchar(100) = ''
, @positionCode   nvarchar(50)  = ''
, @departmentCode nvarchar(50)  = ''
, @dateFrom       nvarchar(8)   = ''   -- yyyyMMdd (วันเริ่มงานตั้งแต่)
, @dateTo         nvarchar(8)   = ''   -- yyyyMMdd (วันเริ่มงานถึง)
)
as
begin

    select t.userId
    , isnull(t.username, '')                          as username
    , isnull(e.employeeCode, '')                      as employeeCode
    , isnull(vf_th.Desc_TH, '')                       as prefix_th
    , isnull(vf_en.Desc_EN, '')                       as prefix_en
    , isnull(p.firstname_th, isnull(t.firstname, '')) as firstname_th
    , isnull(p.lastname_th, isnull(t.lastname, ''))   as lastname_th
    , isnull(p.firstname_en, '')                      as firstname_en
    , isnull(p.lastname_en, '')                       as lastname_en
    , isnull(p.nickname, '')                          as nickname
    , isnull(e.positionCode, '')                      as positionCode
    , isnull(vp.Desc_TH, '')                          as position_th
    , isnull(vp.Desc_EN, '')                          as position_en
    , isnull(e.employeeType, '')                      as employeeTypeCode
    , isnull(vet.Desc_TH, '')                         as employee_type_th
    , isnull(vet.Desc_EN, '')                         as employee_type_en
    , isnull(e.departmentCode, '')                    as departmentCode
    , isnull(vd.Desc_TH, '')                          as department_th
    , isnull(vd.Desc_EN, '')                          as department_en
    , isnull(e.divisionCode, '')                      as divisionCode
    , isnull(vd2.Desc_TH, '')                         as division_th
    , isnull(vd2.Desc_EN, '')                         as division_en
    , isnull(e.functionCode, '')                      as functionCode
    , isnull(vd3.Desc_TH, '')                         as function_th
    , isnull(vd3.Desc_EN, '')                         as function_en
    , convert(nvarchar, e.join_date, 103)             as join_date
    , convert(nvarchar, t.lastWorkingDate, 103)       as resign_date
    , isnull(e.email, '')                             as email
    into #data
    from UserInfo t with(nolock)
    inner join v_user_working w with(nolock) on t.userId = w.userId
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
    and w.is_working = 1
    and (@dateFrom = '' or convert(nvarchar, e.join_date, 112) >= @dateFrom)
    and (@dateTo   = '' or convert(nvarchar, e.join_date, 112) <= @dateTo)

    /* Condition */

    if (@name != '')
    begin
        delete t from #data t
        where t.firstname_th not like '%' + @name + '%'
        and t.lastname_th   not like '%' + @name + '%'
        and t.firstname_en  not like '%' + @name + '%'
        and t.lastname_en   not like '%' + @name + '%'
        and t.username      not like '%' + @name + '%'
        and t.employeeCode  not like '%' + @name + '%'
    end

    if (@positionCode != '')
    begin
        delete t from #data t where t.positionCode != @positionCode
    end

    if (@departmentCode != '')
    begin
        delete t from #data t where t.departmentCode != @departmentCode
    end

    select * from #data
    order by department_th, division_th, function_th, firstname_th

    drop table #data

end
GO
