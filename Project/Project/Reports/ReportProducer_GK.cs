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
    public partial class ReportProducer_GK : Form
    {
        public ReportProducer_GK()
        {
            InitializeComponent();
        }

        private void ReportProducer_GK_Load(object sender, EventArgs e)
        {
            string user = AppSetting.user;

            //------------------------------------
            List<ReportParameter> list_user = new List<ReportParameter>();
            ReportParameter parm_user = new ReportParameter("p_user", user);
            list_user.Add(parm_user);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm_user });
            //------------------------------------

            this.reportViewer1.RefreshReport();
        }
    }
}
