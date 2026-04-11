USE [ZAD]
GO

/********************************************************************************************
 *                                UPDATE V 13.0.0 - إضافة أسعار جملة ونصف جملة
 ********************************************************************************************/
 -- تعديل جدول SystemProgram
/*----------------------------------*/
/* تعديل جدول SystemProgram - إضافة العمود PricesAll مع قيمة افتراضية = 1 */
ALTER TABLE [dbo].[SystemProgram]
ADD [PricesAll] INT NOT NULL 
    CONSTRAINT DF_SystemProgram_PricesAll DEFAULT(1);
GO


-- تعديل جدول PriceUpdateDate
ALTER TABLE [dbo].[PriceUpdateDate]
ADD 
    [PriceGomlaAlgomla] FLOAT NULL,
    [PriceNesfAlgomla] FLOAT NULL;
GO
/*----------------------------------*/

-- تعديل جدول Category
ALTER TABLE [dbo].[Category]
ADD 
    [PriceGomlaAlgomla] FLOAT NULL,
    [PriceNesfAlgomla] FLOAT NULL;
GO

UPDATE [dbo].[Category]
SET 
    [PriceGomlaAlgomla] = 0,
    [PriceNesfAlgomla] = 0;
GO
/*----------------------------------*/

-- تعديل جدول CategoryPrice
ALTER TABLE [dbo].[CategoryPrice]
ADD 
    [PriceGomlaAlgomla] FLOAT NULL,
    [PriceNesfAlgomla] FLOAT NULL;
GO

UPDATE [dbo].[CategoryPrice]
SET 
    [PriceGomlaAlgomla] = 0,
    [PriceNesfAlgomla] = 0;
GO
/*----------------------------------*/

-- إنشاء جدول Barcode_Seting
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
);
GO

SET IDENTITY_INSERT [dbo].[Barcode_Seting] ON
GO

INSERT INTO [dbo].[Barcode_Seting] (
    [ID], 
    [BarcodeStart], 
    [BarcodePrinter], 
    [BarcodeSize], 
    [BarcodeTypeFont], 
    [BarcodeFontSize], 
    [ProductSize], 
    [MarginsCompaneyX], 
    [MarginsCompaneyY], 
    [MarginsBarcodeX], 
    [MarginsBarcodeY], 
    [MarginsCategorysX], 
    [MarginsCategorysY], 
    [MarginsCategoryIDX], 
    [MarginsCategoryIDY], 
    [MarginsPriceX], 
    [MarginsPriceY]
) 
VALUES (
    1, 
    100000, 
    NULL,  -- لأن الحقل نصي، يا إما نص بين علامتي اقتباس أو NULL
    NULL, 
    NULL, 
    0, 
    0, 
    0, 
    0, 
    0, 
    0, 
    0, 
    0, 
    0, 
    0, 
    0, 
    0
);
GO

SET IDENTITY_INSERT [dbo].[Barcode_Seting] OFF
GO
/*----------------------------------*/

-- تعديل جدول SystemProgram
ALTER TABLE [dbo].[SystemProgram]
ADD [OpenFormOther] INT NULL;
GO


/*----------------------------------*/

-- تعديل جدول OsolSabta
ALTER TABLE [dbo].[OsolSabta]
ADD [Movement] NVARCHAR(150) NULL;
GO

ALTER TABLE [dbo].[OsolSabta]
DROP CONSTRAINT [PK_OsolSabta];
GO

ALTER TABLE [dbo].[OsolSabta]
DROP COLUMN [NumBill];
GO
/*----------------------------------*/

-- تعديل جدول Category
ALTER TABLE [dbo].[Category]
ADD [Barcode_Factory] NVARCHAR(150) NULL;
GO
/*----------------------------------*/

-- تعديل جدول SystemProgram
ALTER TABLE [dbo].[SystemProgram]
ADD [BarcodeSalesType] INT NULL;
GO
/*----------------------------------*/

-- إنشاء جدول CategoryIncomplete
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
GO
/*----------------------------------*/

-- تعديل جدول SystemProgram
ALTER TABLE [dbo].[SystemProgram]
ADD [DiscountBill] FLOAT NULL;
GO
/*----------------------------------*/

-- حذف جدول CategoryFaction القديم
DROP TABLE [dbo].[CategoryFaction];
GO
/*----------------------------------*/

-- إنشاء جدول CategoryFaction
CREATE TABLE [dbo].[CategoryFaction] (
    [ID] BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
    [Faction] NVARCHAR(50) NULL,
    [Type] NVARCHAR(50) NULL
);
GO

SET IDENTITY_INSERT [dbo].[CategoryFaction] ON
GO

INSERT INTO [dbo].[CategoryFaction] ([ID], [Faction], [Type]) VALUES
(1, N'كرتونه', N'G'),
(2, N'قطعه', N'G'),
(3, N'دسته', N'G'),
(4, N'قطعه', N'K'),
(5, N'علبه', N'K'),
(6, N'كيلو', N'K');
GO

SET IDENTITY_INSERT [dbo].[CategoryFaction] OFF
GO
/*----------------------------------*/

-- تعديل جدول SystemProgram
ALTER TABLE [dbo].[SystemProgram]
ADD 
    [BarcodeSales] INT NULL,
    [CollectionProduct] INT NULL,
    [HideBalance] INT NULL;
GO
/*----------------------------------*/

ALTER TABLE [dbo].[SystemProgram]
ADD 
    [TypePrinter] NVARCHAR(200) NULL,
    [BarcodeSize] NVARCHAR(30) NULL;
GO
/*----------------------------------*/

-- تعديل جدول Users
ALTER TABLE [dbo].[Users]
ADD [Statistical] INT NULL;
GO
/*----------------------------------*/

-- إنشاء جدول ProjectTotal
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
GO
/*----------------------------------*/

-- إنشاء جدول PriceUpdateDate
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
GO
/*----------------------------------*/

-- إنشاء جدول CategorySN
CREATE TABLE [dbo].[CategorySN] (
    [ID] BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED,
    [CategorySN] NVARCHAR(100) NULL,
    [CategoryBarcode] NVARCHAR(10) NULL,
    [CategoryName] NVARCHAR(150) NULL
);
GO
/*----------------------------------*/

-- تعديل جدول Billing
ALTER TABLE [dbo].[Billing]
ADD [CategorySN] NVARCHAR(100) NULL;
GO
/*----------------------------------*/

-- تعديل جدول Billing1
ALTER TABLE [dbo].[Billing1]
ADD [CategorySN] NVARCHAR(100) NULL;
GO
/*----------------------------------*/
