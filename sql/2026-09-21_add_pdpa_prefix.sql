/*
    2026-09-21  เพิ่มคำนำหน้า (prefix: นาย/นาง/นางสาว) ให้แบบฟอร์มหนังสือให้ความยินยอม PDPA พนักงาน
    - เพิ่มคอลัมน์ prefix ใน FormPdpaEmployee
    - แก้ SP insert (up_form_pdpa_employee_ins) ให้รับ/บันทึก @prefix
    - แก้ SP detail (up_form_pdpa_employee_detail) ให้ส่งค่า prefix กลับ
*/

-- 1) เพิ่มคอลัมน์ prefix
IF NOT EXISTS (
    SELECT 1 FROM sys.columns
    WHERE object_id = OBJECT_ID('dbo.FormPdpaEmployee') AND name = 'prefix'
)
BEGIN
    ALTER TABLE dbo.FormPdpaEmployee ADD prefix nvarchar(20) NULL
END
GO

-- 2) SP insert
ALTER procedure [dbo].[up_form_pdpa_employee_ins]
(
@refId nvarchar(50)
, @prefix nvarchar(20)
, @firstname nvarchar(50)
, @lastname nvarchar(50)
, @idcard nvarchar(50)
, @answer1 nvarchar(50)
, @answer2 nvarchar(50)
, @answer3 nvarchar(50)
, @create_by nvarchar(50)
)
as
begin

	update t set is_active = 0 from FormPdpaEmployee t where t.is_active = 1 and t.refId = @refId

	insert into FormPdpaEmployee(refId, prefix, firstname, lastname, idcard, answer1, answer2, answer3, is_active, create_by, create_date)
	select @refId
	, @prefix
	, @firstname
	, @lastname
	, @idcard
	, @answer1
	, @answer2
	, @answer3
	, 1 as is_active
	, @create_by
	, getdate() as create_date

end
GO

-- 3) SP detail
ALTER procedure [dbo].[up_form_pdpa_employee_detail]
(
@refId nvarchar(50)
)
as
begin

	select refId
	, prefix
	, firstname
	, lastname
	, idcard
	, answer1
	, answer2
	, answer3
	, cast(null as nvarchar(max)) as create_by
	, cast(null as nvarchar(50)) as create_date
	into #data
	from FormPdpaEmployee t with(nolock)
	where t.is_active = 1
	and t.refId = @refId

	/* signature */

	update t set create_by = sg.base64, t.create_date = convert(nvarchar,s.createDate,103)
	from #data t
	inner join ServiceInfo s with(nolock) on t.refId = s.id and s.is_active = 1
	inner join SignatureInfo sg with(nolock) on s.requestBy = sg.refId

	select * from #data

	drop table #data

end
GO
