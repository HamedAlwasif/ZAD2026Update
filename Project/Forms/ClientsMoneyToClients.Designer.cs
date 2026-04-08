namespace ZAD_Sales.Forms
{
    partial class ClientsMoneyToClients
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
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comNameTo = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRemaningOld2 = new System.Windows.Forms.TextBox();
            this.butSearch = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.comName = new System.Windows.Forms.ComboBox();
            this.txtRemaningOld = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textNote = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.textBillingDataNumBill1 = new System.Windows.Forms.TextBox();
            this.butSave = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.butNew = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTransform = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chBoxDeletCat = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.numBillDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moveDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classClientsMoneyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.panel11.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classClientsMoneyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.panel11.Controls.Add(this.panel2);
            this.panel11.Controls.Add(this.comNameTo);
            this.panel11.Controls.Add(this.button1);
            this.panel11.Controls.Add(this.label9);
            this.panel11.Controls.Add(this.label10);
            this.panel11.Controls.Add(this.txtRemaningOld2);
            this.panel11.Controls.Add(this.butSearch);
            this.panel11.Controls.Add(this.label6);
            this.panel11.Controls.Add(this.label1);
            this.panel11.Controls.Add(this.label8);
            this.panel11.Controls.Add(this.label3);
            this.panel11.Controls.Add(this.label25);
            this.panel11.Controls.Add(this.comName);
            this.panel11.Controls.Add(this.txtRemaningOld);
            this.panel11.Location = new System.Drawing.Point(12, 22);
            this.panel11.Name = "panel11";
            this.panel11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel11.Size = new System.Drawing.Size(675, 90);
            this.panel11.TabIndex = 5514;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(326, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(3, 66);
            this.panel2.TabIndex = 5506;
            // 
            // comNameTo
            // 
            this.comNameTo.FormattingEnabled = true;
            this.comNameTo.Location = new System.Drawing.Point(70, 27);
            this.comNameTo.Name = "comNameTo";
            this.comNameTo.Size = new System.Drawing.Size(177, 21);
            this.comNameTo.TabIndex = 5505;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(42)))), ((int)(((byte)(86)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.button1.Location = new System.Drawing.Point(10, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 23);
            this.button1.TabIndex = 5504;
            this.button1.Text = "بحث";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(42)))), ((int)(((byte)(86)))));
            this.label9.Location = new System.Drawing.Point(253, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 5501;
            this.label9.Text = "الاســم";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(42)))), ((int)(((byte)(86)))));
            this.label10.Location = new System.Drawing.Point(253, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 5502;
            this.label10.Text = "الرصيد";
            // 
            // txtRemaningOld2
            // 
            this.txtRemaningOld2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemaningOld2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtRemaningOld2.Location = new System.Drawing.Point(70, 54);
            this.txtRemaningOld2.Name = "txtRemaningOld2";
            this.txtRemaningOld2.ReadOnly = true;
            this.txtRemaningOld2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRemaningOld2.Size = new System.Drawing.Size(177, 23);
            this.txtRemaningOld2.TabIndex = 5503;
            this.txtRemaningOld2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // butSearch
            // 
            this.butSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(54)))), ((int)(((byte)(22)))));
            this.butSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.butSearch.Location = new System.Drawing.Point(359, 26);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(39, 23);
            this.butSearch.TabIndex = 5499;
            this.butSearch.Text = "بحث";
            this.butSearch.UseVisualStyleBackColor = false;
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(42)))), ((int)(((byte)(86)))));
            this.label6.Location = new System.Drawing.Point(111, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "الـــــــــــــــــــــــى";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(54)))), ((int)(((byte)(22)))));
            this.label1.Location = new System.Drawing.Point(489, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "مــــن";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(54)))), ((int)(((byte)(22)))));
            this.label8.Location = new System.Drawing.Point(615, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "الاســم";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(54)))), ((int)(((byte)(22)))));
            this.label3.Location = new System.Drawing.Point(615, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "الرصيد";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(840, 17);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(51, 13);
            this.label25.TabIndex = 5498;
            this.label25.Text = "الإســــم";
            // 
            // comName
            // 
            this.comName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comName.DisplayMember = "Name";
            this.comName.ForeColor = System.Drawing.Color.Red;
            this.comName.FormattingEnabled = true;
            this.comName.Location = new System.Drawing.Point(404, 27);
            this.comName.Name = "comName";
            this.comName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comName.Size = new System.Drawing.Size(200, 21);
            this.comName.TabIndex = 1;
            this.comName.ValueMember = "Name";
            // 
            // txtRemaningOld
            // 
            this.txtRemaningOld.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemaningOld.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtRemaningOld.Location = new System.Drawing.Point(404, 54);
            this.txtRemaningOld.Name = "txtRemaningOld";
            this.txtRemaningOld.ReadOnly = true;
            this.txtRemaningOld.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRemaningOld.Size = new System.Drawing.Size(200, 23);
            this.txtRemaningOld.TabIndex = 23;
            this.txtRemaningOld.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textNote);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.textBillingDataNumBill1);
            this.groupBox1.Controls.Add(this.butSave);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.butNew);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtTransform);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(675, 150);
            this.groupBox1.TabIndex = 5517;
            this.groupBox1.TabStop = false;
            // 
            // textNote
            // 
            this.textNote.Location = new System.Drawing.Point(307, 101);
            this.textNote.Name = "textNote";
            this.textNote.Size = new System.Drawing.Size(278, 20);
            this.textNote.TabIndex = 5500;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label2.Location = new System.Drawing.Point(411, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 399;
            this.label2.Text = "رقم الحساب";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Location = new System.Drawing.Point(256, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 112);
            this.panel1.TabIndex = 594;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(477, 30);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePicker2.RightToLeftLayout = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(108, 20);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // textBillingDataNumBill1
            // 
            this.textBillingDataNumBill1.Enabled = false;
            this.textBillingDataNumBill1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBillingDataNumBill1.ForeColor = System.Drawing.Color.Blue;
            this.textBillingDataNumBill1.Location = new System.Drawing.Point(307, 29);
            this.textBillingDataNumBill1.Name = "textBillingDataNumBill1";
            this.textBillingDataNumBill1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBillingDataNumBill1.Size = new System.Drawing.Size(99, 21);
            this.textBillingDataNumBill1.TabIndex = 398;
            this.textBillingDataNumBill1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // butSave
            // 
            this.butSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(189)))), ((int)(((byte)(50)))));
            this.butSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSave.ForeColor = System.Drawing.Color.White;
            this.butSave.Location = new System.Drawing.Point(25, 33);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(204, 30);
            this.butSave.TabIndex = 8;
            this.butSave.Text = "حفظ";
            this.butSave.UseVisualStyleBackColor = false;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label21.Location = new System.Drawing.Point(616, 34);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 13);
            this.label21.TabIndex = 5;
            this.label21.Text = "التاريخ";
            // 
            // butNew
            // 
            this.butNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.butNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butNew.ForeColor = System.Drawing.Color.White;
            this.butNew.Location = new System.Drawing.Point(25, 69);
            this.butNew.Name = "butNew";
            this.butNew.Size = new System.Drawing.Size(204, 30);
            this.butNew.TabIndex = 9;
            this.butNew.Text = "جديد ";
            this.butNew.UseVisualStyleBackColor = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label14.Location = new System.Drawing.Point(603, 104);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 13);
            this.label14.TabIndex = 388;
            this.label14.Text = "ملاحظات";
            // 
            // txtTransform
            // 
            this.txtTransform.BackColor = System.Drawing.Color.White;
            this.txtTransform.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTransform.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txtTransform.Location = new System.Drawing.Point(307, 62);
            this.txtTransform.Name = "txtTransform";
            this.txtTransform.Size = new System.Drawing.Size(278, 21);
            this.txtTransform.TabIndex = 4;
            this.txtTransform.Text = "0";
            this.txtTransform.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTransform.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransform_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(197)))), ((int)(((byte)(49)))));
            this.label5.Location = new System.Drawing.Point(617, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 592;
            this.label5.Text = "المبلغ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(586, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 591;
            // 
            // chBoxDeletCat
            // 
            this.chBoxDeletCat.AutoSize = true;
            this.chBoxDeletCat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(197)))), ((int)(((byte)(49)))));
            this.chBoxDeletCat.Location = new System.Drawing.Point(622, 569);
            this.chBoxDeletCat.Name = "chBoxDeletCat";
            this.chBoxDeletCat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chBoxDeletCat.Size = new System.Drawing.Size(65, 17);
            this.chBoxDeletCat.TabIndex = 5516;
            this.chBoxDeletCat.Text = "حذف بند";
            this.chBoxDeletCat.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numBillDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.moveDataGridViewTextBoxColumn,
            this.paidDataGridViewTextBoxColumn,
            this.payDataGridViewTextBoxColumn,
            this.discountDataGridViewTextBoxColumn,
            this.addingDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.classClientsMoneyBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(12, 285);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(675, 278);
            this.dataGridView1.TabIndex = 5515;
            // 
            // numBillDataGridViewTextBoxColumn
            // 
            this.numBillDataGridViewTextBoxColumn.DataPropertyName = "NumBill";
            this.numBillDataGridViewTextBoxColumn.HeaderText = "الرقم";
            this.numBillDataGridViewTextBoxColumn.Name = "numBillDataGridViewTextBoxColumn";
            this.numBillDataGridViewTextBoxColumn.Width = 60;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "التاريخ";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            // 
            // moveDataGridViewTextBoxColumn
            // 
            this.moveDataGridViewTextBoxColumn.DataPropertyName = "Move";
            this.moveDataGridViewTextBoxColumn.HeaderText = "الحركة";
            this.moveDataGridViewTextBoxColumn.Name = "moveDataGridViewTextBoxColumn";
            this.moveDataGridViewTextBoxColumn.Width = 220;
            // 
            // paidDataGridViewTextBoxColumn
            // 
            this.paidDataGridViewTextBoxColumn.DataPropertyName = "Paid";
            this.paidDataGridViewTextBoxColumn.HeaderText = "تحصيل";
            this.paidDataGridViewTextBoxColumn.Name = "paidDataGridViewTextBoxColumn";
            this.paidDataGridViewTextBoxColumn.Width = 60;
            // 
            // payDataGridViewTextBoxColumn
            // 
            this.payDataGridViewTextBoxColumn.DataPropertyName = "Pay";
            this.payDataGridViewTextBoxColumn.HeaderText = "توريد";
            this.payDataGridViewTextBoxColumn.Name = "payDataGridViewTextBoxColumn";
            this.payDataGridViewTextBoxColumn.Width = 60;
            // 
            // discountDataGridViewTextBoxColumn
            // 
            this.discountDataGridViewTextBoxColumn.DataPropertyName = "Discount";
            this.discountDataGridViewTextBoxColumn.HeaderText = "خصم";
            this.discountDataGridViewTextBoxColumn.Name = "discountDataGridViewTextBoxColumn";
            this.discountDataGridViewTextBoxColumn.Width = 60;
            // 
            // addingDataGridViewTextBoxColumn
            // 
            this.addingDataGridViewTextBoxColumn.DataPropertyName = "Adding";
            this.addingDataGridViewTextBoxColumn.HeaderText = "اضافة";
            this.addingDataGridViewTextBoxColumn.Name = "addingDataGridViewTextBoxColumn";
            this.addingDataGridViewTextBoxColumn.Width = 60;
            // 
            // classClientsMoneyBindingSource
            // 
            this.classClientsMoneyBindingSource.DataSource = typeof(ZAD_Sales.Forms.ClientsMoneyToClients.Class_ClientsMoney);
            // 
            // ClientsMoneyToClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(115)))), ((int)(((byte)(158)))));
            this.ClientSize = new System.Drawing.Size(708, 602);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chBoxDeletCat);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ClientsMoneyToClients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تحويل اموال من حساب عميل الى حساب عميل اخر";
            this.Load += new System.EventHandler(this.ClientsMoneyToClients_Load);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classClientsMoneyBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRemaningOld2;
        private System.Windows.Forms.Button butSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox comName;
        private System.Windows.Forms.TextBox txtRemaningOld;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textNote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.TextBox textBillingDataNumBill1;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button butNew;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTransform;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chBoxDeletCat;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Windows.Forms.ComboBox comNameTo;
        private System.Windows.Forms.BindingSource classClientsMoneyBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn numBillDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moveDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn payDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addingDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
    }
}