/*
    2026-09-21  เพิ่มฟิลด์ให้แบบฟอร์ม "ขอข้อมูลพนักงาน" (FormEmployeeData)
    เพิ่ม checkbox: คำนำหน้า, ประเภทพนักงาน, สังกัดฝ่าย, สังกัดสาย, สังกัดด้าน (มี TH/EN),
                   ตำแหน่ง (เดิม is_position = ไทย, เพิ่ม is_position_en),
                   สังกัดฝ่าย (เดิม is_department = ไทย, เพิ่ม is_department_en),
                   วันที่เริ่มงาน (is_join_date), วันที่มีผลลาออก (is_resign_date)
    mapping ระดับองค์กร: ด้าน = function, สาย = division, ฝ่าย = department
*/

-- 1) เพิ่มคอลัมน์ (idempotent)
IF NOT EXISTS (
    SELECT 1 FROM sys.columns
    WHERE object_id = OBJECT_ID('dbo.FormEmployeeData') AND name = 'is_prefix_th'
)
BEGIN
    ALTER TABLE dbo.FormEmployeeData ADD
        is_prefix_th int NULL,
        is_prefix_en int NULL,
        is_position_en int NULL,
        is_employee_type_th int NULL,
        is_employee_type_en int NULL,
        is_department_en int NULL,
        is_division_th int NULL,
        is_division_en int NULL,
        is_function_th int NULL,
        is_function_en int NULL,
        is_join_date int NULL,
        is_resign_date int NULL
END
GO

-- 2) SP insert
ALTER procedure [dbo].[up_form_employee_data_ins]
(
@refId nvarchar(50)
, @is_username int
, @is_fullname_th int
, @is_fullname_en int
, @is_position int
, @is_department int
, @is_email int
, @description nvarchar(400)
, @create_by nvarchar(50)
, @is_prefix_th int = 0
, @is_prefix_en int = 0
, @is_position_en int = 0
, @is_employee_type_th int = 0
, @is_employee_type_en int = 0
, @is_department_en int = 0
, @is_division_th int = 0
, @is_division_en int = 0
, @is_function_th int = 0
, @is_function_en int = 0
, @is_join_date int = 0
, @is_resign_date int = 0
)
as
begin

	update t set is_active = 0
	from FormEmployeeData t with(nolock)
	where t.is_active = 1
	and t.refId = @refId

	insert into FormEmployeeData( refId, is_username, is_fullname_th, is_fullname_en, is_position, is_department, is_email, description, is_active, create_by, create_date
	, is_prefix_th, is_prefix_en, is_position_en, is_employee_type_th, is_employee_type_en, is_department_en, is_division_th, is_division_en, is_function_th, is_function_en, is_join_date, is_resign_date )
	select @refId
	, @is_username
	, @is_fullname_th
	, @is_fullname_en
	, @is_position
	, @is_department
	, @is_email
	, @description
	, 1 is_active
	, @create_by
	, getdate() create_date
	, @is_prefix_th
	, @is_prefix_en
	, @is_position_en
	, @is_employee_type_th
	, @is_employee_type_en
	, @is_department_en
	, @is_division_th
	, @is_division_en
	, @is_function_th
	, @is_function_en
	, @is_join_date
	, @is_resign_date

end
GO

-- 3) SP detail
ALTER procedure [dbo].[up_form_employee_data_detail]
(
@refId nvarchar(50)
)
as
begin

	select refId, is_username, is_fullname_th, is_fullname_en, is_position, is_department, is_email, description
	, isnull(is_prefix_th, 0) as is_prefix_th
	, isnull(is_prefix_en, 0) as is_prefix_en
	, isnull(is_position_en, 0) as is_position_en
	, isnull(is_employee_type_th, 0) as is_employee_type_th
	, isnull(is_employee_type_en, 0) as is_employee_type_en
	, isnull(is_department_en, 0) as is_department_en
	, isnull(is_division_th, 0) as is_division_th
	, isnull(is_division_en, 0) as is_division_en
	, isnull(is_function_th, 0) as is_function_th
	, isnull(is_function_en, 0) as is_function_en
	, isnull(is_join_date, 0) as is_join_date
	, isnull(is_resign_date, 0) as is_resign_date
	from FormEmployeeData t
	where t.is_active = 1
	and t.refId = @refId

end
GO
