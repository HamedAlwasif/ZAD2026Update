namespace ZAD_Sales.Forms
{
    partial class ProducerAddBarcodeFactory
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textCategoreyBarcode_Factory2 = new System.Windows.Forms.TextBox();
            this.butAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textCategoreyBarcode_Factory = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.butSearchCategory = new System.Windows.Forms.Button();
            this.textBarcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comStorages = new System.Windows.Forms.ComboBox();
            this.butSearch = new System.Windows.Forms.Button();
            this.comCategory = new System.Windows.Forms.ComboBox();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBarcode2 = new System.Windows.Forms.TextBox();
            this.textCategory2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(255)))), ((int)(((byte)(249)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textCategoreyBarcode_Factory2);
            this.panel1.Controls.Add(this.butAdd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textCategoreyBarcode_Factory);
            this.panel1.Location = new System.Drawing.Point(27, 259);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(465, 138);
            this.panel1.TabIndex = 5560;
            // 
            // textCategoreyBarcode_Factory2
            // 
            this.textCategoreyBarcode_Factory2.Location = new System.Drawing.Point(44, 63);
            this.textCategoreyBarcode_Factory2.Name = "textCategoreyBarcode_Factory2";
            this.textCategoreyBarcode_Factory2.Size = new System.Drawing.Size(337, 20);
            this.textCategoreyBarcode_Factory2.TabIndex = 5551;
            this.textCategoreyBarcode_Factory2.Visible = false;
            // 
            // butAdd
            // 
            this.butAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.butAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAdd.ForeColor = System.Drawing.Color.White;
            this.butAdd.Location = new System.Drawing.Point(44, 94);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(337, 23);
            this.butAdd.TabIndex = 442;
            this.butAdd.Text = "إضافة";
            this.butAdd.UseVisualStyleBackColor = false;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(384, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 439;
            this.label1.Text = "باركود المصنع";
            // 
            // textCategoreyBarcode_Factory
            // 
            this.textCategoreyBarcode_Factory.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCategoreyBarcode_Factory.Location = new System.Drawing.Point(44, 24);
            this.textCategoreyBarcode_Factory.Name = "textCategoreyBarcode_Factory";
            this.textCategoreyBarcode_Factory.Size = new System.Drawing.Size(337, 33);
            this.textCategoreyBarcode_Factory.TabIndex = 441;
            this.textCategoreyBarcode_Factory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox5.Location = new System.Drawing.Point(72, 216);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(337, 26);
            this.textBox5.TabIndex = 438;
            this.textBox5.Text = "0";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(431, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 439;
            this.label7.Text = "الإجمالى";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(452, 194);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 5558;
            this.label11.Text = "الكمية";
            this.label11.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(214, 194);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 5557;
            this.label8.Text = "الوحده";
            this.label8.Visible = false;
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.textBox4.Location = new System.Drawing.Point(136, 190);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(59, 20);
            this.textBox4.TabIndex = 5556;
            this.textBox4.Text = "1";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox4.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Black;
            this.textBox2.Location = new System.Drawing.Point(371, 190);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(59, 20);
            this.textBox2.TabIndex = 5554;
            this.textBox2.Text = "0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(354, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 5559;
            this.label3.Text = "ك";
            this.label3.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.Black;
            this.textBox3.Location = new System.Drawing.Point(262, 190);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(53, 21);
            this.textBox3.TabIndex = 5555;
            this.textBox3.Text = "0";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox3.Visible = false;
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
            this.groupBox2.Location = new System.Drawing.Point(27, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(465, 160);
            this.groupBox2.TabIndex = 5553;
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
            this.butSearchCategory.Location = new System.Drawing.Point(75, 107);
            this.butSearchCategory.Name = "butSearchCategory";
            this.butSearchCategory.Size = new System.Drawing.Size(20, 20);
            this.butSearchCategory.TabIndex = 7496;
            this.butSearchCategory.UseVisualStyleBackColor = false;
            // 
            // textBarcode
            // 
            this.textBarcode.Location = new System.Drawing.Point(75, 72);
            this.textBarcode.Name = "textBarcode";
            this.textBarcode.Size = new System.Drawing.Size(295, 20);
            this.textBarcode.TabIndex = 5516;
            this.textBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(379, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 5515;
            this.label2.Text = "الصنف";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(376, 74);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(39, 13);
            this.label29.TabIndex = 5515;
            this.label29.Text = "الباركود";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(376, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 558;
            this.label4.Text = "المخزن";
            // 
            // comStorages
            // 
            this.comStorages.FormattingEnabled = true;
            this.comStorages.Location = new System.Drawing.Point(75, 35);
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
            this.butSearch.Location = new System.Drawing.Point(16, 107);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(45, 23);
            this.butSearch.TabIndex = 556;
            this.butSearch.Text = "بحث";
            this.butSearch.UseVisualStyleBackColor = false;
            this.butSearch.Visible = false;
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            // 
            // comCategory
            // 
            this.comCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comCategory.FormattingEnabled = true;
            this.comCategory.Location = new System.Drawing.Point(101, 108);
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
            this.label13.Location = new System.Drawing.Point(96, 194);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 5562;
            this.label13.Text = "الفئه";
            this.label13.Visible = false;
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
            this.comboBox2.Location = new System.Drawing.Point(31, 189);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(53, 22);
            this.comboBox2.TabIndex = 5561;
            this.comboBox2.Text = "ق";
            this.comboBox2.Visible = false;
            // 
            // textBarcode2
            // 
            this.textBarcode2.Location = new System.Drawing.Point(311, 9);
            this.textBarcode2.Name = "textBarcode2";
            this.textBarcode2.Size = new System.Drawing.Size(100, 20);
            this.textBarcode2.TabIndex = 5563;
            this.textBarcode2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textCategory2
            // 
            this.textCategory2.Location = new System.Drawing.Point(12, 9);
            this.textCategory2.Name = "textCategory2";
            this.textCategory2.Size = new System.Drawing.Size(246, 20);
            this.textCategory2.TabIndex = 5564;
            this.textCategory2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(415, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 5515;
            this.label5.Text = "الباركود";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(270, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 5515;
            this.label6.Text = "الصنف";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textCategory2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.textBarcode2);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(27, 404);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(465, 40);
            this.panel2.TabIndex = 5565;
            this.panel2.Visible = false;
            // 
            // ProducerAddBarcodeFactory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(190)))), ((int)(((byte)(184)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(523, 462);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProducerAddBarcodeFactory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة باركود المصنع";
            this.Load += new System.EventHandler(this.ProducerAddBarcodeFactory_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textCategoreyBarcode_Factory2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textCategoreyBarcode_Factory;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button butSearchCategory;
        private System.Windows.Forms.TextBox textBarcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comStorages;
        private System.Windows.Forms.Button butSearch;
        private System.Windows.Forms.ComboBox comCategory;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBarcode2;
        private System.Windows.Forms.TextBox textCategory2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
    }
}