using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZAD_Sales.Reports
{
    public partial class Frm_Expenses : Form
    {
        public Frm_Expenses()
        {
            InitializeComponent();
        }

        private void Frm_Expenses_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
