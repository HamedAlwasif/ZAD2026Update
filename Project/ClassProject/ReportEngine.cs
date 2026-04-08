using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ZAD_Sales.ClassProject;

using System.IO;

using Microsoft.Reporting.WinForms;

using System.Windows.Forms;

namespace ZAD_Sales.ClassProject
{
   
    public class ReportEngine
    {

        public static readonly Dictionary<string, string> Reports = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            //----- مقاسات الورق العادية
            {"A4","ReportBillingA4.rdlc"},

            {"A5","ReportBillingA5.rdlc"},

            {"B5","ReportBillingB5.rdlc"},

            {"A5 - Discount","ReportBillingDiscountA5.rdlc"},


            //--------- مقاسات الكاشير

            {"Casher 6 mm","ReportBillingCasher.rdlc"},

            {"Casher 6 mm Disc","ReportBillingCasher_6cm_Dis.rdlc"},

            {"Casher 8 mm","ReportBillingCasher_8cm.rdlc"},

            {"Casher 8 mm No Discount", "ReportBillingCasher_8cm_NoDis.rdlc"},

            //------ طباعة خاصة

            {"A4 List","ReportBillingNoPrice_A4.rdlc"},

            {"A5 List","ReportBillingNoPrice.rdlc"}

        };

        //------------ خاص بالمقاسات

        public static readonly Dictionary<string, string> PaperWidths =
        new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {

            {"A4","21cm"},

            {"A5","14.8cm"},

            {"B5","17.6cm"},

            {"Casher 6 mm","5.7cm"},

            {"Casher 6 mm Disc","5.7cm"},

            {"Casher 8 mm","7.9cm"},

            {"Casher 8 mm No Discount","7.9cm"},

            {"A5 - Discount","14.8cm"},

            {"A4 List","21cm"},

            {"A5 List","14.8cm"}

        };

        public static LocalReport BuildReport(
        string reportFile,
        ReportDataSource source,
        InvoiceData data)
        {

            LocalReport report =
            new LocalReport();

            string path =
            Path.Combine(
            Application.StartupPath,
            "Reports",
            reportFile);

            report.ReportPath = path;

            report.DataSources.Clear();

            report.DataSources.Add(source);

            report.EnableExternalImages = true;

            ReportParameterBuilder.SetParameters(
            report,
            data);

            report.Refresh();

            return report;

        }
        //-------------A5  لو المقاس مش موجود يرجع الى 
        public static string GetReportFile(string size)
        {

            if (Reports.ContainsKey(size))
                return Reports[size];

            return Reports["A5"];

        }

        //----------- لاسترجاع التقارير الناقصة
        public static void ValidateReports()
        {

            List<string> missing =
            new List<string>();

            foreach (var report in Reports)
            {

                string path =
                Path.Combine(
                Application.StartupPath,
                "Reports",
                report.Value);

                if (!File.Exists(path))
                {

                    missing.Add(report.Value);

                }

            }

            if (missing.Count > 0)
            {

                MessageBox.Show(

                "Missing Reports:\n\n" +

                string.Join("\n", missing),

                "Report Error",

                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            }

        }


    }
}
