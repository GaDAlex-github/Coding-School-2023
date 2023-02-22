namespace FuelStation.WinForm {
    partial class TransactionPage {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.grvTransactions = new System.Windows.Forms.DataGridView();
            this.clmDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPaymentMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grvTransactionLines = new System.Windows.Forms.DataGridView();
            this.clmItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmItemPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNetValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDiscountPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDiscountValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTransaction = new System.Windows.Forms.Label();
            this.lblTransactionLine = new System.Windows.Forms.Label();
            this.btnTLSave = new System.Windows.Forms.Button();
            this.btnTLDelete = new System.Windows.Forms.Button();
            this.btnTLCreate = new System.Windows.Forms.Button();
            this.bsTransactions = new System.Windows.Forms.BindingSource(this.components);
            this.bsTransactionLines = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grvTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTransactionLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransactionLines)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(536, 396);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(86, 42);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.Location = new System.Drawing.Point(536, 129);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 42);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDelete.Location = new System.Drawing.Point(536, 81);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(86, 42);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCreate.Location = new System.Drawing.Point(536, 33);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(86, 42);
            this.btnCreate.TabIndex = 11;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // grvTransactions
            // 
            this.grvTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmDate,
            this.clmEmployeeId,
            this.clmCustomerId,
            this.clmPaymentMethod,
            this.clmTotalValue});
            this.grvTransactions.Location = new System.Drawing.Point(22, 33);
            this.grvTransactions.Name = "grvTransactions";
            this.grvTransactions.RowTemplate.Height = 25;
            this.grvTransactions.Size = new System.Drawing.Size(493, 151);
            this.grvTransactions.TabIndex = 10;
            // 
            // clmDate
            // 
            this.clmDate.HeaderText = "Date";
            this.clmDate.Name = "clmDate";
            this.clmDate.ReadOnly = true;
            this.clmDate.Width = 70;
            // 
            // clmEmployeeId
            // 
            this.clmEmployeeId.HeaderText = "Employee";
            this.clmEmployeeId.Name = "clmEmployeeId";
            // 
            // clmCustomerId
            // 
            this.clmCustomerId.HeaderText = "Customer";
            this.clmCustomerId.Name = "clmCustomerId";
            this.clmCustomerId.ReadOnly = true;
            // 
            // clmPaymentMethod
            // 
            this.clmPaymentMethod.HeaderText = "PaymentMethod";
            this.clmPaymentMethod.Name = "clmPaymentMethod";
            // 
            // clmTotalValue
            // 
            this.clmTotalValue.HeaderText = "TotalValue";
            this.clmTotalValue.Name = "clmTotalValue";
            this.clmTotalValue.Width = 80;
            // 
            // grvTransactionLines
            // 
            this.grvTransactionLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grvTransactionLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvTransactionLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmItemId,
            this.clmQuantity,
            this.clmItemPrice,
            this.clmNetValue,
            this.clmDiscountPercent,
            this.clmDiscountValue,
            this.dataGridViewTextBoxColumn5});
            this.grvTransactionLines.Location = new System.Drawing.Point(22, 230);
            this.grvTransactionLines.Name = "grvTransactionLines";
            this.grvTransactionLines.RowTemplate.Height = 25;
            this.grvTransactionLines.Size = new System.Drawing.Size(493, 208);
            this.grvTransactionLines.TabIndex = 15;
            // 
            // clmItemId
            // 
            this.clmItemId.HeaderText = "Item";
            this.clmItemId.Name = "clmItemId";
            this.clmItemId.ReadOnly = true;
            this.clmItemId.Width = 80;
            // 
            // clmQuantity
            // 
            this.clmQuantity.HeaderText = "Quantity";
            this.clmQuantity.Name = "clmQuantity";
            this.clmQuantity.Width = 60;
            // 
            // clmItemPrice
            // 
            this.clmItemPrice.HeaderText = "ItemPrice";
            this.clmItemPrice.Name = "clmItemPrice";
            this.clmItemPrice.ReadOnly = true;
            this.clmItemPrice.Width = 60;
            // 
            // clmNetValue
            // 
            this.clmNetValue.HeaderText = "NetValue";
            this.clmNetValue.Name = "clmNetValue";
            this.clmNetValue.Width = 60;
            // 
            // clmDiscountPercent
            // 
            this.clmDiscountPercent.HeaderText = "Discount%";
            this.clmDiscountPercent.Name = "clmDiscountPercent";
            this.clmDiscountPercent.Width = 70;
            // 
            // clmDiscountValue
            // 
            this.clmDiscountValue.HeaderText = "Discount";
            this.clmDiscountValue.Name = "clmDiscountValue";
            this.clmDiscountValue.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Total";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 60;
            // 
            // lblTransaction
            // 
            this.lblTransaction.AutoSize = true;
            this.lblTransaction.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTransaction.Location = new System.Drawing.Point(22, 9);
            this.lblTransaction.Name = "lblTransaction";
            this.lblTransaction.Size = new System.Drawing.Size(89, 21);
            this.lblTransaction.TabIndex = 16;
            this.lblTransaction.Text = "Transaction";
            // 
            // lblTransactionLine
            // 
            this.lblTransactionLine.AutoSize = true;
            this.lblTransactionLine.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTransactionLine.Location = new System.Drawing.Point(22, 206);
            this.lblTransactionLine.Name = "lblTransactionLine";
            this.lblTransactionLine.Size = new System.Drawing.Size(129, 21);
            this.lblTransactionLine.TabIndex = 17;
            this.lblTransactionLine.Text = "Transaction Lines";
            // 
            // btnTLSave
            // 
            this.btnTLSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnTLSave.Location = new System.Drawing.Point(536, 326);
            this.btnTLSave.Name = "btnTLSave";
            this.btnTLSave.Size = new System.Drawing.Size(86, 42);
            this.btnTLSave.TabIndex = 20;
            this.btnTLSave.Text = "Save";
            this.btnTLSave.UseVisualStyleBackColor = true;
            this.btnTLSave.Click += new System.EventHandler(this.btnTLSave_Click);
            // 
            // btnTLDelete
            // 
            this.btnTLDelete.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnTLDelete.Location = new System.Drawing.Point(536, 278);
            this.btnTLDelete.Name = "btnTLDelete";
            this.btnTLDelete.Size = new System.Drawing.Size(86, 42);
            this.btnTLDelete.TabIndex = 19;
            this.btnTLDelete.Text = "Delete";
            this.btnTLDelete.UseVisualStyleBackColor = true;
            this.btnTLDelete.Click += new System.EventHandler(this.btnTLDelete_Click);
            // 
            // btnTLCreate
            // 
            this.btnTLCreate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnTLCreate.Location = new System.Drawing.Point(536, 230);
            this.btnTLCreate.Name = "btnTLCreate";
            this.btnTLCreate.Size = new System.Drawing.Size(86, 42);
            this.btnTLCreate.TabIndex = 18;
            this.btnTLCreate.Text = "Create";
            this.btnTLCreate.UseVisualStyleBackColor = true;
            this.btnTLCreate.Click += new System.EventHandler(this.btnTLCreate_Click);
            // 
            // TransactionPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 451);
            this.Controls.Add(this.btnTLSave);
            this.Controls.Add(this.btnTLDelete);
            this.Controls.Add(this.btnTLCreate);
            this.Controls.Add(this.lblTransactionLine);
            this.Controls.Add(this.lblTransaction);
            this.Controls.Add(this.grvTransactionLines);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.grvTransactions);
            this.MaximumSize = new System.Drawing.Size(660, 490);
            this.MinimumSize = new System.Drawing.Size(660, 490);
            this.Name = "TransactionPage";
            this.Text = "TransactionPage";
            this.Load += new System.EventHandler(this.TransactionPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTransactionLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransactionLines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnBack;
        private Button btnSave;
        private Button btnDelete;
        private Button btnCreate;
        private DataGridView grvTransactions;
        private DataGridViewTextBoxColumn clmDate;
        private DataGridViewTextBoxColumn clmEmployeeId;
        private DataGridViewTextBoxColumn clmCustomerId;
        private DataGridViewTextBoxColumn clmPaymentMethod;
        private DataGridViewTextBoxColumn clmTotalValue;
        private DataGridView grvTransactionLines;
        private Label lblTransaction;
        private Label lblTransactionLine;
        private DataGridViewTextBoxColumn clmItemId;
        private DataGridViewTextBoxColumn clmQuantity;
        private DataGridViewTextBoxColumn clmItemPrice;
        private DataGridViewTextBoxColumn clmNetValue;
        private DataGridViewTextBoxColumn clmDiscountPercent;
        private DataGridViewTextBoxColumn clmDiscountValue;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private Button btnTLSave;
        private Button btnTLDelete;
        private Button btnTLCreate;
        private BindingSource bsTransactions;
        private BindingSource bsTransactionLines;
    }
}