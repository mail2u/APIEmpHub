/* ============================================================================
   Add certificate number for training/certificate records.

   Field name used by API and UI: certificateNo

   Run the DB change before deploying APIEmpHub, because the API now sends
   @certificateNo to up_service_training_save.
   ============================================================================ */

/* STEP 0: Find the real training table.
   The stored procedure definitions are not versioned in this repo, so confirm
   the table name from the live database first. */
SELECT  s.name AS [schema_name]
      , t.name AS [table_name]
FROM    sys.tables t
        INNER JOIN sys.schemas s ON s.schema_id = t.schema_id
WHERE   EXISTS (SELECT 1 FROM sys.columns c WHERE c.object_id = t.object_id AND c.name = 'trainingId')
  AND   EXISTS (SELECT 1 FROM sys.columns c WHERE c.object_id = t.object_id AND c.name = 'license')
  AND   EXISTS (SELECT 1 FROM sys.columns c WHERE c.object_id = t.object_id AND c.name = 'organization')
ORDER BY s.name, t.name;
GO

/* STEP 1: Add the column.
   Replace {{TrainingTable}} with the table found in STEP 0. */
IF NOT EXISTS (
        SELECT 1
        FROM sys.columns
        WHERE object_id = OBJECT_ID('dbo.{{TrainingTable}}')
          AND name = 'certificateNo'
    )
BEGIN
    ALTER TABLE dbo.{{TrainingTable}}
        ADD certificateNo NVARCHAR(100) NULL;
END
GO

/* STEP 2: Update stored procedures.

   1) up_service_training_save
      Add parameter:
          , @certificateNo NVARCHAR(100) = NULL

      Add to INSERT column/value:
          , certificateNo
          , @certificateNo

      Add to UPDATE:
          , certificateNo = @certificateNo

   2) up_service_training_sel
      Add to SELECT:
          , certificateNo

   3) up_user_training_sel
      Add to SELECT:
          , certificateNo

   Keep @certificateNo defaulted to NULL so older callers still work.
*/

/* STEP 3: Verify after procedure updates. */
SELECT  t.name AS [table_name]
      , c.name AS [column_name]
      , ty.name AS [type_name]
      , c.max_length
FROM    sys.columns c
        INNER JOIN sys.tables t ON t.object_id = c.object_id
        INNER JOIN sys.types ty ON ty.user_type_id = c.user_type_id
WHERE   c.name = 'certificateNo';
GO

SELECT  o.name AS [procedure_name]
FROM    sys.sql_modules m
        INNER JOIN sys.objects o ON o.object_id = m.object_id
WHERE   o.name IN ('up_service_training_save', 'up_service_training_sel', 'up_user_training_sel')
  AND   m.definition LIKE '%certificateNo%'
ORDER BY o.name;
GO
