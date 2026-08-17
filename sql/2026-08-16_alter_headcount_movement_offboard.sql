/* ============================================================================
   รายงานคนเข้าคนออก : ให้นับตรงกับระบบลาออกใหม่  (พร้อมรัน)

   ต้องรัน 2026-08-08_add_employee_offboard.sql ก่อน

   ------------------------------------------------------------------------------
   ปัญหาของเดิม

   ตัวนับคนออกใช้
       where isnull(u.is_active, 0) = 0
       and year(isnull(u.update_date, u.create_date)) = @targetYear

   แต่ระบบลาออกใหม่ไม่ได้แตะ is_active เลย
   up_user_offboard_upd เก็บที่ offboardType / lastWorkingDate แล้วปล่อย is_active = 1
   ให้ v_user_working คำนวณสถานะสด ๆ จากวันที่แทน

   ผลคือ
     1. คนที่ลาออกผ่านระบบใหม่ ไม่ถูกนับเป็นคนออกเลย
        รายงานนี้จะโชว์ 0 ขณะที่ turnover-attrition โชว์ครบ
     2. beginningHeadcount / endingHeadcount ก็ผิดแบบเดียวกัน
        คนที่ออกไปแล้วยังถูกนับเป็นพนักงานตลอดไป
     3. update_date คือวันแก้ไขล่าสุด ไม่ใช่วันลาออก
        แก้ประวัติคนที่ออกไปแล้วเมื่อไร ตัวเลขย้ายเดือนทันที
     4. คนที่บันทึกผิด (Void) ถูกนับเป็นคนออก ทำให้ตัวเลขเกินจริง

   ------------------------------------------------------------------------------
   วิธีแก้

   ใช้ lastWorkingDate เป็นหลัก และคง logic เดิมไว้เป็น fallback
   สำหรับข้อมูลเก่าที่บันทึกก่อนมีระบบใหม่ (ไม่มี offboardType)
   ถ้าตัดของเดิมทิ้งเลย ประวัติปีก่อน ๆ จะหายไปจากรายงานทันที

   ตัด Void ออกจากทุกตัวนับ ทั้งคนเข้า คนออก และ headcount
   เพราะเป็นรายการที่บันทึกผิด ไม่ใช่พนักงานจริง

   กติกา "ยังทำงานอยู่ ณ วันที่ D" ให้ตรงกับ v_user_working
     - มี lastWorkingDate  ->  ยังอยู่ถ้า lastWorkingDate > D
     - ไม่มี               ->  ใช้ is_active / update_date แบบเดิม
   ============================================================================ */

USE [EmpHub]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[up_report_headcount_movement_sel]
(
@year int
, @page int
, @row int
, @total int output
)
as
begin

	declare @targetYear int = case when @year > 0 then @year else year(getdate()) end;

	create table #budget(month_no int, budgetHeadcount int);

	declare @manpowerTable nvarchar(300);
	select top 1 @manpowerTable = quotename(s.name) + '.' + quotename(t.name)
	from sys.tables t
	inner join sys.schemas s on t.schema_id = s.schema_id
	where exists (select 1 from sys.columns c where c.object_id = t.object_id and c.name = 'refId')
	and exists (select 1 from sys.columns c where c.object_id = t.object_id and c.name = 'num_employee')
	and exists (select 1 from sys.columns c where c.object_id = t.object_id and c.name = 'department')
	order by case when t.name like '%ManPower%' then 0 else 1 end, t.name;

	if @manpowerTable is not null
	begin
		declare @sql nvarchar(max) = N'
			insert into #budget(month_no, budgetHeadcount)
			select month(isnull(s.requestDate, s.createDate)) as month_no, sum(isnull(mp.num_employee, 0)) as budgetHeadcount
			from ' + @manpowerTable + N' mp
			inner join ServiceInfo s with(nolock) on mp.refId = s.id and s.is_active = 1
			where year(isnull(s.requestDate, s.createDate)) = @targetYear
			and s.status not in (''Cancel'', ''Reject'')
			group by month(isnull(s.requestDate, s.createDate));';

		exec sp_executesql @sql, N'@targetYear int', @targetYear;
	end

	;with m as (
		select 1 month_no, 'Jan' monthName union all
		select 2, 'Feb' union all
		select 3, 'Mar' union all
		select 4, 'Apr' union all
		select 5, 'May' union all
		select 6, 'Jun' union all
		select 7, 'Jul' union all
		select 8, 'Aug' union all
		select 9, 'Sep' union all
		select 10, 'Oct' union all
		select 11, 'Nov' union all
		select 12, 'Dec'
	)
	select
		m.month_no,
		@targetYear as reportYear,
		m.monthName,
		isnull(beginning.beginningHeadcount, 0) as beginningHeadcount,
		isnull(newHire.newHire, 0) as newHire,
		isnull(resign.resignCount, 0) as resignCount,
		isnull(ending.endingHeadcount, 0) as endingHeadcount,
		isnull(b.budgetHeadcount, 0) as budgetHeadcount,
		isnull(ending.endingHeadcount, 0) - isnull(b.budgetHeadcount, 0) as variance,

		/* เพิ่ม : คนเข้าลบคนออก บอกทิศทางว่าเดือนนั้นโตหรือหด
		   ดูจาก beginning/ending อย่างเดียวจะแยกไม่ออกว่าเข้า 10 ออก 10
		   ต่างจากไม่มีใครเข้าออกเลย ทั้งที่ความหมายต่างกันมาก */
		isnull(newHire.newHire, 0) - isnull(resign.resignCount, 0) as netChange,

		/* เพิ่ม : อัตราการลาออกรายเดือน
		   หารด้วยค่าเฉลี่ยต้นงวดกับปลายงวด ไม่ใช่ปลายงวดอย่างเดียว
		   เพราะถ้าเดือนนั้นคนออกเยอะ ปลายงวดจะเล็กจนอัตราพองเกินจริง */
		cast(case when (isnull(beginning.beginningHeadcount,0) + isnull(ending.endingHeadcount,0)) = 0
			then 0
			else (isnull(resign.resignCount,0) * 100.0)
				 / ((isnull(beginning.beginningHeadcount,0) + isnull(ending.endingHeadcount,0)) / 2.0)
			end as decimal(18,2)) as turnoverRate
	into #data
	from m
	outer apply (
		/* ยอดต้นงวด = ยังทำงานอยู่ ณ วันแรกของเดือน */
		select count(*) beginningHeadcount
		from UserInfo u with(nolock)
		inner join UserEmployeeInfo ue with(nolock) on u.userId = ue.userId and ue.is_active = 1
		where ue.join_date < datefromparts(@targetYear, m.month_no, 1)
		and isnull(u.offboardType, '') <> 'Void'
		and (
			/* ระบบใหม่ : เทียบวันทำงานวันสุดท้าย */
			(u.lastWorkingDate is not null and u.lastWorkingDate >= datefromparts(@targetYear, m.month_no, 1))
			/* ข้อมูลเก่า : ไม่มี lastWorkingDate ใช้ตรรกะเดิม */
			or (u.lastWorkingDate is null
				and (u.is_active = 1 or isnull(u.update_date, getdate()) >= datefromparts(@targetYear, m.month_no, 1)))
		)
	) beginning
	outer apply (
		/* คนเข้าใหม่ = วันเริ่มงานอยู่ในเดือนนั้น  ตัดรายการที่บันทึกผิดออก */
		select count(*) newHire
		from UserInfo u with(nolock)
		inner join UserEmployeeInfo ue with(nolock) on u.userId = ue.userId and ue.is_active = 1
		where year(ue.join_date) = @targetYear
		and month(ue.join_date) = m.month_no
		and isnull(u.offboardType, '') <> 'Void'
	) newHire
	outer apply (
		/* คนออก
		   ระบบใหม่ : นับจาก lastWorkingDate เฉพาะ Resign  ตรงกับ turnover-attrition
		   ข้อมูลเก่า : ไม่มี offboardType ใช้ is_active + update_date แบบเดิม
		                คงไว้เพื่อไม่ให้ประวัติปีก่อนหายจากรายงาน */
		select count(*) resignCount
		from UserInfo u with(nolock)
		where isnull(u.offboardType, '') <> 'Void'
		and (
			(
				u.offboardType = 'Resign'
				and u.lastWorkingDate is not null
				and year(u.lastWorkingDate) = @targetYear
				and month(u.lastWorkingDate) = m.month_no
			)
			or
			(
				isnull(u.offboardType, '') = ''
				and isnull(u.is_active, 0) = 0
				and year(isnull(u.update_date, u.create_date)) = @targetYear
				and month(isnull(u.update_date, u.create_date)) = m.month_no
			)
		)
	) resign
	outer apply (
		/* ยอดปลายงวด = ยังทำงานอยู่ ณ วันสุดท้ายของเดือน */
		select count(*) endingHeadcount
		from UserInfo u with(nolock)
		inner join UserEmployeeInfo ue with(nolock) on u.userId = ue.userId and ue.is_active = 1
		where ue.join_date <= eomonth(datefromparts(@targetYear, m.month_no, 1))
		and isnull(u.offboardType, '') <> 'Void'
		and (
			(u.lastWorkingDate is not null and u.lastWorkingDate > eomonth(datefromparts(@targetYear, m.month_no, 1)))
			or (u.lastWorkingDate is null
				and (u.is_active = 1 or isnull(u.update_date, getdate()) > eomonth(datefromparts(@targetYear, m.month_no, 1))))
		)
	) ending
	left join #budget b on m.month_no = b.month_no;

	select @total = count(*) from #data;
	declare @start int = ((@page - 1) * @row) + 1
	declare @end int = @page * @row

	select 0 as rn, * into #sort from #data t
	delete t from #sort t

	insert into #sort
	select row_number() over(order by t.month_no) as rn, * from #data t

	/* Result */

	select *
	from #sort t
	where t.rn between @start and @end
	order by t.rn

	drop table #sort
	drop table #data

end
GO


/* ============================================================================
   ตรวจผลหลังรัน
   ============================================================================ */
-- 1. ยอดคนออกทั้งปีของสองรายงานต้องตรงกัน
--    (turnover-attrition นับเฉพาะ Resign เหมือนกัน)
DECLARE @t INT
EXEC up_report_headcount_movement_sel @year = 2026, @page = 1, @row = 12, @total = @t OUTPUT
GO

SELECT  MONTH(lastWorkingDate) AS month_no, COUNT(*) AS resign_new_system
FROM    UserInfo WITH(NOLOCK)
WHERE   offboardType = 'Resign'
  AND   YEAR(lastWorkingDate) = 2026
GROUP BY MONTH(lastWorkingDate)
ORDER BY 1;
GO

-- 2. ดูว่ามีข้อมูลเก่าแบบไหนอยู่บ้าง จะได้รู้ว่า fallback ยังจำเป็นหรือไม่
SELECT  CASE WHEN ISNULL(offboardType,'') <> '' THEN 'ระบบใหม่'
             WHEN ISNULL(is_active,0) = 0       THEN 'ข้อมูลเก่า (is_active=0)'
             ELSE 'ยังทำงานอยู่' END AS data_type
      , COUNT(*) AS total
FROM    UserInfo WITH(NOLOCK)
GROUP BY CASE WHEN ISNULL(offboardType,'') <> '' THEN 'ระบบใหม่'
              WHEN ISNULL(is_active,0) = 0       THEN 'ข้อมูลเก่า (is_active=0)'
              ELSE 'ยังทำงานอยู่' END;
GO


/* ============================================================================
   ข้อควรรู้

   1. การลาออกที่บันทึกล่วงหน้า
      lastWorkingDate ที่เป็นวันในอนาคต จะไปนับในเดือนนั้นทันที
      ตัวเลขของเดือนปัจจุบันจึงยังเปลี่ยนได้ถ้ามีคนบันทึกลาออกล่วงหน้าเพิ่ม
      เป็นพฤติกรรมที่ถูกต้องสำหรับรายงานที่มองไปข้างหน้า
      แต่ถ้าต้องการนับเฉพาะที่เกิดขึ้นจริงแล้ว ให้เพิ่ม
          and u.lastWorkingDate <= getdate()

   2. ยังไม่มีตัวกรองหน่วยงาน
      proc นี้รับแค่ @year ต่างจาก turnover-attrition ที่กรอง ด้าน/สาย/ฝ่าย/ส่วน ได้แล้ว
      ถ้าต้องการให้เทียบกันได้ระดับหน่วยงาน ต้องเพิ่มพารามิเตอร์ชุดเดียวกัน
      และต้องกรอง headcount ด้วยขอบเขตเดียวกับตัวนับ ไม่งั้นตัวเลขจะเพี้ยน

   3. beginningHeadcount ของเดือนถัดไป อาจไม่เท่ากับ endingHeadcount ของเดือนก่อน
      เพราะสองตัวใช้ >= กับ > คนละแบบตามนิยามต้นงวด/ปลายงวด
      ถ้าเจอส่วนต่างให้ตรวจว่าเป็นคนที่ lastWorkingDate ตรงกับวันสิ้นเดือนพอดีหรือไม่
   ============================================================================ */
