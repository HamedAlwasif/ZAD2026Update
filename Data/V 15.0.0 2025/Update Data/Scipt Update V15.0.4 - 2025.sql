USE [ZAD];
GO

/********************************************************************************************
 *                          UPDATE SCRIPT - SAFE & OPTIMIZED VERSION
 *  هذا السكربت خاص بالتحديثات: إضافة أعمدة - تعديل جداول - إنشاء جداول جديدة - حذف جداول قديمة
 *  تمت كتابته بحيث يمكن تشغيله عدة مرات بدون التسبب في أخطاء أو تعارض مع البيانات
 ********************************************************************************************/
 --تعديلات هامة 
 ALTER TABLE BillingData
ALTER COLUMN Move NVARCHAR(150);

ALTER TABLE BillingData1
ALTER COLUMN Move NVARCHAR(150);


ALTER TABLE [dbo].[BoxMove]
ALTER COLUMN Note NVARCHAR(150);
/*==========================================================================================
    1- تعديل جدول SystemProgram
==========================================================================================*/



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



-- إضافة العمود PricesAll إن لم يكن موجود
IF COL_LENGTH('dbo.SystemProgram', 'PricesAll') IS NULL
BEGIN
    ALTER TABLE [dbo].[SystemProgram]
    ADD [PricesAll] INT NOT NULL 
        CONSTRAINT DF_SystemProgram_PricesAll DEFAULT(1);
END
GO

-- إضافة العمود OpenFormOther
IF COL_LENGTH('dbo.SystemProgram', 'OpenFormOther') IS NULL
BEGIN
    ALTER TABLE [dbo].[SystemProgram] ADD [OpenFormOther] INT NULL;
END
GO

-- إضافة العمود BarcodeSalesType
IF COL_LENGTH('dbo.SystemProgram', 'BarcodeSalesType') IS NULL
BEGIN
    ALTER TABLE [dbo].[SystemProgram] ADD [BarcodeSalesType] INT NULL;
END
GO

-- إضافة العمود DiscountBill
IF COL_LENGTH('dbo.SystemProgram', 'DiscountBill') IS NULL
BEGIN
    ALTER TABLE [dbo].[SystemProgram] ADD [DiscountBill] FLOAT NULL;
END
GO

-- إضافة الأعمدة (BarcodeSales, CollectionProduct, HideBalance)
IF COL_LENGTH('dbo.SystemProgram', 'BarcodeSales') IS NULL
BEGIN
    ALTER TABLE [dbo].[SystemProgram]
    ADD 
        [BarcodeSales] INT NULL,
        [CollectionProduct] INT NULL,
        [HideBalance] INT NULL;
END
GO

-- إضافة الأعمدة (TypePrinter, BarcodeSize)
IF COL_LENGTH('dbo.SystemProgram', 'TypePrinter') IS NULL
BEGIN
    ALTER TABLE [dbo].[SystemProgram]
    ADD 
        [TypePrinter] NVARCHAR(200) NULL,
        [BarcodeSize] NVARCHAR(30) NULL;
END
GO


/*==========================================================================================
    2- تعديل جدول PriceUpdateDate
==========================================================================================*/

IF COL_LENGTH('dbo.PriceUpdateDate', 'PriceGomlaAlgomla') IS NULL
BEGIN
    ALTER TABLE [dbo].[PriceUpdateDate]
    ADD 
        [PriceGomlaAlgomla] FLOAT NULL,
        [PriceNesfAlgomla] FLOAT NULL;
END
GO


/*==========================================================================================
    3- تعديل جدول Category
==========================================================================================*/

IF COL_LENGTH('dbo.Category', 'PriceGomlaAlgomla') IS NULL
BEGIN
    ALTER TABLE [dbo].[Category]
    ADD 
        [PriceGomlaAlgomla] FLOAT NULL,
        [PriceNesfAlgomla] FLOAT NULL;
    
    UPDATE [dbo].[Category]
    SET [PriceGomlaAlgomla] = 0, [PriceNesfAlgomla] = 0;
END
GO

-- إضافة العمود Barcode_Factory
IF COL_LENGTH('dbo.Category', 'Barcode_Factory') IS NULL
BEGIN
    ALTER TABLE [dbo].[Category]
    ADD [Barcode_Factory] NVARCHAR(150) NULL;
END
GO


/*==========================================================================================
    4- تعديل جدول CategoryPrice
==========================================================================================*/

IF COL_LENGTH('dbo.CategoryPrice', 'PriceGomlaAlgomla') IS NULL
BEGIN
    ALTER TABLE [dbo].[CategoryPrice]
    ADD 
        [PriceGomlaAlgomla] FLOAT NULL,
        [PriceNesfAlgomla] FLOAT NULL;
    
    UPDATE [dbo].[CategoryPrice]
    SET [PriceGomlaAlgomla] = 0, [PriceNesfAlgomla] = 0;
END
GO


/*==========================================================================================
    5- إنشاء جدول Barcode_Seting
==========================================================================================*/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Barcode_Seting]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[Barcode_Seting] (
        [ID] BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
        [BarcodeStart] BIGINT NULL,
        [BarcodePrinter] NVARCHAR(150) NULL,
        [BarcodeSize] NVARCHAR(50) NULL,
        [BarcodeTypeFont] NVARCHAR(150) NULL,
        [BarcodeFontSize] FLOAT NULL,
        [ProductSize] FLOAT NULL,
        [MarginsCompaneyX] FLOAT NULL,
        [MarginsCompaneyY] FLOAT NULL,
        [MarginsBarcodeX] FLOAT NULL,
        [MarginsBarcodeY] FLOAT NULL,
        [MarginsCategorysX] FLOAT NULL,
        [MarginsCategorysY] FLOAT NULL,
        [MarginsCategoryIDX] FLOAT NULL,
        [MarginsCategoryIDY] FLOAT NULL,
        [MarginsPriceX] FLOAT NULL,
        [MarginsPriceY] FLOAT NULL
		[BarcodeSeparator] FLOAT NULL
    );

    INSERT INTO [dbo].[Barcode_Seting] (
        [BarcodeStart], [BarcodePrinter], [BarcodeSize], [BarcodeTypeFont], [BarcodeFontSize],
        [ProductSize], [MarginsCompaneyX], [MarginsCompaneyY], [MarginsBarcodeX], [MarginsBarcodeY],
        [MarginsCategorysX], [MarginsCategorysY], [MarginsCategoryIDX], [MarginsCategoryIDY],
        [MarginsPriceX], [MarginsPriceY],[BarcodeSeparator]
    ) 
    VALUES (100000, NULL, NULL, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,50);
END
GO


/*==========================================================================================
    6- تعديل جدول OsolSabta
==========================================================================================*/

IF COL_LENGTH('dbo.OsolSabta', 'Movement') IS NULL
BEGIN
    ALTER TABLE [dbo].[OsolSabta] ADD [Movement] NVARCHAR(150) NULL;
END
GO

-- حذف العمود NumBill لو موجود
IF COL_LENGTH('dbo.OsolSabta', 'NumBill') IS NOT NULL
BEGIN
    ALTER TABLE [dbo].[OsolSabta] DROP COLUMN [NumBill];
END
GO


/*==========================================================================================
    7- إنشاء جدول CategoryIncomplete
==========================================================================================*/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoryIncomplete]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[CategoryIncomplete] (
        [ID] BIGINT IDENTITY(1,1) NOT NULL,
        [Barcode] NVARCHAR(10) NOT NULL PRIMARY KEY CLUSTERED,
        [Category] NVARCHAR(150) NULL,
        [Total] FLOAT NULL,
        [Faction] NVARCHAR(50) NULL,
        [Price] FLOAT NULL,
        [Value] FLOAT NULL,
        [Emwared] NVARCHAR(150) NULL
    );
END
GO


/*==========================================================================================
    8- تعديل جدول CategoryFaction
==========================================================================================*/

-- حذف الجدول القديم لو موجود
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoryFaction]') AND type = 'U')
BEGIN
    DROP TABLE [dbo].[CategoryFaction];
END
GO

-- إنشاء الجدول من جديد
CREATE TABLE [dbo].[CategoryFaction] (
    [ID] BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
    [Faction] NVARCHAR(50) NULL,
    [Type] NVARCHAR(50) NULL
);

INSERT INTO [dbo].[CategoryFaction] ([Faction], [Type]) VALUES
(N'كرتونه', N'G'),
(N'قطعه', N'G'),
(N'دسته', N'G'),
(N'قطعه', N'K'),
(N'علبه', N'K'),
(N'كيلو', N'K');
GO


/*==========================================================================================
    9- تعديل جدول Users
==========================================================================================*/

IF COL_LENGTH('dbo.Users', 'Statistical') IS NULL
BEGIN
    ALTER TABLE [dbo].[Users] ADD [Statistical] INT NULL;
END
GO


/*==========================================================================================
    10- إنشاء جدول ProjectTotal
==========================================================================================*/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProjectTotal]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[ProjectTotal] (
        [ID] BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
        [Month] INT NULL,
        [Year] INT NULL,
        [Date] NVARCHAR(8) NOT NULL,
        [StoreValue] FLOAT NULL,
        [CustomerValue] FLOAT NULL,
        [BoxValue] FLOAT NULL,
        [Profits] FLOAT NULL,
        [DailyExpenses] FLOAT NULL,
        [AdvExpenses] FLOAT NULL,
        [SeianaExpenses] FLOAT NULL,
        [RentExpenses] FLOAT NULL,
        [ElectricityExpenses] FLOAT NULL,
        [WaterExpenses] FLOAT NULL,
        [PhoneExpenses] FLOAT NULL,
        [InternetExpenses] FLOAT NULL,
        [CarExpenses] FLOAT NULL,
        [Salaries] FLOAT NULL,
        [WithdrawProfits] FLOAT NULL,
        [TotalExpenses] FLOAT NULL,
        [PurchasingExpenses] FLOAT NULL,
        [AddMoneyBox] FLOAT NULL,
        [DiscMoneyBox] FLOAT NULL,
        [Sales] FLOAT NULL,
        [DiscSales] FLOAT NULL,
        [Purchases] FLOAT NULL,
        [DiscPurchases] FLOAT NULL,
        [PurchaseReturns] FLOAT NULL,
        [SalesReturns] FLOAT NULL,
        [Taweredat] FLOAT NULL,
        [Tahselat] FLOAT NULL
    );
END
GO


/*==========================================================================================
    11- إنشاء جدول PriceUpdateDate (لو غير موجود)
==========================================================================================*/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PriceUpdateDate]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[PriceUpdateDate] (
        [ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
        [Date] DATE NULL,
        [Move] NVARCHAR(50) NULL,
        [Ratio] FLOAT NULL,
        [DecimalNumber] INT NULL,
        [Shera] FLOAT NULL,
        [Gomla] FLOAT NULL,
        [Kataee] FLOAT NULL
    );
END
GO


/*==========================================================================================
    12- إنشاء جدول CategorySN
==========================================================================================*/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategorySN]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[CategorySN] (
        [ID] BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
        [CategorySN] NVARCHAR(100) NULL,
        [CategoryBarcode] NVARCHAR(10) NULL,
        [CategoryName] NVARCHAR(150) NULL
    );
END
GO


/*==========================================================================================
    13- تعديل جداول Billing + Billing1
==========================================================================================*/

IF COL_LENGTH('dbo.Billing', 'CategorySN') IS NULL
BEGIN
    ALTER TABLE [dbo].[Billing] ADD [CategorySN] NVARCHAR(100) NULL;
END
GO

IF COL_LENGTH('dbo.Billing1', 'CategorySN') IS NULL
BEGIN
    ALTER TABLE [dbo].[Billing1] ADD [CategorySN] NVARCHAR(100) NULL;
END
GO

/*==========================================================================================
    14- Occasions جدول مناسبات العام 
==========================================================================================*/
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



/********************************************************************************************
 * انتهى التحديث
 ********************************************************************************************/
