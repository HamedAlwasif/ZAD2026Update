/*==================================================================
  1 - إنشاء المستخدم (Login + User)
==================================================================*/
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'zezo')
BEGIN
    CREATE LOGIN [zezo] WITH PASSWORD = N'123', CHECK_POLICY = OFF;
END
GO

USE [master];
GO

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = N'ZAD')
BEGIN
    CREATE DATABASE [ZAD];
END
GO

USE [ZAD];
GO

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'zezo')
BEGIN
    CREATE USER [zezo] FOR LOGIN [zezo];
    EXEC sp_addrolemember N'db_owner', N'zezo';
END
GO

/*----------------------------------
  2 - جدول SystemProgram
----------------------------------*/
--USE [ZAD];
--GO

/*----------------------------------*/
/* جدول Bank */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bank]') AND type = 'U')
BEGIN
			CREATE TABLE [dbo].[Bank](
				[ID] [int] IDENTITY(1,1) NOT NULL,
				[Storage] [nvarchar](50) NULL,
				[NumHesab] [nvarchar](50) NOT NULL,
				[Name] [nvarchar](150) NULL,
				[Alomala] [nvarchar](50) NULL,
				[PriceSarf] [float] NULL,
				[BankName] [nvarchar](150) NULL,
				[Department] [nvarchar](50) NULL,
				[Type] [char](10) NULL,
				[Address] [nvarchar](250) NULL,
				[Tel1] [nchar](20) NULL,
				[Tel2] [nchar](20) NULL,
				[Tel3] [nchar](20) NULL,
				[Fax] [nchar](20) NULL,
				[Rased] [float] NULL,
				[DateLast] [datetime] NULL,
				[Note] [nvarchar](250) NULL,
		 CONSTRAINT [PK_Bank] PRIMARY KEY CLUSTERED 
		(
			[NumHesab] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
		) ON [PRIMARY] ;
END
GO

/*----------------------------------*/
/* جدول BankHesab */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BankHesab]') AND type = 'U')
BEGIN
		   CREATE TABLE [dbo].[BankHesab](
				[ID] [int] IDENTITY(1,1) NOT NULL,
				[NumHesab] [nvarchar](50) NOT NULL,
				[BankName] [nvarchar](150) NULL,
				[Department] [nvarchar](50) NULL,
				[Date] [datetime] NULL,
				[Move] [nvarchar](50) NULL,
				[Remaining1] [float] NULL,
				[Maden] [float] NULL,
				[Daen] [float] NULL,
				[Remaining] [float] NULL,
				[NumSkeek] [nvarchar](50) NULL,
				[Name] [nvarchar](50) NULL,
				[ValueSheek] [float] NULL,
				[dateDay] [datetime] NULL,
				[DateElestehkak] [datetime] NULL,
				[Note] [nvarchar](250) NULL
		) ON [PRIMARY] ;
END
GO

/*----------------------------------*/
/* جدول Barcode_Seting */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Barcode_Seting]') AND type = 'U')
BEGIN
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
			[BarcodeSeparator] [float] NULL,
	 CONSTRAINT [PK_Barcode_Seting] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY];
END
GO

/*----------------------------------*/
/* جدول Billing */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Billing]') AND type = 'U')
BEGIN
		CREATE TABLE [dbo].[Billing](
			[NumBill] [bigint] NULL,
			[Num] [int] NULL,
			[ClinentID] [bigint] NULL,
			[ClientName] [nvarchar](150) NULL,
			[CategoryID] [bigint] NULL,
			[Storage] [nvarchar](50) NULL,
			[Category] [nvarchar](150) NULL,
			[Date] [datetime] NULL,
			[Quantity] [float] NULL,
			[Type] [nvarchar](50) NULL,
			[Price] [float] NULL,
			[Discount] [float] NULL,
			[Total] [float] NULL,
			[CategorySN] [nvarchar](100) NULL
	) ON [PRIMARY];
END
GO

/*----------------------------------*/
/* جدول Billing1 */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Billing1]') AND type = 'U')
BEGIN
	  CREATE TABLE [dbo].[Billing1](
			[NumBill] [bigint] NULL,
			[Num] [int] NULL,
			[ClinentID] [bigint] NULL,
			[ClientName] [nvarchar](150) NULL,
			[CategoryID] [bigint] NULL,
			[Storage] [nvarchar](50) NULL,
			[Category] [nvarchar](150) NULL,
			[Date] [datetime] NULL,
			[Quantity] [float] NULL,
			[Type] [nvarchar](50) NULL,
			[Price] [float] NULL,
			[Discount] [float] NULL,
			[Total] [float] NULL,
			[CategorySN] [nvarchar](100) NULL
	) ON [PRIMARY];
END
GO

/*----------------------------------*/
/* جدول BillingData */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BillingData]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[BillingData](
			[NumBill] [bigint] NOT NULL,
			[ClientID] [bigint] NULL,
			[Name] [nvarchar](150) NULL,
			[Type] [nvarchar](50) NULL,
			[Date] [datetime] NULL,
			[Move] [nvarchar](250) NULL,
			[TimePrint] [time](7) NULL,
			[TypeBill] [nchar](10) NULL,
			[NamePrint] [nvarchar](50) NULL,
			[NameMandop] [nvarchar](50) NULL,
			[TotalBill] [float] NULL,
			[TotalBillBuy] [float] NULL,
			[DiscountBuy] [float] NULL,
			[TotalBillInvalid] [float] NULL,
			[TotalBillBuyInvalid] [float] NULL,
			[NumberCategory] [int] NULL,
			[PreviousBalance] [float] NULL,
			[Creditor] [float] NULL,
			[Total] [float] NULL,
			[Discount] [float] NULL,
			[ReasonDiscount] [nvarchar](250) NULL,
			[Adding] [float] NULL,
			[ReasonAdd] [nvarchar](250) NULL,
			[Pay] [float] NULL,
			[Paid] [float] NULL,
			[Remaining] [float] NULL,
			[State] [varchar](50) NULL,
	 CONSTRAINT [PK_بيانات الفاتورة] PRIMARY KEY CLUSTERED 
	(
		[NumBill] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] ;
END
GO

/*----------------------------------*/
/* جدول BillingData1 */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BillingData1]') AND type = 'U')
BEGIN
		CREATE TABLE [dbo].[BillingData1](
			[NumBill] [bigint] NOT NULL,
			[NumBillBillingData] [bigint] NULL,
			[ClientID] [bigint] NULL,
			[Name] [nvarchar](150) NULL,
			[Date] [datetime] NULL,
			[Move] [nvarchar](250) NULL,
			[TotalBill] [float] NULL,
			[NumberCategory] [int] NULL,
			[PreviousBalance] [float] NULL,
			[Creditor] [float] NULL,
			[Total] [float] NULL,
			[Discount] [float] NULL,
			[ReasonDiscount] [nvarchar](250) NULL,
			[Adding] [float] NULL,
			[ReasonAdd] [nvarchar](250) NULL,
			[Paid] [float] NULL,
			[Remaining] [float] NULL,
			[State] [varchar](50) NULL,
	 CONSTRAINT [PK_BillingData1] PRIMARY KEY CLUSTERED 
	(
		[NumBill] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] ;
END
GO

/*----------------------------------*/
/* جدول BillingInvalid */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BillingInvalid]') AND type = 'U')
BEGIN
		CREATE TABLE [dbo].[BillingInvalid](
			[NumBill] [bigint] NULL,
			[Num] [int] NULL,
			[ClinetID] [int] NULL,
			[ClinetName] [nvarchar](150) NULL,
			[Catogory] [nvarchar](150) NULL,
			[Date] [datetime] NULL,
			[Quantity] [int] NULL,
			[Type] [char](10) NULL,
			[Price] [float] NULL,
			[Total] [float] NULL,
			[DateReplacement] [nvarchar](50) NULL,
			[Notes] [nvarchar](250) NULL,
			[Importer] [nvarchar](50) NULL
	) ON [PRIMARY] ;
END
GO

/*----------------------------------*/
/* جدول BoxMove */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BoxMove]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[BoxMove](
		[ID] [int] NOT NULL,
		[Date] [datetime] NULL,
		[Move] [nvarchar](150) NULL,
		[Name] [nvarchar](150) NULL,
		[NumBill] [bigint] NOT NULL,
		[Remaining] [float] NULL,
		[Sader] [float] NULL,
		[Wared] [float] NULL,
		[Total] [float] NULL,
		[Note] [nvarchar](250) NULL,
	 CONSTRAINT [PK_BoxMove_1] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] ;
END
GO

/*----------------------------------*/
/* جدول Car */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Car]') AND type = 'U')
BEGIN
	  CREATE TABLE [dbo].[Car](
			[ID] [int] IDENTITY(1,1) NOT NULL,
			[TypeLicense] [char](10) NULL,
			[TypeCar] [char](10) NULL,
			[TypeLoha] [nvarchar](50) NULL,
			[CharCar] [char](10) NULL,
			[NumCar] [int] NOT NULL,
			[NumShaseh] [nvarchar](250) NULL,
			[NumMotor] [nvarchar](250) NULL,
			[Mark] [char](10) NULL,
			[CapacityLiter] [bigint] NULL,
			[DateMake] [bigint] NULL,
			[Model] [char](10) NULL,
			[Price] [float] NULL,
	 CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED 
	(
		[NumCar] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] ;
END
GO

/*----------------------------------*/
/* جدول Category */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[Category](
			[ID] [bigint] IDENTITY(1,1) NOT NULL,
			[Barcode] [nvarchar](10) NULL,
			[Category] [nvarchar](150) NULL,
			[Storage] [nvarchar](50) NULL,
			[Group_Name] [nvarchar](150) NULL,
			[Date] [datetime] NULL,
			[Quantity] [float] NULL,
			[QuantityT] [float] NULL,
			[Unity] [int] NULL,
			[Faction] [nvarchar](50) NULL,
			[Total] [float] NULL,
			[Price] [float] NULL,
			[PriceGomla] [float] NULL,
			[PriceMostahlek] [float] NULL,
			[Value] [float] NULL,
			[Near] [int] NULL,
			[Available] [char](10) NULL,
			[Emwared] [nvarchar](80) NULL,
			[Image] [image] NULL,
			[Barcode_Factory] [nvarchar](150) NULL,
			[PriceGomlaAlgomla] [float] NULL,
			[PriceNesfAlgomla] [float] NULL,
	 CONSTRAINT [PK_Category1] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] ;
END
GO

/*----------------------------------*/
/* جدول Category_BestSeller */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category_BestSeller]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[Category_BestSeller](
		[ID] [bigint] IDENTITY(1,1) NOT NULL,
		[LastDate] [date] NULL,
		[Category_Barcode] [nvarchar](50) NULL,
		[Category] [nvarchar](150) NULL,
		[Number_Sales] [bigint] NULL,
		[Selection] [nvarchar](50) NULL,
	 CONSTRAINT [PK_BestSeller] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY];
END
GO

/*----------------------------------*/
/* جدول CategoryCart */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoryCart]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[CategoryCart](
		[ID] [bigint] NULL,
		[Category] [nvarchar](150) NULL,
		[Almwared] [nvarchar](50) NULL,
		[PriceSH] [float] NULL,
		[PriceG] [float] NULL,
		[PriceK] [float] NULL,
		[RateRecession] [int] NULL
	) ON [PRIMARY];
END
GO

/*----------------------------------*/
/* جدول CategoryFaction */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoryFaction]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[CategoryFaction](
		[ID] [bigint] IDENTITY(1,1) NOT NULL,
		[Faction] [nvarchar](50) NULL,
		[Type] [nvarchar](50) NULL,
	 CONSTRAINT [PK_CategoryFaction] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]	;
END
GO

/*----------------------------------*/
/* جدول CategoryGroup */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoryGroup]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[CategoryGroup](
		[ID] [bigint] IDENTITY(1,1) NOT NULL,
		[Group_Name] [nvarchar](150) NULL,
	 CONSTRAINT [PK_CategoryGroup] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY];
END
GO

/*----------------------------------*/
/* جدول CategoryIncomplete */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoryIncomplete]') AND type = 'U')
BEGIN
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
	) ON [PRIMARY]	;
END
GO

/*----------------------------------*/
/* جدول CategoryMove */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoryMove]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[CategoryMove](
		[ID] [bigint] IDENTITY(1,1) NOT NULL,
		[Category] [nvarchar](150) NULL,
		[Num] [int] NULL,
		[Barcode] [nvarchar](50) NULL,
		[Storage] [nvarchar](50) NULL,
		[IDBill] [bigint] NULL,
		[Clients] [varchar](50) NULL,
		[Date] [datetime] NULL,
		[Move] [nvarchar](50) NULL,
		[Alwared] [float] NULL,
		[FactionAlwared] [nvarchar](50) NULL,
		[PriceSH] [float] NULL,
		[ValueAlwared] [float] NULL,
		[Alsader] [float] NULL,
		[FactionAlsader] [nvarchar](50) NULL,
		[PriceB] [float] NULL,
		[valueAlsader] [float] NULL,
		[BalanceK] [float] NULL,
		[BalanceT] [float] NULL,
	 CONSTRAINT [PK_CategoryMove] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY];
END
GO

/*----------------------------------*/
/* جدول CategoryMove2 */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoryMove2]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[CategoryMove2](
		[ID] [bigint] IDENTITY(1,1) NOT NULL,
		[Category] [nvarchar](150) NULL,
		[Num] [int] NULL,
		[Storage] [nvarchar](50) NULL,
		[CategoryFrom] [nvarchar](50) NULL,
		[CategoryTo] [nvarchar](50) NULL,
		[MoveBill] [nvarchar](50) NULL,
		[IDBill] [bigint] NULL,
		[Date] [date] NULL,
		[Move] [nvarchar](50) NULL,
		[Wared] [float] NULL,
		[Sader] [float] NULL,
		[Quantity] [float] NULL,
		[Total] [float] NULL,
		[Users] [nvarchar](50) NULL,
	 CONSTRAINT [PK_CategoryMove2] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY];
END
GO


/*----------------------------------*/
/* جدول CategoryOthers */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoryOthers]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[CategoryOthers](
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[Date] [date] NULL,
		[ExpensesOther] [float] NULL,
		[IncomeOther] [float] NULL,
		[Statement] [nvarchar](150) NULL,
	 CONSTRAINT [PK_CategoryOthers] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY];
END
GO

/*----------------------------------*/
/* جدول CategoryPrice */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoryPrice]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[CategoryPrice](
		[ID] [int] NOT NULL,
		[Category] [nvarchar](50) NULL,
		[Date] [datetime] NULL,
		[PriceShraa] [float] NULL,
		[PriceGomla] [float] NULL,
		[PriceMostahlek] [float] NULL,
		[Faction] [nvarchar](50) NULL,
		[PriceGomlaAlgomla] [float] NULL,
		[PriceNesfAlgomla] [float] NULL,
	 CONSTRAINT [PK_CategoryPrice] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY];
END
GO

/*----------------------------------*/
/* جدول CategorysMaterials */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategorysMaterials]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[CategorysMaterials](
		[ID] [bigint] IDENTITY(1,1) NOT NULL,
		[NumBill] [nchar](10) NULL,
		[MaterialNum] [bigint] NULL,
		[CategoryID] [bigint] NULL,
		[Category] [nvarchar](150) NULL,
		[Date] [date] NULL,
		[MaterialCategory] [nvarchar](150) NULL,
		[Quantity] [float] NULL,
		[Faction] [nvarchar](50) NULL,
		[Price] [float] NULL,
		[Total] [float] NULL,
	 CONSTRAINT [PK_CategorysMaterials_1] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY];
END
GO

/*----------------------------------*/
/* جدول CategorysMaterialsData */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategorysMaterialsData]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[CategorysMaterialsData](
		[NumBill] [bigint] NOT NULL,
		[CategoryID] [bigint] NULL,
		[Category] [nvarchar](150) NULL,
		[Date] [date] NULL,
		[TotalCategorysMaterials] [float] NULL,
		[CategoryQuantity] [float] NULL,
		[CategoryCostPrice] [float] NULL,
		[CategoryPrice] [float] NULL,
		[State] [nvarchar](150) NULL,
	 CONSTRAINT [PK_CategorysMaterialsData] PRIMARY KEY CLUSTERED 
	(
		[NumBill] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY];
END
GO

/*----------------------------------*/
/* جدول CategorySN */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategorySN]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[CategorySN](
		[ID] [bigint] IDENTITY(1,1) NOT NULL,
		[CategorySN] [nvarchar](100) NULL,
		[CategoryBarcode] [nvarchar](10) NULL,
		[CategoryName] [nvarchar](150) NULL,
	 CONSTRAINT [PK_CategorySN] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY];
END
GO

/*----------------------------------*/
/* جدول CategoryTotal */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoryTotal]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[CategoryTotal](
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[Date] [date] NOT NULL,
		[Total_Category] [float] NULL,
	 CONSTRAINT [PK_CategoryTotal] PRIMARY KEY CLUSTERED 
	(
		[Date] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY];
END
GO

/*----------------------------------*/
/* جدول Clients */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Clients]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[Clients](
		[ID] [bigint] IDENTITY(1,1) NOT NULL,
		[Name] [nvarchar](150) NULL,
		[Company] [nvarchar](50) NULL,
		[TelHome] [char](11) NULL,
		[TelMobil] [nchar](11) NULL,
		[Address] [nvarchar](250) NULL,
		[PreviousBalance] [float] NULL,
		[Creditor] [float] NULL,
		[Image] [image] NULL,
		[StateRaseed] [nvarchar](30) NULL,
		[LimitCredit] [float] NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 	;
END
GO

/*----------------------------------*/
/* جدول D */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[D]') AND type = 'U')
BEGIN
	 CREATE TABLE [dbo].[D](
		[NumBill] [bigint] NULL,
		[Num] [int] NULL,
		[ClinentID] [bigint] NULL,
		[ClientName] [nvarchar](50) NULL,
		[CategoryID] [bigint] NULL,
		[Storage] [nvarchar](50) NULL,
		[Category] [nvarchar](50) NULL,
		[Date] [nvarchar](50) NULL,
		[Quantity] [int] NULL,
		[Type] [char](10) NULL,
		[Price] [float] NULL,
		[Discount] [float] NULL,
		[Total] [float] NULL
	) ON [PRIMARY];
END
GO

/*----------------------------------*/
/* جدول Employed */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employed]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[Employed](
		[ID] [bigint] IDENTITY(1,1) NOT NULL,
		[Name] [nvarchar](max) NULL,
		[Address] [nvarchar](max) NULL,
		[NumIdentity] [bigint] NULL,
		[Tel] [char](11) NULL,
		[DateBirth] [datetime] NULL,
		[DateRegistry] [datetime] NULL,
		[Jop] [nchar](10) NULL,
		[Salary] [bigint] NULL,
		[DateEnd] [datetime] NULL,
		[State] [char](10) NULL,
		[Remaining] [float] NULL,
		[DateRemaining] [datetime] NULL,
	 CONSTRAINT [PK_Employed] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] ;
END
GO


/*----------------------------------*/
/* جدول EmployedSalary */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmployedSalary]') AND type = 'U')
BEGIN
    CREATE TABLE [dbo].[EmployedSalary](
			[ID] [int] IDENTITY(1,1) NOT NULL,
			[Date] [datetime] NULL,
			[IdEmployed] [int] NULL,
			[Employed] [nvarchar](50) NULL,
			[Salary] [float] NULL,
			[RemainingSalary] [float] NULL,
			[Move] [nvarchar](50) NULL,
			[Sarf] [float] NULL,
			[AddSalary] [float] NULL,
			[Remaining] [float] NULL,
			[Notice] [nvarchar](250) NULL
    ) ON [PRIMARY] ;
END
GO

/*----------------------------------*/
/* جدول Events */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Events]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[Events](
		[ID] [bigint] IDENTITY(1,1) NOT NULL,
		[Date] [date] NULL,
		[Time] [nvarchar](20) NULL,
		[Users] [nvarchar](50) NULL,
		[Events] [nvarchar](250) NULL,
	 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] ;
END
GO

/*----------------------------------*/
/* جدول Expended */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Expended]') AND type = 'U')
BEGIN
CREATE TABLE [dbo].[Expended](
	[ID] [int] NOT NULL,
	[Date] [datetime] NULL,
	[Name] [nvarchar](150) NULL,
	[move] [nvarchar](30) NULL,
	[Report] [nvarchar](250) NULL,
	[Paid] [float] NULL
) ON [PRIMARY] ;
END
GO

/*----------------------------------*/
/* جدول Expended1 */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Expended1]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[Expended1](
		[ID] [int] NOT NULL,
		[Date] [nvarchar](50) NULL,
		[Name] [nvarchar](150) NULL,
		[Report] [nvarchar](250) NULL,
		[Paid] [float] NULL,
	 CONSTRAINT [PK_Expended1] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] ;
END
GO

/*----------------------------------*/
/* جدول Final */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Final]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[Final](
		[ID] [bigint] NOT NULL,
		[Name] [nvarchar](max) NULL,
		[date] [date] NULL,
		[Company] [nvarchar](max) NULL,
		[mab] [float] NULL,
		[mosh] [float] NULL,
		[mard] [float] NULL,
		[mardBuy] [float] NULL,
		[discount] [float] NULL,
		[discountBuy] [float] NULL,
		[added] [float] NULL,
		[tahsel] [float] NULL,
		[daf] [float] NULL,
		[nesba] [float] NULL,
		[final] [float] NULL,
	 CONSTRAINT [PK_Final] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] 	;
END
GO

/*----------------------------------*/
/* جدول FristGard */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FristGard]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[FristGard](
		[ID] [int] NOT NULL,
		[Date] [datetime] NULL,
		[Move] [nvarchar](50) NULL,
		[NumBill] [bigint] NULL,
		[Name] [nvarchar](50) NULL,
		[GardFrist] [float] NULL,
		[Madenon] [float] NULL,
		[Daenon] [float] NULL,
		[Box] [float] NULL,
		[Building] [float] NULL,
		[Electronic] [float] NULL,
		[BasisOFFICE] [float] NULL,
		[Bank] [float] NULL,
		[adv] [float] NULL,
	 CONSTRAINT [PK_FristGard] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY];
END
GO

/*----------------------------------*/
/* جدول Groups */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Groups]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[Groups](
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[GroupName] [nvarchar](100) NULL,
		[Information] [nvarchar](150) NULL
	) ON [PRIMARY];
END
GO

/*----------------------------------*/
/* جدول Installment */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Installment]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[Installment](
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[InstallmentID] [bigint] NULL,
		[NumBill] [bigint] NULL,
		[InstallmentHistory] [date] NULL,
		[Recipient] [nvarchar](150) NULL,
		[Date] [nvarchar](50) NULL,
		[Paid] [float] NULL,
	 CONSTRAINT [PK_Installment] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY];
END
GO

/*----------------------------------*/
/* جدول InstallmentData */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InstallmentData]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[InstallmentData](
		[InstallmentID] [bigint] IDENTITY(1,1) NOT NULL,
		[ClientID] [bigint] NULL,
		[ClientName] [nvarchar](150) NULL,
		[ClientNumCard] [nvarchar](14) NULL,
		[ClientPhone] [nvarchar](15) NULL,
		[ClientImageCard] [image] NULL,
		[GuarantorName] [nvarchar](100) NULL,
		[GuarantorNumCard] [nvarchar](14) NULL,
		[GuarantorPhone] [nvarchar](15) NULL,
		[GuarantorImageCard] [image] NULL,
		[NumBill] [bigint] NULL,
		[Date] [date] NULL,
		[TotalBill] [float] NULL,
		[Paid] [float] NULL,
		[Remeaning] [float] NULL,
		[DateFristInstallment] [date] NULL,
		[NumInstallment] [int] NULL,
		[TypeInstallment] [nvarchar](15) NULL,
		[State] [nvarchar](20) NULL,
	 CONSTRAINT [PK_InstallmentData] PRIMARY KEY CLUSTERED 
	(
		[InstallmentID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] ;
END
GO

/*----------------------------------*/
/* جدول Invalid */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Invalid]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[Invalid](
		[ID] [bigint] IDENTITY(1,1) NOT NULL,
		[NumBill] [bigint] NULL,
		[Name] [nvarchar](150) NULL,
		[Storage] [nvarchar](50) NULL,
		[Category] [nvarchar](150) NULL,
		[Unity] [int] NULL,
		[Notes] [nvarchar](250) NULL,
		[DateReceiving] [datetime] NULL,
		[DateReplacement] [datetime] NULL,
		[Importer] [nvarchar](50) NULL,
	 CONSTRAINT [PK_Invalid] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] ;
END
GO

/*----------------------------------*/
/* جدول KaematEldakhel */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KaematEldakhel]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[KaematEldakhel](
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[Date] [datetime] NULL,
		[Frist] [float] NULL,
		[ShraaTotal] [float] NULL,
		[MardodatMabeat] [float] NULL,
		[MasarefNasria] [float] NULL,
		[MasarefCar] [float] NULL,
		[DiscountMabeat] [float] NULL,
		[HalekTotal] [float] NULL,
		[Total] [float] NULL,
		[Last] [float] NULL,
		[MabeatTotal] [float] NULL,
		[MardodatSheraa] [float] NULL,
		[DiscountSheraa] [float] NULL,
		[Total1] [float] NULL
	) ON [PRIMARY];
END
GO

/*----------------------------------*/
/* جدول Materials */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Materials]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[Materials](
		[ID] [bigint] IDENTITY(1,1) NOT NULL,
		[MaterialsName] [nvarchar](150) NULL,
		[Price] [float] NULL,
		[Qunt] [float] NULL,
		[DateExpiry] [date] NULL,
	 CONSTRAINT [PK_Materials] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY];
END
GO

/*----------------------------------*/
/* جدول MaterialsBill */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MaterialsBill]') AND type = 'U')
BEGIN
CREATE TABLE [dbo].[MaterialsBill](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BoxID] [int] NULL,
	[Date] [date] NULL,
	[MaterialsName] [nvarchar](150) NULL,
	[MaterialsID] [bigint] NULL,
	[Price] [float] NULL,
	[Qunt] [float] NULL,
	[Total] [float] NULL,
	[DateExpiry] [date] NULL,
	[Note] [nvarchar](150) NULL,
 CONSTRAINT [PK_MaterialsBill] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY];
END
GO

/*----------------------------------*/
/* جدول Mortagaat */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Mortagaat]') AND type = 'U')
BEGIN
CREATE TABLE [dbo].[Mortagaat](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NULL,
	[Name] [nvarchar](150) NULL,
	[Move] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[DateState] [datetime] NULL,
 CONSTRAINT [PK_Mortagaat] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY];
END
GO

/*----------------------------------*/
/* جدول Movemoney */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Movemoney]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[Movemoney](
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[Date] [date] NULL,
		[Name] [nvarchar](150) NULL,
		[Report] [nvarchar](50) NULL,
		[Sader] [float] NULL,
		[Wared] [float] NULL,
	 CONSTRAINT [PK_Movemoney] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY];
END
GO

/*----------------------------------*/
/* جدول OsolSabta */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OsolSabta]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[OsolSabta](
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[Date] [date] NULL,
		[Report] [nvarchar](250) NULL,
		[Akaar] [float] NULL,
		[Arady] [float] NULL,
		[Electric] [float] NULL,
		[Asas] [float] NULL,
		[Total] [float] NULL,
		[Users] [nvarchar](50) NULL,
		[Movement] [nvarchar](150) NULL
	) ON [PRIMARY] ;
END
GO

/*----------------------------------*/
/* جدول PriceUpdateDate */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PriceUpdateDate]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[PriceUpdateDate](
		[ID] [bigint] IDENTITY(1,1) NOT NULL,
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
	) ON [PRIMARY];
END
GO

/*----------------------------------*/
/* جدول Profit */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Profit]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[Profit](
		[NumBill] [bigint] NULL,
		[Date] [date] NULL,
		[Category] [nvarchar](150) NULL,
		[Num] [int] NULL,
		[Quantity] [float] NULL,
		[Type] [nvarchar](50) NULL,
		[PriceShraa] [float] NULL,
		[PriceBeaa] [float] NOT NULL,
		[Profit] [float] NULL
	) ON [PRIMARY];
END
GO

/*----------------------------------*/
/* جدول ProjectTotal */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProjectTotal]') AND type = 'U')
BEGIN
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
	) ON [PRIMARY];
END
GO

/*----------------------------------*/
/* جدول RasMoney */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RasMoney]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[RasMoney](
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[Date] [datetime] NOT NULL,
		[Building] [float] NULL,
		[Electronic] [float] NULL,
		[BasisOFFICE] [float] NULL,
		[Bank] [float] NULL,
		[AddBox] [float] NULL,
		[Total] [float] NULL,
	 CONSTRAINT [PK_RasMoney] PRIMARY KEY CLUSTERED 
	(
		[Date] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY];
END
GO

/*----------------------------------*/
/* جدول SavePass */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SavePass]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[SavePass](
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[Name] [nvarchar](50) NOT NULL,
		[Pass] [nvarchar](50) NULL,
		[SavePass] [nchar](10) NULL,
	 CONSTRAINT [PK_SavePass] PRIMARY KEY CLUSTERED 
	(
		[Name] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY];
END
GO

/*----------------------------------*/
/* جدول SearchCar */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SearchCar]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[SearchCar](
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[NumCar] [int] NULL,
		[Date] [date] NULL,
		[Washed] [float] NULL,
		[Filter] [float] NULL,
		[Petroleum] [float] NULL,
		[Oil] [float] NULL,
		[Mechanical] [float] NULL,
		[PartChange] [float] NULL,
		[Total] [float] NULL,
		[Notice] [nvarchar](250) NULL,
		[Driver] [nvarchar](150) NULL,
	 CONSTRAINT [PK_SearchCar] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] ;
END
GO

/*----------------------------------*/
/* جدول SheekSave */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SheekSave]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[SheekSave](
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[Move] [nchar](10) NULL,
		[TypeMove] [nchar](10) NULL,
		[Name] [nvarchar](50) NULL,
		[Storage] [nvarchar](50) NULL,
		[NumSkeek] [nvarchar](50) NOT NULL,
		[ValueSheek] [float] NULL,
		[dateDay] [date] NULL,
		[DateElestehkak] [date] NULL,
		[NumHesab] [nvarchar](50) NULL,
		[BankName] [nvarchar](50) NULL,
		[Note] [nvarchar](250) NULL,
		[State] [nvarchar](50) NULL,
	 CONSTRAINT [PK_SheekSave] PRIMARY KEY CLUSTERED 
	(
		[NumSkeek] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] ;
END
GO

/*----------------------------------*/
/* جدول Storage */
/*----------------------------------*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Storage]') AND type = 'U')
BEGIN
	CREATE TABLE [dbo].[Storage](
		[ID] [bigint] IDENTITY(1,1) NOT NULL,
		[Storage] [nvarchar](50) NULL,
		[Place] [nvarchar](50) NULL,
		[Phone] [numeric](18, 0) NULL,
	 CONSTRAINT [PK_Storage] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY];
END
GO

/****** Table: SystemProgram ******/
CREATE TABLE [dbo].[SystemProgram](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GomlaKataey] [int] NULL,
	[Kataey] [int] NULL,
	[Company_Name] [nvarchar](100) NULL,
	[Company_Description] [nvarchar](150) NULL,
	[Company_Address] [nvarchar](150) NULL,
	[Company_Phone] [nvarchar](50) NULL,
	[NoteToBill] [nvarchar](max) NULL,
	[PrinterBill] [nvarchar](50) NULL,
	[SizePaperBill] [nvarchar](50) NULL,
	[PrinterBarcode] [nvarchar](50) NULL,
	[PrintNameComToBill] [int] NULL,
	[PrintLogoComToBill] [int] NULL,
	[FontSizeBarcode] [float] NULL,
	[PriceSheraaAcount] [nvarchar](50) NULL,
	[BathBackup] [nvarchar](1000) NULL,
	[Comp_Logo] [nvarchar](1000) NULL,
	[BarcodeStart] [bigint] NULL,
	[TypeBillDefoult] [nvarchar](20) NULL,
	[TypeCurrency] [nvarchar](20) NULL,
	[TypeFont] [nvarchar](100) NULL,
	[UseLimitCredit] [int] NULL,
	[DiscountBill] [float] NULL,
	[BarcodeSales] [int] NULL,
	[CollectionProduct] [int] NULL,
	[HideBalance] [int] NULL,
	[TypePrinter] [nvarchar](200) NULL,
	[BarcodeSize] [nvarchar](30) NULL,
	[BarcodeSalesType] [int] NULL,
	[OpenFormOther] [int] NULL,
	[PricesAll] [int] NULL,
	[PriceKataeeProfitRate] DECIMAL(5,2) NULL,         -- نسبة البيع العادي
    [PriceAlgomlaProfitRate] DECIMAL(5,2) NULL,      -- نسبة الجملة
    [PriceNesfAlgomlaProfitRate] DECIMAL(5,2) NULL,  -- نسبة نصف الجملة
    [PriceGomlaAlgomlaProfitRate] DECIMAL(5,2) NULL,  -- نسبة جملة الجملة
 CONSTRAINT [PK_SysemProgram] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 
GO

/****** Table: Transport ******/
CREATE TABLE [dbo].[Transport](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[Category] [nvarchar](150) NULL,
	[Quantity] [int] NULL,
	[Part] [int] NULL,
	[FromStorage] [nvarchar](50) NULL,
	[ToStorage] [nvarchar](50) NULL,
 CONSTRAINT [PK_Transport] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Table: Treasury ******/
CREATE TABLE [dbo].[Treasury](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Users] [nvarchar](50) NULL,
	[BalanceStored] [float] NULL,
	[Tahseel] [float] NULL,
	[Tawred] [float] NULL,
	[MassarefStored] [float] NULL,
	[MassarefCar] [float] NULL,
	[SafyStored] [float] NULL,
	[AddStored] [float] NULL,
	[ExporTtreasury] [float] NULL,
	[Remaining] [float] NULL,
	[Notice] [nvarchar](250) NULL,
 CONSTRAINT [PK_Treasury] PRIMARY KEY CLUSTERED 
(
	[Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] ;
GO

/****** Table: TreasuryRemaning ******/
CREATE TABLE [dbo].[TreasuryRemaning](
	[ID] [int] NULL,
	[Date] [date] NULL,
	[RemaningTreasury] [float] NULL,
	[BedaaaHalia] [float] NULL,
	[Madioniat] [float] NULL,
	[Daenat] [float] NULL,
	[Akarat] [float] NULL,
	[HesabBank] [float] NULL,
	[Total] [float] NULL,
	[FarkMaKablh] [float] NULL
) ON [PRIMARY]
GO

/****** Table: Users ******/
CREATE TABLE [dbo].[Users](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Bassword] [nvarchar](50) NULL,
	[Sales] [int] NULL,
	[Purchases] [int] NULL,
	[Expenses] [int] NULL,
	[MoneyToBox] [int] NULL,
	[MoneyFromBox] [int] NULL,
	[GroupAdd] [int] NULL,
	[EmployeeAdd] [int] NULL,
	[EmployeeSalaryPayment] [int] NULL,
	[EmployeeSalaryMovement] [int] NULL,
	[EmployeeBonusAdd] [int] NULL,
	[EmployeePenaltyAdd] [int] NULL,
	[CarsAdd] [int] NULL,
	[CarsExpenses] [int] NULL,
	[CarsExpensesMovement] [int] NULL,
	[BackupSave] [int] NULL,
	[BackupRestore] [int] NULL,
	[SettingsGeneral] [int] NULL,
	[SystemReset] [int] NULL,
	[License] [int] NULL,
	[CallUs] [int] NULL,
	[ClientAdd] [int] NULL,
	[ClientsMoney] [int] NULL,
	[ExplainSystem] [int] NULL,
	[Connection] [int] NULL,
	[ProducerNewAdd] [int] NULL,
	[StoreNewAdd] [int] NULL,
	[Prices] [int] NULL,
	[ProducerUpdate] [int] NULL,
	[Inventory] [int] NULL,
	[Barcode] [int] NULL,
	[ProducerIncomplete] [int] NULL,
	[StoreToStore] [int] NULL,
	[ProductMovement] [int] NULL,
	[BoxMovement] [int] NULL,
	[ClientsList] [int] NULL,
	[BanksList] [int] NULL,
	[Profits] [int] NULL,
	[DailySalesPurchases] [int] NULL,
	[DailyTransactions] [int] NULL,
	[FinancialStatements] [int] NULL,
	[BankAddAccount] [int] NULL,
	[CheckSaderWared] [int] NULL,
	[CheckSave] [int] NULL,
	[BankStatement] [int] NULL,
	[BankToBank] [int] NULL,
	[ClientAccountStatement] [int] NULL,
	[UserAdd1] [int] NULL,
	[FirstAccounts] [int] NULL,
	[AllowUser] [int] NULL,
	[b] [int] NULL,
	[c] [int] NULL,
	[d] [int] NULL,
	[g] [int] NULL,
	[Statistical] [int] NULL
) ON [PRIMARY]
GO

/****** Table: Occasions ******/

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




/***===================     END CREAT TABLE      ===================****/
/***===================     END CREAT TABLE      ===================****/
/***===================     END CREAT TABLE      ===================****/



-- *********************   البيانات الافتراضية   *******************************

/*-------------------------  CategoryFaction  -------------------------*/
SET IDENTITY_INSERT [dbo].[CategoryFaction] ON;
INSERT INTO [dbo].[CategoryFaction] ([ID], [Faction], [Type]) VALUES 
(1, N'كرتونه', N'G'),
(2, N'قطعه', N'G'),
(3, N'دسته', N'G'),
(4, N'قطعه', N'K'),
(5, N'علبه', N'K'),
(6, N'كيلو', N'K');
SET IDENTITY_INSERT [dbo].[CategoryFaction] OFF;
GO

/*-------------------------  Clients  -------------------------*/
SET IDENTITY_INSERT [dbo].[Clients] ON;
INSERT INTO [dbo].[Clients] ([ID], [Name], [Company], [TelHome], [TelMobil], [Address], [PreviousBalance], [Creditor], [Image], [StateRaseed], [LimitCredit]) 
VALUES (1, N'عميل نقدى', N'عملاء', N'0', N'0', N'المنصورة', 0, 0, NULL, N'فعال', N'0');
SET IDENTITY_INSERT [dbo].[Clients] OFF;
GO

/*-------------------------  Groups  -------------------------*/
SET IDENTITY_INSERT [dbo].[Groups] ON;
INSERT INTO [dbo].[Groups] ([ID], [GroupName], [Information]) VALUES
(1, N'عملاء', N'عملائنا الذين يعملون معنا'),
(2, N'موردين', N'الشركات والمصانع التى اتعامل معها');
SET IDENTITY_INSERT [dbo].[Groups] OFF;
GO

/*-------------------------  Storage  -------------------------*/
SET IDENTITY_INSERT [dbo].[Storage] ON;
INSERT INTO [dbo].[Storage] ([ID], [Storage], [Place], [Phone]) VALUES (1, N'الرئيسى', NULL, NULL);
SET IDENTITY_INSERT [dbo].[Storage] OFF;
GO

/*-------------------------  SystemProgram  -------------------------*/
SET IDENTITY_INSERT [dbo].[SystemProgram] ON;

INSERT INTO [dbo].[SystemProgram] (
    [ID], [GomlaKataey], [Kataey], [Company_Name], [Company_Description], [Company_Address], [Company_Phone], 
    [NoteToBill], [PrinterBill], [SizePaperBill], [PrinterBarcode], [PrintNameComToBill], [PrintLogoComToBill], 
    [FontSizeBarcode], [PriceSheraaAcount], [BathBackup], [Comp_Logo], [BarcodeStart], [TypeBillDefoult], 
    [TypeCurrency], [TypeFont], [UseLimitCredit], [DiscountBill], [BarcodeSales], [CollectionProduct], [HideBalance], 
    [TypePrinter], [BarcodeSize], [BarcodeSalesType], [OpenFormOther], [PricesAll],[PriceKataeeProfitRate], [PriceAlgomlaProfitRate],[PriceNesfAlgomlaProfitRate],[PriceGomlaAlgomlaProfitRate]
) VALUES (
    1, 0, 1, N'الوصيف', N'للدعاية والاعلان', N'طناح : منتصف شارع النقطة القديمة', N'01224349933', 
    N'شكرا لزيارتكم', N'HP LaserJet Professional P 1102w', N'A5', N'HP LaserJet Professional P 1102w', 
    1, 1, 14, N'السعر الجديد', N'D:\Alwasif\DATA\Backup\Auto\ZadAuto.bak', 
    N'D:\Alwasif\ZAD v5.0.0\logo.png', 100000, N'آجل', N'جنيه', N'IDAHC39M Code 39 Barcode', 
    0, 20, 1, 0, 0, 0, 0, 14,0,0,35,20,25,10
);

SET IDENTITY_INSERT [dbo].[SystemProgram] OFF;
GO

/*-------------------------  Users  -------------------------*/
SET IDENTITY_INSERT [dbo].[Users] ON;

INSERT INTO [dbo].[Users] (
    [ID], [UserName], [Bassword], [Sales], [Purchases], [Expenses], [MoneyToBox], [MoneyFromBox], [GroupAdd], 
    [EmployeeAdd], [EmployeeSalaryPayment], [EmployeeSalaryMovement], [EmployeeBonusAdd], [EmployeePenaltyAdd], 
    [CarsAdd], [CarsExpenses], [CarsExpensesMovement], [BackupSave], [BackupRestore], [SettingsGeneral], 
    [SystemReset], [License], [CallUs], [ClientAdd], [ClientsMoney], [ExplainSystem], [Connection], [ProducerNewAdd], 
    [StoreNewAdd], [Prices], [ProducerUpdate], [Inventory], [Barcode], [ProducerIncomplete], [StoreToStore], 
    [ProductMovement], [BoxMovement], [ClientsList], [BanksList], [Profits], [DailySalesPurchases], 
    [DailyTransactions], [FinancialStatements], [BankAddAccount], [CheckSaderWared], [CheckSave], [BankStatement], 
    [BankToBank], [ClientAccountStatement], [UserAdd1], [FirstAccounts], [AllowUser], [b], [c], [d], [g], [Statistical]
) VALUES (
    1, N'1', N'1', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1
);

SET IDENTITY_INSERT [dbo].[Users] OFF;
GO

/*-------------------------  Barcode_Seting  -------------------------*/
SET IDENTITY_INSERT [dbo].[Barcode_Seting] ON;
INSERT INTO [dbo].[Barcode_Seting] (
    [ID], [BarcodeStart], [BarcodePrinter], [BarcodeSize], [BarcodeTypeFont], [BarcodeFontSize], [ProductSize], 
    [MarginsCompaneyX], [MarginsCompaneyY], [MarginsBarcodeX], [MarginsBarcodeY], [MarginsCategorysX], 
    [MarginsCategorysY], [MarginsCategoryIDX], [MarginsCategoryIDY], [MarginsPriceX], [MarginsPriceY],[BarcodeSeparator]
) VALUES (
    1, 100000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,50
);
SET IDENTITY_INSERT [dbo].[Barcode_Seting] OFF;
GO
