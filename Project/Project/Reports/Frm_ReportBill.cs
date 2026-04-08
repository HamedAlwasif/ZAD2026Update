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

namespace ZAD_Sales.Reports
{
    public partial class Frm_ReportBill : Form
    {
         
        string PrinterBill = "";
        string SizePaperBill = "";
        string imageLogoUrl;
        public Frm_ReportBill()
        {
            InitializeComponent();
          
        }

        private void Frm_ReportBill_Load(object sender, EventArgs e)
        {


            imageLogoUrl = AppSetting.Comp_Logo;


            //---------- ايجاد الطابعه الافتراضية وحجم الورقة -----
            PrinterBill = AppSetting.PrinterBill;
            SizePaperBill = AppSetting.SizePaperBill;
            //-----------------------------------
            if (SizePaperBill == "A4")
            {

                buttA4.PerformClick();

            }
            else if (SizePaperBill == "A5")
            {

                buttA5.PerformClick();


            }
            else if (SizePaperBill == "B5")
            {

                buttB5.PerformClick();

            }
            else if (SizePaperBill == "A5 - Discount")
            {
                button4.PerformClick();

            }
            else if (SizePaperBill == "Casher 6 mm")
            {

                buttCaser6.PerformClick();

            }
            else if (SizePaperBill == "Casher 8 mm -Discount")
            {
                buttCaser8cm.PerformClick();
            }
            else if (SizePaperBill == "Casher 8 mm")
            {

                buttCaser8cm_NoDes.PerformClick();
            }
            else if (SizePaperBill == "A4 List")
            {

                buttNoPriceA4.PerformClick();

            }
            else if (SizePaperBill == "A5 List")
            {

                buttNoPriceA4.PerformClick();

            }
            else
            {
                MessageBox.Show("    لم يتم اختيار حجم الورقة الافتراضى     ", "خطأ");
            }


            // picCompany_Logo.Image = AppSetting.pic_logo;


            //================================================

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

            //================================================



            //butA4.BackColor = Color.Green;
            //butB5.BackColor = Color.Green;
            //butCaser.BackColor = Color.Green;
            //butReportEmp.BackColor = Color.Green;
            //button2.BackColor = Color.Green;
            //butCaser8cm.BackColor = Color.Green;
            //butCaser8cm_NoDes.BackColor = Color.Green;
            //butNoPriceA4.BackColor = Color.Green;

            // FileInfo fi = new FileInfo(_imageUrl);

            // List<ReportParameter> list_Company_Image = new List<ReportParameter>();
            // ReportParameter parm_Company_Image = new ReportParameter("Parm_Image", new Uri(_imageUrl).AbsoluteUri);
            // list_Company_Image.Add(parm_Company_Image);
            // //reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Image });
            // //reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Image });
            // //reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Image });
            // //reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Image });
            // //reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Image });
            // //reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Image });

            // //reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Image });
            // reportViewerCasher_8cm_NoDis.LocalReport.EnableExternalImages = true;
            //reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Image });


            //// reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Image });
            ///
            //   reportViewerCasher_8cm_NoDis.LocalReport.ReportPath = "D:\\workspace\\Report\\FichePersonne.rdlc";

            //ReportParameter lim = new ReportParameter("parmImageUrl", @"~\logo.png", true);
            //reportViewerCasher_8cm_NoDis.LocalReport.EnableExternalImages = true;
            //reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { lim });
            //this.reportViewerCasher_8cm_NoDis.RefreshReport();



            //***************** طباعه اللوجو 
            //string imagepath = "file:///" + "//logo.png";


            //this.reportViewerCasher_8cm_NoDis.LocalReport.EnableExternalImages = true;
            //ReportParameter[] param = new ReportParameter[1];
            //param[0] = new ReportParameter("parmImageUrl", imagepath);
            //this.reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(param);
            //this.reportViewerCasher_8cm_NoDis.RefreshReport();


            //****************************************************************
            //****************************************************************
            //****************************************************************
            //****************************************************************
            //List<ReportParameter> list_Company_Name = new List<ReportParameter>();
            //ReportParameter parm_Company_Name = new ReportParameter("Parm_Company_Name", AppSetting.textCompany_Name);
            //list_Company_Name.Add(parm_Company_Name);
            //reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Name });
            //reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Name });
            //reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Name });
            //reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Name });
            //reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Name });
            //reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Name });

            //reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Name });
            //reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Name });


            //reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Name });


            ////***********************
            //List<ReportParameter> list_Company_Address = new List<ReportParameter>();
            //ReportParameter parm_Company_Address = new ReportParameter("Parm_Company_Address", AppSetting.textCompany_Address);
            //list_Company_Address.Add(parm_Company_Name);
            //reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Address });
            //reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Address });
            //reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Address });
            //reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Address });
            //reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Address });
            //reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Address });

            //reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Address });
            //reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Address });


            //reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Address });


            ////***********************
            ////List<ReportParameter> list_Company_Description = new List<ReportParameter>();
            ////ReportParameter parm_Company_Description = new ReportParameter("Parm_Company_Description", AppSetting.textCompany_Description);
            ////list_Company_Description.Add(parm_Company_Name);
            ////reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });
            ////reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });
            ////reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });
            ////reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });
            ////reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });
            ////reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });

            ////reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });
            ////reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });


            ////reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });


            ////***********************

            //List<ReportParameter> list_Company_Description = new List<ReportParameter>();
            //ReportParameter parm_Company_Description = new ReportParameter("Parm_Company_Description", AppSetting.textCompany_Description);
            //list_Company_Description.Add(parm_Company_Description);
            //reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });
            //reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });
            //reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });
            //reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });
            //reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });
            //reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });

            //reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });
            //reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });

            //reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });

            ////***********************



            //List<ReportParameter> list_Company_Phone = new List<ReportParameter>();
            //ReportParameter parm_Company_Phone = new ReportParameter("Parm_Company_Phone", AppSetting.textCompany_Phone);
            //list_Company_Phone.Add(parm_Company_Phone);
            //reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Phone });
            //reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Phone });
            //reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Phone });
            //reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Phone });
            //reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Phone });
            //reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Phone });

            //reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Phone });
            //reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Phone });

            //reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Phone });



            ////------------------------------------
            //List<ReportParameter> list_NoteToBill = new List<ReportParameter>();
            //ReportParameter parm_NoteToBill = new ReportParameter("Parm_NoteToBill", AppSetting.NoteToBill);
            //list_NoteToBill.Add(parm_NoteToBill);
            //reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm_NoteToBill });
            //reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm_NoteToBill });
            //reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm_NoteToBill });
            //reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm_NoteToBill });
            //reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm_NoteToBill });
            //reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm_NoteToBill });
            //reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm_NoteToBill });
            //reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm_NoteToBill });

            //reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm_NoteToBill });


            ////------------------------------------

            //List<ReportParameter> list17 = new List<ReportParameter>();
            //ReportParameter parm17 = new ReportParameter("Parm_MoveBill", AppSetting.MoveBill);
            //list17.Add(parm17);
            //reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm17 });
            //reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm17 });
            //reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm17 });
            //reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm17 });
            //reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm17 });
            //reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm17 });
            //reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm17 });
            //reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm17 });

            //reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm17 });


            ////------------------------------------
            //List<ReportParameter> list1 = new List<ReportParameter>();
            //ReportParameter parm1 = new ReportParameter("TypeBill", AppSetting.TypeBill);
            //list1.Add(parm1);
            //reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm1 });
            //reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm1 });
            //reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm1 });
            //reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm1 });
            //reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm1 });
            //reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm1 });
            //reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm1 });

            //reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm1 });

            //reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm1 });

            ////------------------------------------
            //List<ReportParameter> list2 = new List<ReportParameter>();
            //ReportParameter parm2 = new ReportParameter("Name", AppSetting.ClintName);
            //list2.Add(parm2);
            //reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm2 });
            //reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm2 });
            //reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm2 });
            //reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm2 });
            //reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm2 });
            //reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm2 });

            //reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm2 });
            //reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm2 });

            //reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm2 });

            ////------------------------------------

            //List<ReportParameter> list3 = new List<ReportParameter>();
            //ReportParameter parm3 = new ReportParameter("Print", AppSetting.user);
            //list3.Add(parm3);
            //reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm3 });
            //reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm3 });
            //reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm3 });
            //reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm3 });
            //reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm3 });
            //reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm3 });

            //reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm3 });
            //reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm3 });

            //reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm3 });

            ////------------------------------------

            //List<ReportParameter> list4 = new List<ReportParameter>();
            //ReportParameter parm4 = new ReportParameter("NumBill", AppSetting.BillingDataNumBill);
            //list4.Add(parm4);
            //reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm4 });
            //reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm4 });
            //reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm4 });
            //reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm4 });
            //reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm4 });
            //reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm4 });

            //reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm4 });
            //reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm4 });

            //reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm4 });

            ////------------------------------------

            //List<ReportParameter> list5 = new List<ReportParameter>();
            //ReportParameter parm5 = new ReportParameter("Date", AppSetting.dateTimePicker1);
            //list5.Add(parm5);
            //reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm5 });
            //reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm5 });
            //reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm5 });
            //reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm5 });
            //reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm5 });
            //reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm5 });

            //reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm5 });
            //reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm5 });

            //reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm5 });

            ////------------------------------------

            //List<ReportParameter> list6 = new List<ReportParameter>();
            //ReportParameter parm6 = new ReportParameter("Total", AppSetting.TotalBill);
            //list6.Add(parm6);
            //reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm6 });
            //reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm6 });
            //reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm6 });
            //reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm6 });
            //reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm6 });
            //reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm6 });

            //reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm6 });
            //reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm6 });

            //reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm6 });

            ////------------------------------------
            //List<ReportParameter> list7 = new List<ReportParameter>();
            //ReportParameter parm7 = new ReportParameter("Sabek", AppSetting.RemaningOld);
            //list7.Add(parm7);
            //reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm7 });
            //reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm7 });
            //reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm7 });
            //reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm7 });
            //reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm7 });
            //reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm7 });

            //reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm7 });
            //reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm7 });

            //reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm7 });

            ////------------------------------------
            //List<ReportParameter> list9 = new List<ReportParameter>();
            //ReportParameter parm9 = new ReportParameter("Discount", AppSetting.Dic);
            //list9.Add(parm9);
            //reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm9 });
            //reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm9 });
            //reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm9 });
            //reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm9 });
            //reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm9 });
            //reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm9 });

            //reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm9 });
            //reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm9 });

            //reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm9 });

            ////------------------------------------
            //List<ReportParameter> list10 = new List<ReportParameter>();
            //ReportParameter parm10 = new ReportParameter("Mosadad", AppSetting.Mosadad);
            //list10.Add(parm10);
            //reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm10 });
            //reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm10 });
            //reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm10 });
            //reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm10 });
            //reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm10 });
            //reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm10 });

            //reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm10 });
            //reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm10 });

            //reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm10 });

            ////------------------------------------
            //List<ReportParameter> list11 = new List<ReportParameter>();
            //ReportParameter parm11 = new ReportParameter("Remaning", AppSetting.RemainingNow);
            //list11.Add(parm11);
            //reportViewerA5.LocalReport.SetParameters(new ReportParameter[] { parm11 });
            //reportViewerA4.LocalReport.SetParameters(new ReportParameter[] { parm11 });
            //reportViewerB5.LocalReport.SetParameters(new ReportParameter[] { parm11 });
            //reportViewerCasher.LocalReport.SetParameters(new ReportParameter[] { parm11 });
            //reportViewerDiscount.LocalReport.SetParameters(new ReportParameter[] { parm11 });
            //reportViewerRepEmp.LocalReport.SetParameters(new ReportParameter[] { parm11 });

            //reportViewerCasher_8cm.LocalReport.SetParameters(new ReportParameter[] { parm11 });
            //reportViewerCasher_8cm_NoDis.LocalReport.SetParameters(new ReportParameter[] { parm11 });

            //reportViewerRepEmpA4.LocalReport.SetParameters(new ReportParameter[] { parm11 });

            ////------------------------------------





            ////this.reportViewer1.RefreshReport();

            //this.reportViewerA5.RefreshReport();


        //    this.reportViewer1.RefreshReport();
        }

        private void getprameterreports(ReportViewer reportchange)

        {

            //***************** طباعه اللوجو 
            //string imagepath = "file:///" + "//logo.png";


            //reportchange.LocalReport.EnableExternalImages = true;
            //ReportParameter[] param = new ReportParameter[1];
            //param[0] = new ReportParameter("parmImageUrl", imagepath);
            //reportchange.LocalReport.SetParameters(param);
            //reportchange.RefreshReport();

            //  FileInfo fi = new FileInfo(_imageUrl);
            ////  ReportParameter pName = new ReportParameter("pName", fi.Name);
            //  ReportParameter pImageUrl = new ReportParameter("parmImageUrl", new Uri(_imageUrl).AbsoluteUri);
            //  reportchange.LocalReport.EnableExternalImages = true;
            //  reportchange.LocalReport.SetParameters(new ReportParameter[] {  pImageUrl });
            //  reportchange.RefreshReport();

            try
            {
                FileInfo fi = new FileInfo(imageLogoUrl);
                //  ReportParameter pName = new ReportParameter("pName", fi.Name);
                ReportParameter pImageUrl = new ReportParameter("parmImageUrl", new Uri(imageLogoUrl).AbsoluteUri);
                reportchange.LocalReport.EnableExternalImages = true;
                reportchange.LocalReport.SetParameters(new ReportParameter[] { pImageUrl });
                reportchange.RefreshReport();
            }
            catch
            { }

            //-------------------------------------------------------------


            List<ReportParameter> list_Company_Name = new List<ReportParameter>();
            ReportParameter parm_Company_Name = new ReportParameter("Parm_Company_Name", AppSetting.textCompany_Name);
            list_Company_Name.Add(parm_Company_Name);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Name });

            //***********************
            List<ReportParameter> list_Company_Address = new List<ReportParameter>();
            ReportParameter parm_Company_Address = new ReportParameter("Parm_Company_Address", AppSetting.textCompany_Address);
            list_Company_Address.Add(parm_Company_Address);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Address });



            //***********************

            //***********************

            List<ReportParameter> list_Company_Description = new List<ReportParameter>();
            ReportParameter parm_Company_Description = new ReportParameter("Parm_Company_Description", AppSetting.textCompany_Description);
            list_Company_Description.Add(parm_Company_Description);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });


            //***********************



            List<ReportParameter> list_Company_Phone = new List<ReportParameter>();
            ReportParameter parm_Company_Phone = new ReportParameter("Parm_Company_Phone", AppSetting.textCompany_Phone);
            list_Company_Phone.Add(parm_Company_Phone);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Phone });


            //------------------------------------
            List<ReportParameter> list_NoteToBill = new List<ReportParameter>();
            ReportParameter parm_NoteToBill = new ReportParameter("Parm_NoteToBill", AppSetting.NoteToBill);
            list_NoteToBill.Add(parm_NoteToBill);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm_NoteToBill });

            //------------------------------------

            List<ReportParameter> list17 = new List<ReportParameter>();
            ReportParameter parm17 = new ReportParameter("Parm_MoveBill", AppSetting.MoveBill);
            list17.Add(parm17);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm17 });


            //------------------------------------
            List<ReportParameter> list1 = new List<ReportParameter>();
            ReportParameter parm1 = new ReportParameter("TypeBill", AppSetting.TypeBill);
            list1.Add(parm1);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm1 });

            //------------------------------------
            List<ReportParameter> list2 = new List<ReportParameter>();
            ReportParameter parm2 = new ReportParameter("Name", AppSetting.ClintName);
            list2.Add(parm2);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm2 });

            //------------------------------------

            List<ReportParameter> list3 = new List<ReportParameter>();
            ReportParameter parm3 = new ReportParameter("Print", AppSetting.user);
            list3.Add(parm3);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm3 });


            //------------------------------------

            List<ReportParameter> list4 = new List<ReportParameter>();
            ReportParameter parm4 = new ReportParameter("NumBill", AppSetting.BillingDataNumBill);
            list4.Add(parm4);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm4 });

            //------------------------------------

            List<ReportParameter> list5 = new List<ReportParameter>();
            ReportParameter parm5 = new ReportParameter("Date", AppSetting.dateTimePicker1);
            list5.Add(parm5);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm5 });

            //------------------------------------

            List<ReportParameter> list6 = new List<ReportParameter>();
            ReportParameter parm6 = new ReportParameter("Total", AppSetting.TotalBill);
            list6.Add(parm6);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm6 });

            //------------------------------------
            List<ReportParameter> list7 = new List<ReportParameter>();
            ReportParameter parm7 = new ReportParameter("Sabek", AppSetting.RemaningOld);
            list7.Add(parm7);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm7 });

            //------------------------------------
            List<ReportParameter> list9 = new List<ReportParameter>();
            ReportParameter parm9 = new ReportParameter("Discount", AppSetting.Dic);
            list9.Add(parm9);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm9 });

            //------------------------------------
            List<ReportParameter> list10 = new List<ReportParameter>();
            ReportParameter parm10 = new ReportParameter("Mosadad", AppSetting.Mosadad);
            list10.Add(parm10);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm10 });


            //------------------------------------
            List<ReportParameter> list11 = new List<ReportParameter>();
            ReportParameter parm11 = new ReportParameter("Remaning", AppSetting.RemainingNow);
            list11.Add(parm11);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm11 });

            //------------------------------------
            List<ReportParameter> list111 = new List<ReportParameter>();
            ReportParameter parm111 = new ReportParameter("Demo", AppSetting.DemoOnBill);
            list11.Add(parm111);
            reportchange.LocalReport.SetParameters(new ReportParameter[] { parm111 });



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
           
            getprameterreports(reportViewerA5);

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
            //butA4.BackColor = Color.Green;
            //butB5.BackColor = Color.Green;
            //butCaser.BackColor = Color.Green;
            //butReportEmp.BackColor = Color.Green;
            //button2.BackColor = Color.Green;
            //butCaser8cm.BackColor = Color.Green;
            //butCaser8cm_NoDes.BackColor = Color.Green;
            //butNoPriceA4.BackColor = Color.Green;




            this.reportViewerA5.RefreshReport();
        }

        private void butB5_Click(object sender, EventArgs e)
        {
            getprameterreports(reportViewerB5);

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

            this.reportViewerB5.RefreshReport();
        }

        private void butA4_Click(object sender, EventArgs e)
        {
            getprameterreports(reportViewerA4);

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

            this.reportViewerA4.RefreshReport();
        }

        private void butCaser_Click(object sender, EventArgs e)
        {
            getprameterreports(reportViewerCasher);

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

            this.reportViewerCasher.RefreshReport();
        }

        private void butReportEmp_Click(object sender, EventArgs e)
        {
            getprameterreports(reportViewerRepEmp);

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

            this.reportViewerRepEmp.RefreshReport();
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
            getprameterreports(reportViewerA5);

            reportViewerCasher_6cm_Dis.Visible = false;
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
            //butA4.BackColor = Color.Green;
            //butB5.BackColor = Color.Green;
            //butCaser.BackColor = Color.Green;
            //butReportEmp.BackColor = Color.Green;
            //button2.BackColor = Color.Green;
            //butCaser8cm.BackColor = Color.Green;
            //butCaser8cm_NoDes.BackColor = Color.Green;
            //butNoPriceA4.BackColor = Color.Green;




            this.reportViewerA5.RefreshReport();
        }

        private void buttB5_Click(object sender, EventArgs e)
        {
            getprameterreports(reportViewerB5);

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

            //butA5.BackColor = Color.Green;
            //butA4.BackColor = Color.Green;
            butB5.BackColor = Color.Red;
            //butCaser.BackColor = Color.Green;
            //butReportEmp.BackColor = Color.Green;
            //button2.BackColor = Color.Green;
            //butCaser8cm.BackColor = Color.Green;
            //butCaser8cm_NoDes.BackColor = Color.Green;
            //butNoPriceA4.BackColor = Color.Green;

            this.reportViewerB5.RefreshReport();
        }

        private void buttA4_Click(object sender, EventArgs e)
        {
            getprameterreports(reportViewerA4);

            reportViewerCasher_6cm_Dis.Visible = false;
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

            this.reportViewerA4.RefreshReport();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            getprameterreports(reportViewerDiscount);

            reportViewerCasher_6cm_Dis.Visible = false;
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

        private void buttCaser6_Click(object sender, EventArgs e)
        {
            getprameterreports(reportViewerCasher);

            reportViewerCasher_6cm_Dis.Visible = false;
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

            this.reportViewerCasher.RefreshReport();
        }

        private void buttCaser8cm_Click(object sender, EventArgs e)
        {
            getprameterreports(reportViewerCasher_8cm);

            reportViewerCasher_6cm_Dis.Visible = false;
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

        private void buttCaser8cm_NoDes_Click(object sender, EventArgs e)
        {
            getprameterreports(reportViewerCasher_8cm_NoDis);

            reportViewerCasher_6cm_Dis.Visible = false;
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

        private void butReportEmpA5_Click(object sender, EventArgs e)
        {
            getprameterreports(reportViewerRepEmp);

            reportViewerCasher_6cm_Dis.Visible = false;
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

            this.reportViewerRepEmp.RefreshReport();
        }

        private void buttNoPriceA4_Click(object sender, EventArgs e)
        {
            getprameterreports(reportViewerRepEmpA4);

            reportViewerCasher_6cm_Dis.Visible = false;
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            getprameterreports(reportViewerCasher_6cm_Dis);

            reportViewerA4.Visible = false;
            reportViewerA5.Visible = false;
            reportViewerCasher_6cm_Dis.Visible = true; 
                reportViewerCasher.Visible = false;
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

            this.reportViewerCasher_6cm_Dis.RefreshReport();
        }
    }
}
