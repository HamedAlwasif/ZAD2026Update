using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ZAD_Sales.ClassProject
{
    public static class UnitConverter
    {
        private const float MmPerInch = 25.4f;

        public static float MmToInch(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return 0f;

            value = value.Replace(',', '.');

            if (float.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out float mm))
            {
                return mm / MmPerInch;
            }

            return 0f;
        }
    }
}
