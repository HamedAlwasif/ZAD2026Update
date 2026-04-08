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
    public partial class Frm_BillDay : Form
    {
        public Frm_BillDay()
        {
            InitializeComponent();
        }

        private void Frm_BillDay_Load(object sender, EventArgs e)
        {
            //      public static string Total_Bill = "0";
            //public static string Total_Paid = "0";

            string user = AppSetting.user;
            string datefrom = AppSetting.date_From;
            string dateto = AppSetting.date_To;

            //------------------------------------
            List<ReportParameter> list_user = new List<ReportParameter>();
            ReportParameter parm_user = new ReportParameter("p_user", user);
            list_user.Add(parm_user);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm_user });
            //------------------------------------

            List<ReportParameter> list_Total_Bill = new List<ReportParameter>();
            ReportParameter parm_Total_Bill = new ReportParameter("Total_Bill", AppSetting.Total_Bill);
            list_Total_Bill.Add(parm_Total_Bill);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm_Total_Bill });

            List<ReportParameter> list_Total_Paid = new List<ReportParameter>();
            ReportParameter parm_Total_Paid = new ReportParameter("Total_Paid", AppSetting.Total_Paid);
            list_Total_Paid.Add(parm_Total_Paid);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm_Total_Paid });

            //------------------------------------

            List<ReportParameter> list5 = new List<ReportParameter>();
            ReportParameter parm5 = new ReportParameter("DateDay", AppSetting.dateTimePicker1);
            list5.Add(parm5);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm5 });

            //------------------------------------
            List<ReportParameter> list_datefrom = new List<ReportParameter>();
            ReportParameter parm_datefrom = new ReportParameter("p_datefrom", datefrom);
            list_datefrom.Add(parm_datefrom);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm_datefrom });
            //------------------------------------
            List<ReportParameter> list_dateto = new List<ReportParameter>();
            ReportParameter parm_dateto = new ReportParameter("p_dateto", dateto);
            list_dateto.Add(parm_dateto);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm_dateto });

            //------------------------------------

            this.reportViewer1.RefreshReport();
        }
    }
}
