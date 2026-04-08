using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZAD_Sales.Forms
{
    public partial class CallUs : Form
    {
        public CallUs()
        {
            InitializeComponent();
        }

        private void butFace_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/zadsales");

        }

        private void butTwiter_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://x.com/ZadSales");

        }

        private void butInstgram_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/zad.sales/");

        }

        private void butYoutube_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/@zadsoft");
        }

        private void butWhats_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://api.whatsapp.com/send?phone=0201224349933");

        }

        private void butIn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/hamed-alwasif-aa869a176");

        }

        private void butSite_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://zad.alwasif.net");

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}
