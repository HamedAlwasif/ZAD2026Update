namespace ZAD_Sales.Forms
{
    partial class CarsExpenses
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
            this.comDriver = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butAdd = new System.Windows.Forms.Button();
            this.butEdit = new System.Windows.Forms.Button();
            this.butDelete = new System.Windows.Forms.Button();
            this.butSearch = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textNote = new System.Windows.Forms.TextBox();
            this.textTotal = new System.Windows.Forms.TextBox();
            this.texKamaliat = new System.Windows.Forms.TextBox();
            this.textMekaneky = new System.Windows.Forms.TextBox();
            this.textMoveBoxID = new System.Windows.Forms.TextBox();
            this.textOil = new System.Windows.Forms.TextBox();
            this.textGas = new System.Windows.Forms.TextBox();
            this.textFilter = new System.Windows.Forms.TextBox();
            this.textGhaseel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textDriver = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comNumCar = new System.Windows.Forms.ComboBox();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comDriver
            // 
            this.comDriver.FormattingEnabled = true;
            this.comDriver.Location = new System.Drawing.Point(280, 29);
            this.comDriver.Name = "comDriver";
            this.comDriver.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comDriver.Size = new System.Drawing.Size(144, 21);
            this.comDriver.TabIndex = 45466;
            this.comDriver.TextChanged += new System.EventHandler(this.comDriver_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.butAdd);
            this.panel1.Controls.Add(this.butEdit);
            this.panel1.Controls.Add(this.butDelete);
            this.panel1.Location = new System.Drawing.Point(32, 255);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(630, 50);
            this.panel1.TabIndex = 45461;
            // 
            // butAdd
            // 
            this.butAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.butAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAdd.ForeColor = System.Drawing.Color.White;
            this.butAdd.Location = new System.Drawing.Point(363, 6);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(91, 34);
            this.butAdd.TabIndex = 21;
            this.butAdd.Text = "إضافة";
            this.butAdd.UseVisualStyleBackColor = false;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // butEdit
            // 
            this.butEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(137)))), ((int)(((byte)(167)))));
            this.butEdit.Enabled = false;
            this.butEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butEdit.ForeColor = System.Drawing.Color.White;
            this.butEdit.Location = new System.Drawing.Point(266, 6);
            this.butEdit.Name = "butEdit";
            this.butEdit.Size = new System.Drawing.Size(90, 34);
            this.butEdit.TabIndex = 16;
            this.butEdit.Text = "تعديل";
            this.butEdit.UseVisualStyleBackColor = false;
            this.butEdit.Click += new System.EventHandler(this.butEdit_Click);
            // 
            // butDelete
            // 
            this.butDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(137)))), ((int)(((byte)(167)))));
            this.butDelete.Enabled = false;
            this.butDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDelete.ForeColor = System.Drawing.Color.White;
            this.butDelete.Location = new System.Drawing.Point(169, 6);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(90, 34);
            this.butDelete.TabIndex = 17;
            this.butDelete.Text = "حذف";
            this.butDelete.UseVisualStyleBackColor = false;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // butSearch
            // 
            this.butSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.butSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSearch.ForeColor = System.Drawing.Color.White;
            this.butSearch.Location = new System.Drawing.Point(478, 27);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(43, 23);
            this.butSearch.TabIndex = 45465;
            this.butSearch.Text = "بحث";
            this.butSearch.UseVisualStyleBackColor = false;
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(99, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 13);
            this.label13.TabIndex = 45464;
            this.label13.Text = "رقم";
            // 
            // textBox12
            // 
            this.textBox12.Enabled = false;
            this.textBox12.Location = new System.Drawing.Point(34, 26);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(59, 20);
            this.textBox12.TabIndex = 45463;
            this.textBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(430, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 45462;
            this.label12.Text = "السائق";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textNote);
            this.groupBox1.Controls.Add(this.textTotal);
            this.groupBox1.Controls.Add(this.texKamaliat);
            this.groupBox1.Controls.Add(this.textMekaneky);
            this.groupBox1.Controls.Add(this.textMoveBoxID);
            this.groupBox1.Controls.Add(this.textOil);
            this.groupBox1.Controls.Add(this.textGas);
            this.groupBox1.Controls.Add(this.textFilter);
            this.groupBox1.Controls.Add(this.textGhaseel);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textDriver);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(34, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(628, 193);
            this.groupBox1.TabIndex = 45460;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "   مصاريف  ";
            // 
            // textNote
            // 
            this.textNote.Location = new System.Drawing.Point(117, 159);
            this.textNote.Name = "textNote";
            this.textNote.Size = new System.Drawing.Size(315, 20);
            this.textNote.TabIndex = 19;
            // 
            // textTotal
            // 
            this.textTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textTotal.Location = new System.Drawing.Point(117, 89);
            this.textTotal.Name = "textTotal";
            this.textTotal.ReadOnly = true;
            this.textTotal.Size = new System.Drawing.Size(100, 21);
            this.textTotal.TabIndex = 18;
            this.textTotal.Text = "0";
            this.textTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // texKamaliat
            // 
            this.texKamaliat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texKamaliat.Location = new System.Drawing.Point(117, 57);
            this.texKamaliat.Name = "texKamaliat";
            this.texKamaliat.Size = new System.Drawing.Size(100, 21);
            this.texKamaliat.TabIndex = 17;
            this.texKamaliat.Text = "0";
            this.texKamaliat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.texKamaliat.TextChanged += new System.EventHandler(this.texKamaliat_TextChanged);
            // 
            // textMekaneky
            // 
            this.textMekaneky.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textMekaneky.Location = new System.Drawing.Point(117, 25);
            this.textMekaneky.Name = "textMekaneky";
            this.textMekaneky.Size = new System.Drawing.Size(100, 21);
            this.textMekaneky.TabIndex = 16;
            this.textMekaneky.Text = "0";
            this.textMekaneky.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textMekaneky.TextChanged += new System.EventHandler(this.textMekaneky_TextChanged);
            // 
            // textMoveBoxID
            // 
            this.textMoveBoxID.Location = new System.Drawing.Point(17, 110);
            this.textMoveBoxID.Name = "textMoveBoxID";
            this.textMoveBoxID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textMoveBoxID.Size = new System.Drawing.Size(42, 20);
            this.textMoveBoxID.TabIndex = 5495;
            this.textMoveBoxID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textMoveBoxID.Visible = false;
            // 
            // textOil
            // 
            this.textOil.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textOil.Location = new System.Drawing.Point(332, 125);
            this.textOil.Name = "textOil";
            this.textOil.Size = new System.Drawing.Size(100, 21);
            this.textOil.TabIndex = 15;
            this.textOil.Text = "0";
            this.textOil.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textOil.TextChanged += new System.EventHandler(this.textOil_TextChanged);
            // 
            // textGas
            // 
            this.textGas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textGas.Location = new System.Drawing.Point(332, 93);
            this.textGas.Name = "textGas";
            this.textGas.Size = new System.Drawing.Size(100, 21);
            this.textGas.TabIndex = 14;
            this.textGas.Text = "0";
            this.textGas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textGas.TextChanged += new System.EventHandler(this.textGas_TextChanged);
            // 
            // textFilter
            // 
            this.textFilter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textFilter.Location = new System.Drawing.Point(332, 61);
            this.textFilter.Name = "textFilter";
            this.textFilter.Size = new System.Drawing.Size(100, 21);
            this.textFilter.TabIndex = 13;
            this.textFilter.Text = "0";
            this.textFilter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textFilter.TextChanged += new System.EventHandler(this.textFilter_TextChanged);
            // 
            // textGhaseel
            // 
            this.textGhaseel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textGhaseel.Location = new System.Drawing.Point(332, 29);
            this.textGhaseel.Name = "textGhaseel";
            this.textGhaseel.Size = new System.Drawing.Size(100, 21);
            this.textGhaseel.TabIndex = 12;
            this.textGhaseel.Text = "0";
            this.textGhaseel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textGhaseel.TextChanged += new System.EventHandler(this.textGhaseel_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(227, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "شغل ميكانيكى";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(467, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "غسيل";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(355, 166);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "ملاحظات";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(480, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "فلتر";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(257, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "الإجمالى";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(473, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "تفويل";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(264, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "كماليات";
            // 
            // textDriver
            // 
            this.textDriver.Location = new System.Drawing.Point(6, 128);
            this.textDriver.Name = "textDriver";
            this.textDriver.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textDriver.Size = new System.Drawing.Size(38, 20);
            this.textDriver.TabIndex = 22;
            this.textDriver.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(457, 162);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 13);
            this.label14.TabIndex = 7;
            this.label14.Text = "ملاحظات";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(481, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "زيت";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(45, 132);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "السائق";
            this.label11.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 45459;
            this.label2.Text = "التاريخ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(630, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 45458;
            this.label1.Text = "السيارة";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(124, 26);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePicker1.RightToLeftLayout = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(90, 20);
            this.dateTimePicker1.TabIndex = 45457;
            // 
            // comNumCar
            // 
            this.comNumCar.DisplayMember = "NumCar";
            this.comNumCar.FormattingEnabled = true;
            this.comNumCar.Location = new System.Drawing.Point(525, 28);
            this.comNumCar.Name = "comNumCar";
            this.comNumCar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comNumCar.Size = new System.Drawing.Size(99, 21);
            this.comNumCar.TabIndex = 45456;
            this.comNumCar.ValueMember = "NumCar";
            this.comNumCar.TextChanged += new System.EventHandler(this.comNumCar_TextChanged);
            // 
            // CarsExpenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(208)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(697, 339);
            this.Controls.Add(this.comDriver);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.butSearch);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comNumCar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CarsExpenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مصروفات سيارة";
            this.Load += new System.EventHandler(this.CarsExpenses_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comDriver;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.Button butEdit;
        private System.Windows.Forms.Button butDelete;
        private System.Windows.Forms.Button butSearch;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textNote;
        private System.Windows.Forms.TextBox textTotal;
        private System.Windows.Forms.TextBox texKamaliat;
        private System.Windows.Forms.TextBox textMekaneky;
        private System.Windows.Forms.TextBox textMoveBoxID;
        private System.Windows.Forms.TextBox textOil;
        private System.Windows.Forms.TextBox textGas;
        private System.Windows.Forms.TextBox textFilter;
        private System.Windows.Forms.TextBox textGhaseel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textDriver;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comNumCar;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
    }
}