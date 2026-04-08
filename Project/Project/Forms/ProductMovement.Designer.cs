namespace ZAD_Sales.Forms
{
    partial class ProductMovement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBarcode = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.butSearch = new System.Windows.Forms.Button();
            this.comCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateDateDay = new System.Windows.Forms.DateTimePicker();
            this.comStorages = new System.Windows.Forms.ComboBox();
            this.butPrint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRemainingNOW = new System.Windows.Forms.TextBox();
            this.txtSaderTotal = new System.Windows.Forms.TextBox();
            this.txtWaredTotal = new System.Windows.Forms.TextBox();
            this.txtReminngOLD1 = new System.Windows.Forms.TextBox();
            this.txtSader = new System.Windows.Forms.TextBox();
            this.txtWared = new System.Windows.Forms.TextBox();
            this.txtReminngOLD = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGrDetais = new System.Windows.Forms.DataGridView();
            this.usersDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryFromDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryToDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moveBillDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDBillDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moveDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waredDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classProductMovementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrDetais)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classProductMovementBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(327, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(321, 80);
            this.groupBox2.TabIndex = 5506;
            this.groupBox2.TabStop = false;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(123, 47);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePicker2.RightToLeftLayout = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(151, 20);
            this.dateTimePicker2.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label4.Location = new System.Drawing.Point(283, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "من";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(123, 19);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePicker1.RightToLeftLayout = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(151, 20);
            this.dateTimePicker1.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label3.Location = new System.Drawing.Point(280, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "إلى";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(23, 45);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "بحث";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBarcode);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.butSearch);
            this.groupBox1.Controls.Add(this.comCategory);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(664, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(348, 80);
            this.groupBox1.TabIndex = 5505;
            this.groupBox1.TabStop = false;
            // 
            // textBarcode
            // 
            this.textBarcode.Location = new System.Drawing.Point(76, 19);
            this.textBarcode.Name = "textBarcode";
            this.textBarcode.Size = new System.Drawing.Size(214, 20);
            this.textBarcode.TabIndex = 5518;
            this.textBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBarcode_KeyDown);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label29.Location = new System.Drawing.Point(293, 22);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(39, 13);
            this.label29.TabIndex = 5517;
            this.label29.Text = "الباركود";
            // 
            // butSearch
            // 
            this.butSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(137)))), ((int)(((byte)(167)))));
            this.butSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSearch.ForeColor = System.Drawing.Color.White;
            this.butSearch.Location = new System.Drawing.Point(10, 46);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(60, 23);
            this.butSearch.TabIndex = 5485;
            this.butSearch.Text = "بحث";
            this.butSearch.UseVisualStyleBackColor = false;
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            // 
            // comCategory
            // 
            this.comCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comCategory.DisplayMember = "Category";
            this.comCategory.FormattingEnabled = true;
            this.comCategory.Location = new System.Drawing.Point(76, 46);
            this.comCategory.Name = "comCategory";
            this.comCategory.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comCategory.Size = new System.Drawing.Size(214, 21);
            this.comCategory.TabIndex = 0;
            this.comCategory.ValueMember = "Category";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label2.Location = new System.Drawing.Point(296, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "الصنف";
            // 
            // dateDateDay
            // 
            this.dateDateDay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDateDay.Location = new System.Drawing.Point(-21, 170);
            this.dateDateDay.Name = "dateDateDay";
            this.dateDateDay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateDateDay.RightToLeftLayout = true;
            this.dateDateDay.Size = new System.Drawing.Size(24, 20);
            this.dateDateDay.TabIndex = 5504;
            // 
            // comStorages
            // 
            this.comStorages.DisplayMember = "Storage";
            this.comStorages.FormattingEnabled = true;
            this.comStorages.Location = new System.Drawing.Point(920, 5);
            this.comStorages.Name = "comStorages";
            this.comStorages.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comStorages.Size = new System.Drawing.Size(58, 21);
            this.comStorages.TabIndex = 5488;
            this.comStorages.ValueMember = "Storage";
            this.comStorages.Visible = false;
            // 
            // butPrint
            // 
            this.butPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(172)))), ((int)(((byte)(132)))));
            this.butPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butPrint.ForeColor = System.Drawing.Color.White;
            this.butPrint.Location = new System.Drawing.Point(33, 498);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(126, 29);
            this.butPrint.TabIndex = 5503;
            this.butPrint.Text = "طباعه";
            this.butPrint.UseVisualStyleBackColor = false;
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(974, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 5490;
            this.label1.Text = "المخزن";
            this.label1.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label8.Location = new System.Drawing.Point(165, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 5502;
            this.label8.Text = "رصيد بداية المدة";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label7.Location = new System.Drawing.Point(483, 510);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 5500;
            this.label7.Text = "الاجمالى";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label6.Location = new System.Drawing.Point(701, 509);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 5501;
            this.label6.Text = "اجمالى الصادر";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label5.Location = new System.Drawing.Point(942, 509);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 5499;
            this.label5.Text = "اجمالى الوارد";
            // 
            // txtRemainingNOW
            // 
            this.txtRemainingNOW.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemainingNOW.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtRemainingNOW.Location = new System.Drawing.Point(333, 506);
            this.txtRemainingNOW.Name = "txtRemainingNOW";
            this.txtRemainingNOW.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRemainingNOW.Size = new System.Drawing.Size(144, 21);
            this.txtRemainingNOW.TabIndex = 5498;
            this.txtRemainingNOW.Text = "0";
            this.txtRemainingNOW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSaderTotal
            // 
            this.txtSaderTotal.Location = new System.Drawing.Point(544, 505);
            this.txtSaderTotal.Name = "txtSaderTotal";
            this.txtSaderTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSaderTotal.Size = new System.Drawing.Size(134, 20);
            this.txtSaderTotal.TabIndex = 5497;
            this.txtSaderTotal.Text = "0";
            this.txtSaderTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtWaredTotal
            // 
            this.txtWaredTotal.Location = new System.Drawing.Point(799, 505);
            this.txtWaredTotal.Name = "txtWaredTotal";
            this.txtWaredTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtWaredTotal.Size = new System.Drawing.Size(138, 20);
            this.txtWaredTotal.TabIndex = 5496;
            this.txtWaredTotal.Text = "0";
            this.txtWaredTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtReminngOLD1
            // 
            this.txtReminngOLD1.Location = new System.Drawing.Point(-13, 134);
            this.txtReminngOLD1.Name = "txtReminngOLD1";
            this.txtReminngOLD1.Size = new System.Drawing.Size(40, 20);
            this.txtReminngOLD1.TabIndex = 5495;
            this.txtReminngOLD1.Visible = false;
            // 
            // txtSader
            // 
            this.txtSader.Location = new System.Drawing.Point(-13, 108);
            this.txtSader.Name = "txtSader";
            this.txtSader.Size = new System.Drawing.Size(40, 20);
            this.txtSader.TabIndex = 5494;
            this.txtSader.Text = "0";
            this.txtSader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSader.Visible = false;
            // 
            // txtWared
            // 
            this.txtWared.Location = new System.Drawing.Point(-13, 82);
            this.txtWared.Name = "txtWared";
            this.txtWared.Size = new System.Drawing.Size(40, 20);
            this.txtWared.TabIndex = 5493;
            this.txtWared.Text = "0";
            this.txtWared.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtWared.Visible = false;
            // 
            // txtReminngOLD
            // 
            this.txtReminngOLD.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReminngOLD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtReminngOLD.Location = new System.Drawing.Point(33, 64);
            this.txtReminngOLD.Name = "txtReminngOLD";
            this.txtReminngOLD.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtReminngOLD.Size = new System.Drawing.Size(126, 23);
            this.txtReminngOLD.TabIndex = 5492;
            this.txtReminngOLD.Text = "0";
            this.txtReminngOLD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(-13, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox1.Size = new System.Drawing.Size(40, 20);
            this.textBox1.TabIndex = 5491;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Visible = false;
            // 
            // dataGrDetais
            // 
            this.dataGrDetais.AllowUserToAddRows = false;
            this.dataGrDetais.AutoGenerateColumns = false;
            this.dataGrDetais.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrDetais.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrDetais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrDetais.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.usersDataGridViewTextBoxColumn,
            this.categoryFromDataGridViewTextBoxColumn,
            this.categoryToDataGridViewTextBoxColumn,
            this.moveBillDataGridViewTextBoxColumn,
            this.iDBillDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.moveDataGridViewTextBoxColumn,
            this.waredDataGridViewTextBoxColumn,
            this.saderDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn});
            this.dataGrDetais.DataSource = this.classProductMovementBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrDetais.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGrDetais.Location = new System.Drawing.Point(33, 101);
            this.dataGrDetais.Name = "dataGrDetais";
            this.dataGrDetais.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrDetais.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGrDetais.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGrDetais.Size = new System.Drawing.Size(979, 391);
            this.dataGrDetais.TabIndex = 5489;
            // 
            // usersDataGridViewTextBoxColumn
            // 
            this.usersDataGridViewTextBoxColumn.DataPropertyName = "Users";
            this.usersDataGridViewTextBoxColumn.HeaderText = "المستخدم";
            this.usersDataGridViewTextBoxColumn.Name = "usersDataGridViewTextBoxColumn";
            // 
            // categoryFromDataGridViewTextBoxColumn
            // 
            this.categoryFromDataGridViewTextBoxColumn.DataPropertyName = "CategoryFrom";
            this.categoryFromDataGridViewTextBoxColumn.HeaderText = "من";
            this.categoryFromDataGridViewTextBoxColumn.Name = "categoryFromDataGridViewTextBoxColumn";
            // 
            // categoryToDataGridViewTextBoxColumn
            // 
            this.categoryToDataGridViewTextBoxColumn.DataPropertyName = "CategoryTo";
            this.categoryToDataGridViewTextBoxColumn.HeaderText = "الى";
            this.categoryToDataGridViewTextBoxColumn.Name = "categoryToDataGridViewTextBoxColumn";
            // 
            // moveBillDataGridViewTextBoxColumn
            // 
            this.moveBillDataGridViewTextBoxColumn.DataPropertyName = "MoveBill";
            this.moveBillDataGridViewTextBoxColumn.HeaderText = "نوع الفاتورة";
            this.moveBillDataGridViewTextBoxColumn.Name = "moveBillDataGridViewTextBoxColumn";
            // 
            // iDBillDataGridViewTextBoxColumn
            // 
            this.iDBillDataGridViewTextBoxColumn.DataPropertyName = "IDBill";
            this.iDBillDataGridViewTextBoxColumn.HeaderText = "رقم الفاتورة";
            this.iDBillDataGridViewTextBoxColumn.Name = "iDBillDataGridViewTextBoxColumn";
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "التاريخ";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.Width = 80;
            // 
            // moveDataGridViewTextBoxColumn
            // 
            this.moveDataGridViewTextBoxColumn.DataPropertyName = "Move";
            this.moveDataGridViewTextBoxColumn.HeaderText = "الحركة";
            this.moveDataGridViewTextBoxColumn.Name = "moveDataGridViewTextBoxColumn";
            // 
            // waredDataGridViewTextBoxColumn
            // 
            this.waredDataGridViewTextBoxColumn.DataPropertyName = "Wared";
            this.waredDataGridViewTextBoxColumn.HeaderText = "وارد";
            this.waredDataGridViewTextBoxColumn.Name = "waredDataGridViewTextBoxColumn";
            this.waredDataGridViewTextBoxColumn.Width = 80;
            // 
            // saderDataGridViewTextBoxColumn
            // 
            this.saderDataGridViewTextBoxColumn.DataPropertyName = "Sader";
            this.saderDataGridViewTextBoxColumn.HeaderText = "صادر";
            this.saderDataGridViewTextBoxColumn.Name = "saderDataGridViewTextBoxColumn";
            this.saderDataGridViewTextBoxColumn.Width = 80;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.HeaderText = "الرصيد";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.Width = 80;
            // 
            // classProductMovementBindingSource
            // 
            this.classProductMovementBindingSource.DataSource = typeof(ZAD_Sales.Forms.ProductMovement.Class_ProductMovement);
            // 
            // ProductMovement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(147)))));
            this.ClientSize = new System.Drawing.Size(1034, 535);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dateDateDay);
            this.Controls.Add(this.comStorages);
            this.Controls.Add(this.butPrint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRemainingNOW);
            this.Controls.Add(this.txtSaderTotal);
            this.Controls.Add(this.txtWaredTotal);
            this.Controls.Add(this.txtReminngOLD1);
            this.Controls.Add(this.txtSader);
            this.Controls.Add(this.txtWared);
            this.Controls.Add(this.txtReminngOLD);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGrDetais);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProductMovement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "حركة المنتجات";
            this.Load += new System.EventHandler(this.ProductMovement_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrDetais)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classProductMovementBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBarcode;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button butSearch;
        private System.Windows.Forms.ComboBox comCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateDateDay;
        private System.Windows.Forms.ComboBox comStorages;
        private System.Windows.Forms.Button butPrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRemainingNOW;
        private System.Windows.Forms.TextBox txtSaderTotal;
        private System.Windows.Forms.TextBox txtWaredTotal;
        private System.Windows.Forms.TextBox txtReminngOLD1;
        private System.Windows.Forms.TextBox txtSader;
        private System.Windows.Forms.TextBox txtWared;
        private System.Windows.Forms.TextBox txtReminngOLD;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGrDetais;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Windows.Forms.BindingSource classProductMovementBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn usersDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryFromDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryToDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moveBillDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDBillDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moveDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn waredDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn saderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
    }
}