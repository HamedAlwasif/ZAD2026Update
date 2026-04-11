IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = N'ZAD')
BEGIN
    CREATE DATABASE [ZAD]
    ON PRIMARY
    (
        NAME = N'ZAD_Data',
        FILENAME = N'D:\ZAD\DATA\ZAD.mdf',  -- مسار واسم ملف البيانات
        SIZE = 10MB,
        --MAXSIZE = 500MB, -- لتحديد حجم البيانات
        FILEGROWTH = 10MB
    )
    LOG ON
    (
        NAME = N'ZAD_Log',
        FILENAME = N'D:\ZAD\DATA\ZAD_Log.ldf', -- مسار واسم ملف السجل
        SIZE = 5MB,
        --MAXSIZE = 100MB,  -- لتحديد حجم البيانات
        FILEGROWTH = 5MB
    );
END
GO

USE [ZAD];
GO

