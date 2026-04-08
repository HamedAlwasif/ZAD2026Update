namespace ZAD_Sales.Forms
{
    partial class FrmBillingSummary
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
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvBillingSummary = new System.Windows.Forms.DataGridView();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.txtTopCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.txtDiscountBuy = new System.Windows.Forms.TextBox();
            this.txtBuyInvalid = new System.Windows.Forms.TextBox();
            this.txtDiscountSales = new System.Windows.Forms.TextBox();
            this.txtSalesInvalid = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotalBuy = new System.Windows.Forms.TextBox();
            this.txtTotalRemaining = new System.Windows.Forms.TextBox();
            this.txtTotalPay = new System.Windows.Forms.TextBox();
            this.txtTotalPaid = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotalSales = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.butPrint = new System.Windows.Forms.Button();
            this.cmbOrderBy = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillingSummary)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(1441, 12);
            this.dtpDateFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpDateFrom.RightToLeftLayout = true;
            this.dtpDateFrom.Size = new System.Drawing.Size(145, 22);
            this.dtpDateFrom.TabIndex = 0;
            this.dtpDateFrom.ValueChanged += new System.EventHandler(this.dtpDateFrom_ValueChanged);
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTo.Location = new System.Drawing.Point(1166, 12);
            this.dtpDateTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpDateTo.RightToLeftLayout = true;
            this.dtpDateTo.Size = new System.Drawing.Size(145, 22);
            this.dtpDateTo.TabIndex = 0;
            this.dtpDateTo.ValueChanged += new System.EventHandler(this.dtpDateTo_ValueChanged);
            // 
            // lblFromDate
            // 
            this.lblFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(76)))), ((int)(((byte)(119)))));
            this.lblFromDate.Location = new System.Drawing.Point(1595, 15);
            this.lblFromDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(48, 17);
            this.lblFromDate.TabIndex = 1;
            this.lblFromDate.Text = "من تاريخ";
            this.lblFromDate.Click += new System.EventHandler(this.lblFromDate_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(76)))), ((int)(((byte)(119)))));
            this.label2.Location = new System.Drawing.Point(1333, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "إلى تاريخ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(76)))), ((int)(((byte)(119)))));
            this.btnSearch.Location = new System.Drawing.Point(453, 9);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 28);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "بحث";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvBillingSummary
            // 
            this.dgvBillingSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBillingSummary.BackgroundColor = System.Drawing.Color.White;
            this.dgvBillingSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillingSummary.Location = new System.Drawing.Point(32, 75);
            this.dgvBillingSummary.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvBillingSummary.Name = "dgvBillingSummary";
            this.dgvBillingSummary.RowHeadersWidth = 51;
            this.dgvBillingSummary.Size = new System.Drawing.Size(1687, 658);
            this.dgvBillingSummary.TabIndex = 3;
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(76)))), ((int)(((byte)(119)))));
            this.lblGrandTotal.Location = new System.Drawing.Point(1189, 12);
            this.lblGrandTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(87, 17);
            this.lblGrandTotal.TabIndex = 1;
            this.lblGrandTotal.Text = "إجمالي المشتريات";
            // 
            // txtTopCount
            // 
            this.txtTopCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTopCount.Location = new System.Drawing.Point(810, 12);
            this.txtTopCount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTopCount.Name = "txtTopCount";
            this.txtTopCount.Size = new System.Drawing.Size(135, 22);
            this.txtTopCount.TabIndex = 5;
            this.txtTopCount.TextChanged += new System.EventHandler(this.txtTopCount_TextChanged);
            this.txtTopCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTopCount_KeyDown);
            this.txtTopCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTopCount_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(76)))), ((int)(((byte)(119)))));
            this.label1.Location = new System.Drawing.Point(982, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "عرض اعلى عدد عملاء";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFooter.BackColor = System.Drawing.Color.LightBlue;
            this.pnlFooter.Controls.Add(this.txtDiscountBuy);
            this.pnlFooter.Controls.Add(this.txtBuyInvalid);
            this.pnlFooter.Controls.Add(this.txtDiscountSales);
            this.pnlFooter.Controls.Add(this.txtSalesInvalid);
            this.pnlFooter.Controls.Add(this.label8);
            this.pnlFooter.Controls.Add(this.txtTotalBuy);
            this.pnlFooter.Controls.Add(this.txtTotalRemaining);
            this.pnlFooter.Controls.Add(this.txtTotalPay);
            this.pnlFooter.Controls.Add(this.txtTotalPaid);
            this.pnlFooter.Controls.Add(this.label9);
            this.pnlFooter.Controls.Add(this.txtTotalSales);
            this.pnlFooter.Controls.Add(this.label10);
            this.pnlFooter.Controls.Add(this.label5);
            this.pnlFooter.Controls.Add(this.label4);
            this.pnlFooter.Controls.Add(this.label3);
            this.pnlFooter.Controls.Add(this.label7);
            this.pnlFooter.Controls.Add(this.label6);
            this.pnlFooter.Controls.Add(this.lblGrandTotal);
            this.pnlFooter.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlFooter.Location = new System.Drawing.Point(32, 743);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1687, 85);
            this.pnlFooter.TabIndex = 6;
            this.pnlFooter.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFooter_Paint);
            // 
            // txtDiscountBuy
            // 
            this.txtDiscountBuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiscountBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountBuy.Location = new System.Drawing.Point(982, 37);
            this.txtDiscountBuy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDiscountBuy.Name = "txtDiscountBuy";
            this.txtDiscountBuy.ReadOnly = true;
            this.txtDiscountBuy.Size = new System.Drawing.Size(145, 23);
            this.txtDiscountBuy.TabIndex = 4;
            this.txtDiscountBuy.Text = "0";
            this.txtDiscountBuy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBuyInvalid
            // 
            this.txtBuyInvalid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuyInvalid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuyInvalid.Location = new System.Drawing.Point(638, 37);
            this.txtBuyInvalid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBuyInvalid.Name = "txtBuyInvalid";
            this.txtBuyInvalid.ReadOnly = true;
            this.txtBuyInvalid.Size = new System.Drawing.Size(145, 23);
            this.txtBuyInvalid.TabIndex = 4;
            this.txtBuyInvalid.Text = "0";
            this.txtBuyInvalid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDiscountSales
            // 
            this.txtDiscountSales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiscountSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountSales.Location = new System.Drawing.Point(1326, 37);
            this.txtDiscountSales.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDiscountSales.Name = "txtDiscountSales";
            this.txtDiscountSales.ReadOnly = true;
            this.txtDiscountSales.Size = new System.Drawing.Size(145, 23);
            this.txtDiscountSales.TabIndex = 4;
            this.txtDiscountSales.Text = "0";
            this.txtDiscountSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSalesInvalid
            // 
            this.txtSalesInvalid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSalesInvalid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesInvalid.Location = new System.Drawing.Point(810, 37);
            this.txtSalesInvalid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSalesInvalid.Name = "txtSalesInvalid";
            this.txtSalesInvalid.ReadOnly = true;
            this.txtSalesInvalid.Size = new System.Drawing.Size(145, 23);
            this.txtSalesInvalid.TabIndex = 4;
            this.txtSalesInvalid.Text = "0";
            this.txtSalesInvalid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(76)))), ((int)(((byte)(119)))));
            this.label8.Location = new System.Drawing.Point(1019, 12);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "خصم المشتريات";
            // 
            // txtTotalBuy
            // 
            this.txtTotalBuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalBuy.Location = new System.Drawing.Point(1154, 37);
            this.txtTotalBuy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTotalBuy.Name = "txtTotalBuy";
            this.txtTotalBuy.ReadOnly = true;
            this.txtTotalBuy.Size = new System.Drawing.Size(145, 23);
            this.txtTotalBuy.TabIndex = 4;
            this.txtTotalBuy.Text = "0";
            this.txtTotalBuy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalRemaining
            // 
            this.txtTotalRemaining.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalRemaining.Location = new System.Drawing.Point(122, 37);
            this.txtTotalRemaining.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTotalRemaining.Name = "txtTotalRemaining";
            this.txtTotalRemaining.ReadOnly = true;
            this.txtTotalRemaining.Size = new System.Drawing.Size(145, 23);
            this.txtTotalRemaining.TabIndex = 4;
            this.txtTotalRemaining.Text = "0";
            this.txtTotalRemaining.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalPay
            // 
            this.txtTotalPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPay.Location = new System.Drawing.Point(466, 37);
            this.txtTotalPay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTotalPay.Name = "txtTotalPay";
            this.txtTotalPay.ReadOnly = true;
            this.txtTotalPay.Size = new System.Drawing.Size(145, 23);
            this.txtTotalPay.TabIndex = 4;
            this.txtTotalPay.Text = "0";
            this.txtTotalPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalPaid
            // 
            this.txtTotalPaid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPaid.Location = new System.Drawing.Point(294, 37);
            this.txtTotalPaid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTotalPaid.Name = "txtTotalPaid";
            this.txtTotalPaid.ReadOnly = true;
            this.txtTotalPaid.Size = new System.Drawing.Size(145, 23);
            this.txtTotalPaid.TabIndex = 4;
            this.txtTotalPaid.Text = "0";
            this.txtTotalPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(76)))), ((int)(((byte)(119)))));
            this.label9.Location = new System.Drawing.Point(1374, 12);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "خصم المبيعات";
            // 
            // txtTotalSales
            // 
            this.txtTotalSales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalSales.Location = new System.Drawing.Point(1498, 37);
            this.txtTotalSales.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTotalSales.Name = "txtTotalSales";
            this.txtTotalSales.ReadOnly = true;
            this.txtTotalSales.Size = new System.Drawing.Size(145, 23);
            this.txtTotalSales.TabIndex = 4;
            this.txtTotalSales.Text = "0";
            this.txtTotalSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(76)))), ((int)(((byte)(119)))));
            this.label10.Location = new System.Drawing.Point(493, 12);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "اجمالى الدفع";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(76)))), ((int)(((byte)(119)))));
            this.label5.Location = new System.Drawing.Point(150, 12);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "اجمالى المتبقى";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(76)))), ((int)(((byte)(119)))));
            this.label4.Location = new System.Drawing.Point(319, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "اجمالى التحصيل";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(76)))), ((int)(((byte)(119)))));
            this.label3.Location = new System.Drawing.Point(1533, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "اجمالى المبيعات";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(76)))), ((int)(((byte)(119)))));
            this.label7.Location = new System.Drawing.Point(649, 12);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "مردودات المشتريات";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(76)))), ((int)(((byte)(119)))));
            this.label6.Location = new System.Drawing.Point(839, 12);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "مردودات المبيعات";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.LightBlue;
            this.panel2.Controls.Add(this.butPrint);
            this.panel2.Controls.Add(this.cmbOrderBy);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.dtpDateFrom);
            this.panel2.Controls.Add(this.txtTopCount);
            this.panel2.Controls.Add(this.dtpDateTo);
            this.panel2.Controls.Add(this.lblFromDate);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Location = new System.Drawing.Point(32, 16);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1687, 52);
            this.panel2.TabIndex = 7;
            // 
            // butPrint
            // 
            this.butPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(172)))), ((int)(((byte)(132)))));
            this.butPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butPrint.ForeColor = System.Drawing.Color.White;
            this.butPrint.Location = new System.Drawing.Point(22, 11);
            this.butPrint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.butPrint.Name = "butPrint";
            this.butPrint.Size = new System.Drawing.Size(96, 28);
            this.butPrint.TabIndex = 5481;
            this.butPrint.Text = "طباعة";
            this.butPrint.UseVisualStyleBackColor = false;
            this.butPrint.Click += new System.EventHandler(this.butPrint_Click);
            // 
            // cmbOrderBy
            // 
            this.cmbOrderBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbOrderBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrderBy.FormattingEnabled = true;
            this.cmbOrderBy.Location = new System.Drawing.Point(562, 11);
            this.cmbOrderBy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbOrderBy.Name = "cmbOrderBy";
            this.cmbOrderBy.Size = new System.Drawing.Size(221, 24);
            this.cmbOrderBy.TabIndex = 6;
            this.cmbOrderBy.SelectedIndexChanged += new System.EventHandler(this.cmbOrderBy_SelectedIndexChanged);
            // 
            // FrmBillingSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(76)))), ((int)(((byte)(119)))));
            this.ClientSize = new System.Drawing.Size(1762, 841);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.dgvBillingSummary);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmBillingSummary";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تقرير إجمالي المبيعات حسب العملاء";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmBillingSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillingSummary)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvBillingSummary;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.TextBox txtTopCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtTotalRemaining;
        private System.Windows.Forms.TextBox txtTotalPaid;
        private System.Windows.Forms.TextBox txtTotalSales;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiscountSales;
        private System.Windows.Forms.TextBox txtDiscountBuy;
        private System.Windows.Forms.TextBox txtBuyInvalid;
        private System.Windows.Forms.TextBox txtSalesInvalid;
        private System.Windows.Forms.TextBox txtTotalBuy;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTotalPay;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbOrderBy;
        private System.Windows.Forms.Button butPrint;
    }
}