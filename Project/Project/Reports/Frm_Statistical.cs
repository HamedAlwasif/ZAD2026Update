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
    public partial class Frm_Statistical : Form
    {
        public Frm_Statistical()
        {
            InitializeComponent();
        }

        private void Frm_Statistical_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
