USE [ZEZO];
GO


IF EXISTS (
    SELECT 1 
    FROM sys.columns 
    WHERE Name = N'Move' 
      AND Object_ID = Object_ID(N'dbo.BillingData')
      AND system_type_id = 35 -- 35 = نوع text
)
BEGIN
    ALTER TABLE [dbo].[BillingData]
    ALTER COLUMN [Move] NVARCHAR(250) NULL;
END
GO
