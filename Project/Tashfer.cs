using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Management;
using System.Net.NetworkInformation;

namespace ZAD_Sales
{
    class Tashfer
    {
        //------------ دالة التشفير -----------
        public static string Get_Tashfer(string val)
        {
            //string val = num;
            // لكي يكون البرنامج أكثر احترافية سنقوم بتشفير رقم المعالج
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(val));
            byte[] reslt = md5.Hash;
            StringBuilder strbuilder = new StringBuilder();

            for (int i = 0; (i <= (reslt.Length - 1)); i++)
            {
                strbuilder.Append(reslt[i].ToString("x2"));
            }
            //return strbuilder.ToString();
            // كذلك نستطيع أن نقسم الرقم التعريفي إلى عدة أجزاء لجعله أكثر احترافية وتعقيدا
            for (int i = 0; (i
             <= (reslt.Length - 1)); i++)
            {
                strbuilder.Append(reslt[i].ToString("x2"));
            }

            string ss = strbuilder.ToString();
            string newss = (ss.Substring(0, 4) + ("-"
                        + (ss.Substring(4, 4) + ("-"
                        + (ss.Substring(8, 4) + ("-"
                        + (ss.Substring(12, 4) + ("-" + ss.Substring(16, 4)))))))));
            return newss.ToUpper();
        }
        public static string Get_Procces_ID()
        {
            string val = "";
            ManagementObjectSearcher mos = new ManagementObjectSearcher("Select * from Win32_Processor");

            foreach (ManagementObject mo in mos.Get())
            {
                val = mo["ProcessorID"].ToString();
            }

            //return val;

            // لكي يكون البرنامج أكثر احترافية سنقوم بتشفير رقم المعالج
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(val));
            byte[] reslt = md5.Hash;
            StringBuilder strbuilder = new StringBuilder();

            for (int i = 0; (i <= (reslt.Length - 1)); i++)
            {
                strbuilder.Append(reslt[i].ToString("x2"));
            }

            return strbuilder.ToString();


            // كذلك نستطيع أن نقسم الرقم التعريفي إلى عدة أجزاء لجعله أكثر احترافية وتعقيدا
            //for (int i = 0; (i
            // <= (reslt.Length - 1)); i++)
            //{
            //    strbuilder.Append(reslt[i].ToString("x2"));
            //}

            //string ss = strbuilder.ToString();
            //string newss = (ss.Substring(0, 4) + ("-"
            //            + (ss.Substring(4, 4) + ("-"
            //            + (ss.Substring(8, 4) + ("-"
            //            + (ss.Substring(12, 4) + ("-" + ss.Substring(16, 4)))))))));
            //return newss.ToUpper();

        }
    }
}
