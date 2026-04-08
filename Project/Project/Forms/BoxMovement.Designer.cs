namespace ZAD_Sales.Forms
{
    partial class BoxMovement
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
            this.dateDateDay = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.butPrint = new System.Windows.Forms.Button();
            this.txtReminngOLD = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGrDetais = new System.Windows.Forms.DataGridView();
            this.txtRemainingNOW = new System.Windows.Forms.TextBox();
            this.butSum = new System.Windows.Forms.Button();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.butSearch = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrDetais)).BeginInit();
            this.SuspendLayout();
            // 
            // dateDateDay
            // 
            this.dateDateDay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDateDay.Location = new System.Drawing.Point(-7, 201);
            this.dateDateDay.Name = "dateDateDay";
            this.dateDateDay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateDateDay.RightToLeftLayout = true;
            this.dateDateDay.Size = new System.Drawing.Size(24, 20);
            this.dateDateDay.TabIndex = 5492;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.butPrint);
            this.groupBox2.Controls.Add(this.txtReminngOLD);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.textBox10);
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dataGrDetais);
            this.groupBox2.Location = new System.Drawing.Point(20, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(938, 500);
            this.groupBox2.TabIndex = 5491;
            this.groupBox2.TabStop = false;
            // 
            // butPrint
            // 
            this.butPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(172)))), ((int)(((byte)(132)))));
            this.butPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butPrint.ForeColor = System.Drawing.Color.White;
            this.butPrint.Location = new System.Drawing.Point(779, 463);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(140, 23);
            this.butPrint.TabIndex = 5479;
            this.butPrint.Text = "طباعة";
            this.butPrint.UseVisualStyleBackColor = false;
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // txtReminngOLD
            // 
            this.txtReminngOLD.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReminngOLD.ForeColor = System.Drawing.Color.Red;
            this.txtReminngOLD.Location = new System.Drawing.Point(26, 19);
            this.txtReminngOLD.Name = "txtReminngOLD";
            this.txtReminngOLD.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtReminngOLD.Size = new System.Drawing.Size(188, 23);
            this.txtReminngOLD.TabIndex = 5471;
            this.txtReminngOLD.Text = "0";
            this.txtReminngOLD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(250, 465);
            this.textBox4.Name = "textBox4";
            this.textBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox4.Size = new System.Drawing.Size(114, 20);
            this.textBox4.TabIndex = 5473;
            this.textBox4.Text = "0";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(53)))), ((int)(((byte)(66)))));
            this.label6.Location = new System.Drawing.Point(220, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 5472;
            this.label6.Text = "رصيد بداية المدة";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label10.Location = new System.Drawing.Point(150, 469);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 5478;
            this.label10.Text = "اجمالى الفترة";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.button1.BackgroundImage = global::ZAD_Sales.Properties.Resources.searchZ;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(629, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "بحث";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(473, 465);
            this.textBox5.Name = "textBox5";
            this.textBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox5.Size = new System.Drawing.Size(114, 20);
            this.textBox5.TabIndex = 5474;
            this.textBox5.Text = "0";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox10
            // 
            this.textBox10.ForeColor = System.Drawing.Color.Red;
            this.textBox10.Location = new System.Drawing.Point(26, 465);
            this.textBox10.Name = "textBox10";
            this.textBox10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox10.Size = new System.Drawing.Size(114, 20);
            this.textBox10.TabIndex = 5477;
            this.textBox10.Text = "0";
            this.textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(653, 20);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePicker2.RightToLeftLayout = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(104, 20);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label2.Location = new System.Drawing.Point(763, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "إلى";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label9.Location = new System.Drawing.Point(381, 469);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 5478;
            this.label9.Text = "اجمالى الصادر";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label8.Location = new System.Drawing.Point(600, 469);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 5478;
            this.label8.Text = "اجمالى الوارد";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(793, 20);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePicker1.RightToLeftLayout = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(104, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label1.Location = new System.Drawing.Point(899, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "من";
            // 
            // dataGrDetais
            // 
            this.dataGrDetais.AllowUserToAddRows = false;
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
            this.dataGrDetais.Location = new System.Drawing.Point(26, 54);
            this.dataGrDetais.Name = "dataGrDetais";
            this.dataGrDetais.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrDetais.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            this.dataGrDetais.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGrDetais.Size = new System.Drawing.Size(893, 400);
            this.dataGrDetais.TabIndex = 5466;
            // 
            // txtRemainingNOW
            // 
            this.txtRemainingNOW.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemainingNOW.ForeColor = System.Drawing.Color.Green;
            this.txtRemainingNOW.Location = new System.Drawing.Point(673, 17);
            this.txtRemainingNOW.Name = "txtRemainingNOW";
            this.txtRemainingNOW.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRemainingNOW.Size = new System.Drawing.Size(213, 23);
            this.txtRemainingNOW.TabIndex = 5487;
            this.txtRemainingNOW.Text = "0";
            this.txtRemainingNOW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // butSum
            // 
            this.butSum.Location = new System.Drawing.Point(105, 12);
            this.butSum.Name = "butSum";
            this.butSum.Size = new System.Drawing.Size(46, 23);
            this.butSum.TabIndex = 5490;
            this.butSum.Text = "الاجمالى";
            this.butSum.UseVisualStyleBackColor = true;
            this.butSum.Visible = false;
            this.butSum.Click += new System.EventHandler(this.butSum_Click);
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(-7, 133);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(71, 20);
            this.textBox11.TabIndex = 5489;
            this.textBox11.Text = "0";
            this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox11.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.label7.Location = new System.Drawing.Point(891, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 5488;
            this.label7.Text = "الرصيدالحالى";
            // 
            // butSearch
            // 
            this.butSearch.Location = new System.Drawing.Point(40, 16);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(24, 23);
            this.butSearch.TabIndex = 5484;
            this.butSearch.Text = "بحث";
            this.butSearch.UseVisualStyleBackColor = true;
            this.butSearch.Visible = false;
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(-14, 61);
            this.textBox6.Name = "textBox6";
            this.textBox6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox6.Size = new System.Drawing.Size(85, 20);
            this.textBox6.TabIndex = 5486;
            this.textBox6.Text = "0";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox6.Visible = false;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(-14, 85);
            this.textBox7.Name = "textBox7";
            this.textBox7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox7.Size = new System.Drawing.Size(85, 20);
            this.textBox7.TabIndex = 5485;
            this.textBox7.Text = "0";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox7.Visible = false;
            // 
            // BoxMovement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(115)))), ((int)(((byte)(158)))));
            this.ClientSize = new System.Drawing.Size(985, 557);
            this.Controls.Add(this.dateDateDay);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtRemainingNOW);
            this.Controls.Add(this.butSum);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.butSearch);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox7);
            this.Name = "BoxMovement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "حركة الصندوق";
            this.Load += new System.EventHandler(this.BoxMovement_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrDetais)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateDateDay;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button butPrint;
        private System.Windows.Forms.TextBox txtReminngOLD;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGrDetais;
        private System.Windows.Forms.TextBox txtRemainingNOW;
        private System.Windows.Forms.Button butSum;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button butSearch;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
    }
}