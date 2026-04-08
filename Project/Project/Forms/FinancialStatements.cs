using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace ZAD_Sales.Forms
{
    public partial class FinancialStatements : Form
    {
        //----------------- ConnectionStrings ------------------

        static string constring = ConfigurationManager.ConnectionStrings["ConnectionStringData"].ConnectionString;
        SqlConnection cn = new SqlConnection(constring);

        //--------------------------------
        string FormName = TransferData.FormName;
        string UserName = TransferData.UserName;
        string SystemPro = "";
        //---------------------------------
        private SqlDataReader reed;
        private SqlDataReader rad;

        public FinancialStatements()
        {
            InitializeComponent();
            //cn.Open();
            sqlCommand1.Connection = cn;
        }
        private void GetData()
        {
            //---- فتح الاتصال
            cn.Open();


            //--------- اجمالى البضاعه الحالية -------------

            sqlCommand1.CommandText = "select ISNULL(SUM(Total*Price),0) as ValueShera From Category   ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {
                string ValueShera = reed["ValueShera"].ToString();

                textCategoryTotal.Text = Math.Round(double.Parse(ValueShera), 2).ToString();
                textCategoryMezania.Text = textCategoryTotal.Text;

                //txtDic.Text = Math.Round(double.Parse(txtDic.Text), 2).ToString();
            }
            reed.Close();
            //--------- المبيعات والمشتريات -------------


            sqlCommand1.CommandText = "select ISNULL(SUM(TotalBill),0) as TotalBill,ISNULL(SUM(Discount),0) as Discount,ISNULL(SUM(TotalBillBuy),0) as TotalBillBuy,ISNULL(SUM(DiscountBuy),0) as DiscountBuy,ISNULL(SUM(TotalBillInvalid),0) as TotalBillInvalid,ISNULL(SUM(TotalBillBuyInvalid),0) as TotalBillBuyInvalid,ISNULL(SUM(Creditor),0) as Creditor,ISNULL(SUM(Adding),0) as Adding,ISNULL(SUM(Pay),0) as Pay,ISNULL(SUM(Paid),0) as Paid From BillingData  ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {
                string TotalBill = reed["TotalBill"].ToString();
                string Discount = reed["Discount"].ToString();
                //  string TotalBillBuy = reed["TotalBillBuy"].ToString();
                string DiscountBuy = reed["DiscountBuy"].ToString();
                string TotalBillInvalid = reed["TotalBillInvalid"].ToString();
                string TotalBillBuyInvalid = reed["TotalBillBuyInvalid"].ToString();
                string Creditor = reed["Creditor"].ToString();
                string Adding = reed["Adding"].ToString();
                string Pay = reed["Pay"].ToString();
                string Paid = reed["Paid"].ToString();

                textMabeaat.Text = TotalBill;
                textDiscMabeaat.Text = Discount;
                //  textMoshtriaatTotal.Text = TotalBillBuy;
                textDisSheraa.Text = DiscountBuy;
                textHalekBeeea.Text = TotalBillInvalid;
                textHaleksheraa.Text = TotalBillBuyInvalid;
                textTawreed.Text = Pay;
                textTahseel.Text = Paid;


            }
            reed.Close();

            //------------------ ايجاد قيمة المشتريات بدون بضاعة اول المدة 

            string Moveee = "فاتورة مشتريات";
            
            sqlCommand1.CommandText = "Select ISNULL(SUM(TotalBillBuy),0) as TotalBillBuy From BillingData Where  Move like '" + Moveee + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textMoshtriaatTotal.Text = reed["TotalBillBuy"].ToString();


            }
            reed.Close();

            //--------- الاموال الصادرة والواردة من الادارة -------------

            sqlCommand1.CommandText = "select ISNULL(SUM(Sader),0) as Sader,ISNULL(SUM(Wared),0) as Wared From Movemoney";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {
                string Sader1 = reed["Sader"].ToString();
                string Wared1 = reed["Wared"].ToString();
                textWaredMoney.Text = Wared1;
                textSadreMoney.Text = Sader1;
            }
            reed.Close();

            //--------------------  رصيد الصندوق ----------
            string Wared = "0";
            string Sader = "0";
            sqlCommand1.CommandText = "select ISNULL(SUM(Wared),0) as wared,ISNULL(SUM(Sader),0) as sader From BoxMove";

            //sqlCommand1.CommandText = "select SUM(Wared) as wared,SUM(Sader) as sader From BoxMove Where  Date >='" + Dtp_FromDate.Value.ToString("MM/dd/yyyy") + "'  and Date <='" + Dtp_ToDate.Value.ToString("MM/dd/yyyy") + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                Wared = reed["wared"].ToString();
                Sader = reed["sader"].ToString();



            }
            reed.Close();


            double nn = Convert.ToDouble(Wared);
            double mm = Convert.ToDouble(Sader);
            double rr = nn - mm;
            textBOXMONY.Text = Math.Round(double.Parse(rr.ToString()), 2).ToString();

            //------------ ايجاد المصروفات والايرادات الاخرى

            sqlCommand1.CommandText = "Select ISNULL(SUM(ExpensesOther),0) as ExpensesOther,ISNULL(SUM(IncomeOther),0) as IncomeOther From CategoryOthers";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textMasrofatOkhra.Text = reed["ExpensesOther"].ToString();
                textEradadOther.Text = reed["IncomeOther"].ToString();

            }
            reed.Close();

            //------------ ايجاد الاصول الثابتة

            sqlCommand1.CommandText = "Select ISNULL(SUM(Akaar),0) as Akaar,ISNULL(SUM(Arady),0) as Arady,ISNULL(SUM(Electric),0) as Electric,ISNULL(SUM(Asas),0) as Asas From OsolSabta";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textAkaar.Text = reed["Akaar"].ToString();
                textArady.Text = reed["Arady"].ToString();
                textElectric.Text = reed["Electric"].ToString();
                textAsas.Text = reed["Asas"].ToString();
                textAkarMezania.Text = textAkaar.Text;
                textAradyMezania.Text = textArady.Text;
                textElectricMezania.Text = textElectric.Text;
                textAsasMezania.Text = textAsas.Text;

            }
            reed.Close();

            //------------ ايجاد مصاريف السيارات

            sqlCommand1.CommandText = "Select ISNULL(SUM(Total),0) as Total From SearchCar ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textCars.Text = reed["Total"].ToString();
                textCar2.Text = reed["Total"].ToString();


            }
            reed.Close();
            //------------ ايجاد اجمالى قيمةالسيارات

            sqlCommand1.CommandText = "Select ISNULL(SUM(Price),0) as Price From Car ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textCarsMezania.Text = reed["Price"].ToString();
            }
            reed.Close();

            //------------ ايجاد اول المدة

            sqlCommand1.CommandText = "Select ISNULL(SUM(GardFrist),0) as GardFrist,ISNULL(SUM(Madenon),0) as Madenon,ISNULL(SUM(Daenon),0) as Daenon,ISNULL(SUM(Box),0) as Box,ISNULL(SUM(Building),0) as Building,ISNULL(SUM(Electronic),0) as Electronic,ISNULL(SUM(BasisOFFICE),0) as BasisOFFICE,ISNULL(SUM(Bank),0) as Bank,ISNULL(SUM(adv),0) as adv  From FristGard  ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textCategoryFrist.Text = reed["GardFrist"].ToString();
                textMadenonFrist.Text = reed["Madenon"].ToString();
                textDaneonFrist.Text = reed["Daenon"].ToString();
                textBoxFrist.Text = reed["Box"].ToString();
                textAkaratFrist.Text = reed["Building"].ToString();
                textElectFrist.Text = reed["Electronic"].ToString();
                textAsasFrist.Text = reed["BasisOFFICE"].ToString();
                textBankFrist.Text = reed["Bank"].ToString();
                textAdvFrist.Text = reed["adv"].ToString();

                //textPriceSH.Text = Math.Round(double.Parse(textPriceSH.Text), 2).ToString();

                textDaneonFrist1.Text = textDaneonFrist.Text;
                textMadenonFrist1.Text = textMadenonFrist.Text;


            }
            reed.Close();

            //-------------------------------مسحوبات وواردات اموال 
            sqlCommand1.CommandText = "Select ISNULL(SUM(Sader),0) as Sader,ISNULL(SUM(Wared),0) as Wared From Movemoney";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textSadreMoney.Text = reed["Sader"].ToString();
                textWaredMoney.Text = reed["Wared"].ToString();

                textWaredMoney1.Text = textWaredMoney.Text;
                textSadreMoney1.Text = textSadreMoney.Text;


            }
            reed.Close();
            //--------------------   اجمال الدائنين والمدينين الفعاليين ----------
            string stateClint = "فعال";
            sqlCommand1.CommandText = "select ISNULL(SUM(PreviousBalance),0) as PreviousBalance From Clients Where PreviousBalance >='" + 0 + "' and StateRaseed ='" + stateClint + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textMadenon.Text = reed["PreviousBalance"].ToString();

            }
            reed.Close();

            sqlCommand1.CommandText = "select ISNULL(SUM(PreviousBalance),0) as PreviousBalance From Clients Where PreviousBalance >='" + 0 + "' and StateRaseed !='" + stateClint + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textMadenonMaadomh.Text = reed["PreviousBalance"].ToString();

            }
            reed.Close();

            sqlCommand1.CommandText = "select ISNULL(SUM(PreviousBalance),0) as PreviousBalance From Clients Where PreviousBalance <='" + 0 + "' and StateRaseed ='" + stateClint + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                //textDaenon.Text = reed["PreviousBalance"].ToString();

                double a = Convert.ToDouble(reed["PreviousBalance"].ToString()); //
                double dd = a * (-1); //
                textDaenon.Text = dd.ToString();

            }
            reed.Close();

            sqlCommand1.CommandText = "select ISNULL(SUM(PreviousBalance),0) as PreviousBalance From Clients Where PreviousBalance <='" + 0 + "' and StateRaseed !='" + stateClint + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                //textDaenonMaadomh.Text = reed["PreviousBalance"].ToString();
                double a = Convert.ToDouble(reed["PreviousBalance"].ToString()); //
                double dd = a * (-1); //
                textDaenonMaadomh.Text = dd.ToString();

            }
            reed.Close();

            //---------------------------- المرتبات
            sqlCommand1.CommandText = "Select ISNULL(SUM(Sarf),0) as Sarf From EmployedSalary  ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textMortabat.Text = reed["Sarf"].ToString();
                textMortabat2.Text = reed["Sarf"].ToString();


            }
            reed.Close();
            //-------------------------------------المصاريف ----------------------------//
            //-------------------------------- مصاريف مشتريات ----------------------------------
            string Masrofat = "مصاريف مشتريات";
            textMoshtriat.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat + "'  ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textMoshtriat.Text = reed["Paid"].ToString();
                textMoshtriat.Text = Math.Round(double.Parse(textMoshtriat.Text), 2).ToString();



            }
            reed.Close();
            //-------------------------------- مصاريف نثرية ----------------------------------
            string Masrofat1 = "مصاريف نثريه";
            textNathria.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat1 + "'  ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textNathria.Text = reed["Paid"].ToString();


            }
            reed.Close();
            //-------------------------------- مصاريف دعاية ----------------------------------
            string Masrofat2 = "مصاريف دعاية";
            textAdvs.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat2 + "' ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textAdvs.Text = reed["Paid"].ToString();


            }
            reed.Close();
            //-------------------------------- مصاريف صيانه ----------------------------------
            string Masrofat3 = "مصاريف صيانة";
            textSeiana.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat3 + "'  ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textSeiana.Text = reed["Paid"].ToString();


            }
            reed.Close();
            //-------------------------------- مصاريف ايجار ----------------------------------
            string Masrofat4 = "مصاريف ايجار";
            textEgar.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat4 + "'  ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textEgar.Text = reed["Paid"].ToString();


            }
            reed.Close();
            //-------------------------------- مصاريف كهرباء ----------------------------------
            string Masrofat5 = "فاتورة كهرباء";
            textKahraba.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat5 + "'  ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textKahraba.Text = reed["Paid"].ToString();


            }
            reed.Close();
            //-------------------------------- مصاريف مياه ----------------------------------
            string Masrofat6 = "فاتورة مياه";
            textWater.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat6 + "'  ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textWater.Text = reed["Paid"].ToString();


            }
            reed.Close();
            //-------------------------------- مصاريف تليفون ----------------------------------
            string Masrofat7 = "فاتورة تليفون";
            textTell.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat7 + "'  ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textTell.Text = reed["Paid"].ToString();


            }
            reed.Close();
            //-------------------------------- مصاريف انترنت ----------------------------------
            string Masrofat8 = "فاتورة انترنت";
            textNet.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat8 + "'   ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textNet.Text = reed["Paid"].ToString();


            }
            reed.Close();

            //-------------------------------- الارباح المسحوبة ----------------------------------
            string Masrofat10 = "سحب ارباح";
            textNet.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move = '" + Masrofat10 + "'   ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                text_Arbah.Text = reed["Paid"].ToString();


            }
            reed.Close();
            //--------------------------------   اجمالى المصاريف بدون مصاريف الشراء ----------------------------------
            string Masrofat9 = "مصاريف مشتريات";
            textTotalMasrofat2.Text = "0";
            sqlCommand1.CommandText = "Select ISNULL(SUM(Paid),0) as Paid From Expended Where  move != '" + Masrofat9 + "'  ";
            reed = sqlCommand1.ExecuteReader();
            while (reed.Read())
            {

                textTotalMasrofat2.Text = reed["Paid"].ToString();


            }
            reed.Close();
            //--------- غلق الاتصال ----------------
            cn.Close();

            //------------------ الحساب ------------
            count();
        }
        private void count()
        {
            //------------------------------------------  الحسابات قائمة الدخل------------------------------------//
            // صافى المبيعات = المبيعات - (مردودات + خصم مسموح به
            double aaa = Convert.ToDouble(textMabeaat.Text); // مبيعات
            double bbb = Convert.ToDouble(textHalekBeeea.Text); // مردودات مبيعات
            double ddd = Convert.ToDouble(textDiscMabeaat.Text); // خصومات مبيعات

            double ccc = aaa - (bbb + ddd); // 

            textSafyMabeaat.Text = Math.Round(double.Parse(ccc.ToString()), 2).ToString(); // صافى مبيعات



            //صافى المشتريات = المشتريات + مصروفاتها - مردودات المشتريات + خصم شراء
            // صافى المبيعات = المبيعات - (مردودات + خصم مسموح به
            double aaaa = Convert.ToDouble(textMoshtriaatTotal.Text); // مشتريات
            double bbbb = Convert.ToDouble(textMoshtriat.Text); // مصروفات المشتريات
            double cccc = Convert.ToDouble(textHaleksheraa.Text); // مردودات مشتريات
            double dddd = Convert.ToDouble(textDisSheraa.Text); // خصومات مشتريات

            double eeee = (aaaa + bbbb) - (cccc + dddd); // صافى المشتريات
            textSafyMoshtriat.Text = Math.Round(double.Parse(eeee.ToString()), 2).ToString(); // تكلفة المبيعات

            //تكلفة المبيعات = صافى المشتريات + مخزون اول المدة - مخزون اخر المدة
            double aaa1 = Convert.ToDouble(textCategoryFrist.Text); // بضاعة اول المدة
            double bbb1 = Convert.ToDouble(textCategoryTotal.Text); // بضاعة اخر المدة

            double ccc1 = eeee + (aaa1 - bbb1); // 

            textTakleftMabeaat.Text = Math.Round(double.Parse(ccc1.ToString()), 2).ToString(); // تكلفة المبيعات


            // مجمل الربح
            double aa = Convert.ToDouble(textSafyMabeaat.Text); //صافى مبيعات
            double bb = Convert.ToDouble(textTakleftMabeaat.Text); // تكلفة مبيعات
            double dd = aa - bb; //
            textRebh.Text = Math.Round(double.Parse(dd.ToString()), 2).ToString(); // مجمل الربح

            // اجمالى المصروفات
            double a11 = Convert.ToDouble(textMortabat2.Text); //مرتبات
            double b11 = Convert.ToDouble(textCar2.Text); // سيارات
            double c11 = Convert.ToDouble(textMasrofatOkhra.Text); // مصروفات اخرى
            double d11 = Convert.ToDouble(textTotalMasrofat2.Text); // مصروفات نثرية
            double e11 = a11 + b11 + d11 + c11; // 
            textMasarefTotal.Text = Math.Round(double.Parse(e11.ToString()), 2).ToString(); // اجمالى المصروفات
                                                                                            // اجمالى الايرادات
            double a1 = Convert.ToDouble(textEradadAkarat.Text); //ايرادات عقارات
            double b1 = Convert.ToDouble(textEradadOther.Text); // ايرادات اخرى
                                                                // double ab1 = Convert.ToDouble(textDaenonMaadomh2.Text); // دائنون معدومة لنا
            double d1 = a1 + b1; //
            textEradadTotal.Text = Math.Round(double.Parse(d1.ToString()), 2).ToString(); // اجمالى الايرادات

            // حساب صافى الربح او الخسارة
            double a = Convert.ToDouble(textRebh.Text); // مجمل الربح
            double b = Convert.ToDouble(textMasarefTotal.Text); // اجمالى المصاريف
            double c = Convert.ToDouble(textEradadTotal.Text); // اجمالى الايرادات

            double d = (a + c) - b; // 
                                    //  textRebhOrKHesara.Text = d.ToString(); // الربح او الخسارة
            textRebhOrKHesara.Text = Math.Round(double.Parse(d.ToString()), 2).ToString();





            //------------------------------------------  الحسابات المركز المالى - الميزانية------------------------------------//
            //----------------- الأصــــــــــــــــــــــول ------------------
            textNakdeia.Text = textBOXMONY.Text;  //النقدية



            // حساب المدينون
            double am = Convert.ToDouble(textMadenon.Text); // مدينون
            double bm = Convert.ToDouble(textMadenonMaadomh.Text); // مدينون معدومه
            double cm = am + bm;
            textMadenonMezania.Text = Math.Round(double.Parse(cm.ToString()), 2).ToString(); // مدينون





            // حساب اجمالى الاصول المتداوله
            double amm = Convert.ToDouble(textNakdeia.Text); // النقدية
            double bmm = Convert.ToDouble(textMadenonMezania.Text); // مدينون 
            double cmm = Convert.ToDouble(textCategoryMezania.Text); // البضاعه 
            double dmm = Convert.ToDouble(textMasrofatMokadma.Text); // مصروفات مقدمه 
            double dmm1 = Convert.ToDouble(textSadreMoney1.Text); // مسحوبات 
            double dmm11 = Convert.ToDouble(textDaneonFrist1.Text); // دائنون اول المدة 
            double emm = amm + bmm + cmm + dmm + dmm1 + dmm11;
            textTotalOsolMotadawla.Text = Math.Round(double.Parse(emm.ToString()), 2).ToString(); // اجمالى اصول متداوله

            // حساب اجمالى الاصول الثابتةه
            double aamm = Convert.ToDouble(textAradyMezania.Text); // اراضى
            double bamm = Convert.ToDouble(textAkarMezania.Text); // مبانى 
            double camm = Convert.ToDouble(textCarsMezania.Text); // سيارات 
            double damm = Convert.ToDouble(textAsasMezania.Text); // اثاث
            double damma = Convert.ToDouble(textElectricMezania.Text); // اثاث
            double eamm = aamm + bamm + camm + damm + damma;
            textTotalOsolSabta.Text = Math.Round(double.Parse(eamm.ToString()), 2).ToString(); // اجمالى اصول الثابتة

            // حساب اجمالى الاصــــــــــــــــول
            double asm = Convert.ToDouble(textTotalOsolMotadawla.Text); // اجمالى اصول متداوله
            double bsm = Convert.ToDouble(textTotalOsolSabta.Text); // اجمالى اصول الثابتة
            double csm = Convert.ToDouble(textSHohra.Text); // اجمالى اصول غير ملموسه - شهرة
            double dsm = asm + bsm + csm;
            textTotalOsool.Text = Math.Round(double.Parse(dsm.ToString()), 2).ToString(); // مدينون


            //-------------------------- الخصــــــــــــــــــــوم --------------
            textElarbah.Text = textRebhOrKHesara.Text; // الارباح

            // حساب الدائنون
            double aam = Convert.ToDouble(textDaenon.Text); // دائنون
            double bbm = Convert.ToDouble(textDaenonMaadomh.Text); // دائنون معدومه
            double ccm = aam + bbm;
            textDaenonMezania.Text = Math.Round(double.Parse(ccm.ToString()), 2).ToString(); // دائنون


            // حساب اجمالى الخصوم المتداوله
            double abmm = Convert.ToDouble(textDaenonMezania.Text); // دائنون
            double bbmm = Convert.ToDouble(textMasrofatMostahka.Text); // مصروفات مستحقه 
            double cbmm = Convert.ToDouble(textEradadMokadma.Text); // ايرادات مقدمه 
            double cbmm1 = Convert.ToDouble(textWaredMoney1.Text); // اضافات الصندوق
            double cbmm11 = Convert.ToDouble(textMadenonFrist1.Text); // مدينون اول المده
            double ebmm = abmm + bbmm + cbmm + cbmm1 + cbmm11;
            textTotalKhosomMotadawla.Text = Math.Round(double.Parse(ebmm.ToString()), 2).ToString(); // اجمالى خصوم متداوله

            // حساب اجمالى حقوق الملكيه
            double aaamm = Convert.ToDouble(textRasElmal.Text); // اراضى
            double baamm = Convert.ToDouble(textElarbah.Text); // مبانى 
            double eaamm = aaamm + baamm;
            textTotalHokokELmelkia.Text = Math.Round(double.Parse(eaamm.ToString()), 2).ToString(); // اجمالى حقوق الملكية

            // حساب اجمالى الخصوم وحقوق الملكية
            double asmm = Convert.ToDouble(textTotalKhosomMotadawla.Text); // اجمالى خصوم متداوله
            double bsmm = Convert.ToDouble(textTotalHokokELmelkia.Text); //اجمالى حقوق الملكية
            double csmm = Convert.ToDouble(textKrood.Text); // القروض
            double dsmm = asmm + bsmm + csmm;
            textTotalKhosom.Text = Math.Round(double.Parse(dsmm.ToString()), 2).ToString(); // اجمالى الخصوم وحقوق الملكية
        }
        private void FinancialStatements_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
