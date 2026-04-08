namespace ZAD_Sales.Forms
{
    partial class MoneyToBox
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
            this.chBoxDeletCat = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butAdd = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.texUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butAddFristTime = new System.Windows.Forms.Button();
            this.butEdit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtReminngOLD = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textWared = new System.Windows.Forms.TextBox();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chBoxDeletCat
            // 
            this.chBoxDeletCat.AutoSize = true;
            this.chBoxDeletCat.Location = new System.Drawing.Point(450, 332);
            this.chBoxDeletCat.Name = "chBoxDeletCat";
            this.chBoxDeletCat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chBoxDeletCat.Size = new System.Drawing.Size(65, 17);
            this.chBoxDeletCat.TabIndex = 5505;
            this.chBoxDeletCat.Text = "حذف بند";
            this.chBoxDeletCat.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(12, 27);
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Size = new System.Drawing.Size(501, 297);
            this.dataGridView1.TabIndex = 5504;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(197)))), ((int)(((byte)(49)))));
            this.label5.Location = new System.Drawing.Point(210, 333);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 5501;
            this.label5.Text = "الوارد";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.butAdd);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.texUser);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.butAddFristTime);
            this.groupBox1.Controls.Add(this.butEdit);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(519, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(298, 262);
            this.groupBox1.TabIndex = 5500;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "   أدخل البيانات    ";
            // 
            // butAdd
            // 
            this.butAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(189)))), ((int)(((byte)(50)))));
            this.butAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAdd.ForeColor = System.Drawing.Color.White;
            this.butAdd.Location = new System.Drawing.Point(127, 220);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(144, 23);
            this.butAdd.TabIndex = 5506;
            this.butAdd.Text = "إضافة نقدية للصندوق";
            this.butAdd.UseVisualStyleBackColor = false;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(28, 119);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(175, 95);
            this.textBox3.TabIndex = 3;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(197)))), ((int)(((byte)(49)))));
            this.label20.Location = new System.Drawing.Point(225, 86);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(46, 13);
            this.label20.TabIndex = 68;
            this.label20.Text = "المبــــلغ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label3.Location = new System.Drawing.Point(227, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 5486;
            this.label3.Text = "التـــاريخ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(28, 52);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePicker1.RightToLeftLayout = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(175, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // texUser
            // 
            this.texUser.Location = new System.Drawing.Point(28, 19);
            this.texUser.Name = "texUser";
            this.texUser.ReadOnly = true;
            this.texUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.texUser.Size = new System.Drawing.Size(175, 20);
            this.texUser.TabIndex = 72;
            this.texUser.Text = "الإدارة";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label1.Location = new System.Drawing.Point(225, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 5484;
            this.label1.Text = "الإســـم";
            // 
            // butAddFristTime
            // 
            this.butAddFristTime.BackColor = System.Drawing.Color.Navy;
            this.butAddFristTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddFristTime.ForeColor = System.Drawing.Color.White;
            this.butAddFristTime.Location = new System.Drawing.Point(127, 220);
            this.butAddFristTime.Name = "butAddFristTime";
            this.butAddFristTime.Size = new System.Drawing.Size(142, 23);
            this.butAddFristTime.TabIndex = 4;
            this.butAddFristTime.Text = "إضافة اول المده";
            this.butAddFristTime.UseVisualStyleBackColor = false;
            this.butAddFristTime.Click += new System.EventHandler(this.butAddFristTime_Click);
            // 
            // butEdit
            // 
            this.butEdit.BackColor = System.Drawing.Color.Green;
            this.butEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butEdit.ForeColor = System.Drawing.Color.White;
            this.butEdit.Location = new System.Drawing.Point(30, 220);
            this.butEdit.Name = "butEdit";
            this.butEdit.Size = new System.Drawing.Size(55, 23);
            this.butEdit.TabIndex = 5476;
            this.butEdit.Text = "تعديل";
            this.butEdit.UseVisualStyleBackColor = false;
            this.butEdit.Visible = false;
            this.butEdit.Click += new System.EventHandler(this.butEdit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label2.Location = new System.Drawing.Point(222, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 5485;
            this.label2.Text = "البيــــــان";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(28, 85);
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox1.Size = new System.Drawing.Size(175, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(115)))), ((int)(((byte)(158)))));
            this.panel1.Controls.Add(this.txtReminngOLD);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Location = new System.Drawing.Point(519, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(298, 29);
            this.panel1.TabIndex = 5503;
            // 
            // txtReminngOLD
            // 
            this.txtReminngOLD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReminngOLD.ForeColor = System.Drawing.Color.Green;
            this.txtReminngOLD.Location = new System.Drawing.Point(28, 4);
            this.txtReminngOLD.Name = "txtReminngOLD";
            this.txtReminngOLD.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtReminngOLD.Size = new System.Drawing.Size(174, 21);
            this.txtReminngOLD.TabIndex = 5479;
            this.txtReminngOLD.Text = "0";
            this.txtReminngOLD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(208, 7);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 13);
            this.label18.TabIndex = 5480;
            this.label18.Text = "رصيد الخزنة";
            // 
            // textWared
            // 
            this.textWared.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textWared.Location = new System.Drawing.Point(12, 329);
            this.textWared.Name = "textWared";
            this.textWared.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textWared.Size = new System.Drawing.Size(192, 21);
            this.textWared.TabIndex = 5502;
            this.textWared.Text = "0";
            this.textWared.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MoneyToBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(126)))), ((int)(((byte)(176)))));
            this.ClientSize = new System.Drawing.Size(839, 374);
            this.Controls.Add(this.chBoxDeletCat);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textWared);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MoneyToBox";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة نقدية للصندوق";
            this.Load += new System.EventHandler(this.MoneyToBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chBoxDeletCat;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox texUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butAddFristTime;
        private System.Windows.Forms.Button butEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtReminngOLD;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textWared;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Windows.Forms.Button butAdd;
    }
}