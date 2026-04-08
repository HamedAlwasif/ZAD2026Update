using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;



using ZAD_Sales.ClassProject;

namespace ZAD_Sales.Reports
{

    public partial class Frm_ReportBill : Form
    {

        public InvoiceData InvoiceDataObj;

        public ReportDataSource ReportSource;

        public LocalReport CurrentReport;

        // Report mapping
        //  Dictionary<string, ReportInfo> Reports = new Dictionary<string, ReportInfo>();

       // Dictionary<string, string> Reports =new Dictionary<string, string>();

        

        string PrinterBill = "";
        string SizePaperBill = "";
        string imageLogoUrl;

        ReportDataSource rs;

       // public ReportDataSource ReportSource;


        public Frm_ReportBill()
        {
            InitializeComponent();
            

        }

        LocalReport BuildReport(string reportFile)
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

            report.DataSources.Add(
            ReportSource);

            report.EnableExternalImages = true;

            ReportParameterBuilder.SetParameters(
            report,
            InvoiceDataObj);

            report.Refresh();

            return report;

        }
        //LocalReport BuildReport(string reportFile)
        //{

        //    LocalReport report =
        //    new LocalReport();

        //    string path =
        //    Path.Combine(
        //    Application.StartupPath,
        //    "Reports",
        //    reportFile);

        //    report.ReportPath = path;

        //    report.DataSources.Clear();

        //    report.DataSources.Add(
        //    ReportSource);

        //    report.EnableExternalImages = true;

        //    ReportParameterBuilder.SetParameters(
        //    report,
        //    InvoiceDataObj);

        //    report.Refresh();

        //    return report;

        //}

        //class ReportInfo
        //{

        //    public ReportViewer Viewer { get; set; }

        //    public string File { get; set; }

        //}

        //void HideAllReports()
        //{

        //    reportViewerA4.Visible = false;

        //    reportViewerA5.Visible = false;

        //    reportViewerB5.Visible = false;

        //    reportViewerCasher.Visible = false;

        //    reportViewerCasher_6cm_Dis.Visible = false;

        //    reportViewerCasher_8cm.Visible = false;

        //    reportViewerCasher_8cm_NoDis.Visible = false;

        //    reportViewerDiscount.Visible = false;

        //    reportViewerRepEmp.Visible = false;

        //    reportViewerRepEmpA4.Visible = false;

        //}
        //void LoadReport(string size)
        //{

        //    if (!Reports.ContainsKey(size))
        //    {

        //        MessageBox.Show("Report not defined");

        //        return;

        //    }

        //    var report = Reports[size];

        //    HideAllReports();

        //    LoadReport(
        //    report.Viewer,
        //    report.File);

        //    report.Viewer.Visible = true;

        //}
        //void LoadReport(string size)
        //{

        //    if (!Reports.ContainsKey(size))
        //        return;

        //    CurrentReport =
        //    BuildReport(Reports[size]);

        //    reportViewerMain.LocalReport =
        //    CurrentReport;

        //    reportViewerMain.RefreshReport();

        //    reportViewerMain.SetDisplayMode(
        //    DisplayMode.PrintLayout);

        //    reportViewerMain.ZoomMode =
        //    ZoomMode.PageWidth;

        //}

        void LoadReport(string size)
        {

            if (!ReportEngine.Reports.ContainsKey(size))
                return;

            //CurrentReport =
            //ReportEngine.BuildReport(
            //ReportEngine.Reports[size],
            //ReportSource,
            //InvoiceDataObj);

            CurrentReport =
            ReportEngine.BuildReport(
            ReportEngine.GetReportFile(size),
            ReportSource,
            InvoiceDataObj);

            reportViewerMain.LocalReport.ReportPath =
            CurrentReport.ReportPath;

            reportViewerMain.LocalReport.DataSources.Clear();

            foreach (var ds in CurrentReport.DataSources)
            {

                reportViewerMain.LocalReport.DataSources.Add(ds);

            }

            reportViewerMain.LocalReport.EnableExternalImages = true;

            ReportParameterBuilder.SetParameters(
            reportViewerMain.LocalReport,
            InvoiceDataObj);

            reportViewerMain.RefreshReport();

        }
        //void LoadReport(string size)
        //{

        //    //            if (!Reports.ContainsKey(size))
        //    //                return;

        //    //            //CurrentReport =
        //    //            //BuildReport(Reports[size]);

        //    //            CurrentReport =
        //    //ReportEngine.BuildReport(
        //    //Reports[size],
        //    //ReportSource,
        //    //InvoiceDataObj);

        //    if (!ReportEngine.Reports.ContainsKey(size))
        //        return;

        //    CurrentReport =
        //    ReportEngine.BuildReport(
        //    ReportEngine.Reports[size],
        //    ReportSource,
        //    InvoiceDataObj);

        //    reportViewerMain.LocalReport.ReportPath =
        //    CurrentReport.ReportPath;

        //    reportViewerMain.LocalReport.DataSources.Clear();

        //    foreach (var ds in CurrentReport.DataSources)
        //    {

        //        reportViewerMain.LocalReport.DataSources.Add(ds);

        //    }

        //    reportViewerMain.LocalReport.EnableExternalImages = true;

        //    ReportParameterBuilder.SetParameters(
        //    reportViewerMain.LocalReport,
        //    InvoiceDataObj);

        //    reportViewerMain.RefreshReport();

        //    reportViewerMain.SetDisplayMode(
        //    DisplayMode.PrintLayout);

        //    reportViewerMain.ZoomMode =
        //    ZoomMode.PageWidth;

        //}

        private void Frm_ReportBill_Load(object sender, EventArgs e)
        {

            imageLogoUrl = AppSetting.Comp_Logo;


            //---------- ايجاد الطابعه الافتراضية وحجم الورقة -----
            PrinterBill = AppSetting.PrinterBill;
            SizePaperBill = AppSetting.SizePaperBill;
            //-----------------------------------


            // Mapping reports

           // Reports.Add("A4",
           // "ReportBillingA4.rdlc");

           // Reports.Add("A5",
           // "ReportBillingA5.rdlc");

           // Reports.Add("B5",
           // "ReportBillingB5.rdlc");

           // Reports.Add("Casher 6 mm",
           // "ReportBillingCasher.rdlc");

           // Reports.Add("Casher 6 mm Disc",
           // "ReportBillingCasher_6cm_Dis.rdlc");

           // Reports.Add("Casher 8 mm",
           // "ReportBillingCasher_8cm.rdlc");

           // Reports.Add("Casher 8 mm No Discount",
           // "ReportBillingCasher_8cm_NoDis.rdlc");

           // Reports.Add("A5 - Discount",
           //"ReportBillingDiscountA5.rdlc");

           // Reports.Add("A4 List",
           //"ReportBillingNoPrice_A4.rdlc");

           // Reports.Add("A5 List",
           //"ReportBillingNoPrice.rdlc");


            LoadReport(SizePaperBill);





            //Reports.Add("A4",
            //new ReportInfo
            //{

            //    Viewer = reportViewerA4,

            //    File = "ReportBillingA4.rdlc"

            //});

            //Reports.Add("A5",
            //new ReportInfo
            //{

            //    Viewer = reportViewerA5,

            //    File = "ReportBillingA5.rdlc"

            //});

            //Reports.Add("B5",
            //new ReportInfo
            //{

            //    Viewer = reportViewerB5,

            //    File = "ReportBillingB5.rdlc"

            //});

            //Reports.Add("Casher 6 mm",
            //new ReportInfo
            //{

            //    Viewer = reportViewerCasher_6cm_Dis,

            //    File = "ReportBillingCasher_6cm_Dis.rdlc"

            //});

            //   Reports.Add("Casher 6 mm",
            //new ReportInfo
            //{

            //    Viewer = reportViewerCasher,

            //    File = "ReportBillingCasher.rdlc"

            //});

            //   Reports.Add("Casher 6 mm Disc",
            //             new ReportInfo
            //             {

            //                 Viewer = reportViewerCasher_6cm_Dis,

            //                 File = "ReportBillingCasher_6cm_Dis.rdlc"

            //             });

            //   Reports.Add("Casher 8 mm",
            //   new ReportInfo
            //   {

            //       Viewer = reportViewerCasher_8cm,

            //       File = "ReportBillingCasher_8cm.rdlc"

            //   });

            //   Reports.Add("Casher 8 mm No Discount",
            //   new ReportInfo
            //   {

            //       Viewer = reportViewerCasher_8cm_NoDis,

            //       File = "ReportBillingCasher_8cm_NoDis.rdlc"

            //   });

            //   Reports.Add("A5 - Discount",
            //   new ReportInfo
            //   {

            //       Viewer = reportViewerDiscount,

            //       File = "ReportBillingDiscountA5.rdlc"

            //   });

            //   Reports.Add("A4 List",
            //   new ReportInfo
            //   {

            //       Viewer = reportViewerRepEmpA4,

            //       File = "ReportBillingNoPrice_A4.rdlc"

            //   });

            //   Reports.Add("A5 List",
            //   new ReportInfo
            //   {

            //       Viewer = reportViewerRepEmp,

            //       File = "ReportBillingNoPrice.rdlc"

            //   });


            // Load default report

            //   LoadReport(SizePaperBill);

            //-------------------------------------------






            //if (SizePaperBill == "A4")
            //{

            //    buttA4.PerformClick();

            //}
            //else if (SizePaperBill == "A5")
            //{

            //    buttA5.PerformClick();


            //}
            //else if (SizePaperBill == "B5")
            //{

            //    buttB5.PerformClick();

            //}
            //else if (SizePaperBill == "A5 - Discount")
            //{
            //    button4.PerformClick();

            //}
            //else if (SizePaperBill == "Casher 6 mm")
            //{

            //    buttCaser6.PerformClick();

            //}
            //else if (SizePaperBill == "Casher 8 mm No Discount")
            //{
            //    buttCaser8cm_NoDes.PerformClick();
            //   // buttCaser8cm.PerformClick();
            //}
            //else if (SizePaperBill == "Casher 8 mm")
            //{
            //    buttCaser8cm.PerformClick();

            //   // buttCaser8cm_NoDes.PerformClick();
            //}
            //else if (SizePaperBill == "A4 List")
            //{

            //    buttNoPriceA4.PerformClick();

            //}
            //else if (SizePaperBill == "A5 List")
            //{

            //    buttNoPriceA4.PerformClick();

            //}
            //else
            //{
            //    MessageBox.Show("    لم يتم اختيار حجم الورقة الافتراضى     ", "خطأ");
            //}



        }

        //private void getprameterreports(ReportViewer reportchange)

        //{


        //    try
        //    {
        //        FileInfo fi = new FileInfo(imageLogoUrl);
        //        //  ReportParameter pName = new ReportParameter("pName", fi.Name);
        //        ReportParameter pImageUrl = new ReportParameter("parmImageUrl", new Uri(imageLogoUrl).AbsoluteUri);
        //        reportchange.LocalReport.EnableExternalImages = true;
        //        reportchange.LocalReport.SetParameters(new ReportParameter[] { pImageUrl });
        //        reportchange.RefreshReport();
        //    }
        //    catch
        //    { }

        //    //-------------------------------------------------------------


        //    List<ReportParameter> list_Company_Name = new List<ReportParameter>();
        //    ReportParameter parm_Company_Name = new ReportParameter("Parm_Company_Name", AppSetting.textCompany_Name ?? "");
        //    list_Company_Name.Add(parm_Company_Name);
        //    reportchange.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Name });

        //    //***********************
        //    List<ReportParameter> list_Company_Address = new List<ReportParameter>();
        //    ReportParameter parm_Company_Address = new ReportParameter("Parm_Company_Address", AppSetting.textCompany_Address);
        //    list_Company_Address.Add(parm_Company_Address);
        //    reportchange.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Address });



        //    //***********************

        //    //***********************

        //    List<ReportParameter> list_Company_Description = new List<ReportParameter>();
        //    ReportParameter parm_Company_Description = new ReportParameter("Parm_Company_Description", AppSetting.textCompany_Description);
        //    list_Company_Description.Add(parm_Company_Description);
        //    reportchange.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });


        //    //***********************



        //    List<ReportParameter> list_Company_Phone = new List<ReportParameter>();
        //    ReportParameter parm_Company_Phone = new ReportParameter("Parm_Company_Phone", AppSetting.textCompany_Phone);
        //    list_Company_Phone.Add(parm_Company_Phone);
        //    reportchange.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Phone });


        //    //------------------------------------
        //    List<ReportParameter> list_NoteToBill = new List<ReportParameter>();
        //    ReportParameter parm_NoteToBill = new ReportParameter("Parm_NoteToBill", AppSetting.NoteToBill);
        //    list_NoteToBill.Add(parm_NoteToBill);
        //    reportchange.LocalReport.SetParameters(new ReportParameter[] { parm_NoteToBill });

        //    //------------------------------------

        //    List<ReportParameter> list17 = new List<ReportParameter>();
        //    ReportParameter parm17 = new ReportParameter("Parm_MoveBill", AppSetting.MoveBill);
        //    list17.Add(parm17);
        //    reportchange.LocalReport.SetParameters(new ReportParameter[] { parm17 });


        //    //------------------------------------
        //    List<ReportParameter> list1 = new List<ReportParameter>();
        //    ReportParameter parm1 = new ReportParameter("TypeBill", AppSetting.TypeBill);
        //    list1.Add(parm1);
        //    reportchange.LocalReport.SetParameters(new ReportParameter[] { parm1 });

        //    //------------------------------------
        //    List<ReportParameter> list2 = new List<ReportParameter>();
        //    ReportParameter parm2 = new ReportParameter("Name", AppSetting.ClintName);
        //    list2.Add(parm2);
        //    reportchange.LocalReport.SetParameters(new ReportParameter[] { parm2 });

        //    //------------------------------------

        //    List<ReportParameter> list3 = new List<ReportParameter>();
        //    ReportParameter parm3 = new ReportParameter("Print", AppSetting.user);
        //    list3.Add(parm3);
        //    reportchange.LocalReport.SetParameters(new ReportParameter[] { parm3 });


        //    //------------------------------------

        //    List<ReportParameter> list4 = new List<ReportParameter>();
        //    ReportParameter parm4 = new ReportParameter("NumBill", AppSetting.BillingDataNumBill);
        //    list4.Add(parm4);
        //    reportchange.LocalReport.SetParameters(new ReportParameter[] { parm4 });

        //    //------------------------------------

        //    List<ReportParameter> list5 = new List<ReportParameter>();
        //    ReportParameter parm5 = new ReportParameter("Date", AppSetting.dateTimePicker1);
        //    list5.Add(parm5);
        //    reportchange.LocalReport.SetParameters(new ReportParameter[] { parm5 });

        //    //------------------------------------

        //    List<ReportParameter> list6 = new List<ReportParameter>();
        //    ReportParameter parm6 = new ReportParameter("Total", AppSetting.TotalBill);
        //    list6.Add(parm6);
        //    reportchange.LocalReport.SetParameters(new ReportParameter[] { parm6 });

        //    //------------------------------------
        //    List<ReportParameter> list7 = new List<ReportParameter>();
        //    ReportParameter parm7 = new ReportParameter("Sabek", AppSetting.RemaningOld);
        //    list7.Add(parm7);
        //    reportchange.LocalReport.SetParameters(new ReportParameter[] { parm7 });

        //    //------------------------------------
        //    List<ReportParameter> list9 = new List<ReportParameter>();
        //    ReportParameter parm9 = new ReportParameter("Discount", AppSetting.Dic);
        //    list9.Add(parm9);
        //    reportchange.LocalReport.SetParameters(new ReportParameter[] { parm9 });

        //    //------------------------------------
        //    List<ReportParameter> list10 = new List<ReportParameter>();
        //    ReportParameter parm10 = new ReportParameter("Mosadad", AppSetting.Mosadad);
        //    list10.Add(parm10);
        //    reportchange.LocalReport.SetParameters(new ReportParameter[] { parm10 });


        //    //------------------------------------
        //    List<ReportParameter> list11 = new List<ReportParameter>();
        //    ReportParameter parm11 = new ReportParameter("Remaning", AppSetting.RemainingNow);
        //    list11.Add(parm11);
        //    reportchange.LocalReport.SetParameters(new ReportParameter[] { parm11 });

        //    //------------------------------------
        //    List<ReportParameter> list111 = new List<ReportParameter>();
        //    ReportParameter parm111 = new ReportParameter("Demo", AppSetting.DemoOnBill);
        //    list111.Add(parm111);
        //    reportchange.LocalReport.SetParameters(new ReportParameter[] { parm111 });



        //}

        private void getprameterreports(ReportViewer reportchange)
        {
            if (reportchange.LocalReport == null)
                return;

            try
            {

                List<ReportParameter> allParams =
                new List<ReportParameter>();

                // Company
                allParams.Add(new ReportParameter(
                "Parm_Company_Name",
                AppSetting.textCompany_Name ?? ""));

                allParams.Add(new ReportParameter(
                "Parm_Company_Address",
                AppSetting.textCompany_Address ?? ""));

                allParams.Add(new ReportParameter(
                "Parm_Company_Description",
                AppSetting.textCompany_Description ?? ""));

                allParams.Add(new ReportParameter(
                "Parm_Company_Phone",
                AppSetting.textCompany_Phone ?? ""));

                // Bill info
                allParams.Add(new ReportParameter(
                "Parm_NoteToBill",
                AppSetting.NoteToBill ?? ""));

                allParams.Add(new ReportParameter(
                "Parm_MoveBill",
                AppSetting.MoveBill ?? ""));

                allParams.Add(new ReportParameter(
                "TypeBill",
                AppSetting.TypeBill ?? ""));

                allParams.Add(new ReportParameter(
                "Name",
                AppSetting.ClintName ?? ""));

                allParams.Add(new ReportParameter(
                "Print",
                AppSetting.user ?? ""));

                allParams.Add(new ReportParameter(
                "NumBill",
                AppSetting.BillingDataNumBill ?? ""));

                allParams.Add(new ReportParameter(
                "Date",
                AppSetting.dateTimePicker1 ?? ""));

                // Money
                allParams.Add(new ReportParameter(
                "Total",
                AppSetting.TotalBill ?? "0"));

                allParams.Add(new ReportParameter(
                "Sabek",
                AppSetting.RemaningOld ?? "0"));

                allParams.Add(new ReportParameter(
                "Discount",
                AppSetting.Dic ?? "0"));

                allParams.Add(new ReportParameter(
                "Mosadad",
                AppSetting.Mosadad ?? "0"));

                allParams.Add(new ReportParameter(
                "Remaning",
                AppSetting.RemainingNow ?? "0"));

                allParams.Add(new ReportParameter(
                "Demo",
                AppSetting.DemoOnBill ?? ""));

                // Logo
                string logoPath =
                AppSetting.Comp_Logo ?? "";

                reportchange.LocalReport.EnableExternalImages = true;

                allParams.Add(new ReportParameter(
                "parmImageUrl",

                File.Exists(logoPath)
                ? new Uri(logoPath).AbsoluteUri
                : ""));

                // Apply once
                reportchange.LocalReport.SetParameters(allParams);

                reportchange.RefreshReport();

            }
            catch (Exception ex)
            {

                MessageBox.Show(
                "Report Parameter Error\n" +
                ex.Message);

            }

        }

        void LoadReport(ReportViewer viewer, string reportName)
        {

            if (string.IsNullOrEmpty(
            viewer.LocalReport.ReportPath))
            {

                viewer.LocalReport.ReportPath =
                Path.Combine(
                Application.StartupPath,
                "Reports",
                reportName);

            }

            getprameterreports(viewer);

            viewer.RefreshReport();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            

        }
        private void ColorBut()
        {
            butA5.BackColor = Color.LightSeaGreen;
            butA4.BackColor = Color.LightSeaGreen;
            butB5.BackColor = Color.LightSeaGreen;
            butCaser.BackColor = Color.LightSeaGreen;
            butReportEmp.BackColor = Color.LightSeaGreen;
            button2.BackColor = Color.LightSeaGreen;
            butCaser8cm.BackColor = Color.LightSeaGreen;
            butCaser8cm_NoDes.BackColor = Color.LightSeaGreen;
            butNoPriceA4.BackColor = Color.LightSeaGreen;
        }
        private void butA5_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewerA5, "ReportBillingA5.rdlc");

          //  getprameterreports(reportViewerA5);

            reportViewerA4.Visible = false;
            reportViewerA5.Visible = true;
            reportViewerCasher.Visible = false;
            reportViewerRepEmp.Visible = false;
            reportViewerB5.Visible = false;
            reportViewerDiscount.Visible = false;
            reportViewerCasher_8cm.Visible = false;
            reportViewerCasher_8cm_NoDis.Visible = false;

            reportViewerRepEmpA4.Visible = false;


            ColorBut();

            butA5.BackColor = Color.Red;
            
        }

        private void butB5_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewerB5, "ReportBillingB5.rdlc");


          //  getprameterreports(reportViewerB5);

            reportViewerA4.Visible = false;
            reportViewerA5.Visible = false;
            reportViewerCasher.Visible = false;
            reportViewerRepEmp.Visible = false;
            reportViewerB5.Visible = true;
            reportViewerDiscount.Visible = false;
            reportViewerCasher_8cm.Visible = false;
            reportViewerCasher_8cm_NoDis.Visible = false;
            reportViewerRepEmpA4.Visible = false;



            ColorBut();

            //butA5.BackColor = Color.Green;
            //butA4.BackColor = Color.Green;
            butB5.BackColor = Color.Red;
            //butCaser.BackColor = Color.Green;
            //butReportEmp.BackColor = Color.Green;
            //button2.BackColor = Color.Green;
            //butCaser8cm.BackColor = Color.Green;
            //butCaser8cm_NoDes.BackColor = Color.Green;
            //butNoPriceA4.BackColor = Color.Green;

           // this.reportViewerB5.RefreshReport();
        }

        private void butA4_Click(object sender, EventArgs e)
        {

            LoadReport(reportViewerA4, "ReportBillingA4.rdlc");

           // getprameterreports(reportViewerA4);

            reportViewerA4.Visible = true;
            reportViewerA5.Visible = false;
            reportViewerCasher.Visible = false;
            reportViewerRepEmp.Visible = false;
            reportViewerB5.Visible = false;
            reportViewerDiscount.Visible = false;
            reportViewerCasher_8cm.Visible = false;
            reportViewerCasher_8cm_NoDis.Visible = false;
            reportViewerRepEmpA4.Visible = false;


            ColorBut();
            //butA5.BackColor = Color.Green;
            butA4.BackColor = Color.Red;
            //butB5.BackColor = Color.Green;
            //butCaser.BackColor = Color.Green;
            //butReportEmp.BackColor = Color.Green;
            //button2.BackColor = Color.Green;
            //butCaser8cm.BackColor = Color.Green;
            //butCaser8cm_NoDes.BackColor = Color.Green;
            //butNoPriceA4.BackColor = Color.Green;

           // this.reportViewerA4.RefreshReport();
        }

        private void butCaser_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewerCasher, "ReportBillingCasher.rdlc");


           // getprameterreports(reportViewerCasher);

            reportViewerA4.Visible = false;
            reportViewerA5.Visible = false;
            reportViewerCasher.Visible = true;
            reportViewerRepEmp.Visible = false;
            reportViewerB5.Visible = false;
            reportViewerDiscount.Visible = false;
            reportViewerCasher_8cm.Visible = false;
            reportViewerCasher_8cm_NoDis.Visible = false;
            reportViewerRepEmpA4.Visible = false;




            ColorBut();

            //butA5.BackColor = Color.Green;
            //butA4.BackColor = Color.Green;
            //butB5.BackColor = Color.Green;
            butCaser.BackColor = Color.Red;
            //butReportEmp.BackColor = Color.Green;
            //button2.BackColor = Color.Green;
            //butCaser8cm.BackColor = Color.Green;
            //butCaser8cm_NoDes.BackColor = Color.Green;
            //butNoPriceA4.BackColor = Color.Green;

           // this.reportViewerCasher.RefreshReport();
        }

        private void butReportEmp_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewerRepEmp, "ReportBillingCasher.rdlc");


           // getprameterreports(reportViewerRepEmp);

            reportViewerA4.Visible = false;
            reportViewerA5.Visible = false;
            reportViewerCasher.Visible = false;
            reportViewerRepEmp.Visible = true;
            reportViewerB5.Visible = false;
            reportViewerDiscount.Visible = false;
            reportViewerCasher_8cm.Visible = false;
            reportViewerCasher_8cm_NoDis.Visible = false;
            reportViewerRepEmpA4.Visible = false;


            ColorBut();
            //butA5.BackColor = Color.Green;
            //butA4.BackColor = Color.Green;
            //butB5.BackColor = Color.Green;
            //butCaser.BackColor = Color.Green;
            butReportEmp.BackColor = Color.Red;
            //button2.BackColor = Color.Green;
            //butCaser8cm.BackColor = Color.Green;
            //butCaser8cm_NoDes.BackColor = Color.Green;
            //butNoPriceA4.BackColor = Color.Green;

           // this.reportViewerRepEmp.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getprameterreports(reportViewerDiscount);

            reportViewerA4.Visible = false;
            reportViewerA5.Visible = false;
            reportViewerCasher.Visible = false;
            reportViewerRepEmp.Visible = false;
            reportViewerB5.Visible = false;
            reportViewerDiscount.Visible = true;
            reportViewerCasher_8cm.Visible = false;
            reportViewerCasher_8cm_NoDis.Visible = false;
            reportViewerRepEmpA4.Visible = false;


            ColorBut();
            //butA5.BackColor = Color.Green;
            //butA4.BackColor = Color.Green;
            //butB5.BackColor = Color.Green;
            //butCaser.BackColor = Color.Green;
            //butReportEmp.BackColor = Color.Green;
            button2.BackColor = Color.Red;
            //butCaser8cm.BackColor = Color.Green;
            //butCaser8cm_NoDes.BackColor = Color.Green;
            //butNoPriceA4.BackColor = Color.Green;
            
            
            this.reportViewerDiscount.RefreshReport();
        }

        private void butCaser8cm_Click(object sender, EventArgs e)
        {
            getprameterreports(reportViewerCasher_8cm);

            reportViewerA4.Visible = false;
            reportViewerA5.Visible = false;
            reportViewerCasher.Visible = false;
            reportViewerRepEmp.Visible = false;
            reportViewerB5.Visible = false;
            reportViewerDiscount.Visible = false;
            reportViewerRepEmpA4.Visible = false;

            reportViewerCasher_8cm.Visible = true;

            reportViewerCasher_8cm_NoDis.Visible = false;



            ColorBut();
            //butA5.BackColor = Color.Green;
            //butA4.BackColor = Color.Green;
            //butB5.BackColor = Color.Green;
            //butCaser.BackColor = Color.Green;
            //butReportEmp.BackColor = Color.Green;
            //button2.BackColor = Color.Green;
            butCaser8cm.BackColor = Color.Red;
            //butCaser8cm_NoDes.BackColor = Color.Green;
            //butNoPriceA4.BackColor = Color.Green;

            this.reportViewerCasher_8cm.RefreshReport();
        }

        private void butNoPriceA4_Click(object sender, EventArgs e)
        {
            getprameterreports(reportViewerRepEmpA4);

            reportViewerA4.Visible = false;
            reportViewerA5.Visible = false;
            reportViewerCasher.Visible = false;
            reportViewerRepEmp.Visible = false;
            reportViewerB5.Visible = false;
            reportViewerDiscount.Visible = false;
            reportViewerCasher_8cm.Visible = false;
            reportViewerCasher_8cm_NoDis.Visible = false;
            reportViewerRepEmpA4.Visible = true;


            ColorBut();
            //butA5.BackColor = Color.Green;
            //butA4.BackColor = Color.Green;
            //butB5.BackColor = Color.Green;
            //butCaser.BackColor = Color.Green;
            //butReportEmp.BackColor = Color.Green;
            //button2.BackColor = Color.Green;
            //butCaser8cm.BackColor = Color.Green;
            //butCaser8cm_NoDes.BackColor = Color.Green;
            butNoPriceA4.BackColor = Color.Red;

            this.reportViewerRepEmpA4.RefreshReport();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            getprameterreports(reportViewerCasher_8cm_NoDis);

            reportViewerA4.Visible = false;
            reportViewerA5.Visible = false;
            reportViewerCasher.Visible = false;
            reportViewerRepEmp.Visible = false;
            reportViewerB5.Visible = false;
            reportViewerDiscount.Visible = false;
            reportViewerRepEmpA4.Visible = false;

            reportViewerCasher_8cm.Visible = false;
            reportViewerCasher_8cm_NoDis.Visible = true;



            ColorBut();
            //butA5.BackColor = Color.Green;
            //butA4.BackColor = Color.Green;
            //butB5.BackColor = Color.Green;
            //butCaser.BackColor = Color.Green;
            //butReportEmp.BackColor = Color.Green;
            //button2.BackColor = Color.Green;
            //butCaser8cm.BackColor = Color.Green;
            //butCaser8cm_NoDes.BackColor = Color.Red;
            //butNoPriceA4.BackColor = Color.Green;

            this.reportViewerCasher_8cm_NoDis.RefreshReport();
        }

        private void buttA5_Click(object sender, EventArgs e)
        {
            LoadReport("A5");

            ColorBut();

            butA5.BackColor =
            Color.Red;


            //LoadReport(reportViewerA5,"ReportBillingA5.rdlc");

            //reportViewerCasher_6cm_Dis.Visible = false;
            //reportViewerA4.Visible = false;
            //reportViewerA5.Visible = true;
            //reportViewerCasher.Visible = false;
            //reportViewerRepEmp.Visible = false;
            //reportViewerB5.Visible = false;
            //reportViewerDiscount.Visible = false;
            //reportViewerCasher_8cm.Visible = false;
            //reportViewerCasher_8cm_NoDis.Visible = false;

            //reportViewerRepEmpA4.Visible = false;


            //ColorBut();

            //butA5.BackColor = Color.Red;

        }

        private void buttB5_Click(object sender, EventArgs e)
        {
            LoadReport("B5");


          //  LoadReport(reportViewerB5,"ReportBillingB5.rdlc");


           // getprameterreports(reportViewerB5);

            reportViewerCasher_6cm_Dis.Visible = false;
            reportViewerA4.Visible = false;
            reportViewerA5.Visible = false;
            reportViewerCasher.Visible = false;
            reportViewerRepEmp.Visible = false;
            reportViewerB5.Visible = true;
            reportViewerDiscount.Visible = false;
            reportViewerCasher_8cm.Visible = false;
            reportViewerCasher_8cm_NoDis.Visible = false;
            reportViewerRepEmpA4.Visible = false;



            ColorBut();

            
            butB5.BackColor = Color.Red;
           
        }

        private void buttA4_Click(object sender, EventArgs e)
        {
            LoadReport("A4");

           // LoadReport(reportViewerA4,"ReportBillingA4.rdlc");
          
            //getprameterreports(reportViewerA4);

            //reportViewerCasher_6cm_Dis.Visible = false;
            //reportViewerA4.Visible = true;
            //reportViewerA5.Visible = false;
            //reportViewerCasher.Visible = false;
            //reportViewerRepEmp.Visible = false;
            //reportViewerB5.Visible = false;
            //reportViewerDiscount.Visible = false;
            //reportViewerCasher_8cm.Visible = false;
            //reportViewerCasher_8cm_NoDis.Visible = false;
            //reportViewerRepEmpA4.Visible = false;


            ColorBut();
            
            butA4.BackColor = Color.Red;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadReport("A5 - Discount");



            //LoadReport(reportViewerDiscount, "ReportBillingDiscountA5.rdlc");

            //getprameterreports(reportViewerDiscount);

            //reportViewerCasher_6cm_Dis.Visible = false;
            //reportViewerA4.Visible = false;
            //reportViewerA5.Visible = false;
            //reportViewerCasher.Visible = false;
            //reportViewerRepEmp.Visible = false;
            //reportViewerB5.Visible = false;
            //reportViewerDiscount.Visible = true;
            //reportViewerCasher_8cm.Visible = false;
            //reportViewerCasher_8cm_NoDis.Visible = false;
            //reportViewerRepEmpA4.Visible = false;


            ColorBut();
            //butA5.BackColor = Color.Green;
            //butA4.BackColor = Color.Green;
            //butB5.BackColor = Color.Green;
            //butCaser.BackColor = Color.Green;
            //butReportEmp.BackColor = Color.Green;
            button2.BackColor = Color.Red;
            //butCaser8cm.BackColor = Color.Green;
            //butCaser8cm_NoDes.BackColor = Color.Green;
            //butNoPriceA4.BackColor = Color.Green;


            this.reportViewerDiscount.RefreshReport();
        }

        private void buttCaser6_Click(object sender, EventArgs e)
        {
            LoadReport("Casher 6 mm");


            // LoadReport(reportViewerCasher,"ReportBillingCasher.rdlc");


            //// getprameterreports(reportViewerCasher);

            // reportViewerCasher_6cm_Dis.Visible = false;
            // reportViewerA4.Visible = false;
            // reportViewerA5.Visible = false;
            // reportViewerCasher.Visible = true;
            // reportViewerRepEmp.Visible = false;
            // reportViewerB5.Visible = false;
            // reportViewerDiscount.Visible = false;
            // reportViewerCasher_8cm.Visible = false;
            // reportViewerCasher_8cm_NoDis.Visible = false;
            // reportViewerRepEmpA4.Visible = false;




            ColorBut();

            //butA5.BackColor = Color.Green;
            //butA4.BackColor = Color.Green;
            //butB5.BackColor = Color.Green;
            butCaser.BackColor = Color.Red;
            //butReportEmp.BackColor = Color.Green;
            //button2.BackColor = Color.Green;
            //butCaser8cm.BackColor = Color.Green;
            //butCaser8cm_NoDes.BackColor = Color.Green;
            //butNoPriceA4.BackColor = Color.Green;

           // this.reportViewerCasher.RefreshReport();
        }

        private void buttCaser8cm_Click(object sender, EventArgs e)
        {
            LoadReport("Casher 8 mm");


           // LoadReport(reportViewerCasher_8cm, "ReportBillingCasher_8cm.rdlc");

          //  getprameterreports(reportViewerCasher_8cm);

            //reportViewerCasher_6cm_Dis.Visible = false;
            //reportViewerA4.Visible = false;
            //reportViewerA5.Visible = false;
            //reportViewerCasher.Visible = false;
            //reportViewerRepEmp.Visible = false;
            //reportViewerB5.Visible = false;
            //reportViewerDiscount.Visible = false;
            //reportViewerRepEmpA4.Visible = false;

            //reportViewerCasher_8cm.Visible = true;

            //reportViewerCasher_8cm_NoDis.Visible = false;



            ColorBut();
            //butA5.BackColor = Color.Green;
            //butA4.BackColor = Color.Green;
            //butB5.BackColor = Color.Green;
            //butCaser.BackColor = Color.Green;
            //butReportEmp.BackColor = Color.Green;
            //button2.BackColor = Color.Green;
            butCaser8cm.BackColor = Color.Red;
            //butCaser8cm_NoDes.BackColor = Color.Green;
            //butNoPriceA4.BackColor = Color.Green;

           // this.reportViewerCasher_8cm.RefreshReport();
        }

        private void buttCaser8cm_NoDes_Click(object sender, EventArgs e)
        {
            LoadReport("Casher 8 mm No Discount");



            // LoadReport(reportViewerCasher_8cm_NoDis, "ReportBillingCasher_8cm_NoDis.rdlc");

           // getprameterreports(reportViewerCasher_8cm_NoDis);

            //reportViewerCasher_6cm_Dis.Visible = false;
            //reportViewerA4.Visible = false;
            //reportViewerA5.Visible = false;
            //reportViewerCasher.Visible = false;
            //reportViewerRepEmp.Visible = false;
            //reportViewerB5.Visible = false;
            //reportViewerDiscount.Visible = false;
            //reportViewerRepEmpA4.Visible = false;

            //reportViewerCasher_8cm.Visible = false;
            //reportViewerCasher_8cm_NoDis.Visible = true;



            ColorBut();
            //butA5.BackColor = Color.Green;
            //butA4.BackColor = Color.Green;
            //butB5.BackColor = Color.Green;
            //butCaser.BackColor = Color.Green;
            //butReportEmp.BackColor = Color.Green;
            //button2.BackColor = Color.Green;
            //butCaser8cm.BackColor = Color.Green;
            //butCaser8cm_NoDes.BackColor = Color.Red;
            //butNoPriceA4.BackColor = Color.Green;

          //  this.reportViewerCasher_8cm_NoDis.RefreshReport();
        }

        private void butReportEmpA5_Click(object sender, EventArgs e)
        {
            LoadReport("A5 List");

           // LoadReport(reportViewerRepEmp, "ReportBillingNoPrice.rdlc");


           // getprameterreports(reportViewerRepEmp);

            //reportViewerCasher_6cm_Dis.Visible = false;
            //reportViewerA4.Visible = false;
            //reportViewerA5.Visible = false;
            //reportViewerCasher.Visible = false;
            //reportViewerRepEmp.Visible = true;
            //reportViewerB5.Visible = false;
            //reportViewerDiscount.Visible = false;
            //reportViewerCasher_8cm.Visible = false;
            //reportViewerCasher_8cm_NoDis.Visible = false;
            //reportViewerRepEmpA4.Visible = false;


            ColorBut();
            //butA5.BackColor = Color.Green;
            //butA4.BackColor = Color.Green;
            //butB5.BackColor = Color.Green;
            //butCaser.BackColor = Color.Green;
            butReportEmp.BackColor = Color.Red;
            //button2.BackColor = Color.Green;
            //butCaser8cm.BackColor = Color.Green;
            //butCaser8cm_NoDes.BackColor = Color.Green;
            //butNoPriceA4.BackColor = Color.Green;

           // this.reportViewerRepEmp.RefreshReport();
        }

        private void buttNoPriceA4_Click(object sender, EventArgs e)
        {

            LoadReport("A4 List");


         //   LoadReport(reportViewerRepEmpA4, "ReportBillingNoPrice_A4.rdlc");


         //   getprameterreports(reportViewerRepEmpA4);

            //reportViewerCasher_6cm_Dis.Visible = false;
            //reportViewerA4.Visible = false;
            //reportViewerA5.Visible = false;
            //reportViewerCasher.Visible = false;
            //reportViewerRepEmp.Visible = false;
            //reportViewerB5.Visible = false;
            //reportViewerDiscount.Visible = false;
            //reportViewerCasher_8cm.Visible = false;
            //reportViewerCasher_8cm_NoDis.Visible = false;
            //reportViewerRepEmpA4.Visible = true;


            ColorBut();
            //butA5.BackColor = Color.Green;
            //butA4.BackColor = Color.Green;
            //butB5.BackColor = Color.Green;
            //butCaser.BackColor = Color.Green;
            //butReportEmp.BackColor = Color.Green;
            //button2.BackColor = Color.Green;
            //butCaser8cm.BackColor = Color.Green;
            //butCaser8cm_NoDes.BackColor = Color.Green;
            butNoPriceA4.BackColor = Color.Red;

          //  this.reportViewerRepEmpA4.RefreshReport();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LoadReport("Casher 6 mm Disc");


            //LoadReport("Casher 6 mm");


            //  LoadReport(reportViewerCasher_6cm_Dis, "ReportBillingCasher_6cm_Dis.rdlc");


            ////  getprameterreports(reportViewerCasher_6cm_Dis);

            //  reportViewerA4.Visible = false;
            //  reportViewerA5.Visible = false;
            //  reportViewerCasher_6cm_Dis.Visible = true; 
            //      reportViewerCasher.Visible = false;
            //  reportViewerRepEmp.Visible = false;
            //  reportViewerB5.Visible = false;
            //  reportViewerDiscount.Visible = false;
            //  reportViewerCasher_8cm.Visible = false;
            //  reportViewerCasher_8cm_NoDis.Visible = false;
            //  reportViewerRepEmpA4.Visible = false;




            ColorBut();

            //butA5.BackColor = Color.Green;
            //butA4.BackColor = Color.Green;
            //butB5.BackColor = Color.Green;
            butCaser.BackColor = Color.Red;
            //butReportEmp.BackColor = Color.Green;
            //button2.BackColor = Color.Green;
            //butCaser8cm.BackColor = Color.Green;
            //butCaser8cm_NoDes.BackColor = Color.Green;
            //butNoPriceA4.BackColor = Color.Green;

            //this.reportViewerCasher_6cm_Dis.RefreshReport();
        }
    }
}
