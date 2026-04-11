-- ================== تمكين xp_cmdshell ==================
EXEC sp_configure 'show advanced options', 1;
RECONFIGURE;
EXEC sp_configure 'xp_cmdshell', 1;
RECONFIGURE;
GO

-- ================== إنشاء المجلد إذا لم يكن موجود ==================
EXEC xp_cmdshell 'mkdir D:\ZAD';
EXEC xp_cmdshell 'mkdir D:\ZAD\DATA';
EXEC xp_cmdshell 'mkdir D:\ZAD\DATA\Backup';
GO

-- ================== إنشاء قاعدة البيانات ==================
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = N'ZAD')
BEGIN
    CREATE DATABASE [ZAD]
    ON PRIMARY
    (
        NAME = N'ZAD_Data',
        FILENAME = N'D:\ZAD\DATA\ZAD_Data.mdf',
        SIZE = 50MB,
        MAXSIZE = UNLIMITED,
        FILEGROWTH = 10MB
    )
    LOG ON
    (
        NAME = N'ZAD_Log',
        FILENAME = N'D:\ZAD\DATA\ZAD_Log.ldf',
        SIZE = 20MB,
        MAXSIZE = UNLIMITED,
        FILEGROWTH = 10MB
    );
END
GO

-- ================== استخدام قاعدة البيانات ==================
USE [ZAD];
GO
