namespace ZAD_Sales.Forms
{
    partial class ProducerAddSN
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.butSearchCategory = new System.Windows.Forms.Button();
            this.textBarcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comStorages = new System.Windows.Forms.ComboBox();
            this.butSearch = new System.Windows.Forms.Button();
            this.comCategory = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.dataGridView8 = new System.Windows.Forms.DataGridView();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.label1 = new System.Windows.Forms.Label();
            this.textCategoreySN = new System.Windows.Forms.TextBox();
            this.butAdd = new System.Windows.Forms.Button();
            this.textID_SN = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView8)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.butSearchCategory);
            this.groupBox2.Controls.Add(this.textBarcode);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.comStorages);
            this.groupBox2.Controls.Add(this.butSearch);
            this.groupBox2.Controls.Add(this.comCategory);
            this.groupBox2.Location = new System.Drawing.Point(607, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(465, 160);
            this.groupBox2.TabIndex = 429;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "   البحث   ";
            // 
            // butSearchCategory
            // 
            this.butSearchCategory.BackColor = System.Drawing.Color.White;
            this.butSearchCategory.BackgroundImage = global::ZAD_Sales.Properties.Resources.searchZ;
            this.butSearchCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butSearchCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSearchCategory.ForeColor = System.Drawing.Color.White;
            this.butSearchCategory.Location = new System.Drawing.Point(97, 107);
            this.butSearchCategory.Name = "butSearchCategory";
            this.butSearchCategory.Size = new System.Drawing.Size(20, 20);
            this.butSearchCategory.TabIndex = 7496;
            this.butSearchCategory.UseVisualStyleBackColor = false;
            // 
            // textBarcode
            // 
            this.textBarcode.Location = new System.Drawing.Point(97, 72);
            this.textBarcode.Name = "textBarcode";
            this.textBarcode.Size = new System.Drawing.Size(295, 20);
            this.textBarcode.TabIndex = 5516;
            this.textBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(401, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 5515;
            this.label2.Text = "الصنف";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(398, 74);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(39, 13);
            this.label29.TabIndex = 5515;
            this.label29.Text = "الباركود";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(398, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 558;
            this.label4.Text = "المخزن";
            // 
            // comStorages
            // 
            this.comStorages.FormattingEnabled = true;
            this.comStorages.Location = new System.Drawing.Point(97, 35);
            this.comStorages.Name = "comStorages";
            this.comStorages.Size = new System.Drawing.Size(295, 21);
            this.comStorages.TabIndex = 557;
            // 
            // butSearch
            // 
            this.butSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.butSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSearch.ForeColor = System.Drawing.Color.White;
            this.butSearch.Location = new System.Drawing.Point(26, 107);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(45, 23);
            this.butSearch.TabIndex = 556;
            this.butSearch.Text = "بحث";
            this.butSearch.UseVisualStyleBackColor = false;
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            // 
            // comCategory
            // 
            this.comCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comCategory.FormattingEnabled = true;
            this.comCategory.Location = new System.Drawing.Point(123, 108);
            this.comCategory.Name = "comCategory";
            this.comCategory.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comCategory.Size = new System.Drawing.Size(269, 21);
            this.comCategory.TabIndex = 555;
            this.comCategory.TextChanged += new System.EventHandler(this.comCategory_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(680, 221);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 437;
            this.label13.Text = "الفئه";
            this.label13.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(1040, 221);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 435;
            this.label11.Text = "الكمية";
            this.label11.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(802, 221);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 434;
            this.label8.Text = "الوحده";
            this.label8.Visible = false;
            // 
            // comboBox2
            // 
            this.comboBox2.Enabled = false;
            this.comboBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.ForeColor = System.Drawing.Color.Blue;
            this.comboBox2.Items.AddRange(new object[] {
            "ق",
            "د",
            "ط"});
            this.comboBox2.Location = new System.Drawing.Point(615, 216);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(53, 22);
            this.comboBox2.TabIndex = 433;
            this.comboBox2.Text = "ق";
            this.comboBox2.Visible = false;
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.textBox4.Location = new System.Drawing.Point(724, 217);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(59, 20);
            this.textBox4.TabIndex = 432;
            this.textBox4.Text = "1";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox4.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Black;
            this.textBox2.Location = new System.Drawing.Point(959, 217);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(59, 20);
            this.textBox2.TabIndex = 430;
            this.textBox2.Text = "0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(942, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 436;
            this.label3.Text = "ك";
            this.label3.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.Black;
            this.textBox3.Location = new System.Drawing.Point(850, 217);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(53, 21);
            this.textBox3.TabIndex = 431;
            this.textBox3.Text = "0";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox3.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(403, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 439;
            this.label7.Text = "الإجمالى";
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox5.Location = new System.Drawing.Point(44, 36);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(337, 26);
            this.textBox5.TabIndex = 438;
            this.textBox5.Text = "0";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridView8
            // 
            this.dataGridView8.AllowUserToAddRows = false;
            this.dataGridView8.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView8.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView8.Location = new System.Drawing.Point(12, 41);
            this.dataGridView8.Name = "dataGridView8";
            this.dataGridView8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView8.Size = new System.Drawing.Size(545, 492);
            this.dataGridView8.TabIndex = 440;
            this.dataGridView8.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView8_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(403, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 439;
            this.label1.Text = "السريال";
            // 
            // textCategoreySN
            // 
            this.textCategoreySN.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCategoreySN.Location = new System.Drawing.Point(44, 96);
            this.textCategoreySN.Name = "textCategoreySN";
            this.textCategoreySN.Size = new System.Drawing.Size(337, 33);
            this.textCategoreySN.TabIndex = 441;
            this.textCategoreySN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // butAdd
            // 
            this.butAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.butAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAdd.ForeColor = System.Drawing.Color.White;
            this.butAdd.Location = new System.Drawing.Point(44, 166);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(337, 23);
            this.butAdd.TabIndex = 442;
            this.butAdd.Text = "إضافة";
            this.butAdd.UseVisualStyleBackColor = false;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // textID_SN
            // 
            this.textID_SN.Location = new System.Drawing.Point(3, 102);
            this.textID_SN.Name = "textID_SN";
            this.textID_SN.Size = new System.Drawing.Size(35, 20);
            this.textID_SN.TabIndex = 5551;
            this.textID_SN.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBox5);
            this.panel1.Controls.Add(this.textID_SN);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.butAdd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textCategoreySN);
            this.panel1.Location = new System.Drawing.Point(611, 305);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(465, 228);
            this.panel1.TabIndex = 5552;
            // 
            // ProducerAddSN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1112, 575);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView8);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProducerAddSN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة سريلات للصنف";
            this.Load += new System.EventHandler(this.ProducerAddSN_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView8)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button butSearchCategory;
        private System.Windows.Forms.TextBox textBarcode;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comStorages;
        private System.Windows.Forms.Button butSearch;
        private System.Windows.Forms.ComboBox comCategory;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.DataGridView dataGridView8;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textCategoreySN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.TextBox textID_SN;
        private System.Windows.Forms.Panel panel1;
    }
}