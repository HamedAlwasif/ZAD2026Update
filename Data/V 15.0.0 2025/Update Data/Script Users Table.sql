USE ZAD;
GO

-- اضافة حقول جديدة للصلاحيات
ALTER TABLE Users
ADD 
    SalesReturns INT,
    PurchaseReturns INT,
    PriceViewer INT,
    ProducerAddBarcodeFactory INT,
    ClientsMoneyTo INT,
    DailyEvents INT,
    DailyClosing INT,
    StatisticalFrmBillingSummary INT,
    OtherExpensesRevenues INT,
    Installment INT,
    SalesNoSave INT,
    OccasionsForm INT,
    VersionNew INT,
    Programs INT,
    TermsandConditions INT,
    Group_Name INT,
    FactionCategoreyAdd INT,
    AddSnToCategory INT,
	 ProductMakeAddMateriall INT,
    ProductMakeNeww INT;

-- حذف الحقول المحجوزة حروف
GO

-- b
IF EXISTS (
    SELECT 1 FROM sys.columns 
    WHERE Name = N'b' AND Object_ID = Object_ID(N'Users')
)
ALTER TABLE Users DROP COLUMN b;

-- c
IF EXISTS (
    SELECT 1 FROM sys.columns 
    WHERE Name = N'c' AND Object_ID = Object_ID(N'Users')
)
ALTER TABLE Users DROP COLUMN c;

-- d
IF EXISTS (
    SELECT 1 FROM sys.columns 
    WHERE Name = N'd' AND Object_ID = Object_ID(N'Users')
)
ALTER TABLE Users DROP COLUMN d;

-- g
IF EXISTS (
    SELECT 1 FROM sys.columns 
    WHERE Name = N'g' AND Object_ID = Object_ID(N'Users')
)
ALTER TABLE Users DROP COLUMN g;