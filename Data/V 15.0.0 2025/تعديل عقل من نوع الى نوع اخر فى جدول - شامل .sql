USE [ZEZO];
GO


DECLARE @TableName SYSNAME = N'dbo.BillingData';   -- اسم الجدول
DECLARE @ColumnName SYSNAME = N'ReasonAdd';             -- اسم العمود
DECLARE @NewType NVARCHAR(100) = N'NVARCHAR(250) NULL'; -- النوع الجديد المطلوب

IF EXISTS (
    SELECT 1 
    FROM sys.columns 
    WHERE Name = @ColumnName
      AND Object_ID = Object_ID(@TableName)
      AND system_type_id IN (35, 99, 34) 
      -- 35 = text, 99 = ntext, 34 = image
)
BEGIN
    DECLARE @SQL NVARCHAR(MAX);
    SET @SQL = N'ALTER TABLE ' + @TableName +
               N' ALTER COLUMN [' + @ColumnName + N'] ' + @NewType + N';';
    EXEC sp_executesql @SQL;
END
GO

