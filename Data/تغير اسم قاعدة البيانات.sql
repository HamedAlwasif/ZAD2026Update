/*==========================================================
  Script: Rename DB + Logical File Names + Physical MDF/LDF
  Old DB Name : Recovered_Recovered_ZAD
  New DB Name : ZAD

  Current files (before rename):
   - E:\Hamed\Data\Recovered_Recovered_ZAD.mdf
   - E:\Hamed\Data\Recovered_Recovered_ZAD_log.ldf

  Goal (after rename):
   - DB name: ZAD
   - Logical names: ZAD , ZAD_log
   - Physical files:
       E:\Hamed\Data\ZAD.mdf
       E:\Hamed\Data\ZAD_log.ldf
==========================================================*/

------------------------------------------------------------
-- (0) Optional: Show current logical/physical names before
------------------------------------------------------------
PRINT '--- BEFORE ---';
SELECT name AS logical_name, physical_name
FROM sys.master_files
WHERE database_id = DB_ID(N'Recovered_Recovered_ZAD');

------------------------------------------------------------
-- (1) Rename Database on SQL Server (Recovered... -> ZAD)  - إعادة تسمية قاعدة البيانات على خادم SQL
--     This does NOT change MDF/LDF file names yet. - هذا لا يغير أسماء ملفات MDF/LDF حتى الآن.
------------------------------------------------------------
PRINT '--- STEP 1: Rename database ---';

-- Close connections and force rollback - أغلق الاتصالات وأجبر على التراجع
ALTER DATABASE [Recovered_Recovered_ZAD] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

-- Rename DB
ALTER DATABASE [Recovered_Recovered_ZAD] MODIFY NAME = [ZAD];

-- Return to multi-user (we will switch again later) - العودة إلى وضع المستخدمين المتعددين (سنقوم بالتبديل مرة أخرى لاحقاً)
ALTER DATABASE [ZAD] SET MULTI_USER;

------------------------------------------------------------
-- (2) Confirm DB exists as ZAD and get current file info - تأكد من وجود قاعدة البيانات باسم ZAD واحصل على معلومات الملف الحالي
------------------------------------------------------------
PRINT '--- STEP 2: Confirm current file info for ZAD ---';
SELECT name AS logical_name, physical_name
FROM sys.master_files
WHERE database_id = DB_ID(N'ZAD');

------------------------------------------------------------
-- (3) Put DB in SINGLE_USER (ONLINE) to safely change metadata - ضع قاعدة البيانات في وضع المستخدم الفردي (عبر الإنترنت) لتغيير البيانات الوصفية بأمان
------------------------------------------------------------
PRINT '--- STEP 3: Set SINGLE_USER (ONLINE) ---';
ALTER DATABASE [ZAD] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

------------------------------------------------------------
-- (4) Rename Logical File Names (still ONLINE) - إعادة تسمية أسماء الملفات المنطقية (لا يزال متاحًا عبر الإنترنت)
--     From:
--       Recovered_Recovered_ZAD      -> ZAD
--       Recovered_Recovered_ZAD_log  -> ZAD_log
------------------------------------------------------------
PRINT '--- STEP 4: Rename logical file names ---';
ALTER DATABASE [ZAD] MODIFY FILE (NAME = N'Recovered_Recovered_ZAD',     NEWNAME = N'ZAD');
ALTER DATABASE [ZAD] MODIFY FILE (NAME = N'Recovered_Recovered_ZAD_log', NEWNAME = N'ZAD_log');

------------------------------------------------------------
-- (5) Tell SQL Server the NEW physical file names/paths (ONLINE) - إبلاغ خادم SQL بأسماء/مسارات الملفات الفعلية الجديدة (عبر الإنترنت)
--     NOTE: The files are NOT renamed on disk yet.  - ملاحظة: لم يتم تغيير أسماء الملفات على القرص بعد.
--           We are only updating SQL metadata so it expects the new names.  - نقوم فقط بتحديث بيانات تعريف SQL، لذا فهو يتوقع الأسماء الجديدة.
------------------------------------------------------------
PRINT '--- STEP 5: Update physical file paths in SQL metadata ---';
ALTER DATABASE [ZAD]
MODIFY FILE (NAME = N'ZAD',     FILENAME = N'E:\Hamed\Data\ZAD.mdf');

ALTER DATABASE [ZAD]
MODIFY FILE (NAME = N'ZAD_log', FILENAME = N'E:\Hamed\Data\ZAD_log.ldf');

------------------------------------------------------------
-- (6) Take DB OFFLINE (required before renaming files on disk)  قم بإيقاف تشغيل قاعدة البيانات (مطلوب قبل إعادة تسمية الملفات على القرص)
------------------------------------------------------------
PRINT '--- STEP 6: Set OFFLINE (now rename files in Windows) ---';
ALTER DATABASE [ZAD] SET OFFLINE WITH ROLLBACK IMMEDIATE;

------------------------------------------------------------
/*
  (7) MANUAL STEP (WINDOWS):   الخطوة اليدوية (ويندوز): :
      Go to folder: انتقل إلى المجلد
         E:\Hamed\Data\

      Rename files:  أعد تسمية الملفات
         Recovered_Recovered_ZAD.mdf      -->  ZAD.mdf
         Recovered_Recovered_ZAD_log.ldf  -->  ZAD_log.ldf

      After renaming the files, come back and run STEP 8.  بعد إعادة تسمية الملفات، ارجع ونفّذ الخطوة 8.
*/
------------------------------------------------------------

------------------------------------------------------------
-- (8) Bring DB ONLINE and return MULTI_USER - قم بتشغيل قاعدة البيانات عبر الإنترنت وأرجع MULTI_USER
------------------------------------------------------------
PRINT '--- STEP 8: Set ONLINE + MULTI_USER ---';
ALTER DATABASE [ZAD] SET ONLINE;
ALTER DATABASE [ZAD] SET MULTI_USER;

------------------------------------------------------------
-- (9) FINAL CHECK: show final logical + physical names - التدقيق النهائي: عرض الأسماء المنطقية والفعلية النهائية
------------------------------------------------------------
PRINT '--- AFTER ---';
SELECT name AS logical_name, physical_name
FROM sys.master_files
WHERE database_id = DB_ID(N'ZAD');
