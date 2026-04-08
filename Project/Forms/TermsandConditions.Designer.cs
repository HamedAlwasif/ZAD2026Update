namespace ZAD_Sales.Forms
{
    partial class TermsandConditions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TermsandConditions));
            this.rtbTerms = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbTerms
            // 
            this.rtbTerms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbTerms.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbTerms.Location = new System.Drawing.Point(0, 0);
            this.rtbTerms.Name = "rtbTerms";
            this.rtbTerms.ReadOnly = true;
            this.rtbTerms.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbTerms.Size = new System.Drawing.Size(684, 761);
            this.rtbTerms.TabIndex = 0;
            this.rtbTerms.Text = resources.GetString("rtbTerms.Text");
            // 
            // TermsandConditions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 761);
            this.Controls.Add(this.rtbTerms);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TermsandConditions";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الشروط والأحكام";
            this.Load += new System.EventHandler(this.TermsandConditions_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbTerms;
    }
}