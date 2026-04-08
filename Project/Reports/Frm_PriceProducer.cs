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
    public partial class Frm_PriceProducer : Form
    {
        public Frm_PriceProducer()
        {
            InitializeComponent();
        }

        private void Frm_PriceProducer_Load(object sender, EventArgs e)
        {
            string user = AppSetting.user;

            string TypePrice = AppSetting.TypePrice;


            if (TypePrice== "All")
            {
                reportViewer1.Visible = true;
                reportViewer2.Visible = false;
                reportViewer3.Visible = false;
                reportViewer4.Visible = false;


                //------------------------------------
                List<ReportParameter> list_user = new List<ReportParameter>();
                ReportParameter parm_user = new ReportParameter("p_user", user);
                list_user.Add(parm_user);
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm_user });
                //------------------------------------
                //------------------------------------

                List<ReportParameter> list5 = new List<ReportParameter>();
                ReportParameter parm5 = new ReportParameter("DateDay", AppSetting.dateTimePicker1);
                list5.Add(parm5);
                reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm5 });



                this.reportViewer1.RefreshReport();
            }
            else if (TypePrice == "Sheraa")
            {
                reportViewer1.Visible = false;
                reportViewer2.Visible = true;
                reportViewer3.Visible = false;
                reportViewer4.Visible = false;



                //------------------------------------
                List<ReportParameter> list_user = new List<ReportParameter>();
                ReportParameter parm_user = new ReportParameter("p_user", user);
                list_user.Add(parm_user);
                reportViewer2.LocalReport.SetParameters(new ReportParameter[] { parm_user });
                //------------------------------------
                //------------------------------------

                List<ReportParameter> list5 = new List<ReportParameter>();
                ReportParameter parm5 = new ReportParameter("DateDay", AppSetting.dateTimePicker1);
                list5.Add(parm5);
                reportViewer2.LocalReport.SetParameters(new ReportParameter[] { parm5 });



                this.reportViewer2.RefreshReport();


            }
            else if (TypePrice == "Gomla")
            {
                reportViewer1.Visible = false;
                reportViewer2.Visible = false;
                reportViewer3.Visible = true;
                reportViewer4.Visible = false;



                //------------------------------------
                List<ReportParameter> list_user = new List<ReportParameter>();
                ReportParameter parm_user = new ReportParameter("p_user", user);
                list_user.Add(parm_user);
                reportViewer3.LocalReport.SetParameters(new ReportParameter[] { parm_user });
                //------------------------------------
                //------------------------------------

                List<ReportParameter> list5 = new List<ReportParameter>();
                ReportParameter parm5 = new ReportParameter("DateDay", AppSetting.dateTimePicker1);
                list5.Add(parm5);
                reportViewer3.LocalReport.SetParameters(new ReportParameter[] { parm5 });



                this.reportViewer3.RefreshReport();
            }
            else if (TypePrice == "Kataey")
            {
                reportViewer1.Visible = false;
                reportViewer2.Visible = false;
                reportViewer3.Visible = false;
                reportViewer4.Visible = true;



                //------------------------------------
                List<ReportParameter> list_user = new List<ReportParameter>();
                ReportParameter parm_user = new ReportParameter("p_user", user);
                list_user.Add(parm_user);
                reportViewer4.LocalReport.SetParameters(new ReportParameter[] { parm_user });
                //------------------------------------
                //------------------------------------

                List<ReportParameter> list5 = new List<ReportParameter>();
                ReportParameter parm5 = new ReportParameter("DateDay", AppSetting.dateTimePicker1);
                list5.Add(parm5);
                reportViewer4.LocalReport.SetParameters(new ReportParameter[] { parm5 });



                this.reportViewer4.RefreshReport();
            }


            
            
        }
    }
}
