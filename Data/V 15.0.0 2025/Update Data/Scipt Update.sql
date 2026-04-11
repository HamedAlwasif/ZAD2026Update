USE [ZAD]
GO

 --تعديلات هامة 
 ALTER TABLE BillingData
ALTER COLUMN Move NVARCHAR(150);

ALTER TABLE BillingData1
ALTER COLUMN Move NVARCHAR(150);



ALTER TABLE [dbo].[SystemProgram]
ADD [PriceKataeeProfitRate] DECIMAL(5,2) NULL,         -- نسبة البيع العادي
    [PriceAlgomlaProfitRate] DECIMAL(5,2) NULL,      -- نسبة الجملة
    [PriceNesfAlgomlaProfitRate] DECIMAL(5,2) NULL,  -- نسبة نصف الجملة
    [PriceGomlaAlgomlaProfitRate] DECIMAL(5,2) NULL;  -- نسبة جملة الجملة



	UPDATE [dbo].[SystemProgram]
SET PriceKataeeProfitRate = 30,       -- بيع قطاعي
    PriceAlgomlaProfitRate = 15,      -- جملة
    PriceNesfAlgomlaProfitRate = 20,  -- نصف جملة
    PriceGomlaAlgomlaProfitRate = 8;  -- جملة الجملة




CREATE TABLE Occasions (
    OccasionID INT IDENTITY(1,1) PRIMARY KEY,
    OccasionName NVARCHAR(100) NOT NULL,       -- اسم المناسبة (مثال: عيد الفطر)
    OccasionDate DATE NOT NULL,                -- تاريخ المناسبة
    ReminderDays INT NOT NULL DEFAULT 7,       -- عدد الأيام قبل المناسبة لإظهار التنبيه
    Description NVARCHAR(255) NULL,            -- وصف قصير (مثال: جهّز بضاعة العيد)
    RepeatYearly BIT NOT NULL DEFAULT 1        -- هل المناسبة تتكرر كل سنة (1 = نعم / 0 = لا)
);


INSERT INTO Occasions (OccasionName, OccasionDate, ReminderDays, Description, RepeatYearly)
VALUES 
(N'رمضان', '2025-02-28', 15, N'تحضير عروض رمضان والسلع الغذائية', 1),
(N'عيد الفطر', '2025-03-30', 7, N'تجهيز الحلويات والهدايا', 1),
(N'بداية الدراسة', '2025-09-01', 20, N'تجهيز شنط وأدوات مدرسية', 1);


IF NOT EXISTS (
    SELECT 1 
    FROM sys.columns 
    WHERE Name = N'BarcodeSeparator' 
      AND Object_ID = Object_ID(N'dbo.Barcode_Seting')
)
BEGIN
    ALTER TABLE [dbo].[Barcode_Seting]
    ADD [BarcodeSeparator] FLOAT NULL;
END
GO