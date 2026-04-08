namespace ZAD_Sales.Reports
{
    partial class Frm_ReportDailyCategry
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.Class_CateorayDayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.Class_CateorayDayBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Class_CateorayDayBindingSource
            // 
            this.Class_CateorayDayBindingSource.DataSource = typeof(ZAD_Sales.Forms.DailyClosing.Class_CateorayDay);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Class_CateorayDayBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ZAD_Sales.Reports.Frm_ReportDailyCategory.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(788, 598);
            this.reportViewer1.TabIndex = 0;
            // 
            // Frm_ReportDailyCategry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(147)))));
            this.ClientSize = new System.Drawing.Size(788, 598);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frm_ReportDailyCategry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_ReportDailyCategry";
            this.Load += new System.EventHandler(this.Frm_ReportDailyCategry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Class_CateorayDayBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource Class_CateorayDayBindingSource;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}