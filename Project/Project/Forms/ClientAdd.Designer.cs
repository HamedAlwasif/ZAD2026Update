namespace ZAD_Sales.Forms
{
    partial class ClientAdd
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.butDelete = new System.Windows.Forms.Button();
            this.butUpdate = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.butSearch = new System.Windows.Forms.Button();
            this.comClient = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radbutDaen = new System.Windows.Forms.RadioButton();
            this.labelDaen = new System.Windows.Forms.Label();
            this.radbutMaden = new System.Windows.Forms.RadioButton();
            this.labelMaden = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.textMaden = new System.Windows.Forms.TextBox();
            this.textDaen = new System.Windows.Forms.TextBox();
            this.textBillingDataNumBill = new System.Windows.Forms.TextBox();
            this.combStateRaseed = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textLimitCredit = new System.Windows.Forms.TextBox();
            this.txtID_Clint = new System.Windows.Forms.TextBox();
            this.butPic = new System.Windows.Forms.Button();
            this.combGroups = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txeTell = new System.Windows.Forms.TextBox();
            this.txtMobil = new System.Windows.Forms.TextBox();
            this.txtAdress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butAddClient = new System.Windows.Forms.Button();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.butDaaen = new System.Windows.Forms.Button();
            this.butMadeen = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtID_ClintShearch = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.button5 = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textSearchClintMobil = new System.Windows.Forms.TextBox();
            this.textSearchClint = new System.Windows.Forms.TextBox();
            this.dataGridSearchClint = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telHomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telMobilDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.previousBalanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stateRaseedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classGetAllClintesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSearchClint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classGetAllClintesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(32, 84);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listBox1.Size = new System.Drawing.Size(249, 404);
            this.listBox1.TabIndex = 5505;
            // 
            // butDelete
            // 
            this.butDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(80)))), ((int)(((byte)(57)))));
            this.butDelete.Enabled = false;
            this.butDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDelete.ForeColor = System.Drawing.Color.White;
            this.butDelete.Location = new System.Drawing.Point(53, 540);
            this.butDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(103, 32);
            this.butDelete.TabIndex = 5503;
            this.butDelete.Text = "حذف";
            this.butDelete.UseVisualStyleBackColor = false;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // butUpdate
            // 
            this.butUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(60)))), ((int)(((byte)(117)))));
            this.butUpdate.Enabled = false;
            this.butUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butUpdate.ForeColor = System.Drawing.Color.White;
            this.butUpdate.Location = new System.Drawing.Point(164, 540);
            this.butUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.butUpdate.Name = "butUpdate";
            this.butUpdate.Size = new System.Drawing.Size(103, 32);
            this.butUpdate.TabIndex = 5504;
            this.butUpdate.Text = "تعديل";
            this.butUpdate.UseVisualStyleBackColor = false;
            this.butUpdate.Click += new System.EventHandler(this.butUpdate_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(172)))), ((int)(((byte)(132)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(275, 540);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(84, 32);
            this.button3.TabIndex = 5500;
            this.button3.Text = "جديد ";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // butSearch
            // 
            this.butSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(172)))), ((int)(((byte)(101)))));
            this.butSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSearch.ForeColor = System.Drawing.Color.White;
            this.butSearch.Location = new System.Drawing.Point(561, 31);
            this.butSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(60, 28);
            this.butSearch.TabIndex = 5502;
            this.butSearch.Text = "بحث";
            this.butSearch.UseVisualStyleBackColor = false;
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            // 
            // comClient
            // 
            this.comClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comClient.DisplayMember = "Name";
            this.comClient.FormattingEnabled = true;
            this.comClient.Location = new System.Drawing.Point(628, 33);
            this.comClient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comClient.Name = "comClient";
            this.comClient.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comClient.Size = new System.Drawing.Size(293, 24);
            this.comClient.TabIndex = 5501;
            this.comClient.ValueMember = "Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.textBillingDataNumBill);
            this.groupBox2.Controls.Add(this.combStateRaseed);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.textLimitCredit);
            this.groupBox2.Controls.Add(this.txtID_Clint);
            this.groupBox2.Controls.Add(this.butPic);
            this.groupBox2.Controls.Add(this.combGroups);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.txeTell);
            this.groupBox2.Controls.Add(this.txtMobil);
            this.groupBox2.Controls.Add(this.txtAdress);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(197)))), ((int)(((byte)(49)))));
            this.groupBox2.Location = new System.Drawing.Point(299, 79);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(716, 410);
            this.groupBox2.TabIndex = 5498;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "    بيانات العميل   ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label8.Location = new System.Drawing.Point(216, 34);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 17);
            this.label8.TabIndex = 5510;
            this.label8.Text = "رقم الحساب";
            this.label8.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radbutDaen);
            this.panel1.Controls.Add(this.labelDaen);
            this.panel1.Controls.Add(this.radbutMaden);
            this.panel1.Controls.Add(this.labelMaden);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.textMaden);
            this.panel1.Controls.Add(this.textDaen);
            this.panel1.Location = new System.Drawing.Point(27, 289);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(665, 105);
            this.panel1.TabIndex = 5506;
            // 
            // radbutDaen
            // 
            this.radbutDaen.AutoSize = true;
            this.radbutDaen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radbutDaen.ForeColor = System.Drawing.Color.White;
            this.radbutDaen.Location = new System.Drawing.Point(143, 23);
            this.radbutDaen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radbutDaen.Name = "radbutDaen";
            this.radbutDaen.Size = new System.Drawing.Size(136, 21);
            this.radbutDaen.TabIndex = 5505;
            this.radbutDaen.Text = "له حساب سابق";
            this.radbutDaen.UseVisualStyleBackColor = true;
            this.radbutDaen.CheckedChanged += new System.EventHandler(this.radbutDaen_CheckedChanged);
            // 
            // labelDaen
            // 
            this.labelDaen.AutoSize = true;
            this.labelDaen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.labelDaen.Location = new System.Drawing.Point(316, 75);
            this.labelDaen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDaen.Name = "labelDaen";
            this.labelDaen.Size = new System.Drawing.Size(36, 17);
            this.labelDaen.TabIndex = 5502;
            this.labelDaen.Text = "دائن بـ";
            // 
            // radbutMaden
            // 
            this.radbutMaden.AutoSize = true;
            this.radbutMaden.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radbutMaden.ForeColor = System.Drawing.Color.White;
            this.radbutMaden.Location = new System.Drawing.Point(303, 23);
            this.radbutMaden.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radbutMaden.Name = "radbutMaden";
            this.radbutMaden.Size = new System.Drawing.Size(137, 21);
            this.radbutMaden.TabIndex = 5504;
            this.radbutMaden.Text = "لنا حساب سابق";
            this.radbutMaden.UseVisualStyleBackColor = true;
            this.radbutMaden.CheckedChanged += new System.EventHandler(this.radbutMaden_CheckedChanged);
            // 
            // labelMaden
            // 
            this.labelMaden.AutoSize = true;
            this.labelMaden.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.labelMaden.Location = new System.Drawing.Point(577, 73);
            this.labelMaden.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMaden.Name = "labelMaden";
            this.labelMaden.Size = new System.Drawing.Size(38, 17);
            this.labelMaden.TabIndex = 5500;
            this.labelMaden.Text = "مدين بـ";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.ForeColor = System.Drawing.Color.White;
            this.radioButton1.Location = new System.Drawing.Point(461, 23);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(155, 21);
            this.radioButton1.TabIndex = 5503;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "لا يوجد رصيد سابق";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // textMaden
            // 
            this.textMaden.Enabled = false;
            this.textMaden.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textMaden.ForeColor = System.Drawing.Color.Green;
            this.textMaden.Location = new System.Drawing.Point(387, 70);
            this.textMaden.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textMaden.Name = "textMaden";
            this.textMaden.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textMaden.Size = new System.Drawing.Size(145, 24);
            this.textMaden.TabIndex = 5499;
            this.textMaden.Text = "0";
            this.textMaden.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textMaden.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textMaden_KeyPress);
            // 
            // textDaen
            // 
            this.textDaen.Enabled = false;
            this.textDaen.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDaen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textDaen.Location = new System.Drawing.Point(149, 73);
            this.textDaen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textDaen.Name = "textDaen";
            this.textDaen.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textDaen.Size = new System.Drawing.Size(145, 24);
            this.textDaen.TabIndex = 5501;
            this.textDaen.Text = "0";
            this.textDaen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textDaen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textDaen_KeyPress);
            // 
            // textBillingDataNumBill
            // 
            this.textBillingDataNumBill.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBillingDataNumBill.Location = new System.Drawing.Point(65, 34);
            this.textBillingDataNumBill.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBillingDataNumBill.Name = "textBillingDataNumBill";
            this.textBillingDataNumBill.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBillingDataNumBill.Size = new System.Drawing.Size(132, 24);
            this.textBillingDataNumBill.TabIndex = 5509;
            this.textBillingDataNumBill.Text = "0";
            this.textBillingDataNumBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBillingDataNumBill.Visible = false;
            // 
            // combStateRaseed
            // 
            this.combStateRaseed.FormattingEnabled = true;
            this.combStateRaseed.Items.AddRange(new object[] {
            "فعال",
            "معدوم"});
            this.combStateRaseed.Location = new System.Drawing.Point(472, 251);
            this.combStateRaseed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.combStateRaseed.Name = "combStateRaseed";
            this.combStateRaseed.Size = new System.Drawing.Size(120, 24);
            this.combStateRaseed.TabIndex = 6;
            this.combStateRaseed.Text = "فعال";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label16.Location = new System.Drawing.Point(644, 256);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 17);
            this.label16.TabIndex = 5498;
            this.label16.Text = "الرصيد";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::ZAD_Sales.Properties.Resources.ClientNull;
            this.pictureBox1.Location = new System.Drawing.Point(24, 80);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(159, 145);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5491;
            this.pictureBox1.TabStop = false;
            // 
            // textLimitCredit
            // 
            this.textLimitCredit.Location = new System.Drawing.Point(209, 251);
            this.textLimitCredit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textLimitCredit.Name = "textLimitCredit";
            this.textLimitCredit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textLimitCredit.Size = new System.Drawing.Size(157, 22);
            this.textLimitCredit.TabIndex = 5493;
            this.textLimitCredit.Text = "0";
            this.textLimitCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtID_Clint
            // 
            this.txtID_Clint.Enabled = false;
            this.txtID_Clint.Location = new System.Drawing.Point(435, 39);
            this.txtID_Clint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtID_Clint.Name = "txtID_Clint";
            this.txtID_Clint.ReadOnly = true;
            this.txtID_Clint.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtID_Clint.Size = new System.Drawing.Size(157, 22);
            this.txtID_Clint.TabIndex = 5493;
            this.txtID_Clint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // butPic
            // 
            this.butPic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(172)))), ((int)(((byte)(101)))));
            this.butPic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butPic.ForeColor = System.Drawing.Color.White;
            this.butPic.Location = new System.Drawing.Point(24, 233);
            this.butPic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.butPic.Name = "butPic";
            this.butPic.Size = new System.Drawing.Size(160, 39);
            this.butPic.TabIndex = 5490;
            this.butPic.Text = "إختار الصورة";
            this.butPic.UseVisualStyleBackColor = false;
            this.butPic.Click += new System.EventHandler(this.butPic_Click);
            // 
            // combGroups
            // 
            this.combGroups.FormattingEnabled = true;
            this.combGroups.Location = new System.Drawing.Point(209, 114);
            this.combGroups.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.combGroups.Name = "combGroups";
            this.combGroups.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.combGroups.Size = new System.Drawing.Size(383, 24);
            this.combGroups.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(209, 80);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtName.Name = "txtName";
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.Size = new System.Drawing.Size(383, 22);
            this.txtName.TabIndex = 1;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txeTell
            // 
            this.txeTell.Location = new System.Drawing.Point(209, 150);
            this.txeTell.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txeTell.MaxLength = 11;
            this.txeTell.Name = "txeTell";
            this.txeTell.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txeTell.Size = new System.Drawing.Size(383, 22);
            this.txeTell.TabIndex = 3;
            this.txeTell.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txeTell.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txeTell_KeyPress);
            // 
            // txtMobil
            // 
            this.txtMobil.Location = new System.Drawing.Point(209, 185);
            this.txtMobil.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMobil.MaxLength = 11;
            this.txtMobil.Name = "txtMobil";
            this.txtMobil.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMobil.Size = new System.Drawing.Size(383, 22);
            this.txtMobil.TabIndex = 4;
            this.txtMobil.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMobil.TextChanged += new System.EventHandler(this.txtMobil_TextChanged);
            this.txtMobil.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMobil_KeyPress);
            // 
            // txtAdress
            // 
            this.txtAdress.Location = new System.Drawing.Point(209, 219);
            this.txtAdress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAdress.Name = "txtAdress";
            this.txtAdress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAdress.Size = new System.Drawing.Size(383, 22);
            this.txtAdress.TabIndex = 5;
            this.txtAdress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label5.Location = new System.Drawing.Point(628, 185);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "ت محمول";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label7.Location = new System.Drawing.Point(376, 256);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "الحد الائتمانى";
            this.label7.Click += new System.EventHandler(this.label6_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label4.Location = new System.Drawing.Point(627, 118);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "المجموعة";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label6.Location = new System.Drawing.Point(652, 44);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "الكود";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label1.Location = new System.Drawing.Point(648, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "الإسم";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label3.Location = new System.Drawing.Point(645, 220);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "العنوان";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label2.Location = new System.Drawing.Point(632, 151);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "ت المنزل";
            // 
            // butAddClient
            // 
            this.butAddClient.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.butAddClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.butAddClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddClient.ForeColor = System.Drawing.Color.White;
            this.butAddClient.Location = new System.Drawing.Point(889, 528);
            this.butAddClient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.butAddClient.Name = "butAddClient";
            this.butAddClient.Size = new System.Drawing.Size(135, 44);
            this.butAddClient.TabIndex = 5499;
            this.butAddClient.Text = "إضافة عميل";
            this.butAddClient.UseVisualStyleBackColor = false;
            this.butAddClient.Click += new System.EventHandler(this.button1_Click);
            // 
            // butDaaen
            // 
            this.butDaaen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butDaaen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(203)))), ((int)(((byte)(5)))));
            this.butDaaen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDaaen.ForeColor = System.Drawing.Color.White;
            this.butDaaen.Location = new System.Drawing.Point(889, 528);
            this.butDaaen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.butDaaen.Name = "butDaaen";
            this.butDaaen.Size = new System.Drawing.Size(135, 44);
            this.butDaaen.TabIndex = 5507;
            this.butDaaen.Text = "إضافة عميل";
            this.butDaaen.UseVisualStyleBackColor = false;
            this.butDaaen.Visible = false;
            this.butDaaen.Click += new System.EventHandler(this.butDaaen_Click);
            // 
            // butMadeen
            // 
            this.butMadeen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(105)))), ((int)(((byte)(189)))));
            this.butMadeen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butMadeen.ForeColor = System.Drawing.Color.White;
            this.butMadeen.Location = new System.Drawing.Point(889, 528);
            this.butMadeen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.butMadeen.Name = "butMadeen";
            this.butMadeen.Size = new System.Drawing.Size(135, 44);
            this.butMadeen.TabIndex = 5506;
            this.butMadeen.Text = "إضافة عميل";
            this.butMadeen.UseVisualStyleBackColor = false;
            this.butMadeen.Visible = false;
            this.butMadeen.Click += new System.EventHandler(this.butMadeen_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(35, 34);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePicker1.RightToLeftLayout = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(139, 22);
            this.dateTimePicker1.TabIndex = 5508;
            this.dateTimePicker1.Visible = false;
            // 
            // txtID_ClintShearch
            // 
            this.txtID_ClintShearch.Enabled = false;
            this.txtID_ClintShearch.Location = new System.Drawing.Point(355, 34);
            this.txtID_ClintShearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtID_ClintShearch.Name = "txtID_ClintShearch";
            this.txtID_ClintShearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtID_ClintShearch.Size = new System.Drawing.Size(119, 22);
            this.txtID_ClintShearch.TabIndex = 5509;
            this.txtID_ClintShearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(287, 31);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 28);
            this.button1.TabIndex = 5510;
            this.button1.Text = "بحث";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.ForeColor = System.Drawing.Color.White;
            this.radioButton2.Location = new System.Drawing.Point(961, 35);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioButton2.Size = new System.Drawing.Size(53, 21);
            this.radioButton2.TabIndex = 5511;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "الاسم";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.ForeColor = System.Drawing.Color.White;
            this.radioButton3.Location = new System.Drawing.Point(483, 35);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioButton3.Size = new System.Drawing.Size(52, 21);
            this.radioButton3.TabIndex = 5511;
            this.radioButton3.Text = "الكود";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(157)))), ((int)(((byte)(137)))));
            this.button5.BackgroundImage = global::ZAD_Sales.Properties.Resources.searchZ;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.button5.Location = new System.Drawing.Point(925, 33);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(27, 25);
            this.button5.TabIndex = 7497;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(243)))), ((int)(((byte)(220)))));
            this.panel10.Controls.Add(this.label19);
            this.panel10.Controls.Add(this.label9);
            this.panel10.Controls.Add(this.textSearchClintMobil);
            this.panel10.Controls.Add(this.textSearchClint);
            this.panel10.Controls.Add(this.dataGridSearchClint);
            this.panel10.Location = new System.Drawing.Point(32, 70);
            this.panel10.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(992, 431);
            this.panel10.TabIndex = 7501;
            this.panel10.Visible = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label19.Location = new System.Drawing.Point(283, 27);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(45, 17);
            this.label19.TabIndex = 531;
            this.label19.Text = "المحمول";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(917, 27);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 17);
            this.label9.TabIndex = 530;
            this.label9.Text = "الاسم";
            // 
            // textSearchClintMobil
            // 
            this.textSearchClintMobil.Location = new System.Drawing.Point(21, 22);
            this.textSearchClintMobil.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textSearchClintMobil.Name = "textSearchClintMobil";
            this.textSearchClintMobil.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textSearchClintMobil.Size = new System.Drawing.Size(221, 22);
            this.textSearchClintMobil.TabIndex = 2;
            this.textSearchClintMobil.TextChanged += new System.EventHandler(this.textSearchClintMobil_TextChanged);
            // 
            // textSearchClint
            // 
            this.textSearchClint.Location = new System.Drawing.Point(481, 22);
            this.textSearchClint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textSearchClint.Name = "textSearchClint";
            this.textSearchClint.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textSearchClint.Size = new System.Drawing.Size(417, 22);
            this.textSearchClint.TabIndex = 1;
            this.textSearchClint.TextChanged += new System.EventHandler(this.textSearchClint_TextChanged);
            // 
            // dataGridSearchClint
            // 
            this.dataGridSearchClint.AutoGenerateColumns = false;
            this.dataGridSearchClint.BackgroundColor = System.Drawing.Color.White;
            this.dataGridSearchClint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSearchClint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.companyDataGridViewTextBoxColumn,
            this.telHomeDataGridViewTextBoxColumn,
            this.telMobilDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.previousBalanceDataGridViewTextBoxColumn,
            this.stateRaseedDataGridViewTextBoxColumn});
            this.dataGridSearchClint.DataSource = this.classGetAllClintesBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Coral;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridSearchClint.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridSearchClint.Location = new System.Drawing.Point(9, 58);
            this.dataGridSearchClint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridSearchClint.Name = "dataGridSearchClint";
            this.dataGridSearchClint.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridSearchClint.RowHeadersWidth = 51;
            this.dataGridSearchClint.Size = new System.Drawing.Size(973, 353);
            this.dataGridSearchClint.TabIndex = 0;
            this.dataGridSearchClint.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridSearchClint_CellDoubleClick);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "الكود";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Width = 60;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "الاسم";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 160;
            // 
            // companyDataGridViewTextBoxColumn
            // 
            this.companyDataGridViewTextBoxColumn.DataPropertyName = "Company";
            this.companyDataGridViewTextBoxColumn.HeaderText = "المجموعه";
            this.companyDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.companyDataGridViewTextBoxColumn.Name = "companyDataGridViewTextBoxColumn";
            this.companyDataGridViewTextBoxColumn.Width = 60;
            // 
            // telHomeDataGridViewTextBoxColumn
            // 
            this.telHomeDataGridViewTextBoxColumn.DataPropertyName = "TelHome";
            this.telHomeDataGridViewTextBoxColumn.HeaderText = "التليفون";
            this.telHomeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.telHomeDataGridViewTextBoxColumn.Name = "telHomeDataGridViewTextBoxColumn";
            this.telHomeDataGridViewTextBoxColumn.Width = 70;
            // 
            // telMobilDataGridViewTextBoxColumn
            // 
            this.telMobilDataGridViewTextBoxColumn.DataPropertyName = "TelMobil";
            this.telMobilDataGridViewTextBoxColumn.HeaderText = "المحمول";
            this.telMobilDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.telMobilDataGridViewTextBoxColumn.Name = "telMobilDataGridViewTextBoxColumn";
            this.telMobilDataGridViewTextBoxColumn.Width = 80;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "العنوان";
            this.addressDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.Width = 120;
            // 
            // previousBalanceDataGridViewTextBoxColumn
            // 
            this.previousBalanceDataGridViewTextBoxColumn.DataPropertyName = "PreviousBalance";
            this.previousBalanceDataGridViewTextBoxColumn.HeaderText = "الرصيد";
            this.previousBalanceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.previousBalanceDataGridViewTextBoxColumn.Name = "previousBalanceDataGridViewTextBoxColumn";
            this.previousBalanceDataGridViewTextBoxColumn.Width = 60;
            // 
            // stateRaseedDataGridViewTextBoxColumn
            // 
            this.stateRaseedDataGridViewTextBoxColumn.DataPropertyName = "StateRaseed";
            this.stateRaseedDataGridViewTextBoxColumn.HeaderText = "الحالة";
            this.stateRaseedDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.stateRaseedDataGridViewTextBoxColumn.Name = "stateRaseedDataGridViewTextBoxColumn";
            this.stateRaseedDataGridViewTextBoxColumn.Width = 50;
            // 
            // classGetAllClintesBindingSource
            // 
            this.classGetAllClintesBindingSource.DataSource = typeof(ZAD_Sales.Forms.ClientAdd.Class_GetAllClintes);
            // 
            // ClientAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(157)))), ((int)(((byte)(137)))));
            this.ClientSize = new System.Drawing.Size(1084, 606);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtID_ClintShearch);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.butDaaen);
            this.Controls.Add(this.butMadeen);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.butDelete);
            this.Controls.Add(this.butUpdate);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.butSearch);
            this.Controls.Add(this.comClient);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.butAddClient);
            this.ForeColor = System.Drawing.Color.Coral;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ClientAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة عميل";
            this.Load += new System.EventHandler(this.ClientAdd_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSearchClint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classGetAllClintesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button butDelete;
        private System.Windows.Forms.Button butUpdate;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button butSearch;
        private System.Windows.Forms.ComboBox comClient;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox combStateRaseed;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtID_Clint;
        private System.Windows.Forms.Button butPic;
        private System.Windows.Forms.ComboBox combGroups;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txeTell;
        private System.Windows.Forms.TextBox txtMobil;
        private System.Windows.Forms.TextBox txtAdress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butAddClient;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Windows.Forms.Button butDaaen;
        private System.Windows.Forms.Button butMadeen;
        private System.Windows.Forms.RadioButton radbutDaen;
        private System.Windows.Forms.RadioButton radbutMaden;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox textDaen;
        private System.Windows.Forms.TextBox textMaden;
        private System.Windows.Forms.Label labelMaden;
        private System.Windows.Forms.Label labelDaen;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBillingDataNumBill;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textLimitCredit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtID_ClintShearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textSearchClintMobil;
        private System.Windows.Forms.TextBox textSearchClint;
        private System.Windows.Forms.DataGridView dataGridSearchClint;
        private System.Windows.Forms.BindingSource classGetAllClintesBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telHomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telMobilDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn previousBalanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateRaseedDataGridViewTextBoxColumn;
    }
}