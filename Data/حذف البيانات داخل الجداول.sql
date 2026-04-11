--معاية اسماء الجداول فقط دون تنفيذ الحذف
USE [ZAD];
GO

SELECT 
    SCHEMA_NAME(t.schema_id) AS SchemaName,
    t.name AS TableName,
    'TRUNCATE TABLE ' + QUOTENAME(SCHEMA_NAME(t.schema_id)) + '.' + QUOTENAME(t.name) + ';' AS CommandToRun
FROM sys.tables t
WHERE t.is_ms_shipped = 0
  AND t.name NOT IN
  (
    'Barcode_Seting','Category','CategoryFaction','CategoryGroup','CategoryPrice',
    'Clients','Groups','Occasions','OsolSabta','Storage','Users','SystemProgram'
  )
ORDER BY SchemaName, TableName;



-- تنفيذ حذف الباينات داخل الجداول ما عدا الجداول التى تم عمل استثناء لها

USE [ZAD];
GO

DECLARE @sql NVARCHAR(MAX) = N'';

SELECT @sql += N'TRUNCATE TABLE '
            + QUOTENAME(SCHEMA_NAME(t.schema_id)) + N'.' + QUOTENAME(t.name)
            + N';' + CHAR(13)
FROM sys.tables t
WHERE t.is_ms_shipped = 0
  AND t.name NOT IN
  (
    'Barcode_Seting','Category','CategoryFaction','CategoryGroup','CategoryPrice',
    'Clients','Groups','Occasions','OsolSabta','Storage','Users','SystemProgram'
  );

EXEC sp_executesql @sql;



--تصفير الاجماليات فى جدول الاصناف

USE [ZAD];
GO

UPDATE dbo.Category
SET 
    Quantity   = 0,
    QuantityT  = 0,
    Total      = 0,
    Value      = 0;
