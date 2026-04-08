namespace ZAD_Sales.Forms
{
    partial class CategoryGroup
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
            this.butSearch = new System.Windows.Forms.Button();
            this.comCatGroup = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.butEdit = new System.Windows.Forms.Button();
            this.butDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butNew = new System.Windows.Forms.Button();
            this.butAdd = new System.Windows.Forms.Button();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butSearch
            // 
            this.butSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.butSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSearch.ForeColor = System.Drawing.Color.White;
            this.butSearch.Location = new System.Drawing.Point(196, 20);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(38, 23);
            this.butSearch.TabIndex = 29;
            this.butSearch.Text = "بحث";
            this.butSearch.UseVisualStyleBackColor = false;
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            // 
            // comCatGroup
            // 
            this.comCatGroup.DisplayMember = "Storage";
            this.comCatGroup.FormattingEnabled = true;
            this.comCatGroup.Location = new System.Drawing.Point(240, 22);
            this.comCatGroup.Name = "comCatGroup";
            this.comCatGroup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comCatGroup.Size = new System.Drawing.Size(188, 21);
            this.comCatGroup.TabIndex = 28;
            this.comCatGroup.ValueMember = "Storage";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(65, 23);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(75, 20);
            this.textBox4.TabIndex = 27;
            this.textBox4.Visible = false;
            // 
            // butEdit
            // 
            this.butEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(60)))), ((int)(((byte)(117)))));
            this.butEdit.Enabled = false;
            this.butEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butEdit.ForeColor = System.Drawing.Color.White;
            this.butEdit.Location = new System.Drawing.Point(105, 181);
            this.butEdit.Name = "butEdit";
            this.butEdit.Size = new System.Drawing.Size(60, 23);
            this.butEdit.TabIndex = 26;
            this.butEdit.Text = "تحديث";
            this.butEdit.UseVisualStyleBackColor = false;
            this.butEdit.Click += new System.EventHandler(this.butEdit_Click);
            // 
            // butDelete
            // 
            this.butDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.butDelete.Enabled = false;
            this.butDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDelete.ForeColor = System.Drawing.Color.White;
            this.butDelete.Location = new System.Drawing.Point(170, 181);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(60, 23);
            this.butDelete.TabIndex = 25;
            this.butDelete.Text = "حذف";
            this.butDelete.UseVisualStyleBackColor = false;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(40, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(389, 94);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "    إضافة مخزن جديد    ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(25, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(274, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(327, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "الإسم";
            // 
            // butNew
            // 
            this.butNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(172)))), ((int)(((byte)(132)))));
            this.butNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butNew.ForeColor = System.Drawing.Color.White;
            this.butNew.Location = new System.Drawing.Point(235, 181);
            this.butNew.Name = "butNew";
            this.butNew.Size = new System.Drawing.Size(60, 23);
            this.butNew.TabIndex = 24;
            this.butNew.Text = "جديد";
            this.butNew.UseVisualStyleBackColor = false;
            this.butNew.Click += new System.EventHandler(this.butNew_Click);
            // 
            // butAdd
            // 
            this.butAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.butAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAdd.ForeColor = System.Drawing.Color.White;
            this.butAdd.Location = new System.Drawing.Point(300, 181);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(60, 23);
            this.butAdd.TabIndex = 23;
            this.butAdd.Text = "إضافة";
            this.butAdd.UseVisualStyleBackColor = false;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // CategoryGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(202)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(469, 244);
            this.Controls.Add(this.butSearch);
            this.Controls.Add(this.comCatGroup);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.butEdit);
            this.Controls.Add(this.butDelete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.butNew);
            this.Controls.Add(this.butAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CategoryGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة مجموعة للاصناف";
            this.Load += new System.EventHandler(this.CategoryGroup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butSearch;
        private System.Windows.Forms.ComboBox comCatGroup;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button butEdit;
        private System.Windows.Forms.Button butDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butNew;
        private System.Windows.Forms.Button butAdd;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
    }
}