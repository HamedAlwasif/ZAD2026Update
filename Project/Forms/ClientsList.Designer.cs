namespace ZAD_Sales.Forms
{
    partial class ClientsList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.PanalName = new System.Windows.Forms.Panel();
            this.comClient = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.PanalGroup = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.combGroups = new System.Windows.Forms.ComboBox();
            this.butPrint = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telHomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telMobilDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.previousBalanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stateRaseedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classClientsListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.textMadenon = new System.Windows.Forms.TextBox();
            this.textDaenon = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.combStateRaseed = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.panelRemaining = new System.Windows.Forms.Panel();
            this.PanalName.SuspendLayout();
            this.PanalGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classClientsListBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelRemaining.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox12
            // 
            this.textBox12.Enabled = false;
            this.textBox12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox12.ForeColor = System.Drawing.Color.Green;
            this.textBox12.Location = new System.Drawing.Point(2, 517);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(21, 21);
            this.textBox12.TabIndex = 5482;
            this.textBox12.Text = "0";
            this.textBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox12.Visible = false;
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(-11, 472);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(34, 20);
            this.textBox13.TabIndex = 5483;
            this.textBox13.Text = "الحاله";
            this.textBox13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox13.Visible = false;
            // 
            // PanalName
            // 
            this.PanalName.Controls.Add(this.comClient);
            this.PanalName.Controls.Add(this.label11);
            this.PanalName.Location = new System.Drawing.Point(429, 12);
            this.PanalName.Name = "PanalName";
            this.PanalName.Size = new System.Drawing.Size(275, 31);
            this.PanalName.TabIndex = 5488;
            this.PanalName.Visible = false;
            // 
            // comClient
            // 
            this.comClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comClient.DisplayMember = "Name";
            this.comClient.FormattingEnabled = true;
            this.comClient.Location = new System.Drawing.Point(13, 7);
            this.comClient.Name = "comClient";
            this.comClient.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comClient.Size = new System.Drawing.Size(210, 21);
            this.comClient.TabIndex = 5458;
            this.comClient.ValueMember = "Name";
            this.comClient.TextChanged += new System.EventHandler(this.comClient_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label11.Location = new System.Drawing.Point(226, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 5459;
            this.label11.Text = "الإسم";
            // 
            // comboBox5
            // 
            this.comboBox5.DisplayMember = "NumBill";
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(-44, 494);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(67, 21);
            this.comboBox5.TabIndex = 5481;
            this.comboBox5.ValueMember = "NumBill";
            this.comboBox5.Visible = false;
            // 
            // PanalGroup
            // 
            this.PanalGroup.Controls.Add(this.button5);
            this.PanalGroup.Controls.Add(this.label10);
            this.PanalGroup.Controls.Add(this.combGroups);
            this.PanalGroup.Location = new System.Drawing.Point(494, 11);
            this.PanalGroup.Name = "PanalGroup";
            this.PanalGroup.Size = new System.Drawing.Size(200, 32);
            this.PanalGroup.TabIndex = 5489;
            this.PanalGroup.Visible = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.button5.BackgroundImage = global::ZAD_Sales.Properties.Resources.searchZ;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Location = new System.Drawing.Point(3, 6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(20, 21);
            this.button5.TabIndex = 5457;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label10.Location = new System.Drawing.Point(139, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 5456;
            this.label10.Text = "المجموعة";
            // 
            // combGroups
            // 
            this.combGroups.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.combGroups.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combGroups.FormattingEnabled = true;
            this.combGroups.Items.AddRange(new object[] {
            "عميل",
            "خط 1",
            "خط 2",
            "خط 3"});
            this.combGroups.Location = new System.Drawing.Point(23, 6);
            this.combGroups.Name = "combGroups";
            this.combGroups.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.combGroups.Size = new System.Drawing.Size(106, 21);
            this.combGroups.TabIndex = 5455;
            // 
            // butPrint
            // 
            this.butPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(197)))), ((int)(((byte)(49)))));
            this.butPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(59)))), ((int)(((byte)(72)))));
            this.butPrint.Location = new System.Drawing.Point(29, 15);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(134, 25);
            this.butPrint.TabIndex = 5487;
            this.butPrint.Text = "طباعة";
            this.butPrint.UseVisualStyleBackColor = false;
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label17.Location = new System.Drawing.Point(954, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 13);
            this.label17.TabIndex = 5486;
            this.label17.Text = "طريقة البحث";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "جميع العملاء",
            "العملاء المدينين",
            "العملاء الدائنين",
            "-----------------------",
            "مجموعة عملاء",
            "مجموعة عملاء مدينين",
            "مجموعة عملاء دائنين",
            "-----------------------",
            "جميع العملاء مجموعات",
            "-----------------------",
            "بحث عميل",
            "-----------------------",
            "حالة الرصيد"});
            this.comboBox2.Location = new System.Drawing.Point(722, 17);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox2.Size = new System.Drawing.Size(226, 21);
            this.comboBox2.TabIndex = 5485;
            this.comboBox2.Text = "جميع العملاء";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.companyDataGridViewTextBoxColumn,
            this.telHomeDataGridViewTextBoxColumn,
            this.telMobilDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.previousBalanceDataGridViewTextBoxColumn,
            this.stateRaseedDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.classClientsListBindingSource;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView1.Location = new System.Drawing.Point(29, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridView1.Size = new System.Drawing.Size(992, 460);
            this.dataGridView1.TabIndex = 5484;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "الكود";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Width = 80;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "الاسم";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 220;
            // 
            // companyDataGridViewTextBoxColumn
            // 
            this.companyDataGridViewTextBoxColumn.DataPropertyName = "Company";
            this.companyDataGridViewTextBoxColumn.HeaderText = "مجموعة";
            this.companyDataGridViewTextBoxColumn.Name = "companyDataGridViewTextBoxColumn";
            this.companyDataGridViewTextBoxColumn.Width = 80;
            // 
            // telHomeDataGridViewTextBoxColumn
            // 
            this.telHomeDataGridViewTextBoxColumn.DataPropertyName = "TelHome";
            this.telHomeDataGridViewTextBoxColumn.HeaderText = "ت المنزل";
            this.telHomeDataGridViewTextBoxColumn.Name = "telHomeDataGridViewTextBoxColumn";
            this.telHomeDataGridViewTextBoxColumn.Width = 90;
            // 
            // telMobilDataGridViewTextBoxColumn
            // 
            this.telMobilDataGridViewTextBoxColumn.DataPropertyName = "TelMobil";
            this.telMobilDataGridViewTextBoxColumn.HeaderText = "ت المحمول";
            this.telMobilDataGridViewTextBoxColumn.Name = "telMobilDataGridViewTextBoxColumn";
            this.telMobilDataGridViewTextBoxColumn.Width = 90;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "العنوان";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.Width = 200;
            // 
            // previousBalanceDataGridViewTextBoxColumn
            // 
            this.previousBalanceDataGridViewTextBoxColumn.DataPropertyName = "PreviousBalance";
            this.previousBalanceDataGridViewTextBoxColumn.HeaderText = "الرصيد";
            this.previousBalanceDataGridViewTextBoxColumn.Name = "previousBalanceDataGridViewTextBoxColumn";
            this.previousBalanceDataGridViewTextBoxColumn.Width = 80;
            // 
            // stateRaseedDataGridViewTextBoxColumn
            // 
            this.stateRaseedDataGridViewTextBoxColumn.DataPropertyName = "StateRaseed";
            this.stateRaseedDataGridViewTextBoxColumn.HeaderText = "الحالة";
            this.stateRaseedDataGridViewTextBoxColumn.Name = "stateRaseedDataGridViewTextBoxColumn";
            this.stateRaseedDataGridViewTextBoxColumn.Width = 80;
            // 
            // classClientsListBindingSource
            // 
            this.classClientsListBindingSource.DataSource = typeof(ZAD_Sales.Forms.ClientsList.Class_ClientsList);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(-63, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1200, 1);
            this.panel2.TabIndex = 5480;
            this.panel2.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.textMadenon);
            this.panel1.Controls.Add(this.textDaenon);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(29, 523);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(992, 37);
            this.panel1.TabIndex = 5479;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(21, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(33, 23);
            this.button4.TabIndex = 7;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textMadenon
            // 
            this.textMadenon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textMadenon.ForeColor = System.Drawing.Color.Green;
            this.textMadenon.Location = new System.Drawing.Point(692, 7);
            this.textMadenon.Name = "textMadenon";
            this.textMadenon.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textMadenon.Size = new System.Drawing.Size(158, 21);
            this.textMadenon.TabIndex = 3;
            this.textMadenon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textMadenon.Visible = false;
            // 
            // textDaenon
            // 
            this.textDaenon.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDaenon.ForeColor = System.Drawing.Color.Maroon;
            this.textDaenon.Location = new System.Drawing.Point(65, 7);
            this.textDaenon.Name = "textDaenon";
            this.textDaenon.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textDaenon.Size = new System.Drawing.Size(158, 21);
            this.textDaenon.TabIndex = 4;
            this.textDaenon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textDaenon.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(59)))), ((int)(((byte)(72)))));
            this.label7.Location = new System.Drawing.Point(864, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "إجمالى الديون للشركة";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(59)))), ((int)(((byte)(72)))));
            this.label8.Location = new System.Drawing.Point(255, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "إجمالى الديون على الشركة";
            this.label8.Visible = false;
            // 
            // combStateRaseed
            // 
            this.combStateRaseed.FormattingEnabled = true;
            this.combStateRaseed.Items.AddRange(new object[] {
            "فعال",
            "معدوم"});
            this.combStateRaseed.Location = new System.Drawing.Point(33, 7);
            this.combStateRaseed.Name = "combStateRaseed";
            this.combStateRaseed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.combStateRaseed.Size = new System.Drawing.Size(91, 21);
            this.combStateRaseed.TabIndex = 5499;
            this.combStateRaseed.Text = "فعال";
            this.combStateRaseed.TextChanged += new System.EventHandler(this.combStateRaseed_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label16.Location = new System.Drawing.Point(130, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 13);
            this.label16.TabIndex = 5500;
            this.label16.Text = "الرصيد";
            // 
            // panelRemaining
            // 
            this.panelRemaining.Controls.Add(this.combStateRaseed);
            this.panelRemaining.Controls.Add(this.label16);
            this.panelRemaining.Location = new System.Drawing.Point(218, 8);
            this.panelRemaining.Name = "panelRemaining";
            this.panelRemaining.Size = new System.Drawing.Size(200, 35);
            this.panelRemaining.TabIndex = 5501;
            this.panelRemaining.Visible = false;
            // 
            // ClientsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(115)))), ((int)(((byte)(158)))));
            this.ClientSize = new System.Drawing.Size(1048, 614);
            this.Controls.Add(this.panelRemaining);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.PanalName);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.PanalGroup);
            this.Controls.Add(this.butPrint);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ClientsList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "قائمة العملاء";
            this.Load += new System.EventHandler(this.ClientsList_Load);
            this.PanalName.ResumeLayout(false);
            this.PanalName.PerformLayout();
            this.PanalGroup.ResumeLayout(false);
            this.PanalGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classClientsListBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelRemaining.ResumeLayout(false);
            this.panelRemaining.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.Panel PanalName;
        private System.Windows.Forms.ComboBox comClient;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Panel PanalGroup;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox combGroups;
        private System.Windows.Forms.Button butPrint;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textMadenon;
        private System.Windows.Forms.TextBox textDaenon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telHomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telMobilDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn previousBalanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateRaseedDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource classClientsListBindingSource;
        private System.Windows.Forms.ComboBox combStateRaseed;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panelRemaining;
    }
}