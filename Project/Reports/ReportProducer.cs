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
    public partial class ReportProducer : Form
    {
        public ReportProducer()
        {
            InitializeComponent();
        }

        private void ReportProducer_Load(object sender, EventArgs e)
        {
            string user = AppSetting.user;
            string valuue = AppSetting.ValueeProducerIncomplete;

            //------------------------------------
            List<ReportParameter> list_user = new List<ReportParameter>();
            ReportParameter parm_user = new ReportParameter("p_user", user);
            list_user.Add(parm_user);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm_user });
            reportViewer2.LocalReport.SetParameters(new ReportParameter[] { parm_user });
            reportViewer3.LocalReport.SetParameters(new ReportParameter[] { parm_user });
            //------------------------------------
            List<ReportParameter> list_value = new List<ReportParameter>();
            ReportParameter parm_value = new ReportParameter("Value", valuue);
            list_user.Add(parm_value);
          //  reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm_user });
           // reportViewer2.LocalReport.SetParameters(new ReportParameter[] { parm_user });
            reportViewer3.LocalReport.SetParameters(new ReportParameter[] { parm_value });

            this.reportViewer1.RefreshReport();

            
            //------------------------------------

            this.reportViewer2.RefreshReport();

            //------------------------------------

            this.reportViewer3.RefreshReport();
        }
    }
}
