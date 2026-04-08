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
    public partial class ReportClints : Form
    {
        public ReportClints()
        {
            InitializeComponent();
        }

        private void ReportClints_Load(object sender, EventArgs e)
        {
            string user = AppSetting.user;

            //------------------------------------
            List<ReportParameter> list_user = new List<ReportParameter>();
            ReportParameter parm_user = new ReportParameter("p_user", user);
            list_user.Add(parm_user);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm_user });
            //------------------------------------

            //------------------------------------
            List<ReportParameter> list1 = new List<ReportParameter>();
            ReportParameter parm1 = new ReportParameter("TotalClints", AppSetting.TotalClientsMoney);
            list1.Add(parm1);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm1 });
            //------------------------------------

            //List<ReportParameter> list11 = new List<ReportParameter>();
            //ReportParameter parm11 = new ReportParameter("TotalCreditor", textBox2.Text);
            //list11.Add(parm11);
            //reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm11 });

            //------------------------------------

            this.reportViewer1.RefreshReport();
        }
    }
}
