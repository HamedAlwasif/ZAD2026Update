namespace ZAD_Sales.Forms
{
    partial class Expenses
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butPrint = new System.Windows.Forms.Button();
            this.chBoxDeletCat = new System.Windows.Forms.CheckBox();
            this.comSearchMove = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtReminngOLD = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Dtp_ToDate = new System.Windows.Forms.DateTimePicker();
            this.Dtp_FromDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comBoxMove = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.texUser = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.butAdd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.dataGrData = new System.Windows.Forms.DataGridView();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.panel2.Location = new System.Drawing.Point(323, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 30);
            this.panel2.TabIndex = 5524;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Location = new System.Drawing.Point(476, 22);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(4, 30);
            this.panel4.TabIndex = 5523;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(126)))), ((int)(((byte)(176)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 30);
            this.panel1.TabIndex = 5468;
            // 
            // butPrint
            // 
            this.butPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(189)))), ((int)(((byte)(50)))));
            this.butPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butPrint.ForeColor = System.Drawing.Color.White;
            this.butPrint.Location = new System.Drawing.Point(508, 468);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(79, 23);
            this.butPrint.TabIndex = 5521;
            this.butPrint.Text = "طباعة";
            this.butPrint.UseVisualStyleBackColor = false;
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // chBoxDeletCat
            // 
            this.chBoxDeletCat.AutoSize = true;
            this.chBoxDeletCat.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chBoxDeletCat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.chBoxDeletCat.Location = new System.Drawing.Point(630, 471);
            this.chBoxDeletCat.Name = "chBoxDeletCat";
            this.chBoxDeletCat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chBoxDeletCat.Size = new System.Drawing.Size(76, 20);
            this.chBoxDeletCat.TabIndex = 5520;
            this.chBoxDeletCat.Text = "حذف بند";
            this.chBoxDeletCat.UseVisualStyleBackColor = true;
            // 
            // comSearchMove
            // 
            this.comSearchMove.FormattingEnabled = true;
            this.comSearchMove.Items.AddRange(new object[] {
            "مصاريف نثريه",
            "مصاريف مشتريات",
            "مصاريف دعاية",
            "مصاريف صيانة",
            "مصاريف ايجار",
            "فاتورة كهرباء",
            "فاتورة مياه",
            "فاتورة تليفون",
            "فاتورة انترنت",
            "سحب ارباح"});
            this.comSearchMove.Location = new System.Drawing.Point(333, 27);
            this.comSearchMove.Name = "comSearchMove";
            this.comSearchMove.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comSearchMove.Size = new System.Drawing.Size(94, 21);
            this.comSearchMove.TabIndex = 5519;
            this.comSearchMove.Text = "مصاريف نثريه";
            this.comSearchMove.SelectedIndexChanged += new System.EventHandler(this.comSearchMove_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label10.Location = new System.Drawing.Point(433, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 5518;
            this.label10.Text = "الحـركه";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label8.Location = new System.Drawing.Point(655, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 5517;
            this.label8.Text = "بحث بالبيان";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(490, 27);
            this.textBox7.Name = "textBox7";
            this.textBox7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox7.Size = new System.Drawing.Size(152, 20);
            this.textBox7.TabIndex = 5516;
            this.textBox7.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox16);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.txtReminngOLD);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.groupBox2.Location = new System.Drawing.Point(740, 364);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(266, 100);
            this.groupBox2.TabIndex = 5515;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "   رصيد الخزنة  ";
            this.groupBox2.Visible = false;
            // 
            // textBox16
            // 
            this.textBox16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox16.ForeColor = System.Drawing.Color.Green;
            this.textBox16.Location = new System.Drawing.Point(21, 15);
            this.textBox16.Name = "textBox16";
            this.textBox16.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox16.Size = new System.Drawing.Size(164, 21);
            this.textBox16.TabIndex = 5487;
            this.textBox16.Text = "0";
            this.textBox16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox16.Visible = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label18.Location = new System.Drawing.Point(192, 17);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 13);
            this.label18.TabIndex = 5488;
            this.label18.Text = "رصيد الخزينة";
            // 
            // txtReminngOLD
            // 
            this.txtReminngOLD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReminngOLD.ForeColor = System.Drawing.Color.Maroon;
            this.txtReminngOLD.Location = new System.Drawing.Point(21, 42);
            this.txtReminngOLD.Name = "txtReminngOLD";
            this.txtReminngOLD.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtReminngOLD.Size = new System.Drawing.Size(164, 21);
            this.txtReminngOLD.TabIndex = 5489;
            this.txtReminngOLD.Text = "0";
            this.txtReminngOLD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label26.Location = new System.Drawing.Point(202, 41);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(54, 13);
            this.label26.TabIndex = 5490;
            this.label26.Text = "بعد الصرف";
            this.label26.Visible = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(126)))), ((int)(((byte)(176)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(12, 26);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 5514;
            this.button6.Text = "بحث";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label7.Location = new System.Drawing.Point(178, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 5513;
            this.label7.Text = "إلى";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label6.Location = new System.Drawing.Point(296, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 5512;
            this.label6.Text = "من";
            // 
            // Dtp_ToDate
            // 
            this.Dtp_ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_ToDate.Location = new System.Drawing.Point(91, 27);
            this.Dtp_ToDate.Name = "Dtp_ToDate";
            this.Dtp_ToDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Dtp_ToDate.RightToLeftLayout = true;
            this.Dtp_ToDate.Size = new System.Drawing.Size(85, 20);
            this.Dtp_ToDate.TabIndex = 5511;
            // 
            // Dtp_FromDate
            // 
            this.Dtp_FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dtp_FromDate.Location = new System.Drawing.Point(205, 27);
            this.Dtp_FromDate.Name = "Dtp_FromDate";
            this.Dtp_FromDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Dtp_FromDate.RightToLeftLayout = true;
            this.Dtp_FromDate.Size = new System.Drawing.Size(88, 20);
            this.Dtp_FromDate.TabIndex = 5510;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comBoxMove);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.texUser);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.butAdd);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(197)))), ((int)(((byte)(49)))));
            this.groupBox1.Location = new System.Drawing.Point(740, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(266, 304);
            this.groupBox1.TabIndex = 5508;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "     إضافة مصاريف جديدة    ";
            // 
            // comBoxMove
            // 
            this.comBoxMove.FormattingEnabled = true;
            this.comBoxMove.Items.AddRange(new object[] {
            "مصاريف نثريه",
            "مصاريف مشتريات",
            "مصاريف دعاية",
            "مصاريف صيانة",
            "مصاريف ايجار",
            "فاتورة كهرباء",
            "فاتورة مياه",
            "فاتورة تليفون",
            "فاتورة انترنت",
            "سحب ارباح"});
            this.comBoxMove.Location = new System.Drawing.Point(21, 108);
            this.comBoxMove.Name = "comBoxMove";
            this.comBoxMove.Size = new System.Drawing.Size(164, 21);
            this.comBoxMove.TabIndex = 3;
            this.comBoxMove.Text = "مصاريف نثريه";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label9.Location = new System.Drawing.Point(196, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "الحــــــــركه";
            // 
            // texUser
            // 
            this.texUser.Location = new System.Drawing.Point(21, 67);
            this.texUser.Name = "texUser";
            this.texUser.Size = new System.Drawing.Size(164, 21);
            this.texUser.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(21, 30);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePicker1.RightToLeftLayout = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(164, 21);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(21, 147);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(164, 74);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.textBox2.Location = new System.Drawing.Point(21, 234);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(164, 21);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label1.Location = new System.Drawing.Point(197, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "التــــــــاريخ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label2.Location = new System.Drawing.Point(197, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "المستخـدم";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label3.Location = new System.Drawing.Point(198, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "البيـــــــــان";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label4.Location = new System.Drawing.Point(204, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "المبلــــــغ";
            // 
            // butAdd
            // 
            this.butAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.butAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAdd.ForeColor = System.Drawing.Color.White;
            this.butAdd.Location = new System.Drawing.Point(21, 268);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(232, 26);
            this.butAdd.TabIndex = 6;
            this.butAdd.Text = "إضافة";
            this.butAdd.UseVisualStyleBackColor = false;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.label5.Location = new System.Drawing.Point(149, 476);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 5507;
            this.label5.Text = "إجمالى المصاريف";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.textBox3.Location = new System.Drawing.Point(12, 472);
            this.textBox3.Name = "textBox3";
            this.textBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox3.Size = new System.Drawing.Size(124, 21);
            this.textBox3.TabIndex = 5506;
            this.textBox3.Text = "0";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGrData
            // 
            this.dataGrData.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGrData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrData.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGrData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrData.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGrData.Location = new System.Drawing.Point(12, 58);
            this.dataGrData.Name = "dataGrData";
            this.dataGrData.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrData.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGrData.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGrData.Size = new System.Drawing.Size(698, 407);
            this.dataGrData.TabIndex = 5509;
            this.dataGrData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrData_CellDoubleClick);
            // 
            // Expenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(152)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(1055, 518);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.butPrint);
            this.Controls.Add(this.chBoxDeletCat);
            this.Controls.Add(this.comSearchMove);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Dtp_ToDate);
            this.Controls.Add(this.Dtp_FromDate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.dataGrData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Expenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "المصروفـــــات";
            this.Load += new System.EventHandler(this.Expenses_Load);
            this.panel4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button butPrint;
        private System.Windows.Forms.CheckBox chBoxDeletCat;
        private System.Windows.Forms.ComboBox comSearchMove;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtReminngOLD;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker Dtp_ToDate;
        private System.Windows.Forms.DateTimePicker Dtp_FromDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comBoxMove;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox texUser;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.DataGridView dataGrData;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
    }
}