namespace ZAD_Sales.Forms
{
    partial class GroupAdd
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
            this.comGroup = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textInf = new System.Windows.Forms.TextBox();
            this.textGroup = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.butDelete = new System.Windows.Forms.Button();
            this.butEdit = new System.Windows.Forms.Button();
            this.butNew = new System.Windows.Forms.Button();
            this.butAdd = new System.Windows.Forms.Button();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comGroup
            // 
            this.comGroup.FormattingEnabled = true;
            this.comGroup.Location = new System.Drawing.Point(66, 32);
            this.comGroup.Name = "comGroup";
            this.comGroup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comGroup.Size = new System.Drawing.Size(199, 21);
            this.comGroup.TabIndex = 5474;
            this.comGroup.SelectedIndexChanged += new System.EventHandler(this.comGroup_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textInf);
            this.groupBox1.Controls.Add(this.textGroup);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox1.Location = new System.Drawing.Point(43, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(331, 100);
            this.groupBox1.TabIndex = 5473;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "    إضافة مجموعه عملاء  ";
            // 
            // textInf
            // 
            this.textInf.Location = new System.Drawing.Point(23, 61);
            this.textInf.Name = "textInf";
            this.textInf.Size = new System.Drawing.Size(199, 20);
            this.textInf.TabIndex = 1;
            // 
            // textGroup
            // 
            this.textGroup.Location = new System.Drawing.Point(23, 28);
            this.textGroup.Name = "textGroup";
            this.textGroup.Size = new System.Drawing.Size(199, 20);
            this.textGroup.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(236, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "إسم المجموعة";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(261, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "معلومات";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(279, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 5468;
            this.label1.Text = "إسم المجموعة";
            // 
            // butDelete
            // 
            this.butDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(137)))), ((int)(((byte)(167)))));
            this.butDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDelete.ForeColor = System.Drawing.Color.White;
            this.butDelete.Location = new System.Drawing.Point(73, 188);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(48, 23);
            this.butDelete.TabIndex = 5472;
            this.butDelete.Text = "حذف";
            this.butDelete.UseVisualStyleBackColor = false;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // butEdit
            // 
            this.butEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(137)))), ((int)(((byte)(167)))));
            this.butEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butEdit.ForeColor = System.Drawing.Color.White;
            this.butEdit.Location = new System.Drawing.Point(137, 188);
            this.butEdit.Name = "butEdit";
            this.butEdit.Size = new System.Drawing.Size(48, 23);
            this.butEdit.TabIndex = 5471;
            this.butEdit.Text = "تعديل";
            this.butEdit.UseVisualStyleBackColor = false;
            this.butEdit.Click += new System.EventHandler(this.butEdit_Click);
            // 
            // butNew
            // 
            this.butNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(137)))), ((int)(((byte)(167)))));
            this.butNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butNew.ForeColor = System.Drawing.Color.White;
            this.butNew.Location = new System.Drawing.Point(201, 188);
            this.butNew.Name = "butNew";
            this.butNew.Size = new System.Drawing.Size(48, 23);
            this.butNew.TabIndex = 5470;
            this.butNew.Text = "جديد";
            this.butNew.UseVisualStyleBackColor = false;
            this.butNew.Click += new System.EventHandler(this.butNew_Click);
            // 
            // butAdd
            // 
            this.butAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.butAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAdd.ForeColor = System.Drawing.Color.White;
            this.butAdd.Location = new System.Drawing.Point(265, 188);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(48, 23);
            this.butAdd.TabIndex = 5469;
            this.butAdd.Text = "إضافة";
            this.butAdd.UseVisualStyleBackColor = false;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // GroupAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(428, 236);
            this.Controls.Add(this.comGroup);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butDelete);
            this.Controls.Add(this.butEdit);
            this.Controls.Add(this.butNew);
            this.Controls.Add(this.butAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GroupAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مجموعات العملاء";
            this.Load += new System.EventHandler(this.GroupAdd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comGroup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textInf;
        private System.Windows.Forms.TextBox textGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butDelete;
        private System.Windows.Forms.Button butEdit;
        private System.Windows.Forms.Button butNew;
        private System.Windows.Forms.Button butAdd;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
    }
}