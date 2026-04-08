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
    public partial class Frm_AllBills : Form
    {
        public Frm_AllBills()
        {
            InitializeComponent();
        }

        private void Frm_AllBills_Load(object sender, EventArgs e)
        {
            //string user = AppSetting.user;
            //string datefrom = AppSetting.date_From;
            //string dateto = AppSetting.date_To;

            //------------------------------------
            List<ReportParameter> list_user = new List<ReportParameter>();
            ReportParameter parm_user = new ReportParameter("p_user", AppSetting.user);
            list_user.Add(parm_user);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm_user });

            //***********************
            List<ReportParameter> list_Company_Address = new List<ReportParameter>();
            ReportParameter parm_Company_Address = new ReportParameter("Parm_Company_Address", AppSetting.textCompany_Address);
            list_Company_Address.Add(parm_Company_Address);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Address });



            //***********************

            //***********************

            List<ReportParameter> list_TypeBill = new List<ReportParameter>();
            ReportParameter parm_TypeBill = new ReportParameter("Parm_TypeBill", AppSetting.TypeBill);
            list_TypeBill.Add(parm_TypeBill);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm_TypeBill });


            //***********************



            List<ReportParameter> list_Company_Phone = new List<ReportParameter>();
            ReportParameter parm_Company_Phone = new ReportParameter("Parm_Company_Phone", AppSetting.textCompany_Phone);
            list_Company_Phone.Add(parm_Company_Phone);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm_Company_Phone });


            this.reportViewer1.RefreshReport();
        }
    }
}
