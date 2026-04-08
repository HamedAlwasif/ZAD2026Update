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
    public partial class ReportCarsExpensesMovement : Form
    {
        public ReportCarsExpensesMovement()
        {
            InitializeComponent();
        }

        private void ReportCarsExpensesMovement_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'elwesifDataSet102.SearchCar' table. You can move, or remove it, as needed.
            // this.SearchCarTableAdapter.Fill(this.elwesifDataSet102.SearchCar);
            // TODO: This line of code loads data into the 'elwesifDataSet102.SearchCar' table. You can move, or remove it, as needed.
            //this.SearchCarTableAdapter.Fill(this.elwesifDataSet102.SearchCar);

            //this.reportViewer1.RefreshReport();

            string st =AppSetting.staticfieldcar.text;
            string st1 = AppSetting.staticfieldcar.text1;
            string st2 = AppSetting.staticfieldcar.text2;
            string st3 = AppSetting.staticfieldcar.text3;
            string st4 = AppSetting.staticfieldcar.text4;
            string st5 = AppSetting.staticfieldcar.text5;
            string st6 = AppSetting.staticfieldcar.text6;
            string st7 = AppSetting.staticfieldcar.text7;
            string st8 = AppSetting.staticfieldcar.text8;
            string st9 = AppSetting.staticfieldcar.text9;
            string st10 = AppSetting.staticfieldcar.text10;

            //-----------------------------------

            //------------------------------------
            List<ReportParameter> list16 = new List<ReportParameter>();
            ReportParameter parm16 = new ReportParameter("NumCar", st);
            list16.Add(parm16);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm16 });

            //------------------------------------
            List<ReportParameter> list11 = new List<ReportParameter>();
            ReportParameter parm11 = new ReportParameter("Date1", st2);
            list11.Add(parm11);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm11 });

            //--------------------------------

            List<ReportParameter> list12 = new List<ReportParameter>();
            ReportParameter parm12 = new ReportParameter("Date2", st3);
            list12.Add(parm12);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm12 });

            //--------------------------------

            List<ReportParameter> list13 = new List<ReportParameter>();
            ReportParameter parm13 = new ReportParameter("Washed", st4);
            list13.Add(parm13);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm13 });

            //--------------------------------

            List<ReportParameter> list14 = new List<ReportParameter>();
            ReportParameter parm14 = new ReportParameter("Fliter", st5);
            list14.Add(parm14);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm14 });

            //--------------------------------
            List<ReportParameter> list = new List<ReportParameter>();
            ReportParameter parm = new ReportParameter("Gaz", st6);
            list.Add(parm);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm });

            //--------------------------------
            List<ReportParameter> list1 = new List<ReportParameter>();
            ReportParameter parm1 = new ReportParameter("Oil", st7);
            list1.Add(parm1);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm1 });
            //--------------------------------
            List<ReportParameter> list2 = new List<ReportParameter>();
            ReportParameter parm2 = new ReportParameter("Mekaneky", st8);
            list2.Add(parm2);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm2 });
            //--------------------------------
            List<ReportParameter> list3 = new List<ReportParameter>();
            ReportParameter parm3 = new ReportParameter("Part", st9);
            list3.Add(parm3);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm3 });
            //--------------------------------
            List<ReportParameter> list4 = new List<ReportParameter>();
            ReportParameter parm4 = new ReportParameter("Total", st10);
            list4.Add(parm4);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parm4 });



            this.reportViewer1.RefreshReport();
        }
    }
}
