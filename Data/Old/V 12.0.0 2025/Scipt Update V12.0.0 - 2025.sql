USE [ZAD]
GO


/****** UPDATE V 12.0.0 ******/

/****** Object:  Table [dbo].[Barcode_Seting]    Script Date: 2/23/2025 12:38:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Barcode_Seting](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[BarcodeStart] [bigint] NULL,
	[BarcodePrinter] [nvarchar](150) NULL,
	[BarcodeSize] [nvarchar](50) NULL,
	[BarcodeTypeFont] [nvarchar](150) NULL,
	[BarcodeFontSize] [float] NULL,
	[ProductSize] [float] NULL,
	[MarginsCompaneyX] [float] NULL,
	[MarginsCompaneyY] [float] NULL,
	[MarginsBarcodeX] [float] NULL,
	[MarginsBarcodeY] [float] NULL,
	[MarginsCategorysX] [float] NULL,
	[MarginsCategorysY] [float] NULL,
	[MarginsCategoryIDX] [float] NULL,
	[MarginsCategoryIDY] [float] NULL,
	[MarginsPriceX] [float] NULL,
	[MarginsPriceY] [float] NULL,
 CONSTRAINT [PK_Barcode_Seting] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Barcode_Seting] ON 

GO
INSERT [dbo].[Barcode_Seting] ([ID], [BarcodeStart], [BarcodePrinter], [BarcodeSize], [BarcodeTypeFont], [BarcodeFontSize], [ProductSize], [MarginsCompaneyX], [MarginsCompaneyY], [MarginsBarcodeX], [MarginsBarcodeY], [MarginsCategorysX], [MarginsCategorysY], [MarginsCategoryIDX], [MarginsCategoryIDY], [MarginsPriceX], [MarginsPriceY]) VALUES (1, 100000, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Barcode_Seting] OFF
GO


/***----------------***/


ALTER TABLE [dbo].[SystemProgram]
ADD OpenFormOther [int] NULL;

GO


/****** UPDATE V 11.0.0 ******/

ALTER TABLE [dbo].[OsolSabta]
ADD Movement [nvarchar](150) NULL;

GO

/****** حذف primarey key ******/
ALTER TABLE [dbo].[OsolSabta]
DROP CONSTRAINT [PK_OsolSabta];


ALTER TABLE [dbo].[OsolSabta]
DROP COLUMN [NumBill];

GO

/****** END UPDATE V 11.0.0 ******/






/****** UPDATE V 10.0.0 ******/
/****** UPDATE V 10.0.0 ******/
/****** UPDATE V 10.0.0 ******/
/****** UPDATE V 10.0.0 ******/

ALTER TABLE [dbo].[Category]
ADD Barcode_Factory [nvarchar](150) NULL;

GO

ALTER TABLE [dbo].[SystemProgram]
ADD BarcodeSalesType [int] NULL;

GO


/****** END UPDATE V 10.0.0 ******/
/****** END UPDATE V 10.0.0 ******/
/****** END UPDATE V 10.0.0 ******/
/****** =============================================================================== ******/



/***-------  CREATE TABLE CategoryIncomplete ------- ***/

CREATE TABLE [dbo].[CategoryIncomplete](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Barcode] [nvarchar](10) NOT NULL,
	[Category] [nvarchar](150) NULL,
	[Total] [float] NULL,
	[Faction] [nvarchar](50) NULL,
	[Price] [float] NULL,
	[Value] [float] NULL,
	[Emwared] [nvarchar](150) NULL,
 CONSTRAINT [PK_CategoryIncomplete] PRIMARY KEY CLUSTERED 
(
	[Barcode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/***------- END CREATE TABLE CategoryIncomplete ------- ***/


ALTER TABLE [dbo].[SystemProgram]
ADD DiscountBill float;

GO

/***------- Dlete Table CategoryFactionحذف الجدول القديم    ------- ***/
DROP TABLE [dbo].[CategoryFaction];

GO
/***------- CREATE Table CategoryFaction انشاء جدول جديد للفئات------- ***/

CREATE TABLE [dbo].[CategoryFaction](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Faction] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
 CONSTRAINT [PK_CategoryFaction] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[CategoryFaction] ON 

GO
INSERT [dbo].[CategoryFaction] ([ID], [Faction], [Type]) VALUES (1, N'كرتونه', N'G')
GO
INSERT [dbo].[CategoryFaction] ([ID], [Faction], [Type]) VALUES (2, N'قطعه', N'G')
GO
INSERT [dbo].[CategoryFaction] ([ID], [Faction], [Type]) VALUES (3, N'دسته', N'G')
GO
INSERT [dbo].[CategoryFaction] ([ID], [Faction], [Type]) VALUES (4, N'قطعه', N'K')
GO
INSERT [dbo].[CategoryFaction] ([ID], [Faction], [Type]) VALUES (5, N'علبه', N'K')
GO
INSERT [dbo].[CategoryFaction] ([ID], [Faction], [Type]) VALUES (6, N'كيلو', N'K')
GO
SET IDENTITY_INSERT [dbo].[CategoryFaction] OFF
GO

/***------- إضافة حقل جديد فى جدول------- ***/

ALTER TABLE [dbo].[SystemProgram]
ADD BarcodeSales int,CollectionProduct int,HideBalance int;

GO


ALTER TABLE [dbo].[SystemProgram]
ADD TypePrinter [nvarchar](200) NULL,BarcodeSize [nvarchar](30) NULL;

GO


ALTER TABLE [dbo].[Users]
ADD Statistical int;

GO


/****** Object:  Table [dbo].[ProjectTotal]    Script Date: 21/07/2022 02:50:29 م ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProjectTotal](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Month] [int] NULL,
	[Year] [int] NULL,
	[Date] [nvarchar](8) NOT NULL,
	[StoreValue] [float] NULL,
	[CustomerValue] [float] NULL,
	[BoxValue] [float] NULL,
	[Profits] [float] NULL,
	[DailyExpenses] [float] NULL,
	[AdvExpenses] [float] NULL,
	[SeianaExpenses] [float] NULL,
	[RentExpenses] [float] NULL,
	[ElectricityExpenses] [float] NULL,
	[WaterExpenses] [float] NULL,
	[PhoneExpenses] [float] NULL,
	[InternetExpenses] [float] NULL,
	[CarExpenses] [float] NULL,
	[Salaries] [float] NULL,
	[WithdrawProfits] [float] NULL,
	[TotalExpenses] [float] NULL,
	[PurchasingExpenses] [float] NULL,
	[AddMoneyBox] [float] NULL,
	[DiscMoneyBox] [float] NULL,
	[Sales] [float] NULL,
	[DiscSales] [float] NULL,
	[Purchases] [float] NULL,
	[DiscPurchases] [float] NULL,
	[PurchaseReturns] [float] NULL,
	[SalesReturns] [float] NULL,
	[Taweredat] [float] NULL,
	[Tahselat] [float] NULL,
 CONSTRAINT [PK_ProjectTotal] PRIMARY KEY CLUSTERED 
(
	[Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



/****** Object:  Table [dbo].[PriceUpdateDate]    Script Date: 09/01/2023 02:10:05 م ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PriceUpdateDate](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[Move] [nvarchar](50) NULL,
	[Ratio] [float] NULL,
	[DecimalNumber] [int] NULL,
	[Shera] [float] NULL,
	[Gomla] [float] NULL,
	[Kataee] [float] NULL,
 CONSTRAINT [PK_PriceUpdateDate] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



/****** Date: 30/08/2023 02:08:23 م ******/


/****** Object:  Table [dbo].[CategorySN]    Script Date: 30/08/2023 02:08:23 م ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CategorySN](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CategorySN] [nvarchar](100) NULL,
	[CategoryBarcode] [nvarchar](10) NULL,
	[CategoryName] [nvarchar](150) NULL,
 CONSTRAINT [PK_CategorySN] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



ALTER TABLE [dbo].[Billing]
ADD CategorySN [nvarchar](100) NULL;

GO



ALTER TABLE [dbo].[Billing1]
ADD CategorySN [nvarchar](100) NULL;

GO


