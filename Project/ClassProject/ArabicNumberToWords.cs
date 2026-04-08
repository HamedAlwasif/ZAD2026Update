using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAD_Sales.ClassProject
{
    class ArabicNumberToWords
    {

        private static string[] ones =
    {
        "", "واحد", "اثنان", "ثلاثة", "أربعة",
        "خمسة", "ستة", "سبعة", "ثمانية", "تسعة",
        "عشرة", "أحد عشر", "اثنا عشر", "ثلاثة عشر",
        "أربعة عشر", "خمسة عشر", "ستة عشر",
        "سبعة عشر", "ثمانية عشر", "تسعة عشر"
    };

        private static string[] tens =
        {
        "", "", "عشرون", "ثلاثون", "أربعون",
        "خمسون", "ستون", "سبعون", "ثمانون", "تسعون"
    };

        private static string[] hundreds =
        {
        "", "مائة", "مائتان", "ثلاثمائة",
        "أربعمائة", "خمسمائة", "ستمائة",
        "سبعمائة", "ثمانمائة", "تسعمائة"
    };

        public static string Convert(decimal number)
        {
            if (number == 0)
                return "صفر جنيه";

            long integerPart = (long)number;
            int decimalPart = (int)((number - integerPart) * 100);

            string result = NumberToWords(integerPart);

            if (decimalPart > 0)
            {
                result += " جنيه و " +
                          NumberToWords(decimalPart) +
                          " قرش";
            }
            else
            {
                result += " جنيه فقط لا غير";
            }

            return result;
        }

        private static string NumberToWords(long number)
        {
            if (number == 0)
                return "";

            if (number < 20)
                return ones[number];

            if (number < 100)
                return tens[number / 10] +
                       (number % 10 != 0 ? " و " + ones[number % 10] : "");

            if (number < 1000)
                return hundreds[number / 100] +
                       (number % 100 != 0 ? " و " + NumberToWords(number % 100) : "");

            if (number < 1000000)
                return NumberToWords(number / 1000) + " ألف " +
                       (number % 1000 != 0 ? " و " + NumberToWords(number % 1000) : "");

            if (number < 1000000000)
                return NumberToWords(number / 1000000) + " مليون " +
                       (number % 1000000 != 0 ? " و " + NumberToWords(number % 1000000) : "");

            return number.ToString();
        }
    }
}
