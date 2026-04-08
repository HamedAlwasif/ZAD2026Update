using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace ZAD_Sales.Reports
{
    public partial class Frm_ReceiptOfCash : Form
    {
        public Frm_ReceiptOfCash()
        {
            InitializeComponent();
        }
        
        private void Frm_ReceiptOfCash_Load(object sender, EventArgs e)
        {
            List<ReportParameter> list_Company_Name = new List<ReportParameter>();
            ReportParameter parm_Company_Name = new ReportParameter("Parm_Company_Name", AppSetting.textCompany_Name);
            list_Company_Name.Add(parm_Company_Name);
            reportViewerReceiptDefoult.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Name });
            reportViewerReceiptFull.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Name });
            reportViewerCasher8.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Name });
            reportViewerCasher8Full.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Name });



            //***********************


            List<ReportParameter> list_Company_Description = new List<ReportParameter>();
            ReportParameter parm_Company_Description = new ReportParameter("Parm_Company_Description", AppSetting.textCompany_Description);
            list_Company_Description.Add(parm_Company_Description);
            reportViewerReceiptDefoult.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });
            reportViewerReceiptFull.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });
            reportViewerCasher8.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });
            reportViewerCasher8Full.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Description });

            //***********************



            List<ReportParameter> list_Company_Phone = new List<ReportParameter>();
            ReportParameter parm_Company_Phone = new ReportParameter("Parm_Company_Phone", AppSetting.textCompany_Phone);
            list_Company_Phone.Add(parm_Company_Phone);
            reportViewerReceiptDefoult.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Phone });
            reportViewerReceiptFull.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Phone });
            reportViewerCasher8.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Phone });
            reportViewerCasher8Full.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Phone });


            //------------------------------------
            List<ReportParameter> list_Note = new List<ReportParameter>();
            ReportParameter parm_Note = new ReportParameter("Parm_Note", AppSetting.Note);
            list_Note.Add(parm_Note);
            reportViewerReceiptDefoult.LocalReport.SetParameters(new ReportParameter[] { parm_Note});
            reportViewerReceiptFull.LocalReport.SetParameters(new ReportParameter[] { parm_Note });
            reportViewerCasher8.LocalReport.SetParameters(new ReportParameter[] { parm_Note });
            reportViewerCasher8Full.LocalReport.SetParameters(new ReportParameter[] { parm_Note });

            //------------------------------------
            List<ReportParameter> list2 = new List<ReportParameter>();
            ReportParameter parm2 = new ReportParameter("Name", AppSetting.ClintName);
            list2.Add(parm2);
            reportViewerReceiptDefoult.LocalReport.SetParameters(new ReportParameter[] { parm2 });
            reportViewerReceiptFull.LocalReport.SetParameters(new ReportParameter[] { parm2 });
            reportViewerCasher8.LocalReport.SetParameters(new ReportParameter[] { parm2 });
            reportViewerCasher8Full.LocalReport.SetParameters(new ReportParameter[] { parm2 });

            //------------------------------------

            List<ReportParameter> list3 = new List<ReportParameter>();
            ReportParameter parm3 = new ReportParameter("Print", AppSetting.user);
            list3.Add(parm3);
            reportViewerReceiptDefoult.LocalReport.SetParameters(new ReportParameter[] { parm3 });
            reportViewerReceiptFull.LocalReport.SetParameters(new ReportParameter[] { parm3 });
            reportViewerCasher8.LocalReport.SetParameters(new ReportParameter[] { parm3 });
            reportViewerCasher8Full.LocalReport.SetParameters(new ReportParameter[] { parm3 });

            //------------------------------------

            List<ReportParameter> list4 = new List<ReportParameter>();
            ReportParameter parm4 = new ReportParameter("NumBill", AppSetting.NumRest);
            list4.Add(parm4);
            reportViewerReceiptDefoult.LocalReport.SetParameters(new ReportParameter[] { parm4 });
            reportViewerReceiptFull.LocalReport.SetParameters(new ReportParameter[] { parm4 });
            reportViewerCasher8.LocalReport.SetParameters(new ReportParameter[] { parm4 });
            reportViewerCasher8Full.LocalReport.SetParameters(new ReportParameter[] { parm4 });

            //------------------------------------

            List<ReportParameter> list5 = new List<ReportParameter>();
            ReportParameter parm5 = new ReportParameter("Date", AppSetting.dateTimePicker1);
            list5.Add(parm5);
            reportViewerReceiptDefoult.LocalReport.SetParameters(new ReportParameter[] { parm5 });
            reportViewerReceiptFull.LocalReport.SetParameters(new ReportParameter[] { parm5 });
            reportViewerCasher8.LocalReport.SetParameters(new ReportParameter[] { parm5 });
            reportViewerCasher8Full.LocalReport.SetParameters(new ReportParameter[] { parm5 });

            //------------------------------------
            List<ReportParameter> list10 = new List<ReportParameter>();
            ReportParameter parm10 = new ReportParameter("Mosadad", AppSetting.Mosadad);
            list10.Add(parm10);
            reportViewerReceiptDefoult.LocalReport.SetParameters(new ReportParameter[] { parm10 });
            reportViewerReceiptFull.LocalReport.SetParameters(new ReportParameter[] { parm10 });
            reportViewerCasher8.LocalReport.SetParameters(new ReportParameter[] { parm10 });
            reportViewerCasher8Full.LocalReport.SetParameters(new ReportParameter[] { parm10 });
            //------------------------------------

            List<ReportParameter> listTyprReceipt = new List<ReportParameter>();
            ReportParameter parmTyprReceipt = new ReportParameter("TyprReceipt", AppSetting.TyprReceipt);
            listTyprReceipt.Add(parmTyprReceipt);
            reportViewerReceiptDefoult.LocalReport.SetParameters(new ReportParameter[] { parmTyprReceipt });
            reportViewerReceiptFull.LocalReport.SetParameters(new ReportParameter[] { parmTyprReceipt });
            reportViewerCasher8.LocalReport.SetParameters(new ReportParameter[] { parmTyprReceipt });
            reportViewerCasher8Full.LocalReport.SetParameters(new ReportParameter[] { parmTyprReceipt });

            //------------------------------------
            List<ReportParameter> list7 = new List<ReportParameter>();
            ReportParameter parm7 = new ReportParameter("Sabek", AppSetting.RemaningOld);
            list7.Add(parm7);
          //  reportViewerReceiptDefoult.LocalReport.SetParameters(new ReportParameter[] { parm7 });
            reportViewerReceiptFull.LocalReport.SetParameters(new ReportParameter[] { parm7 });
            reportViewerCasher8Full.LocalReport.SetParameters(new ReportParameter[] { parm7 });

            //------------------------------------
            List<ReportParameter> list9 = new List<ReportParameter>();
            ReportParameter parm9 = new ReportParameter("Discount", AppSetting.Dic);
            list9.Add(parm9);
            //reportViewerReceiptDefoult.LocalReport.SetParameters(new ReportParameter[] { parm9 });
            reportViewerReceiptFull.LocalReport.SetParameters(new ReportParameter[] { parm9 });
            reportViewerCasher8Full.LocalReport.SetParameters(new ReportParameter[] { parm9 });


            //------------------------------------
            List<ReportParameter> list11 = new List<ReportParameter>();
            ReportParameter parm11 = new ReportParameter("Remaning", AppSetting.RemainingNow);
            list11.Add(parm11);
           // reportViewerReceiptDefoult.LocalReport.SetParameters(new ReportParameter[] { parm11 });
            reportViewerReceiptFull.LocalReport.SetParameters(new ReportParameter[] { parm11 });
           reportViewerCasher8Full.LocalReport.SetParameters(new ReportParameter[] { parm11 });


            //------------------------------------
            List<ReportParameter> listAdded = new List<ReportParameter>();
            ReportParameter parmAdded = new ReportParameter("Adding", AppSetting.AddMoney);
            listAdded.Add(parmAdded);
            // reportViewerReceiptDefoult.LocalReport.SetParameters(new ReportParameter[] { parm11 });
            reportViewerReceiptFull.LocalReport.SetParameters(new ReportParameter[] { parmAdded });
           reportViewerCasher8Full.LocalReport.SetParameters(new ReportParameter[] { parmAdded });


            this.reportViewerReceiptDefoult.RefreshReport();
        }

        private void butA5_ReceiptGeneral_Click(object sender, EventArgs e)
        {
            
            reportViewerReceiptDefoult.Visible = true;
            reportViewerReceiptFull.Visible = false;
          

            //butA5.BackColor = Color.Green;
            //butA4.BackColor = Color.Green;
            butA5_ReceiptGeneral.BackColor = Color.Green;
            butA5_ReceiptDetailed.BackColor = Color.Teal;
            //butCaser.BackColor = Color.Green;
            //butReportEmp.BackColor = Color.Green;
            //button2.BackColor = Color.Green;
            //butCaser8cm.BackColor = Color.Green;
            //butCaser8cm_NoDes.BackColor = Color.Green;
            //butNoPriceA4.BackColor = Color.Green;

            this.reportViewerReceiptDefoult.RefreshReport();
        }

        private void butA5_ReceiptDetailed_Click(object sender, EventArgs e)
        {
            reportViewerReceiptDefoult.Visible = false;
            reportViewerCasher8.Visible = false;
            reportViewerCasher8Full.Visible = false;
            reportViewerReceiptFull.Visible = true;


            //butA5.BackColor = Color.Green;
            //butA4.BackColor = Color.Green;
            butA5_ReceiptDetailed.BackColor = Color.Green;
            butA5_ReceiptGeneral.BackColor = Color.Teal;
            //butCaser.BackColor = Color.Green;
            //butReportEmp.BackColor = Color.Green;
            //button2.BackColor = Color.Green;
            //butCaser8cm.BackColor = Color.Green;
            //butCaser8cm_NoDes.BackColor = Color.Green;
            //butNoPriceA4.BackColor = Color.Green;

            this.reportViewerReceiptFull.RefreshReport();
        }

        private void PrintDefoult_Click(object sender, EventArgs e)
        {
            reportViewerReceiptDefoult.Visible = false;
            reportViewerCasher8.Visible = false;
            reportViewerCasher8Full.Visible = false;
            reportViewerReceiptDefoult.Visible = true;
            reportViewerReceiptFull.Visible = false;


            //butA5.BackColor = Color.Green;
            //butA4.BackColor = Color.Green;
            butA5_ReceiptGeneral.BackColor = Color.Green;
            butA5_ReceiptDetailed.BackColor = Color.Teal;
            //butCaser.BackColor = Color.Green;
            //butReportEmp.BackColor = Color.Green;
            //button2.BackColor = Color.Green;
            //butCaser8cm.BackColor = Color.Green;
            //butCaser8cm_NoDes.BackColor = Color.Green;
            //butNoPriceA4.BackColor = Color.Green;

            this.reportViewerReceiptDefoult.RefreshReport();
        }

        private void buttA_Click(object sender, EventArgs e)
        {
            reportViewerReceiptDefoult.Visible = false;
            reportViewerReceiptFull.Visible = true;


            //butA5.BackColor = Color.Green;
            //butA4.BackColor = Color.Green;
            butA5_ReceiptDetailed.BackColor = Color.Green;
            butA5_ReceiptGeneral.BackColor = Color.Teal;
            //butCaser.BackColor = Color.Green;
            //butReportEmp.BackColor = Color.Green;
            //button2.BackColor = Color.Green;
            //butCaser8cm.BackColor = Color.Green;
            //butCaser8cm_NoDes.BackColor = Color.Green;
            //butNoPriceA4.BackColor = Color.Green;

            this.reportViewerReceiptFull.RefreshReport();
        }

        private void buttCaser8Defoult_Click(object sender, EventArgs e)
        {
            reportViewerReceiptDefoult.Visible = false;
            reportViewerCasher8.Visible = true;
            reportViewerCasher8Full.Visible = false;
            reportViewerReceiptDefoult.Visible = false;
            reportViewerReceiptFull.Visible = false;


            //butA5.BackColor = Color.Green;
            //butA4.BackColor = Color.Green;
            butA5_ReceiptGeneral.BackColor = Color.Green;
            butA5_ReceiptDetailed.BackColor = Color.Teal;
            //butCaser.BackColor = Color.Green;
            //butReportEmp.BackColor = Color.Green;
            //button2.BackColor = Color.Green;
            //butCaser8cm.BackColor = Color.Green;
            //butCaser8cm_NoDes.BackColor = Color.Green;
            //butNoPriceA4.BackColor = Color.Green;

            this.reportViewerCasher8.RefreshReport();
        }

        private void buttCaser8cm_Click(object sender, EventArgs e)
        {
            reportViewerReceiptDefoult.Visible = false;
            reportViewerCasher8.Visible = false;
            reportViewerCasher8Full.Visible = true;
            reportViewerReceiptDefoult.Visible = false;
            reportViewerReceiptFull.Visible = false;


            //butA5.BackColor = Color.Green;
            //butA4.BackColor = Color.Green;
            butA5_ReceiptGeneral.BackColor = Color.Green;
            butA5_ReceiptDetailed.BackColor = Color.Teal;
            //butCaser.BackColor = Color.Green;
            //butReportEmp.BackColor = Color.Green;
            //button2.BackColor = Color.Green;
            //butCaser8cm.BackColor = Color.Green;
            //butCaser8cm_NoDes.BackColor = Color.Green;
            //butNoPriceA4.BackColor = Color.Green;

            this.reportViewerCasher8Full.RefreshReport();
        }
    }
}
