using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Net.NetworkInformation;
using System.Security.Cryptography;

namespace ZAD_Sales.Forms
{
    public partial class License : Form
    {
        public License()
        {
            InitializeComponent();
            textSn.Text = Properties.Settings.Default.sn;
        }
        public static PhysicalAddress GetMacAddress()
        {
            foreach (NetworkInterface MAC in NetworkInterface.GetAllNetworkInterfaces())
            {

                if (MAC.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                    MAC.OperationalStatus == OperationalStatus.Up)
                {
                    return MAC.GetPhysicalAddress();
                }
            }
            return null;
        }

        //public string Get_Procces_ID()
        //{
        //    string val = "";
        //    ManagementObjectSearcher mos = new ManagementObjectSearcher("Select * from Win32_Processor");

        //    foreach (ManagementObject mo in mos.Get())
        //    {
        //        val = mo["ProcessorID"].ToString();
        //    }

        //    //return val;

        //    // لكي يكون البرنامج أكثر احترافية سنقوم بتشفير رقم المعالج
        //    MD5 md5 = new MD5CryptoServiceProvider();
        //    md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(val));
        //    byte[] reslt = md5.Hash;
        //    StringBuilder strbuilder = new StringBuilder();

        //    for (int i = 0; (i <= (reslt.Length - 1)); i++)
        //    {
        //        strbuilder.Append(reslt[i].ToString("x2"));
        //    }

        //    return strbuilder.ToString();


        //    // كذلك نستطيع أن نقسم الرقم التعريفي إلى عدة أجزاء لجعله أكثر احترافية وتعقيدا
        //    //for (int i = 0; (i
        //    // <= (reslt.Length - 1)); i++)
        //    //{
        //    //    strbuilder.Append(reslt[i].ToString("x2"));
        //    //}

        //    //string ss = strbuilder.ToString();
        //    //string newss = (ss.Substring(0, 4) + ("-"
        //    //            + (ss.Substring(4, 4) + ("-"
        //    //            + (ss.Substring(8, 4) + ("-"
        //    //            + (ss.Substring(12, 4) + ("-" + ss.Substring(16, 4)))))))));
        //    //return newss.ToUpper();

        //}
        private void butSave_Click(object sender, EventArgs e)
        {
            string texthddserial = textSn.Text;
            string texthddserial1 = textSn1.Text;

            //****** HDD SERIALNUMBER ايجار رقم الهارد*****************

            //ManagementObject dsk = new ManagementObject(@"win32_logicaldisk.deviceid=""c:""");
            //dsk.Get();
            //string id = dsk["VolumeSerialNumber"].ToString();
            //texthddserial1 = "H2646MHM545E." + id.ToString() + ".H2646MHM545E";

            //**************  ايجاد الماك ادرس******************

            //texthddserial1 = "H2646MHM545E." + GetMacAddress().ToString() + ".H2646MHM545E";

            //******************************************************
            Properties.Settings.Default.sn = textSn.Text;
            Properties.Settings.Default.Demo = "no";
            Properties.Settings.Default.Save();


            if (texthddserial == texthddserial1)
            {


                label14.Text = "تم التفعيل بنجاح";
                label14.ForeColor = Color.Green;
                label14.Visible = true;
                textBox1.Text = "1";

               
            }
            else
            {
                label14.Visible = true;
                textBox1.Text = "0";
                Properties.Settings.Default.Demo = "";
                Properties.Settings.Default.Save();
            }
            //Application.Exit();

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.alwasif.com");
        }

        private void butIn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/hamed-alwasif-aa869a176");
        }

        private void butFace_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/alwasif.software");
        }

        private void butTwiter_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/Hamed_Alwasif");
        }

        private void butYoutube_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.youtube.com/elwesiftv");
        }

        private void butInstgram_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/hamedalwasif");
        }

        private void butSite_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.alwasif.online");
        }

        private void button8_Click(object sender, EventArgs e)
        {
        }

        private void butWhats_Click(object sender, EventArgs e)
        {
            
            System.Diagnostics.Process.Start("https://api.whatsapp.com/send?phone=0201224349933");

        }

        private void License_Load(object sender, EventArgs e)
        {
            textBox2.Text = Tashfer.Get_Procces_ID();
            textCodePrograms.Text ="ZAD-"+ textBox2.Text.Remove(5)+"-" + textBox2.Text.Substring(5,5).ToUpper();



            textSn1.Text = Tashfer.Get_Tashfer(textCodePrograms.Text);
            //textCodePrograms.Text = TransferData.CodePrograms;

            

        }

        private void License_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void License_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textBox1.Text == "0")
            {
                Application.Exit();
            }
            else
            { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textSn.Text = Clipboard.GetText();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://api.whatsapp.com/send?phone=020155893519");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://zadsales.com");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/@zad-sales");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://x.com/ZadSales");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/zad.sales/");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/zadsales2");
        }
    }
}
