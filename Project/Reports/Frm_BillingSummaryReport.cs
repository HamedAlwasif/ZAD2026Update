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
    public partial class Frm_BillingSummaryReport : Form
    {
        public Frm_BillingSummaryReport()
        {
            InitializeComponent();
        }

        private void Frm_BillingSummaryReport_Load(object sender, EventArgs e)
        {
            string datefrom = AppSetting.date_From;
            string dateto = AppSetting.date_To;
            string user = AppSetting.user;

            //------------------------------------
            List<ReportParameter> list_user = new List<ReportParameter>();
            ReportParameter parm_user = new ReportParameter("p_user", user);
            list_user.Add(parm_user);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm_user });
            //------------------------------------
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

            this.reportViewer1.RefreshReport();




            //----------------------------------


          //  this.reportViewer2.RefreshReport();
        }

        private void butPrint_Click(object sender, EventArgs e)
        {
           
        }
    }
}
