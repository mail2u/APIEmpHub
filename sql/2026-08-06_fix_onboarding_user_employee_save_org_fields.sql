/* ============================================================================
   MANUAL RUN ONLY
   Onboarding employee save - organization field verification

   This file is prepared for DBA/developer manual execution only.
   Do not execute this script automatically from the application or deployment
   pipeline without explicit review and approval.

   Context
   - The Onboarding employee step now sends:
       functionCode    = Business Unit / Function
       divisionCode    = Group / Division
       departmentCode  = Department
       sectionCode     = Section
   - APIEmpHub now filters parameters before calling up_user_employee_save, so an
     older stored procedure will no longer fail with:
       Procedure or function has too many arguments specified
   - To persist functionCode/organization fields, the database objects must still
     expose and save the same fields.

   Run the verification sections first, then update the stored procedure/table
   based on the actual schema in the target database.
   ============================================================================ */

/* 1) Verify stored procedure parameters. */
SELECT  o.name AS procedureName,
        p.parameter_id,
        p.name AS parameterName,
        TYPE_NAME(p.user_type_id) AS parameterType,
        p.max_length
FROM    sys.parameters p
        INNER JOIN sys.objects o ON o.object_id = p.object_id
WHERE   o.name = 'up_user_employee_save'
ORDER BY p.parameter_id;
GO

/* 2) Verify which tables already have the organization columns. */
SELECT  s.name AS schemaName,
        t.name AS tableName,
        SUM(CASE WHEN c.name = 'functionCode' THEN 1 ELSE 0 END) AS hasFunctionCode,
        SUM(CASE WHEN c.name = 'divisionCode' THEN 1 ELSE 0 END) AS hasDivisionCode,
        SUM(CASE WHEN c.name = 'departmentCode' THEN 1 ELSE 0 END) AS hasDepartmentCode,
        SUM(CASE WHEN c.name = 'sectionCode' THEN 1 ELSE 0 END) AS hasSectionCode
FROM    sys.tables t
        INNER JOIN sys.schemas s ON s.schema_id = t.schema_id
        INNER JOIN sys.columns c ON c.object_id = t.object_id
WHERE   c.name IN ('functionCode', 'divisionCode', 'departmentCode', 'sectionCode')
GROUP BY s.name, t.name
ORDER BY t.name;
GO

/* 3) If the employee table does not have functionCode yet, add it.
      Replace dbo.EmployeeTable with the real table used by up_user_employee_save.
      Keep the statement commented until the table name is confirmed.

IF NOT EXISTS (
    SELECT 1
    FROM sys.columns
    WHERE object_id = OBJECT_ID('dbo.EmployeeTable')
      AND name = 'functionCode'
)
BEGIN
    ALTER TABLE dbo.EmployeeTable ADD functionCode VARCHAR(50) NULL;
END
GO
*/

/* 4) Update up_user_employee_save if any parameters are missing.
      Script the current procedure from SSMS (Right click > Modify), then add any
      missing optional parameters:

        , @functionCode VARCHAR(50) = NULL
        , @divisionCode VARCHAR(50) = NULL
        , @departmentCode VARCHAR(50) = NULL
        , @sectionCode VARCHAR(50) = NULL

      Then persist them in the INSERT/UPDATE statements, for example:

        functionCode   = @functionCode
        divisionCode   = @divisionCode
        departmentCode = @departmentCode
        sectionCode    = @sectionCode

      Use = NULL defaults so older API builds can still call the procedure.
*/

/* 5) Verify the detail procedure returns the same columns after saving. */
SELECT  o.name AS procedureName
FROM    sys.sql_modules m
        INNER JOIN sys.objects o ON o.object_id = m.object_id
WHERE   o.name IN ('up_user_employee_save', 'up_user_employee_detail')
  AND   m.definition LIKE '%functionCode%'
ORDER BY o.name;
GO
