namespace ZAD_Sales.Forms
{
    partial class PriceViewer
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
            this.txtBarcodeScanner = new System.Windows.Forms.TextBox();
            this.txtBarcodeManual = new System.Windows.Forms.TextBox();
            this.btnSearchScanner = new System.Windows.Forms.Button();
            this.btnSearchManual = new System.Windows.Forms.Button();
            this.btnSearchName = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radBut2 = new System.Windows.Forms.RadioButton();
            this.radBut3 = new System.Windows.Forms.RadioButton();
            this.radBut1 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ComCategoryName = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtQut = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBarcod = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtlItemName = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBarcodeScanner
            // 
            this.txtBarcodeScanner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarcodeScanner.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcodeScanner.Location = new System.Drawing.Point(109, 110);
            this.txtBarcodeScanner.Name = "txtBarcodeScanner";
            this.txtBarcodeScanner.Size = new System.Drawing.Size(457, 39);
            this.txtBarcodeScanner.TabIndex = 1;
            this.txtBarcodeScanner.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBarcodeScanner.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcodeScanner_KeyDown);
            // 
            // txtBarcodeManual
            // 
            this.txtBarcodeManual.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarcodeManual.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcodeManual.Location = new System.Drawing.Point(109, 110);
            this.txtBarcodeManual.Name = "txtBarcodeManual";
            this.txtBarcodeManual.Size = new System.Drawing.Size(457, 39);
            this.txtBarcodeManual.TabIndex = 42454754;
            this.txtBarcodeManual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBarcodeManual.Visible = false;
            // 
            // btnSearchScanner
            // 
            this.btnSearchScanner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearchScanner.BackColor = System.Drawing.Color.Green;
            this.btnSearchScanner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchScanner.ForeColor = System.Drawing.Color.White;
            this.btnSearchScanner.Location = new System.Drawing.Point(48, 110);
            this.btnSearchScanner.Name = "btnSearchScanner";
            this.btnSearchScanner.Size = new System.Drawing.Size(55, 38);
            this.btnSearchScanner.TabIndex = 3;
            this.btnSearchScanner.Text = "بحث";
            this.btnSearchScanner.UseVisualStyleBackColor = false;
            this.btnSearchScanner.Visible = false;
            this.btnSearchScanner.Click += new System.EventHandler(this.btnSearchScanner_Click);
            // 
            // btnSearchManual
            // 
            this.btnSearchManual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearchManual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSearchManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchManual.ForeColor = System.Drawing.Color.White;
            this.btnSearchManual.Location = new System.Drawing.Point(48, 110);
            this.btnSearchManual.Name = "btnSearchManual";
            this.btnSearchManual.Size = new System.Drawing.Size(55, 38);
            this.btnSearchManual.TabIndex = 3;
            this.btnSearchManual.Text = "بحث";
            this.btnSearchManual.UseVisualStyleBackColor = false;
            this.btnSearchManual.Visible = false;
            this.btnSearchManual.Click += new System.EventHandler(this.btnSearchManual_Click);
            // 
            // btnSearchName
            // 
            this.btnSearchName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearchName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSearchName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchName.ForeColor = System.Drawing.Color.White;
            this.btnSearchName.Location = new System.Drawing.Point(48, 110);
            this.btnSearchName.Name = "btnSearchName";
            this.btnSearchName.Size = new System.Drawing.Size(55, 39);
            this.btnSearchName.TabIndex = 3;
            this.btnSearchName.Text = "بحث";
            this.btnSearchName.UseVisualStyleBackColor = false;
            this.btnSearchName.Visible = false;
            this.btnSearchName.Click += new System.EventHandler(this.btnSearchName_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkCyan;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(77, 614);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "مسح";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.radBut2);
            this.panel1.Controls.Add(this.radBut3);
            this.panel1.Controls.Add(this.radBut1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ComCategoryName);
            this.panel1.Controls.Add(this.txtBarcodeScanner);
            this.panel1.Controls.Add(this.txtBarcodeManual);
            this.panel1.Controls.Add(this.btnSearchName);
            this.panel1.Controls.Add(this.btnSearchScanner);
            this.panel1.Controls.Add(this.btnSearchManual);
            this.panel1.Location = new System.Drawing.Point(77, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(720, 202);
            this.panel1.TabIndex = 0;
            // 
            // radBut2
            // 
            this.radBut2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radBut2.AutoSize = true;
            this.radBut2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radBut2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.radBut2.Location = new System.Drawing.Point(262, 43);
            this.radBut2.Name = "radBut2";
            this.radBut2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radBut2.Size = new System.Drawing.Size(135, 23);
            this.radBut2.TabIndex = 42454760;
            this.radBut2.Text = "البحث بكتابة الباركود";
            this.radBut2.UseVisualStyleBackColor = true;
            this.radBut2.CheckedChanged += new System.EventHandler(this.radBut2_CheckedChanged);
            // 
            // radBut3
            // 
            this.radBut3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radBut3.AutoSize = true;
            this.radBut3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radBut3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.radBut3.Location = new System.Drawing.Point(109, 43);
            this.radBut3.Name = "radBut3";
            this.radBut3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radBut3.Size = new System.Drawing.Size(121, 23);
            this.radBut3.TabIndex = 42454759;
            this.radBut3.Text = "البحث باسم المنتج";
            this.radBut3.UseVisualStyleBackColor = true;
            this.radBut3.CheckedChanged += new System.EventHandler(this.radBut3_CheckedChanged);
            // 
            // radBut1
            // 
            this.radBut1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radBut1.AutoSize = true;
            this.radBut1.Checked = true;
            this.radBut1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radBut1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.radBut1.Location = new System.Drawing.Point(429, 43);
            this.radBut1.Name = "radBut1";
            this.radBut1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radBut1.Size = new System.Drawing.Size(136, 23);
            this.radBut1.TabIndex = 42454758;
            this.radBut1.TabStop = true;
            this.radBut1.Text = "البحث بقارئ الباركود";
            this.radBut1.UseVisualStyleBackColor = true;
            this.radBut1.CheckedChanged += new System.EventHandler(this.radBut1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(602, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 19);
            this.label3.TabIndex = 42454757;
            this.label3.Text = "المنتج";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(592, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 19);
            this.label2.TabIndex = 42454756;
            this.label2.Text = "الباركود";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(592, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 19);
            this.label1.TabIndex = 42454755;
            this.label1.Text = "الباركود";
            // 
            // ComCategoryName
            // 
            this.ComCategoryName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComCategoryName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ComCategoryName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ComCategoryName.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComCategoryName.FormattingEnabled = true;
            this.ComCategoryName.Location = new System.Drawing.Point(108, 110);
            this.ComCategoryName.Name = "ComCategoryName";
            this.ComCategoryName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ComCategoryName.Size = new System.Drawing.Size(457, 39);
            this.ComCategoryName.TabIndex = 852475;
            this.ComCategoryName.Visible = false;
            this.ComCategoryName.SelectedIndexChanged += new System.EventHandler(this.ComCategoryName_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtQut);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtBarcod);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtPrice);
            this.panel2.Controls.Add(this.txtlItemName);
            this.panel2.Location = new System.Drawing.Point(77, 232);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(720, 376);
            this.panel2.TabIndex = 86586;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(597, 318);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 19);
            this.label7.TabIndex = 42454761;
            this.label7.Text = "الكمية";
            // 
            // txtQut
            // 
            this.txtQut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQut.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtQut.Location = new System.Drawing.Point(108, 307);
            this.txtQut.Name = "txtQut";
            this.txtQut.Size = new System.Drawing.Size(457, 39);
            this.txtQut.TabIndex = 42454760;
            this.txtQut.Text = "0";
            this.txtQut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(588, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 19);
            this.label6.TabIndex = 42454759;
            this.label6.Text = "الباركود";
            // 
            // txtBarcod
            // 
            this.txtBarcod.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarcod.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcod.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.txtBarcod.Location = new System.Drawing.Point(109, 24);
            this.txtBarcod.Name = "txtBarcod";
            this.txtBarcod.Size = new System.Drawing.Size(457, 39);
            this.txtBarcod.TabIndex = 42454758;
            this.txtBarcod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(598, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 19);
            this.label5.TabIndex = 42454757;
            this.label5.Text = "السعر";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(597, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 19);
            this.label4.TabIndex = 42454757;
            this.label4.Text = "المنتج";
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtPrice.Location = new System.Drawing.Point(109, 157);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrice.Size = new System.Drawing.Size(457, 63);
            this.txtPrice.TabIndex = 745454;
            this.txtPrice.Text = "0";
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtlItemName
            // 
            this.txtlItemName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtlItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlItemName.ForeColor = System.Drawing.Color.Red;
            this.txtlItemName.Location = new System.Drawing.Point(109, 91);
            this.txtlItemName.Name = "txtlItemName";
            this.txtlItemName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtlItemName.Size = new System.Drawing.Size(457, 38);
            this.txtlItemName.TabIndex = 234555;
            this.txtlItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PriceViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(182)))));
            this.ClientSize = new System.Drawing.Size(869, 645);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PriceViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "عرض السعر";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PriceViewer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtBarcodeScanner;
        private System.Windows.Forms.TextBox txtBarcodeManual;
        private System.Windows.Forms.Button btnSearchScanner;
        private System.Windows.Forms.Button btnSearchManual;
        private System.Windows.Forms.Button btnSearchName;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox ComCategoryName;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtlItemName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radBut2;
        private System.Windows.Forms.RadioButton radBut3;
        private System.Windows.Forms.RadioButton radBut1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBarcod;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtQut;
    }
}