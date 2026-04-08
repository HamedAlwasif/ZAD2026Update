namespace ZAD_Sales.Forms
{
    partial class MoneyWaredAndSaderOther
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtReminngOLD = new System.Windows.Forms.TextBox();
            this.txtClints = new System.Windows.Forms.TextBox();
            this.txtMove = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.textBoxManey2 = new System.Windows.Forms.TextBox();
            this.butShearchDayFromTO = new System.Windows.Forms.Button();
            this.butShearchDay = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEradat = new System.Windows.Forms.TextBox();
            this.txtMasrofat = new System.Windows.Forms.TextBox();
            this.DateTo = new System.Windows.Forms.DateTimePicker();
            this.DateFrom = new System.Windows.Forms.DateTimePicker();
            this.dateDay = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radbutIncomeOther = new System.Windows.Forms.RadioButton();
            this.radbutExpensesOther = new System.Windows.Forms.RadioButton();
            this.txtStatement = new System.Windows.Forms.TextBox();
            this.txtIncomeOther = new System.Windows.Forms.TextBox();
            this.txtExpensesOther = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateAdd = new System.Windows.Forms.DateTimePicker();
            this.butAdd = new System.Windows.Forms.Button();
            this.butDelete = new System.Windows.Forms.Button();
            this.butUpdate = new System.Windows.Forms.Button();
            this.dataGridShearch = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridShearch)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(229)))));
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtReminngOLD);
            this.panel1.Controls.Add(this.txtClints);
            this.panel1.Location = new System.Drawing.Point(-18, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(687, 36);
            this.panel1.TabIndex = 5506;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(202, 12);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 13);
            this.label18.TabIndex = 5480;
            this.label18.Text = "رصيد الخزنة";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(608, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 2161;
            this.label10.Text = "الإسم";
            // 
            // txtReminngOLD
            // 
            this.txtReminngOLD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReminngOLD.ForeColor = System.Drawing.Color.Green;
            this.txtReminngOLD.Location = new System.Drawing.Point(40, 8);
            this.txtReminngOLD.Name = "txtReminngOLD";
            this.txtReminngOLD.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtReminngOLD.Size = new System.Drawing.Size(142, 21);
            this.txtReminngOLD.TabIndex = 2155;
            this.txtReminngOLD.Text = "0";
            this.txtReminngOLD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtClints
            // 
            this.txtClints.Location = new System.Drawing.Point(354, 8);
            this.txtClints.Name = "txtClints";
            this.txtClints.Size = new System.Drawing.Size(242, 20);
            this.txtClints.TabIndex = 2160;
            this.txtClints.Text = "عميل حر";
            this.txtClints.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMove
            // 
            this.txtMove.Location = new System.Drawing.Point(635, 155);
            this.txtMove.Name = "txtMove";
            this.txtMove.Size = new System.Drawing.Size(116, 20);
            this.txtMove.TabIndex = 5504;
            this.txtMove.Text = "مصروفات أخرى";
            this.txtMove.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMove.Visible = false;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(635, 129);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(34, 20);
            this.txtID.TabIndex = 5502;
            this.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtID.Visible = false;
            // 
            // textBoxManey2
            // 
            this.textBoxManey2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxManey2.ForeColor = System.Drawing.Color.Green;
            this.textBoxManey2.Location = new System.Drawing.Point(635, 106);
            this.textBoxManey2.Name = "textBoxManey2";
            this.textBoxManey2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxManey2.Size = new System.Drawing.Size(55, 21);
            this.textBoxManey2.TabIndex = 5505;
            this.textBoxManey2.Text = "0";
            this.textBoxManey2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxManey2.Visible = false;
            // 
            // butShearchDayFromTO
            // 
            this.butShearchDayFromTO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(189)))), ((int)(((byte)(50)))));
            this.butShearchDayFromTO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butShearchDayFromTO.ForeColor = System.Drawing.Color.White;
            this.butShearchDayFromTO.Location = new System.Drawing.Point(20, 213);
            this.butShearchDayFromTO.Name = "butShearchDayFromTO";
            this.butShearchDayFromTO.Size = new System.Drawing.Size(46, 23);
            this.butShearchDayFromTO.TabIndex = 5503;
            this.butShearchDayFromTO.Text = "بحث";
            this.butShearchDayFromTO.UseVisualStyleBackColor = false;
            this.butShearchDayFromTO.Click += new System.EventHandler(this.butShearchDayFromTO_Click);
            // 
            // butShearchDay
            // 
            this.butShearchDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(189)))), ((int)(((byte)(50)))));
            this.butShearchDay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butShearchDay.ForeColor = System.Drawing.Color.White;
            this.butShearchDay.Location = new System.Drawing.Point(427, 213);
            this.butShearchDay.Name = "butShearchDay";
            this.butShearchDay.Size = new System.Drawing.Size(46, 23);
            this.butShearchDay.TabIndex = 5501;
            this.butShearchDay.Text = "بحث";
            this.butShearchDay.UseVisualStyleBackColor = false;
            this.butShearchDay.Click += new System.EventHandler(this.butShearchDay_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label9.Location = new System.Drawing.Point(124, 485);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 5500;
            this.label9.Text = "إجمالى الإيرادات";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label8.Location = new System.Drawing.Point(536, 485);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 5499;
            this.label8.Text = "إجمالى المصروفات";
            // 
            // txtEradat
            // 
            this.txtEradat.Location = new System.Drawing.Point(18, 481);
            this.txtEradat.Name = "txtEradat";
            this.txtEradat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtEradat.Size = new System.Drawing.Size(100, 20);
            this.txtEradat.TabIndex = 5498;
            this.txtEradat.Text = "0";
            this.txtEradat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMasrofat
            // 
            this.txtMasrofat.Location = new System.Drawing.Point(430, 481);
            this.txtMasrofat.Name = "txtMasrofat";
            this.txtMasrofat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMasrofat.Size = new System.Drawing.Size(100, 20);
            this.txtMasrofat.TabIndex = 5497;
            this.txtMasrofat.Text = "0";
            this.txtMasrofat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DateTo
            // 
            this.DateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateTo.Location = new System.Drawing.Point(72, 214);
            this.DateTo.Name = "DateTo";
            this.DateTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DateTo.RightToLeftLayout = true;
            this.DateTo.Size = new System.Drawing.Size(106, 20);
            this.DateTo.TabIndex = 5496;
            // 
            // DateFrom
            // 
            this.DateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateFrom.Location = new System.Drawing.Point(221, 214);
            this.DateFrom.Name = "DateFrom";
            this.DateFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DateFrom.RightToLeftLayout = true;
            this.DateFrom.Size = new System.Drawing.Size(106, 20);
            this.DateFrom.TabIndex = 5495;
            // 
            // dateDay
            // 
            this.dateDay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDay.Location = new System.Drawing.Point(479, 214);
            this.dateDay.Name = "dateDay";
            this.dateDay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateDay.RightToLeftLayout = true;
            this.dateDay.Size = new System.Drawing.Size(106, 20);
            this.dateDay.TabIndex = 5494;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radbutIncomeOther);
            this.groupBox1.Controls.Add(this.radbutExpensesOther);
            this.groupBox1.Controls.Add(this.txtStatement);
            this.groupBox1.Controls.Add(this.txtIncomeOther);
            this.groupBox1.Controls.Add(this.txtExpensesOther);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateAdd);
            this.groupBox1.Controls.Add(this.butAdd);
            this.groupBox1.Controls.Add(this.butDelete);
            this.groupBox1.Controls.Add(this.butUpdate);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(22, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(607, 153);
            this.groupBox1.TabIndex = 5493;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "  إضافة مصروفات وإيرادات أخرى  ";
            // 
            // radbutIncomeOther
            // 
            this.radbutIncomeOther.AutoSize = true;
            this.radbutIncomeOther.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(197)))), ((int)(((byte)(49)))));
            this.radbutIncomeOther.Location = new System.Drawing.Point(305, 28);
            this.radbutIncomeOther.Name = "radbutIncomeOther";
            this.radbutIncomeOther.Size = new System.Drawing.Size(113, 17);
            this.radbutIncomeOther.TabIndex = 12;
            this.radbutIncomeOther.Text = "إضافة إيرادات أخرى";
            this.radbutIncomeOther.UseVisualStyleBackColor = true;
            this.radbutIncomeOther.CheckedChanged += new System.EventHandler(this.radbutIncomeOther_CheckedChanged);
            // 
            // radbutExpensesOther
            // 
            this.radbutExpensesOther.AutoSize = true;
            this.radbutExpensesOther.Checked = true;
            this.radbutExpensesOther.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(197)))), ((int)(((byte)(49)))));
            this.radbutExpensesOther.Location = new System.Drawing.Point(461, 28);
            this.radbutExpensesOther.Name = "radbutExpensesOther";
            this.radbutExpensesOther.Size = new System.Drawing.Size(124, 17);
            this.radbutExpensesOther.TabIndex = 11;
            this.radbutExpensesOther.TabStop = true;
            this.radbutExpensesOther.Text = "إضافة مصروفات أخرى";
            this.radbutExpensesOther.UseVisualStyleBackColor = true;
            this.radbutExpensesOther.CheckedChanged += new System.EventHandler(this.radbutExpensesOther_CheckedChanged);
            // 
            // txtStatement
            // 
            this.txtStatement.Location = new System.Drawing.Point(142, 101);
            this.txtStatement.Name = "txtStatement";
            this.txtStatement.Size = new System.Drawing.Size(397, 20);
            this.txtStatement.TabIndex = 7;
            // 
            // txtIncomeOther
            // 
            this.txtIncomeOther.Location = new System.Drawing.Point(142, 64);
            this.txtIncomeOther.Name = "txtIncomeOther";
            this.txtIncomeOther.Size = new System.Drawing.Size(108, 20);
            this.txtIncomeOther.TabIndex = 6;
            this.txtIncomeOther.Text = "0";
            this.txtIncomeOther.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIncomeOther.Visible = false;
            this.txtIncomeOther.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIncomeOther_KeyPress);
            // 
            // txtExpensesOther
            // 
            this.txtExpensesOther.Location = new System.Drawing.Point(142, 64);
            this.txtExpensesOther.Name = "txtExpensesOther";
            this.txtExpensesOther.Size = new System.Drawing.Size(108, 20);
            this.txtExpensesOther.TabIndex = 5;
            this.txtExpensesOther.Text = "0";
            this.txtExpensesOther.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label4.Location = new System.Drawing.Point(559, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "البيان";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label3.Location = new System.Drawing.Point(290, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "إيرادات أخرى";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(279, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "مصروفات اخرى";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label1.Location = new System.Drawing.Point(555, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "التاريخ";
            // 
            // dateAdd
            // 
            this.dateAdd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateAdd.Location = new System.Drawing.Point(391, 64);
            this.dateAdd.Name = "dateAdd";
            this.dateAdd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateAdd.RightToLeftLayout = true;
            this.dateAdd.Size = new System.Drawing.Size(148, 20);
            this.dateAdd.TabIndex = 0;
            // 
            // butAdd
            // 
            this.butAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.butAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAdd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butAdd.ForeColor = System.Drawing.Color.White;
            this.butAdd.Location = new System.Drawing.Point(19, 41);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(88, 23);
            this.butAdd.TabIndex = 8;
            this.butAdd.Text = "إضـــافة";
            this.butAdd.UseVisualStyleBackColor = false;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // butDelete
            // 
            this.butDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(122)))));
            this.butDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butDelete.ForeColor = System.Drawing.Color.White;
            this.butDelete.Location = new System.Drawing.Point(19, 101);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(88, 23);
            this.butDelete.TabIndex = 9;
            this.butDelete.Text = "حـــــذف";
            this.butDelete.UseVisualStyleBackColor = false;
            this.butDelete.Visible = false;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // butUpdate
            // 
            this.butUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.butUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butUpdate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butUpdate.ForeColor = System.Drawing.Color.White;
            this.butUpdate.Location = new System.Drawing.Point(19, 71);
            this.butUpdate.Name = "butUpdate";
            this.butUpdate.Size = new System.Drawing.Size(88, 23);
            this.butUpdate.TabIndex = 9;
            this.butUpdate.Text = "تعــديــل";
            this.butUpdate.UseVisualStyleBackColor = false;
            this.butUpdate.Visible = false;
            this.butUpdate.Click += new System.EventHandler(this.butUpdate_Click);
            // 
            // dataGridShearch
            // 
            this.dataGridShearch.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridShearch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridShearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridShearch.Location = new System.Drawing.Point(18, 243);
            this.dataGridShearch.Name = "dataGridShearch";
            this.dataGridShearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridShearch.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridShearch.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridShearch.Size = new System.Drawing.Size(610, 232);
            this.dataGridShearch.TabIndex = 5491;
            this.dataGridShearch.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridShearch_CellDoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label7.Location = new System.Drawing.Point(184, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 5490;
            this.label7.Text = "الى";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label6.Location = new System.Drawing.Point(333, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 5492;
            this.label6.Text = "من";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label5.Location = new System.Drawing.Point(591, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 5489;
            this.label5.Text = "التاريخ";
            // 
            // MoneyWaredAndSaderOther
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(147)))));
            this.ClientSize = new System.Drawing.Size(661, 517);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtMove);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.textBoxManey2);
            this.Controls.Add(this.butShearchDayFromTO);
            this.Controls.Add(this.butShearchDay);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtEradat);
            this.Controls.Add(this.txtMasrofat);
            this.Controls.Add(this.DateTo);
            this.Controls.Add(this.DateFrom);
            this.Controls.Add(this.dateDay);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridShearch);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MoneyWaredAndSaderOther";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مصروفات وايرادات اخرى";
            this.Load += new System.EventHandler(this.MoneyWaredAndSaderOther_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridShearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtReminngOLD;
        private System.Windows.Forms.TextBox txtClints;
        private System.Windows.Forms.TextBox txtMove;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox textBoxManey2;
        private System.Windows.Forms.Button butShearchDayFromTO;
        private System.Windows.Forms.Button butShearchDay;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEradat;
        private System.Windows.Forms.TextBox txtMasrofat;
        private System.Windows.Forms.DateTimePicker DateTo;
        private System.Windows.Forms.DateTimePicker DateFrom;
        private System.Windows.Forms.DateTimePicker dateDay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radbutIncomeOther;
        private System.Windows.Forms.RadioButton radbutExpensesOther;
        private System.Windows.Forms.TextBox txtStatement;
        private System.Windows.Forms.TextBox txtIncomeOther;
        private System.Windows.Forms.TextBox txtExpensesOther;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateAdd;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.Button butDelete;
        private System.Windows.Forms.Button butUpdate;
        private System.Windows.Forms.DataGridView dataGridShearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
    }
}