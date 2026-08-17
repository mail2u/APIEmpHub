/* ============================================================================
   Stored procedure สำหรับหน้า Service/OnBehalf  (พร้อมรัน)

   ต้องรัน 2 ไฟล์นี้ก่อน "ตามลำดับ"
     1. 2026-08-11_add_service_draft_onbehalf.sql   (up_service_ins รับ @status)
     2. 2026-08-12_add_service_createmode.sql       (คอลัมน์ createMode / batchId)

   *** ไฟล์นี้อ้างคอลัมน์ createMode ถ้ายังไม่รันข้อ 2 จะสร้าง proc ไม่ผ่าน ***

   สร้าง 2 ตัว
     up_service_onbehalf_sel        รายการใบงานที่ฉันสร้างแทนคนอื่น
     up_service_onbehalf_summary    ตัวเลขนับแยกตามสถานะ (ใช้กับ badge บนแท็บ)

   นิยาม "ใบที่สร้างแทนผู้ใช้" คือ
       createBy = ฉัน   และ   userId <> createBy
   ต่างจาก Approve/Work/Inquire ที่กรองจาก "ใบที่ฉันต้องทำ"
   ============================================================================ */

USE [EmpHub]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/* ============================================================================
   1) up_service_onbehalf_sel
   ============================================================================ */
IF OBJECT_ID('dbo.up_service_onbehalf_sel', 'P') IS NOT NULL
    DROP PROCEDURE dbo.up_service_onbehalf_sel
GO

CREATE procedure [dbo].[up_service_onbehalf_sel]
(
@userBy nvarchar(50)
, @status nvarchar(50) = ''
, @serviceNo nvarchar(50) = ''
, @userName nvarchar(100) = ''
, @page int = 1
, @row int = 10
, @sortBy nvarchar(50) = ''
, @total int output
)
as
begin

    set @status    = isnull(@status, '')
    set @serviceNo = isnull(@serviceNo, '')
    set @userName  = isnull(@userName, '')

    select t.id
    , isnull(t.serviceNo,'') as serviceNo
    , isnull(t.categoryCode,'') as categoryCode
    , isnull(t.categoryDesc,'') as categoryDesc
    , isnull(t.subCategoryCode,'') as subCategoryCode
    , isnull(t.subCategoryDesc,'') as subCategoryDesc
    , isnull(t.title,'') as title
    , t.status
    , case when t.status = 'Draft'    then N'รอกรอกข้อมูล'
           when t.status = 'Request'  then N'ส่งแล้ว'
           when t.status = 'Cancel'   then N'ยกเลิก'
           when t.status = 'Reject'   then N'ไม่อนุมัติ'
           when t.status = 'Complete' then N'เสร็จสิ้น'
           when t.status like 'Approve%' then N'รออนุมัติ'
           when t.status = 'Work'     then N'อยู่ระหว่างดำเนินการ'
           else t.status end as statusDesc
    , t.userId
    , isnull(up.firstname_th,'') + ' ' + isnull(up.lastname_th,'') as userName
    , isnull(ue.employeeCode,'') as employeeCode
    , isnull(uvd.Desc_TH,'') as userDepartment
    , isnull(uvs.Desc_TH,'') as userSection
    , convert(nvarchar, t.createDate, 103) + ' ' + convert(nvarchar, t.createDate, 108) as createDate
    , t.createDate as createDateSort
    into #data
    from ServiceInfo t with(nolock)
    left outer join UserPersonalInfo up with(nolock) on t.userId = up.userId and up.is_active = 1
    left outer join UserEmployeeInfo ue with(nolock) on t.userId = ue.userId and ue.is_active = 1
    left outer join UserInfo u with(nolock) on t.userId = u.userId
    left outer join v_department uvd with(nolock) on ue.departmentCode = uvd.Code
    left outer join v_section uvs with(nolock) on u.section = uvs.Code
    where t.is_active = 1
    and t.createBy = @userBy
    /* ต้องกรองด้วย createMode ไม่ใช่ userId <> createBy
       เพราะใบที่ HR แก้ไขข้อมูลพนักงานผ่านฟอร์มก็มี userId <> createBy เหมือนกัน
       จะติดมาด้วยทั้งหมด  ดู 2026-08-12_add_service_createmode.sql */
    and t.createMode = 'OnBehalfDraft'

    /* Condition */

    if @status != ''
    begin

        if @status = 'Request'
        begin
            /* แท็บ "ส่งแล้ว" หมายถึงพ้นสถานะ Draft แล้ว ไม่ใช่สถานะ Request เป๊ะ ๆ
               เพราะพอพนักงานกดส่ง ใบจะไหลไป Approve1..6 / Work / Complete ต่อทันที */
            delete t
            from #data t
            where t.status in ('Draft','Cancel')
        end
        else
        begin
            delete t
            from #data t
            where t.status != @status
        end

    end

    if @serviceNo != ''
    begin

        delete t
        from #data t
        where t.serviceNo not like '%' + @serviceNo + '%'

    end

    if @userName != ''
    begin

        delete t
        from #data t
        where t.userName not like '%' + @userName + '%'
        and t.employeeCode not like '%' + @userName + '%'

    end

    /* Paging */

    set @total = (select count(*) from #data)

    declare @start int = ((@page - 1) * @row) + 1
    declare @end int = @page * @row

    select 0 as rn, * into #sort from #data t
    delete t from #sort t

    if @sortBy = 'serviceNo'
    begin
        insert into #sort
        select row_number() over(order by t.serviceNo) as rn, * from #data t
    end
    else if @sortBy = '-serviceNo'
    begin
        insert into #sort
        select row_number() over(order by t.serviceNo desc) as rn, * from #data t
    end
    else if @sortBy = 'userName'
    begin
        insert into #sort
        select row_number() over(order by t.userName) as rn, * from #data t
    end
    else if @sortBy = '-userName'
    begin
        insert into #sort
        select row_number() over(order by t.userName desc) as rn, * from #data t
    end
    else if @sortBy = 'createDate'
    begin
        insert into #sort
        select row_number() over(order by t.createDateSort) as rn, * from #data t
    end
    else
    begin
        insert into #sort
        select row_number() over(order by t.createDateSort desc) as rn, * from #data t
    end

    select *
    from #sort t
    where t.rn between @start and @end
    order by t.rn

    drop table #sort
    drop table #data

end
GO


/* ============================================================================
   2) up_service_onbehalf_summary
   ============================================================================ */
IF OBJECT_ID('dbo.up_service_onbehalf_summary', 'P') IS NOT NULL
    DROP PROCEDURE dbo.up_service_onbehalf_summary
GO

CREATE procedure [dbo].[up_service_onbehalf_summary]
(
@userBy nvarchar(50)
, @serviceNo nvarchar(50) = ''
, @userName nvarchar(100) = ''
)
as
begin

    set @serviceNo = isnull(@serviceNo, '')
    set @userName  = isnull(@userName, '')

    /* คืนครบ 3 แถวเสมอ แม้ยอดเป็น 0
       เพราะหน้าจอใช้ result.find(x => x.status == '...') ถ้าไม่มีแถวจะไม่รีเซ็ตตัวเลข */
    declare @summary table (status nvarchar(50), total int, alert_total int)

    insert into @summary
    select 'Draft' as status, 0 as total, 0 as alert_total
    union all select 'Request', 0, 0
    union all select 'Cancel', 0, 0

    select case when t.status = 'Draft' then 'Draft'
                when t.status = 'Cancel' then 'Cancel'
                else 'Request' end as status          /* ที่เหลือนับรวมเป็น "ส่งแล้ว" */
    , count(*) as total
    , 0 as alert_total
    into #sum
    from ServiceInfo t with(nolock)
    left outer join UserPersonalInfo up with(nolock) on t.userId = up.userId and up.is_active = 1
    left outer join UserEmployeeInfo ue with(nolock) on t.userId = ue.userId and ue.is_active = 1
    where t.is_active = 1
    and t.createBy = @userBy
    and t.createMode = 'OnBehalfDraft'      /* ต้องตรงกับตัวกรองใน up_service_onbehalf_sel */
    and ( @serviceNo = '' or t.serviceNo like '%' + @serviceNo + '%' )
    and ( @userName = ''
          or isnull(up.firstname_th,'') + ' ' + isnull(up.lastname_th,'') like '%' + @userName + '%'
          or isnull(ue.employeeCode,'') like '%' + @userName + '%' )
    group by case when t.status = 'Draft' then 'Draft'
                  when t.status = 'Cancel' then 'Cancel'
                  else 'Request' end

    update t set total = s.total, alert_total = s.alert_total
    from @summary t
    inner join #sum s on t.status = s.status

    select * from @summary

    drop table #sum

end
GO


/* ============================================================================
   ตรวจผลหลังรัน  (แทน <userId ของ HR> ด้วยค่าจริง)
   ============================================================================ */
-- DECLARE @t INT
-- EXEC up_service_onbehalf_sel @userBy = N'<userId ของ HR>', @status = '',
--      @serviceNo = '', @userName = '', @page = 1, @row = 10, @sortBy = '', @total = @t OUTPUT
-- SELECT @t AS total
-- EXEC up_service_onbehalf_summary @userBy = N'<userId ของ HR>', @serviceNo = '', @userName = ''
GO
