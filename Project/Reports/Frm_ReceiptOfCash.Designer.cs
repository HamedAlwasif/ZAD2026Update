namespace ZAD_Sales.Reports
{
    partial class Frm_ReceiptOfCash
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.butA5_ReceiptGeneral = new System.Windows.Forms.Button();
            this.butA5_ReceiptDetailed = new System.Windows.Forms.Button();
            this.reportViewerReceiptDefoult = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewerReceiptFull = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewerCasher8 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewerCasher8Full = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttNoPriceA4 = new System.Windows.Forms.Button();
            this.butReportEmpA5 = new System.Windows.Forms.Button();
            this.buttCaser8cm_NoDes = new System.Windows.Forms.Button();
            this.buttCaser8cm = new System.Windows.Forms.Button();
            this.buttCaser8Defoult = new System.Windows.Forms.Button();
            this.PrintDefoult = new System.Windows.Forms.Button();
            this.buttA4 = new System.Windows.Forms.Button();
            this.buttB5 = new System.Windows.Forms.Button();
            this.buttA = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butA5_ReceiptGeneral
            // 
            this.butA5_ReceiptGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(172)))), ((int)(((byte)(132)))));
            this.butA5_ReceiptGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butA5_ReceiptGeneral.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butA5_ReceiptGeneral.ForeColor = System.Drawing.Color.White;
            this.butA5_ReceiptGeneral.Location = new System.Drawing.Point(765, 76);
            this.butA5_ReceiptGeneral.Name = "butA5_ReceiptGeneral";
            this.butA5_ReceiptGeneral.Size = new System.Drawing.Size(191, 39);
            this.butA5_ReceiptGeneral.TabIndex = 55;
            this.butA5_ReceiptGeneral.Text = "طباعة ايصال عام";
            this.butA5_ReceiptGeneral.UseVisualStyleBackColor = false;
            this.butA5_ReceiptGeneral.Visible = false;
            this.butA5_ReceiptGeneral.Click += new System.EventHandler(this.butA5_ReceiptGeneral_Click);
            // 
            // butA5_ReceiptDetailed
            // 
            this.butA5_ReceiptDetailed.BackColor = System.Drawing.Color.Teal;
            this.butA5_ReceiptDetailed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butA5_ReceiptDetailed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butA5_ReceiptDetailed.ForeColor = System.Drawing.Color.White;
            this.butA5_ReceiptDetailed.Location = new System.Drawing.Point(765, 121);
            this.butA5_ReceiptDetailed.Name = "butA5_ReceiptDetailed";
            this.butA5_ReceiptDetailed.Size = new System.Drawing.Size(191, 39);
            this.butA5_ReceiptDetailed.TabIndex = 56;
            this.butA5_ReceiptDetailed.Text = "طباعة ايصال تفصيلى";
            this.butA5_ReceiptDetailed.UseVisualStyleBackColor = false;
            this.butA5_ReceiptDetailed.Visible = false;
            this.butA5_ReceiptDetailed.Click += new System.EventHandler(this.butA5_ReceiptDetailed_Click);
            // 
            // reportViewerReceiptDefoult
            // 
            this.reportViewerReceiptDefoult.LocalReport.ReportEmbeddedResource = "ZAD_Sales.Reports.Frm_ReceiptOfCash.rdlc";
            this.reportViewerReceiptDefoult.Location = new System.Drawing.Point(27, 62);
            this.reportViewerReceiptDefoult.Name = "reportViewerReceiptDefoult";
            this.reportViewerReceiptDefoult.ServerReport.BearerToken = null;
            this.reportViewerReceiptDefoult.Size = new System.Drawing.Size(728, 509);
            this.reportViewerReceiptDefoult.TabIndex = 57;
            // 
            // reportViewerReceiptFull
            // 
            this.reportViewerReceiptFull.LocalReport.ReportEmbeddedResource = "ZAD_Sales.Reports.Frm_ReceiptOfCashFull.rdlc";
            this.reportViewerReceiptFull.Location = new System.Drawing.Point(27, 62);
            this.reportViewerReceiptFull.Name = "reportViewerReceiptFull";
            this.reportViewerReceiptFull.ServerReport.BearerToken = null;
            this.reportViewerReceiptFull.Size = new System.Drawing.Size(728, 509);
            this.reportViewerReceiptFull.TabIndex = 58;
            this.reportViewerReceiptFull.Visible = false;
            // 
            // reportViewerCasher8
            // 
            this.reportViewerCasher8.LocalReport.ReportEmbeddedResource = "ZAD_Sales.Reports.Frm_ReceiptOfCashCasher8.rdlc";
            this.reportViewerCasher8.Location = new System.Drawing.Point(27, 62);
            this.reportViewerCasher8.Name = "reportViewerCasher8";
            this.reportViewerCasher8.ServerReport.BearerToken = null;
            this.reportViewerCasher8.Size = new System.Drawing.Size(728, 509);
            this.reportViewerCasher8.TabIndex = 58;
            this.reportViewerCasher8.Visible = false;
            // 
            // reportViewerCasher8Full
            // 
            this.reportViewerCasher8Full.LocalReport.ReportEmbeddedResource = "ZAD_Sales.Reports.Frm_ReceiptOfCashFullCasher8.rdlc";
            this.reportViewerCasher8Full.Location = new System.Drawing.Point(27, 62);
            this.reportViewerCasher8Full.Name = "reportViewerCasher8Full";
            this.reportViewerCasher8Full.ServerReport.BearerToken = null;
            this.reportViewerCasher8Full.Size = new System.Drawing.Size(728, 509);
            this.reportViewerCasher8Full.TabIndex = 58;
            this.reportViewerCasher8Full.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(216)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.buttNoPriceA4);
            this.panel1.Controls.Add(this.butReportEmpA5);
            this.panel1.Controls.Add(this.buttCaser8cm_NoDes);
            this.panel1.Controls.Add(this.buttCaser8cm);
            this.panel1.Controls.Add(this.buttCaser8Defoult);
            this.panel1.Controls.Add(this.PrintDefoult);
            this.panel1.Controls.Add(this.buttA4);
            this.panel1.Controls.Add(this.buttB5);
            this.panel1.Controls.Add(this.buttA);
            this.panel1.Location = new System.Drawing.Point(-1, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 60);
            this.panel1.TabIndex = 66;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(101)))), ((int)(((byte)(132)))));
            this.label9.Location = new System.Drawing.Point(13, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 13);
            this.label9.TabIndex = 5544;
            this.label9.Text = "A4 - بيان بدون اسعار";
            this.label9.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(101)))), ((int)(((byte)(132)))));
            this.label8.Location = new System.Drawing.Point(51, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 5544;
            this.label8.Text = "A5 - بيان بدون اسعار";
            this.label8.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(101)))), ((int)(((byte)(132)))));
            this.label7.Location = new System.Drawing.Point(119, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 5544;
            this.label7.Text = "كاشير 8 بدون خصم";
            this.label7.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(101)))), ((int)(((byte)(132)))));
            this.label6.Location = new System.Drawing.Point(248, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 5544;
            this.label6.Text = "كاشير 8 تفصيلى";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(101)))), ((int)(((byte)(132)))));
            this.label5.Location = new System.Drawing.Point(339, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 5544;
            this.label5.Text = "كاشير 8 عام";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(101)))), ((int)(((byte)(132)))));
            this.label4.Location = new System.Drawing.Point(426, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 5544;
            this.label4.Text = "ايصال تفصيلى";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(101)))), ((int)(((byte)(132)))));
            this.label3.Location = new System.Drawing.Point(707, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 5544;
            this.label3.Text = "A4";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(101)))), ((int)(((byte)(132)))));
            this.label2.Location = new System.Drawing.Point(763, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 5544;
            this.label2.Text = "B5";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(101)))), ((int)(((byte)(132)))));
            this.label1.Location = new System.Drawing.Point(507, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 5544;
            this.label1.Text = "ايصال عام";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(101)))), ((int)(((byte)(132)))));
            this.panel2.Location = new System.Drawing.Point(414, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(3, 50);
            this.panel2.TabIndex = 66;
            // 
            // buttNoPriceA4
            // 
            this.buttNoPriceA4.AccessibleName = "عملاء اليوم";
            this.buttNoPriceA4.BackgroundImage = global::ZAD_Sales.Properties.Resources.PrintNoPrice_Zad1;
            this.buttNoPriceA4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttNoPriceA4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttNoPriceA4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(216)))), ((int)(((byte)(224)))));
            this.buttNoPriceA4.Location = new System.Drawing.Point(45, 6);
            this.buttNoPriceA4.Name = "buttNoPriceA4";
            this.buttNoPriceA4.Size = new System.Drawing.Size(32, 30);
            this.buttNoPriceA4.TabIndex = 5543;
            this.buttNoPriceA4.UseVisualStyleBackColor = true;
            this.buttNoPriceA4.Visible = false;
            // 
            // butReportEmpA5
            // 
            this.butReportEmpA5.AccessibleName = "عملاء اليوم";
            this.butReportEmpA5.BackgroundImage = global::ZAD_Sales.Properties.Resources.PrintNoPrice_Zad;
            this.butReportEmpA5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butReportEmpA5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butReportEmpA5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(216)))), ((int)(((byte)(224)))));
            this.butReportEmpA5.Location = new System.Drawing.Point(84, 3);
            this.butReportEmpA5.Name = "butReportEmpA5";
            this.butReportEmpA5.Size = new System.Drawing.Size(32, 30);
            this.butReportEmpA5.TabIndex = 5543;
            this.butReportEmpA5.UseVisualStyleBackColor = true;
            this.butReportEmpA5.Visible = false;
            // 
            // buttCaser8cm_NoDes
            // 
            this.buttCaser8cm_NoDes.AccessibleName = "عملاء اليوم";
            this.buttCaser8cm_NoDes.BackgroundImage = global::ZAD_Sales.Properties.Resources.PrintCacher_Zad;
            this.buttCaser8cm_NoDes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttCaser8cm_NoDes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttCaser8cm_NoDes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(216)))), ((int)(((byte)(224)))));
            this.buttCaser8cm_NoDes.Location = new System.Drawing.Point(122, 0);
            this.buttCaser8cm_NoDes.Name = "buttCaser8cm_NoDes";
            this.buttCaser8cm_NoDes.Size = new System.Drawing.Size(32, 30);
            this.buttCaser8cm_NoDes.TabIndex = 5543;
            this.buttCaser8cm_NoDes.UseVisualStyleBackColor = true;
            this.buttCaser8cm_NoDes.Visible = false;
            // 
            // buttCaser8cm
            // 
            this.buttCaser8cm.AccessibleName = "عملاء اليوم";
            this.buttCaser8cm.BackgroundImage = global::ZAD_Sales.Properties.Resources.PrintCacher_Zad2;
            this.buttCaser8cm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttCaser8cm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttCaser8cm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(216)))), ((int)(((byte)(224)))));
            this.buttCaser8cm.Location = new System.Drawing.Point(267, 6);
            this.buttCaser8cm.Name = "buttCaser8cm";
            this.buttCaser8cm.Size = new System.Drawing.Size(32, 30);
            this.buttCaser8cm.TabIndex = 5543;
            this.buttCaser8cm.UseVisualStyleBackColor = true;
            this.buttCaser8cm.Click += new System.EventHandler(this.buttCaser8cm_Click);
            // 
            // buttCaser8Defoult
            // 
            this.buttCaser8Defoult.AccessibleName = "عملاء اليوم";
            this.buttCaser8Defoult.BackgroundImage = global::ZAD_Sales.Properties.Resources.PrintCacher_Zad3;
            this.buttCaser8Defoult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttCaser8Defoult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttCaser8Defoult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(216)))), ((int)(((byte)(224)))));
            this.buttCaser8Defoult.Location = new System.Drawing.Point(355, 6);
            this.buttCaser8Defoult.Name = "buttCaser8Defoult";
            this.buttCaser8Defoult.Size = new System.Drawing.Size(32, 30);
            this.buttCaser8Defoult.TabIndex = 5543;
            this.buttCaser8Defoult.UseVisualStyleBackColor = true;
            this.buttCaser8Defoult.Click += new System.EventHandler(this.buttCaser8Defoult_Click);
            // 
            // PrintDefoult
            // 
            this.PrintDefoult.AccessibleName = "عملاء اليوم";
            this.PrintDefoult.BackgroundImage = global::ZAD_Sales.Properties.Resources.Print_Zad3;
            this.PrintDefoult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PrintDefoult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrintDefoult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(216)))), ((int)(((byte)(224)))));
            this.PrintDefoult.Location = new System.Drawing.Point(517, 9);
            this.PrintDefoult.Name = "PrintDefoult";
            this.PrintDefoult.Size = new System.Drawing.Size(32, 30);
            this.PrintDefoult.TabIndex = 5543;
            this.PrintDefoult.UseVisualStyleBackColor = true;
            this.PrintDefoult.Click += new System.EventHandler(this.PrintDefoult_Click);
            // 
            // buttA4
            // 
            this.buttA4.AccessibleName = "عملاء اليوم";
            this.buttA4.BackgroundImage = global::ZAD_Sales.Properties.Resources.Print_Zad6;
            this.buttA4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttA4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttA4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(216)))), ((int)(((byte)(224)))));
            this.buttA4.Location = new System.Drawing.Point(700, 9);
            this.buttA4.Name = "buttA4";
            this.buttA4.Size = new System.Drawing.Size(32, 30);
            this.buttA4.TabIndex = 5543;
            this.buttA4.UseVisualStyleBackColor = true;
            this.buttA4.Visible = false;
            // 
            // buttB5
            // 
            this.buttB5.AccessibleName = "عملاء اليوم";
            this.buttB5.BackgroundImage = global::ZAD_Sales.Properties.Resources.print;
            this.buttB5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttB5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttB5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(216)))), ((int)(((byte)(224)))));
            this.buttB5.Location = new System.Drawing.Point(755, 9);
            this.buttB5.Name = "buttB5";
            this.buttB5.Size = new System.Drawing.Size(32, 30);
            this.buttB5.TabIndex = 5543;
            this.buttB5.UseVisualStyleBackColor = true;
            this.buttB5.Visible = false;
            // 
            // buttA
            // 
            this.buttA.AccessibleName = "عملاء اليوم";
            this.buttA.BackgroundImage = global::ZAD_Sales.Properties.Resources.printerZAD;
            this.buttA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(216)))), ((int)(((byte)(224)))));
            this.buttA.Location = new System.Drawing.Point(441, 9);
            this.buttA.Name = "buttA";
            this.buttA.Size = new System.Drawing.Size(32, 30);
            this.buttA.TabIndex = 5543;
            this.buttA.UseVisualStyleBackColor = true;
            this.buttA.Click += new System.EventHandler(this.buttA_Click);
            // 
            // Frm_ReceiptOfCash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(793, 583);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.reportViewerCasher8Full);
            this.Controls.Add(this.reportViewerCasher8);
            this.Controls.Add(this.reportViewerReceiptFull);
            this.Controls.Add(this.reportViewerReceiptDefoult);
            this.Controls.Add(this.butA5_ReceiptDetailed);
            this.Controls.Add(this.butA5_ReceiptGeneral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_ReceiptOfCash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إيصال إستلام نقدية";
            this.Load += new System.EventHandler(this.Frm_ReceiptOfCash_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butA5_ReceiptGeneral;
        private System.Windows.Forms.Button butA5_ReceiptDetailed;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerReceiptDefoult;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerReceiptFull;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerCasher8;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerCasher8Full;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttNoPriceA4;
        private System.Windows.Forms.Button butReportEmpA5;
        private System.Windows.Forms.Button buttCaser8cm_NoDes;
        private System.Windows.Forms.Button buttCaser8cm;
        private System.Windows.Forms.Button buttCaser8Defoult;
        private System.Windows.Forms.Button PrintDefoult;
        private System.Windows.Forms.Button buttA4;
        private System.Windows.Forms.Button buttB5;
        private System.Windows.Forms.Button buttA;
    }
}