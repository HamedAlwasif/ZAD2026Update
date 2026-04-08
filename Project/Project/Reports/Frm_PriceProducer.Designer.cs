namespace ZAD_Sales.Reports
{
    partial class Frm_PriceProducer
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer3 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer4 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ZAD_Sales.Reports.Frm_PriceProducer.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(23, 29);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(751, 571);
            this.reportViewer1.TabIndex = 0;
            // 
            // reportViewer2
            // 
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "ZAD_Sales.Reports.Frm_PriceProducer_Sheraa.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(23, 29);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(751, 571);
            this.reportViewer2.TabIndex = 0;
            // 
            // reportViewer3
            // 
            this.reportViewer3.LocalReport.ReportEmbeddedResource = "ZAD_Sales.Reports.Frm_PriceProducer_SheraaGomla.rdlc";
            this.reportViewer3.Location = new System.Drawing.Point(23, 29);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.ServerReport.BearerToken = null;
            this.reportViewer3.Size = new System.Drawing.Size(751, 571);
            this.reportViewer3.TabIndex = 0;
            // 
            // reportViewer4
            // 
            this.reportViewer4.LocalReport.ReportEmbeddedResource = "ZAD_Sales.Reports.Frm_PriceProducer_SheraaKataey.rdlc";
            this.reportViewer4.Location = new System.Drawing.Point(23, 29);
            this.reportViewer4.Name = "reportViewer4";
            this.reportViewer4.ServerReport.BearerToken = null;
            this.reportViewer4.Size = new System.Drawing.Size(751, 571);
            this.reportViewer4.TabIndex = 0;
            // 
            // Frm_PriceProducer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(76)))), ((int)(((byte)(119)))));
            this.ClientSize = new System.Drawing.Size(800, 612);
            this.Controls.Add(this.reportViewer4);
            this.Controls.Add(this.reportViewer3);
            this.Controls.Add(this.reportViewer2);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frm_PriceProducer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "طباعة الأسعار";
            this.Load += new System.EventHandler(this.Frm_PriceProducer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer3;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer4;
    }
}