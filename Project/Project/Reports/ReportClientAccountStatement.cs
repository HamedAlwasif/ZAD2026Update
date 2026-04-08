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
    public partial class ReportClientAccountStatement : Form
    {
        public ReportClientAccountStatement()
        {
            InitializeComponent();
        }

        private void ReportClientAccountStatement_Load(object sender, EventArgs e)
        {

            string clint_name = AppSetting.client_name;
            string user = AppSetting.user;
            string datefrom = AppSetting.date_From;
            string dateto = AppSetting.date_To;

            //------------------------------------
            List<ReportParameter> list_clint_name = new List<ReportParameter>();
            ReportParameter parm_clint_name = new ReportParameter("p_clint_name", clint_name);
            list_clint_name.Add(parm_clint_name);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm_clint_name });
            //------------------------------------
            List<ReportParameter> list_user = new List<ReportParameter>();
            ReportParameter parm_user = new ReportParameter("p_user", user);
            list_user.Add(parm_user);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm_user });
            reportViewer2.LocalReport.SetParameters(new ReportParameter[] { parm_user });
            //------------------------------------
            List<ReportParameter> list_datefrom = new List<ReportParameter>();
            ReportParameter parm_datefrom = new ReportParameter("p_datefrom", datefrom);
            list_datefrom.Add(parm_datefrom);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm_datefrom });
            reportViewer2.LocalReport.SetParameters(new ReportParameter[] { parm_datefrom });
            //------------------------------------
            List<ReportParameter> list_dateto = new List<ReportParameter>();
            ReportParameter parm_dateto = new ReportParameter("p_dateto", dateto);
            list_dateto.Add(parm_dateto);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm_dateto });
            reportViewer2.LocalReport.SetParameters(new ReportParameter[] { parm_dateto });

            if (AppSetting.Clientall == "Client")
            {
                reportViewer1.Visible = true;
                reportViewer2.Visible = false;
                this.reportViewer1.RefreshReport();
            }
            else if (AppSetting.Clientall == "ClientAll")
            {
                reportViewer1.Visible = false;
                reportViewer2.Visible = true;
                this.reportViewer2.RefreshReport();
            }
        }
    }
}
