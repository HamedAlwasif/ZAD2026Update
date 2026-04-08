using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAD_Sales.ClassProject
{
    public static class CompanyInfo
    {
        public static string ImageLogoUrl { get; private set; }
        public static string CompanyName { get; private set; }
        public static string CompanyAddress { get; private set; }
        public static string CompanyDescription { get; private set; }
        public static string CompanyPhone { get; private set; }
        public static string NoteToBill { get; private set; }
        public static bool Demo { get; private set; }

        public static void LoadData()
        {
            ImageLogoUrl = AppSetting.Comp_Logo;
            CompanyName = AppSetting.textCompany_Name;
            CompanyAddress = AppSetting.textCompany_Address;
            CompanyDescription = AppSetting.textCompany_Description;
            CompanyPhone = AppSetting.textCompany_Phone;
            NoteToBill = AppSetting.NoteToBill;
          //  Demo = AppSetting.DemoOnBill;
        }
    }
}
