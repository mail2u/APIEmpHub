/* ============================================================================
   กรองพนักงานที่ออกแล้วออกจากลิสต์และยอดนับ  (พร้อมรัน)

   ต้องรัน 2026-08-08_add_employee_offboard.sql ก่อน
   เพราะสคริปต์นี้อ้าง view v_user_working ที่สร้างไว้ในไฟล์นั้น

   สิ่งที่แก้ในแต่ละ proc มีแค่ 2 บรรทัด
       inner join v_user_working w with(nolock) on t.userId = w.userId
       and w.is_working = 1
   ที่เหลือคงของเดิมไว้ทั้งหมด

   ผลที่ได้
     - บันทึกผิด (Void)                    -> หายจากลิสต์ทันที
     - ลาออก + วันสุดท้ายยังไม่ถึง          -> ยังอยู่ในลิสต์ตามปกติ
     - ลาออก + เลยวันสุดท้ายแล้ว            -> หายเอง ไม่ต้องรัน job อะไร

   up_user_sel ตัวเดียวคุมทั้ง ลิสต์พนักงาน / ผังองค์กร Team-Company /
   dropdown เลือกหัวหน้า เพราะทุกหน้าเรียกผ่าน User/DataList
   ============================================================================ */

USE [EmpHub]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/* ============================================================================
   1) up_user_sel
   ============================================================================ */
ALTER procedure [dbo].[up_user_sel]
(
@firstname_th nvarchar(50)
, @departmentCode nvarchar(50)
, @positionCode nvarchar(50)
, @employeeType nvarchar(50)
, @dateFrom nvarchar(50)
, @dateTo nvarchar(50)
, @page int
, @row int
, @sortBy nvarchar(50)
, @total int output
)
as
begin

	select t.userId
	, isnull(t.username,'') as username
	, isnull(ue.employeeCode,'') as employeeCode
	, cast(null as nvarchar(50)) as prefix_en
	, isnull(up.firstname_en,'') as firstname_en
	, isnull(up.lastname_en,'') as lastname_en
	, cast(null as nvarchar(50)) as prefix_th
	, isnull(up.firstname_th, isnull(t.firstname,'')) as firstname_th
	, isnull(up.lastname_th, isnull(t.lastname,'')) as lastname_th
	, up.nickname
	, ue.email
	, ue.ext
	, ue.join_date
	, ue.functionCode
	, cast(null as nvarchar(50)) as functionDesc
	, ue.divisionCode
	, cast(null as nvarchar(50)) as divisionDesc
	, ue.departmentCode
	, vd.Desc_TH as departmentDesc
	, isnull(t.section,'') as sectionCode
	, vs.desc_th as sectionDesc
	, isnull(t.position,'') as positionCode
	, vp.Desc_TH as positionDesc
	, isnull(ue.employeeType,'') as employeeType
	, t.create_date
	, case when isnull(vp.condition_2,'') = '' then '99' else vp.condition_2 end as positionOrder
	, 0 as have_signature
	into #data
	from UserInfo t with(nolock)
	left outer join UserPersonalInfo up with(nolock) on t.userId = up.userId and up.is_active = 1
	left outer join UserEmployeeInfo ue with(nolock) on t.userId = ue.userId and ue.is_active = 1
	left outer join v_department vd with(nolock) on t.department = vd.Code
	left outer join v_section vs with(nolock) on t.section = vs.Code
	left outer join v_position vp with(nolock) on t.position = vp.Code
	inner join v_user_working w with(nolock) on t.userId = w.userId		/* << เพิ่ม : ตัดคนที่ออกแล้ว */
	where t.is_active = 1
	and w.is_working = 1												/* << เพิ่ม */

	/* Condition */

	if @firstname_th != ''
	begin

		delete t
		from #data t
		where t.username not like '%' + @firstname_th + '%'
		and t.firstname_en not like '%' + @firstname_th + '%'
		and t.firstname_th not like '%' + @firstname_th + '%'
		and t.lastname_en not like '%' + @firstname_th + '%'
		and t.lastname_th not like '%' + @firstname_th + '%'
		and t.employeeCode not like '%' + @firstname_th + '%'

	end

	if @departmentCode != ''
	begin

		delete t
		from #data t
		where t.departmentCode != @departmentCode

	end

	if @positionCode != ''
	begin

		delete t
		from #data t
		where t.positionCode != @positionCode

	end

	if @employeeType != ''
	begin

		delete t
		from #data t
		where t.employeeType != @employeeType

	end

	if @dateFrom != ''
	begin

		delete t
		from #data t
		where convert(nvarchar,t.join_date,112) < @dateFrom

	end

	if @dateTo != ''
	begin

		delete t
		from #data t
		where convert(nvarchar,t.join_date,112) > @dateTo

	end

	/* Sort */


	set @total = (select count(*) from #data)

	declare @start int = ((@page - 1) * @row) + 1
	declare @end int = @page * @row

	select 0 as rn, * into #sort from #data t
	delete t from #sort t

	if @sortBy = 'department'
	begin

		insert into #sort
		select row_number() over(order by t.departmentDesc) as rn, * from #data t

	end
	else if @sortBy = 'position'
	begin

		insert into #sort
		select row_number() over(order by t.positionOrder) as rn, * from #data t

	end
	else
	begin

		insert into #sort
		select row_number() over(order by t.join_date desc) as rn, * from #data t

	end

	select *
	into #result
	from #sort t
	where t.rn between @start and @end
	order by t.rn

	/* Update Info */

	update t set prefix_en = v.Desc_EN
	from #result t
	inner join UserPersonalInfo up with(nolock) on t.userId = up.userId and up.is_active = 1
	inner join v_Prefix v on up.prefix_en = v.Code

	update t set prefix_th = v.Desc_TH
	from #result t
	inner join UserPersonalInfo up with(nolock) on t.userId = up.userId and up.is_active = 1
	inner join v_Prefix v on up.prefix_th = v.Code

	update t set prefix_th = v.Desc_TH
	from #result t
	inner join UserPersonalInfo up with(nolock) on t.userId = up.userId and up.is_active = 1
	inner join v_Prefix v on up.prefix_th = v.Code

	/* Name */

	update t set departmentDesc = d1.Desc_TH
	from #result t
	inner join v_department d1 on t.departmentCode = d1.Code

	update t set divisionDesc = d1.Desc_TH
	from #result t
	inner join v_department d1 on t.divisionCode = d1.Code

	update t set functionDesc = d1.Desc_TH
	from #result t
	inner join v_department d1 on t.functionCode = d1.Code

	/* Check Signature */

	update t set have_signature = 1
	from #result t
	inner join SignatureInfo s with(nolock) on t.userId = s.refId and s.is_active = 1

	select * from #result

	drop table #sort
	drop table #data
	drop table #result

end
GO


/* ============================================================================
   2) up_user_summary
   ============================================================================ */
ALTER procedure [dbo].[up_user_summary]
(
@firstname_th nvarchar(50)
, @departmentCode nvarchar(50)
, @positionCode nvarchar(50)
)
as
begin

	declare @summary table (status nvarchar(50), total int, alert_total int)

	insert into @summary
	select'Permanent' as status, 0 as total, 0 as alert_total
	union all select 'Contract' as status, 0 as total, 0 as alert_total
	union all select 'None' as status, 0 as total, 0 as alert_total

	select r.employeeType as status, count(*) as total, 0 as alert_total
	into #sum
	from (
		select case when isnull(ue.employeeType,'') = '' then 'None' else ue.employeeType end as employeeType
		from UserInfo t with(nolock)
		left outer join UserPersonalInfo up with(nolock) on t.userId = up.userId and up.is_active = 1
		left outer join UserEmployeeInfo ue with(nolock) on t.userId = ue.userId and ue.is_active = 1
		left outer join v_department vd with(nolock) on ue.departmentCode = vd.Code
		left outer join v_position vp with(nolock) on ue.positionCode = vp.Code
		inner join v_user_working w with(nolock) on t.userId = w.userId		/* << เพิ่ม : ตัดคนที่ออกแล้ว */
		where t.is_active = 1
		and w.is_working = 1												/* << เพิ่ม */
		and (
			t.username like '%' + @firstname_th + '%'
			or up.firstname_en like '%' + @firstname_th + '%'
			or up.firstname_th like '%' + @firstname_th + '%'
			or up.lastname_en like '%' + @firstname_th + '%'
			or up.lastname_th like '%' + @firstname_th + '%'
		)
		and ( ue.departmentCode = @departmentCode or vd.Desc_TH like '%' + @departmentCode + '%' or vd.Desc_EN like '%' + @departmentCode + '%' or isnull(@departmentCode,'') = '' )
		and ( ue.positionCode = @positionCode or vp.Desc_TH like '%' + @positionCode + '%' or vp.Desc_EN like '%' + @positionCode + '%' or isnull(@positionCode,'') = '' )
	) as r
	group by r.employeeType

	update t set total = s.total, alert_total = s.alert_total
	from @summary t
	inner join #sum s on t.status = s.status

	select * from @summary

end
GO


/* ============================================================================
   ตรวจผลหลังรัน
   ============================================================================ */
-- 1. proc ทั้งสองอ้างถึง v_user_working แล้ว (ต้องได้ 2 แถว)
SELECT  o.name AS [procedure], o.modify_date
FROM    sys.sql_modules m
        INNER JOIN sys.objects o ON o.object_id = m.object_id
WHERE   m.definition LIKE '%v_user_working%'
  AND   o.name IN ('up_user_sel','up_user_summary');
GO

-- 2. ดูสถานะคนที่ถูกบันทึกนำออกไว้
SELECT  u.userId, u.offboardType, u.lastWorkingDate, w.is_working
FROM    UserInfo u WITH(NOLOCK)
        INNER JOIN v_user_working w WITH(NOLOCK) ON u.userId = w.userId
WHERE   ISNULL(u.offboardType,'') <> ''
ORDER BY u.offboardDate DESC;
GO

/*  ทดสอบว่าเปลี่ยนเองจริงโดยไม่ต้องรัน job
      1. บันทึกลาออกโดยใส่วันสุดท้ายเป็นอีก 30 วัน -> ยังเห็นในหน้ารายชื่อพนักงาน
      2. UPDATE UserInfo SET lastWorkingDate = DATEADD(DAY,-1,GETDATE()) WHERE userId = '<id>'
      3. รีเฟรชหน้ารายชื่อ -> ต้องหายไปทันที โดยไม่ต้องรันอะไรเพิ่ม            */
