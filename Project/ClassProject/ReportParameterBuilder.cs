using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.Reporting.WinForms;

using ZAD_Sales.ClassProject;


using System.IO;

namespace ZAD_Sales.ClassProject
{

    public class ReportParameterBuilder
    {

        public static void SetParameters(
        LocalReport report,
        InvoiceData data)
        {

            try
            {

                Dictionary<string, string> allParams =
                new Dictionary<string, string>()
                {

{"Parm_Company_Name",
data.CompanyName ?? ""},

{"Name",
data.Name ?? ""},

{"Date",
data.Date ?? ""},

{"Total",
data.Total ?? "0"},

{"Sabek",
data.Sabek ?? "0"},

{"Sabek1",
data.Sabek1 ?? "0"},

{"Mosadad",
data.Mosadad ?? "0"},

{"Remaning",
data.Remaning ?? "0"},

{"Discount",
data.Discount ?? "0"},

{"State",
data.State ?? ""},

{"NumBill",
data.NumBill ?? ""},

{"Print",
data.UserPrint ?? ""},

{"TypeBill",
data.TypeBill ?? ""},

{"Parm_MoveBill",
data.MoveBill ?? ""},

{"Parm_NoteToBill",
data.NoteToBill ?? ""},

{"Parm_Company_Description",
data.CompanyDescription ?? ""},

{"Parm_Company_Address",
data.CompanyAddress ?? ""},

{"Parm_Company_Phone",
data.CompanyPhone ?? ""},

{"Mosadad_Actual",
data.MosadadActual ?? "0"},

{"Return",
data.ReturnValue ?? "0"},

{"Demo",
data.Demo ?? ""},

{"Note",
data.Note ?? ""}

                };

                List<ReportParameter> reportParams =
                new List<ReportParameter>();

                foreach (var rp in report.GetParameters())
                {

                    if (allParams.ContainsKey(rp.Name))
                    {

                        reportParams.Add(
                        new ReportParameter(
                        rp.Name,
                        allParams[rp.Name]));

                    }

                }

                // logo

                report.EnableExternalImages = true;

                reportParams.Add(
                new ReportParameter(
                "parmImageUrl",

                File.Exists(data.ImageLogo)
                ? new Uri(data.ImageLogo).AbsoluteUri
                : ""));

                report.SetParameters(reportParams);

            }
            catch
            {

            }

        }

    }

}
