using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace ZAD_Sales.ClassProject
{
    public static class UnitHelper
    {
        private const float MmPerInch = 25.4f;

        // mm → inch
        public static float MmToInch(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return 0f;

            value = value.Replace(',', '.');

            if (float.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out float mm))
                return mm / MmPerInch;

            return 0f;
        }

        // mm → pixel (حسب DPI)
        public static float MmToPixel(string value, float dpi)
        {
            return MmToInch(value) * dpi;
        }

        // mm → PaperSize unit (hundredths of inch)
        public static int MmToPaperUnit(float mm)
        {
            return (int)((mm / MmPerInch) * 100);
        }
    }
}
