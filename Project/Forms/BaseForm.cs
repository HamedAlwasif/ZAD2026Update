using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Drawing;
using System.Windows.Forms;

using ZAD_Sales.ClassProject;

namespace ZAD_Sales.Forms
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();

            ApplyTheme(this);
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {

        }

      

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ApplyTheme(this);
        }

        private void ApplyTheme(Control control)
        {
            control.BackColor = AppTheme.BackColor;
            control.ForeColor = AppTheme.TextColor;
            control.Font = AppTheme.MainFont;

            foreach (Control c in control.Controls)
            {
                if (c is Panel)
                {
                    c.BackColor = AppTheme.PanelColor;
                }

                else if (c is Button btn)
                {
                    btn.BackColor = AppTheme.ButtonColor;
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Font = AppTheme.BoldFont;

                    btn.MouseEnter += (s, e) => btn.BackColor = AppTheme.ButtonHover;
                    btn.MouseLeave += (s, e) => btn.BackColor = AppTheme.ButtonColor;
                }

                else if (c is TextBox txt)
                {
                    txt.BackColor = Color.FromArgb(37, 37, 38);
                    txt.ForeColor = Color.White;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                }

                else if (c is Label lbl)
                {
                    lbl.ForeColor = AppTheme.SubTextColor;
                }

                ApplyTheme(c);
            }
        }
    }
}
