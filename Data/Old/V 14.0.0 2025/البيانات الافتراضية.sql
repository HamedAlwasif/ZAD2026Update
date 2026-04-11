USE [ZAD1];
GO


-- *********************   البيانات الافتراضية   *******************************

/*-------------------------  CategoryFaction  -------------------------*/
SET IDENTITY_INSERT [dbo].[CategoryFaction] ON;
GO

INSERT INTO [dbo].[CategoryFaction] ([ID], [Faction], [Type]) VALUES (1, N'كرتونه', N'G');
INSERT INTO [dbo].[CategoryFaction] ([ID], [Faction], [Type]) VALUES (2, N'قطعه', N'G');
INSERT INTO [dbo].[CategoryFaction] ([ID], [Faction], [Type]) VALUES (3, N'دسته', N'G');
INSERT INTO [dbo].[CategoryFaction] ([ID], [Faction], [Type]) VALUES (4, N'قطعه', N'K');
INSERT INTO [dbo].[CategoryFaction] ([ID], [Faction], [Type]) VALUES (5, N'علبه', N'K');
INSERT INTO [dbo].[CategoryFaction] ([ID], [Faction], [Type]) VALUES (6, N'كيلو', N'K');

SET IDENTITY_INSERT [dbo].[CategoryFaction] OFF;
GO

/*-------------------------  Clients  -------------------------*/
SET IDENTITY_INSERT [dbo].[Clients] ON;
GO

INSERT INTO [dbo].[Clients] 
([ID], [Name], [Company], [TelHome], [TelMobil], [Address], [PreviousBalance], [Creditor], [Image], [StateRaseed], [LimitCredit]) 
VALUES 
(1, N'عميل نقدى', N'عملاء', N'0          ', N'0          ', N'المنصورة', 0, 0, NULL, N'فعال', NULL);

SET IDENTITY_INSERT [dbo].[Clients] OFF;
GO

/*-------------------------  Groups  -------------------------*/
SET IDENTITY_INSERT [dbo].[Groups] ON;
GO

INSERT INTO [dbo].[Groups] ([ID], [GroupName], [Information]) VALUES (1, N'عملاء', N'عملائنا الذين يعملون معنا');
INSERT INTO [dbo].[Groups] ([ID], [GroupName], [Information]) VALUES (2, N'موردين', N'الشركات والمصانع التى اتعامل معها');

SET IDENTITY_INSERT [dbo].[Groups] OFF;
GO

/*-------------------------  Storage  -------------------------*/
SET IDENTITY_INSERT [dbo].[Storage] ON;
GO

INSERT INTO [dbo].[Storage] ([ID], [Storage], [Place], [Phone]) VALUES (1, N'الرئيسى', NULL, NULL);

SET IDENTITY_INSERT [dbo].[Storage] OFF;
GO

/*-------------------------  SystemProgram  -------------------------*/
SET IDENTITY_INSERT [dbo].[SystemProgram] ON;
GO

INSERT INTO [dbo].[SystemProgram] (
    [ID], [GomlaKataey], [Kataey], [Company_Name], [Company_Description], [Company_Address], [Company_Phone], 
    [NoteToBill], [PrinterBill], [SizePaperBill], [PrinterBarcode], [PrintNameComToBill], [PrintLogoComToBill], 
    [FontSizeBarcode], [PriceSheraaAcount], [BathBackup], [Comp_Logo], [BarcodeStart], [TypeBillDefoult], 
    [TypeCurrency], [TypeFont], [UseLimitCredit], [DiscountBill],[BarcodeSales],[CollectionProduct],[HideBalance],[TypePrinter],[BarcodeSize]) 
VALUES (
    1, 0, 1, N'الوصيف', N'للدعاية والاعلان', N'طناح : منتصف شارع النقطة القديمة', N'01224349933', 
    N'شكرا لزيارتكم', N'HP LaserJet Professional P 1102w', N'A5', N'HP LaserJet Professional P 1102w', 
    N'1', N'1', 14, N'السعر الجديد', N'D:\Alwasif\DATA\Backup\Auto\ZadAuto.bak', 
    N'D:\Alwasif\ZAD v5.0.0\logo.png', 100000, N'آجل', N'جنيه', N'IDAHC39M Code 39 Barcode', 0, 20,1,0,0,0,14
);

SET IDENTITY_INSERT [dbo].[SystemProgram] OFF;
GO

/*-------------------------  Users  -------------------------*/
SET IDENTITY_INSERT [dbo].[Users] ON;
GO

INSERT INTO [dbo].[Users] (
    [ID], [UserName], [Bassword], [Sales], [Purchases], [Expenses], [MoneyToBox], [MoneyFromBox], [GroupAdd], 
    [EmployeeAdd], [EmployeeSalaryPayment], [EmployeeSalaryMovement], [EmployeeBonusAdd], [EmployeePenaltyAdd], 
    [CarsAdd], [CarsExpenses], [CarsExpensesMovement], [BackupSave], [BackupRestore], [SettingsGeneral], 
    [SystemReset], [License], [CallUs], [ClientAdd], [ClientsMoney], [ExplainSystem], [Connection], [ProducerNewAdd], 
    [StoreNewAdd], [Prices], [ProducerUpdate], [Inventory], [Barcode], [ProducerIncomplete], [StoreToStore], 
    [ProductMovement], [BoxMovement], [ClientsList], [BanksList], [Profits], [DailySalesPurchases], 
    [DailyTransactions], [FinancialStatements], [BankAddAccount], [CheckSaderWared], [CheckSave], [BankStatement], 
    [BankToBank], [ClientAccountStatement], [UserAdd1], [FirstAccounts], [AllowUser], [b], [c], [d], [g]
) VALUES (
    1, N'1', N'1', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1
);

SET IDENTITY_INSERT [dbo].[Users] OFF;
GO

/*-----------------------  Barcode_Seting  -------------------------*/
SET IDENTITY_INSERT [dbo].[Barcode_Seting] ON;
GO

INSERT INTO [dbo].[Barcode_Seting] (
    [ID], [BarcodeStart], [BarcodePrinter], [BarcodeSize], [BarcodeTypeFont], [BarcodeFontSize], [ProductSize], 
    [MarginsCompaneyX], [MarginsCompaneyY], [MarginsBarcodeX], [MarginsBarcodeY], [MarginsCategorysX], 
    [MarginsCategorysY], [MarginsCategoryIDX], [MarginsCategoryIDY], [MarginsPriceX], [MarginsPriceY]
) VALUES (
    1, 100000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
);

SET IDENTITY_INSERT [dbo].[Barcode_Seting] OFF;
GO
