namespace ZAD_Sales.Forms
{
    partial class MaterialsAdd
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
            this.combMaterial = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textPrice = new System.Windows.Forms.TextBox();
            this.textQunt = new System.Windows.Forms.TextBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.txtTotalMaterial = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.butAddMaterial = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialsNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quntDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateExpiryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classMaterialsBillBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textTotalQuentety = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBarcode = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textNumMaterial = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.textNOTE = new System.Windows.Forms.TextBox();
            this.txtReminngOLD = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.butAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classMaterialsBillBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // combMaterial
            // 
            this.combMaterial.FormattingEnabled = true;
            this.combMaterial.Location = new System.Drawing.Point(791, 109);
            this.combMaterial.Name = "combMaterial";
            this.combMaterial.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.combMaterial.Size = new System.Drawing.Size(200, 21);
            this.combMaterial.TabIndex = 2;
            this.combMaterial.SelectedIndexChanged += new System.EventHandler(this.combMaterial_SelectedIndexChanged);
            this.combMaterial.TextChanged += new System.EventHandler(this.combMaterial_TextChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(846, 37);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePicker1.RightToLeftLayout = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(145, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // textPrice
            // 
            this.textPrice.Location = new System.Drawing.Point(791, 182);
            this.textPrice.Name = "textPrice";
            this.textPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textPrice.Size = new System.Drawing.Size(200, 20);
            this.textPrice.TabIndex = 4;
            this.textPrice.Text = "0";
            this.textPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textPrice.TextChanged += new System.EventHandler(this.textPrice_TextChanged);
            this.textPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textPrice_KeyPress);
            // 
            // textQunt
            // 
            this.textQunt.Location = new System.Drawing.Point(791, 146);
            this.textQunt.Name = "textQunt";
            this.textQunt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textQunt.Size = new System.Drawing.Size(200, 20);
            this.textQunt.TabIndex = 3;
            this.textQunt.Text = "0";
            this.textQunt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textQunt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textQunt_KeyPress);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(791, 218);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePicker2.RightToLeftLayout = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1035, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "التاريخ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1035, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "الخامة";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1013, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "السعـــــــر";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(1016, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "العــــــــدد";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(999, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "تاريخ الصلاحية";
            // 
            // txtTotalMaterial
            // 
            this.txtTotalMaterial.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalMaterial.ForeColor = System.Drawing.Color.Teal;
            this.txtTotalMaterial.Location = new System.Drawing.Point(791, 290);
            this.txtTotalMaterial.Name = "txtTotalMaterial";
            this.txtTotalMaterial.ReadOnly = true;
            this.txtTotalMaterial.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalMaterial.Size = new System.Drawing.Size(200, 21);
            this.txtTotalMaterial.TabIndex = 560;
            this.txtTotalMaterial.Text = "0";
            this.txtTotalMaterial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(1022, 293);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 561;
            this.label6.Text = "الإجمالى";
            // 
            // butAddMaterial
            // 
            this.butAddMaterial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.butAddMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAddMaterial.ForeColor = System.Drawing.Color.White;
            this.butAddMaterial.Location = new System.Drawing.Point(790, 319);
            this.butAddMaterial.Name = "butAddMaterial";
            this.butAddMaterial.Size = new System.Drawing.Size(283, 23);
            this.butAddMaterial.TabIndex = 7;
            this.butAddMaterial.Text = "إضافة";
            this.butAddMaterial.UseVisualStyleBackColor = false;
            this.butAddMaterial.Click += new System.EventHandler(this.butAddMaterial_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.materialsNameDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.quntDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn,
            this.dateExpiryDataGridViewTextBoxColumn,
            this.noteDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.classMaterialsBillBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(24, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(724, 355);
            this.dataGridView1.TabIndex = 563;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "رقم";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Width = 50;
            // 
            // materialsNameDataGridViewTextBoxColumn
            // 
            this.materialsNameDataGridViewTextBoxColumn.DataPropertyName = "MaterialsName";
            this.materialsNameDataGridViewTextBoxColumn.HeaderText = "الخامة";
            this.materialsNameDataGridViewTextBoxColumn.Name = "materialsNameDataGridViewTextBoxColumn";
            this.materialsNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "السعر";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.Width = 60;
            // 
            // quntDataGridViewTextBoxColumn
            // 
            this.quntDataGridViewTextBoxColumn.DataPropertyName = "Qunt";
            this.quntDataGridViewTextBoxColumn.HeaderText = "العدد";
            this.quntDataGridViewTextBoxColumn.Name = "quntDataGridViewTextBoxColumn";
            this.quntDataGridViewTextBoxColumn.Width = 60;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "الاجمالى";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.Width = 80;
            // 
            // dateExpiryDataGridViewTextBoxColumn
            // 
            this.dateExpiryDataGridViewTextBoxColumn.DataPropertyName = "DateExpiry";
            this.dateExpiryDataGridViewTextBoxColumn.HeaderText = "الصلاحية";
            this.dateExpiryDataGridViewTextBoxColumn.Name = "dateExpiryDataGridViewTextBoxColumn";
            this.dateExpiryDataGridViewTextBoxColumn.Width = 80;
            // 
            // noteDataGridViewTextBoxColumn
            // 
            this.noteDataGridViewTextBoxColumn.DataPropertyName = "Note";
            this.noteDataGridViewTextBoxColumn.HeaderText = "ملاحظات";
            this.noteDataGridViewTextBoxColumn.Name = "noteDataGridViewTextBoxColumn";
            this.noteDataGridViewTextBoxColumn.Width = 120;
            // 
            // classMaterialsBillBindingSource
            // 
            this.classMaterialsBillBindingSource.DataSource = typeof(ZAD_Sales.Forms.MaterialsAdd.Class_MaterialsBill);
            // 
            // textTotalQuentety
            // 
            this.textTotalQuentety.Location = new System.Drawing.Point(792, 365);
            this.textTotalQuentety.Name = "textTotalQuentety";
            this.textTotalQuentety.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textTotalQuentety.Size = new System.Drawing.Size(200, 20);
            this.textTotalQuentety.TabIndex = 454545;
            this.textTotalQuentety.Text = "0";
            this.textTotalQuentety.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label7.Location = new System.Drawing.Point(1004, 368);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "الموجود بالمخزن";
            // 
            // textBarcode
            // 
            this.textBarcode.Location = new System.Drawing.Point(790, 73);
            this.textBarcode.Name = "textBarcode";
            this.textBarcode.ReadOnly = true;
            this.textBarcode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBarcode.Size = new System.Drawing.Size(201, 20);
            this.textBarcode.TabIndex = 7483;
            this.textBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.ForeColor = System.Drawing.Color.White;
            this.label29.Location = new System.Drawing.Point(1041, 77);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(29, 13);
            this.label29.TabIndex = 7482;
            this.label29.Text = "الكود";
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(23, 5);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.ReadOnly = true;
            this.textBoxID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxID.Size = new System.Drawing.Size(100, 20);
            this.textBoxID.TabIndex = 7484;
            this.textBoxID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textNumMaterial
            // 
            this.textNumMaterial.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNumMaterial.Location = new System.Drawing.Point(24, 398);
            this.textNumMaterial.Name = "textNumMaterial";
            this.textNumMaterial.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textNumMaterial.Size = new System.Drawing.Size(99, 21);
            this.textNumMaterial.TabIndex = 7488;
            this.textNumMaterial.Text = "0";
            this.textNumMaterial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Purple;
            this.textBox1.Location = new System.Drawing.Point(498, 393);
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox1.Size = new System.Drawing.Size(138, 21);
            this.textBox1.TabIndex = 7487;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.ForeColor = System.Drawing.Color.White;
            this.label69.Location = new System.Drawing.Point(135, 401);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(64, 13);
            this.label69.TabIndex = 7486;
            this.label69.Text = "عدد الأصناف";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.ForeColor = System.Drawing.Color.White;
            this.label70.Location = new System.Drawing.Point(671, 396);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(78, 13);
            this.label70.TabIndex = 7485;
            this.label70.Text = "اجمالى الخامات";
            // 
            // textNOTE
            // 
            this.textNOTE.Location = new System.Drawing.Point(791, 254);
            this.textNOTE.Name = "textNOTE";
            this.textNOTE.Size = new System.Drawing.Size(200, 20);
            this.textNOTE.TabIndex = 6;
            this.textNOTE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtReminngOLD
            // 
            this.txtReminngOLD.Location = new System.Drawing.Point(408, 4);
            this.txtReminngOLD.Name = "txtReminngOLD";
            this.txtReminngOLD.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtReminngOLD.Size = new System.Drawing.Size(100, 20);
            this.txtReminngOLD.TabIndex = 7484;
            this.txtReminngOLD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtReminngOLD.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(1022, 257);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "ملاحظات";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(152, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 7486;
            this.label9.Text = "رقم الصندوق";
            // 
            // butAll
            // 
            this.butAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(210)))), ((int)(((byte)(211)))));
            this.butAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAll.ForeColor = System.Drawing.Color.White;
            this.butAll.Location = new System.Drawing.Point(611, 5);
            this.butAll.Name = "butAll";
            this.butAll.Size = new System.Drawing.Size(138, 23);
            this.butAll.TabIndex = 454546;
            this.butAll.Text = "جميع الخامات";
            this.butAll.UseVisualStyleBackColor = false;
            this.butAll.Click += new System.EventHandler(this.butAll_Click);
            // 
            // MaterialsAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(163)))), ((int)(((byte)(164)))));
            this.ClientSize = new System.Drawing.Size(1109, 450);
            this.Controls.Add(this.butAll);
            this.Controls.Add(this.textNumMaterial);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label69);
            this.Controls.Add(this.label70);
            this.Controls.Add(this.textNOTE);
            this.Controls.Add(this.txtReminngOLD);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.textBarcode);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtTotalMaterial);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.butAddMaterial);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.textTotalQuentety);
            this.Controls.Add(this.textQunt);
            this.Controls.Add(this.textPrice);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.combMaterial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MaterialsAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اضافة خامات";
            this.Load += new System.EventHandler(this.MaterialsAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classMaterialsBillBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox combMaterial;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textPrice;
        private System.Windows.Forms.TextBox textQunt;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Windows.Forms.TextBox txtTotalMaterial;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button butAddMaterial;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textTotalQuentety;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBarcode;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textNumMaterial;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.TextBox textNOTE;
        private System.Windows.Forms.TextBox txtReminngOLD;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialsNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quntDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateExpiryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource classMaterialsBillBindingSource;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button butAll;
    }
}