using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ZAD_Sales.ClassProject
{
    public static class AppTheme
    {
        public static Color BackColor = Color.FromArgb(30, 30, 30);
        public static Color PanelColor = Color.FromArgb(45, 45, 48);
        public static Color ButtonColor = Color.FromArgb(0, 122, 204);
        public static Color ButtonHover = Color.FromArgb(28, 151, 234);
        public static Color TextColor = Color.White;
        public static Color SubTextColor = Color.Gainsboro;
        public static Color BorderColor = Color.FromArgb(70, 70, 70);

        public static Font MainFont = new Font("Cairo", 10);
        public static Font BoldFont = new Font("Cairo", 10, FontStyle.Bold);
    }
}
