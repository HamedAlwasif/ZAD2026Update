namespace ZAD_Sales.Forms
{
    partial class TypeProgram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TypeProgram));
            this.butDemo = new System.Windows.Forms.Button();
            this.butOreginal = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.panelType = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panelUser = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textUserName = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.butLogin = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBassword = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.combVersion = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.combServer = new System.Windows.Forms.ComboBox();
            this.textDatabase = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lab_SERVER = new System.Windows.Forms.Label();
            this.labelDataBaseName = new System.Windows.Forms.Label();
            this.panelType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panelUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // butDemo
            // 
            this.butDemo.BackColor = System.Drawing.Color.HotPink;
            this.butDemo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDemo.ForeColor = System.Drawing.Color.White;
            this.butDemo.Location = new System.Drawing.Point(247, 70);
            this.butDemo.Name = "butDemo";
            this.butDemo.Size = new System.Drawing.Size(133, 83);
            this.butDemo.TabIndex = 0;
            this.butDemo.Text = "نسخة تجريبية";
            this.butDemo.UseVisualStyleBackColor = false;
            this.butDemo.Click += new System.EventHandler(this.butDemo_Click);
            // 
            // butOreginal
            // 
            this.butOreginal.BackColor = System.Drawing.Color.MediumTurquoise;
            this.butOreginal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butOreginal.ForeColor = System.Drawing.Color.White;
            this.butOreginal.Location = new System.Drawing.Point(39, 70);
            this.butOreginal.Name = "butOreginal";
            this.butOreginal.Size = new System.Drawing.Size(142, 83);
            this.butOreginal.TabIndex = 1;
            this.butOreginal.Text = "نسخة أصلية";
            this.butOreginal.UseVisualStyleBackColor = false;
            this.butOreginal.Click += new System.EventHandler(this.butOreginal_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(226, -18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(3, 300);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(256, 15);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(119, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "سوف يتوقف البرنامج\r\nعن العمل بعد فترة";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(24, 31);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(186, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "سوف يعمل البرنامج بشكل كامل ";
            // 
            // panelType
            // 
            this.panelType.BackColor = System.Drawing.Color.White;
            this.panelType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelType.Controls.Add(this.pictureBox3);
            this.panelType.Controls.Add(this.label2);
            this.panelType.Controls.Add(this.butDemo);
            this.panelType.Controls.Add(this.label1);
            this.panelType.Controls.Add(this.butOreginal);
            this.panelType.Controls.Add(this.panel1);
            this.panelType.Location = new System.Drawing.Point(33, 39);
            this.panelType.Name = "panelType";
            this.panelType.Size = new System.Drawing.Size(573, 207);
            this.panelType.TabIndex = 5;
            this.panelType.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.BackgroundImage = global::ZAD_Sales.Properties.Resources.logooooooooooooooooo;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(397, 33);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(158, 141);
            this.pictureBox3.TabIndex = 536;
            this.pictureBox3.TabStop = false;
            // 
            // panelUser
            // 
            this.panelUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelUser.BackColor = System.Drawing.Color.White;
            this.panelUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUser.Controls.Add(this.pictureBox2);
            this.panelUser.Controls.Add(this.groupBox3);
            this.panelUser.Location = new System.Drawing.Point(37, 37);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(570, 210);
            this.panelUser.TabIndex = 47;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BackgroundImage = global::ZAD_Sales.Properties.Resources.LOGO2024;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(11, 22);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(158, 161);
            this.pictureBox2.TabIndex = 535;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textUserName);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.butLogin);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBassword);
            this.groupBox3.Controls.Add(this.button9);
            this.groupBox3.Location = new System.Drawing.Point(175, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(365, 169);
            this.groupBox3.TabIndex = 534;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "  ادخل بيانات الدخول  ";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(267, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "الباسورد";
            // 
            // textUserName
            // 
            this.textUserName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textUserName.Location = new System.Drawing.Point(38, 49);
            this.textUserName.Name = "textUserName";
            this.textUserName.Size = new System.Drawing.Size(211, 20);
            this.textUserName.TabIndex = 0;
            this.textUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(82)))), ((int)(((byte)(83)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(104, 118);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "دخول";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // butLogin
            // 
            this.butLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.butLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.butLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butLogin.ForeColor = System.Drawing.Color.White;
            this.butLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLogin.Location = new System.Drawing.Point(292, 140);
            this.butLogin.Name = "butLogin";
            this.butLogin.Size = new System.Drawing.Size(67, 23);
            this.butLogin.TabIndex = 2;
            this.butLogin.Text = "دخول";
            this.butLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.butLogin.UseVisualStyleBackColor = false;
            this.butLogin.Visible = false;
            this.butLogin.Click += new System.EventHandler(this.butLogin_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(276, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "الإسم";
            // 
            // textBassword
            // 
            this.textBassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBassword.Location = new System.Drawing.Point(38, 83);
            this.textBassword.Name = "textBassword";
            this.textBassword.PasswordChar = '*';
            this.textBassword.Size = new System.Drawing.Size(211, 20);
            this.textBassword.TabIndex = 1;
            this.textBassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button9
            // 
            this.button9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(38, 118);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(46, 23);
            this.button9.TabIndex = 525;
            this.button9.Text = "خروج";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.pictureBox4);
            this.panel3.Location = new System.Drawing.Point(37, 31);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(573, 207);
            this.panel3.TabIndex = 52;
            this.panel3.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(91, 164);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(359, 20);
            this.label6.TabIndex = 537;
            this.label6.Text = "يرجى تفعيل البرنامج لاستكمال العمل عليه شكرا جزيلا 01224349933";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.White;
            this.pictureBox4.BackgroundImage = global::ZAD_Sales.Properties.Resources.LOGO2024;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(206, 7);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(158, 154);
            this.pictureBox4.TabIndex = 536;
            this.pictureBox4.TabStop = false;
            // 
            // combVersion
            // 
            this.combVersion.FormattingEnabled = true;
            this.combVersion.Items.AddRange(new object[] {
            "Lite",
            "Professional",
            "Enterprise"});
            this.combVersion.Location = new System.Drawing.Point(148, 33);
            this.combVersion.Name = "combVersion";
            this.combVersion.Size = new System.Drawing.Size(223, 21);
            this.combVersion.TabIndex = 48;
            this.combVersion.Text = "Professional";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label27);
            this.panel2.Controls.Add(this.label28);
            this.panel2.Controls.Add(this.combServer);
            this.panel2.Controls.Add(this.textDatabase);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.combVersion);
            this.panel2.Location = new System.Drawing.Point(35, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(573, 207);
            this.panel2.TabIndex = 49;
            this.panel2.Visible = false;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label27.Location = new System.Drawing.Point(34, 74);
            this.label27.Name = "label27";
            this.label27.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label27.Size = new System.Drawing.Size(85, 15);
            this.label27.TabIndex = 212159;
            this.label27.Text = "Server Name :";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label28.Location = new System.Drawing.Point(34, 114);
            this.label28.Name = "label28";
            this.label28.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label28.Size = new System.Drawing.Size(100, 15);
            this.label28.TabIndex = 212160;
            this.label28.Text = "DataBase Name :";
            // 
            // combServer
            // 
            this.combServer.FormattingEnabled = true;
            this.combServer.Location = new System.Drawing.Point(148, 72);
            this.combServer.Name = "combServer";
            this.combServer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.combServer.Size = new System.Drawing.Size(223, 21);
            this.combServer.TabIndex = 212157;
            // 
            // textDatabase
            // 
            this.textDatabase.Location = new System.Drawing.Point(148, 111);
            this.textDatabase.Name = "textDatabase";
            this.textDatabase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textDatabase.Size = new System.Drawing.Size(223, 20);
            this.textDatabase.TabIndex = 212158;
            this.textDatabase.Text = "ZAD";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(82)))), ((int)(((byte)(83)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(272, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 538;
            this.button1.Text = "تم";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(37, 33);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(50, 15);
            this.label5.TabIndex = 537;
            this.label5.Text = "Version";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = global::ZAD_Sales.Properties.Resources.LOGO2024;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(397, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(158, 155);
            this.pictureBox1.TabIndex = 536;
            this.pictureBox1.TabStop = false;
            // 
            // lab_SERVER
            // 
            this.lab_SERVER.AutoSize = true;
            this.lab_SERVER.Location = new System.Drawing.Point(32, 258);
            this.lab_SERVER.Name = "lab_SERVER";
            this.lab_SERVER.Size = new System.Drawing.Size(47, 13);
            this.lab_SERVER.TabIndex = 51;
            this.lab_SERVER.Text = "الاعدادات";
            this.lab_SERVER.Click += new System.EventHandler(this.lab_SERVER_Click);
            // 
            // labelDataBaseName
            // 
            this.labelDataBaseName.AutoSize = true;
            this.labelDataBaseName.Location = new System.Drawing.Point(44, 9);
            this.labelDataBaseName.Name = "labelDataBaseName";
            this.labelDataBaseName.Size = new System.Drawing.Size(35, 13);
            this.labelDataBaseName.TabIndex = 53;
            this.labelDataBaseName.Text = "label7";
            // 
            // TypeProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(62)))), ((int)(((byte)(138)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(647, 287);
            this.Controls.Add(this.labelDataBaseName);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lab_SERVER);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelUser);
            this.Controls.Add(this.panelType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TypeProgram";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZAD";
            this.Load += new System.EventHandler(this.TypeProgram_Load);
            this.panelType.ResumeLayout(false);
            this.panelType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panelUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butDemo;
        private System.Windows.Forms.Button butOreginal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Windows.Forms.Panel panelType;
        private System.Windows.Forms.Panel panelUser;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textUserName;
        private System.Windows.Forms.Button butLogin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBassword;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ComboBox combVersion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lab_SERVER;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label labelDataBaseName;
        internal System.Windows.Forms.Label label27;
        internal System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox combServer;
        private System.Windows.Forms.TextBox textDatabase;
        private System.Windows.Forms.Button button2;
    }
}