namespace FuelStation.WinForm {
    partial class ItemPage {
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
            this.grvItems = new System.Windows.Forms.DataGridView();
            this.bsItems = new System.Windows.Forms.BindingSource(this.components);
            this.clmCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmItemType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clmPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItems)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(537, 381);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(86, 42);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.Location = new System.Drawing.Point(537, 166);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 42);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDelete.Location = new System.Drawing.Point(537, 118);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(86, 42);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCreate.Location = new System.Drawing.Point(537, 70);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(86, 42);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // grvItems
            // 
            this.grvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCode,
            this.clmDescription,
            this.ClmItemType,
            this.clmPrice,
            this.clmCost,
            this.clmId});
            this.grvItems.Location = new System.Drawing.Point(24, 24);
            this.grvItems.Name = "grvItems";
            this.grvItems.RowTemplate.Height = 25;
            this.grvItems.Size = new System.Drawing.Size(493, 400);
            this.grvItems.TabIndex = 5;
            // 
            // clmCode
            // 
            this.clmCode.DataPropertyName = "Code";
            this.clmCode.HeaderText = "Code";
            this.clmCode.Name = "clmCode";
            this.clmCode.ReadOnly = true;
            this.clmCode.Width = 60;
            // 
            // clmDescription
            // 
            this.clmDescription.DataPropertyName = "Description";
            this.clmDescription.HeaderText = "Description";
            this.clmDescription.Name = "clmDescription";
            this.clmDescription.Width = 200;
            // 
            // ClmItemType
            // 
            this.ClmItemType.DataPropertyName = "ItemType";
            this.ClmItemType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.ClmItemType.HeaderText = "ItemType";
            this.ClmItemType.Name = "ClmItemType";
            this.ClmItemType.ReadOnly = true;
            this.ClmItemType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ClmItemType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ClmItemType.Width = 90;
            // 
            // clmPrice
            // 
            this.clmPrice.DataPropertyName = "Price";
            this.clmPrice.HeaderText = "Price";
            this.clmPrice.Name = "clmPrice";
            this.clmPrice.Width = 50;
            // 
            // clmCost
            // 
            this.clmCost.DataPropertyName = "Cost";
            this.clmCost.HeaderText = "Cost";
            this.clmCost.Name = "clmCost";
            this.clmCost.Width = 50;
            // 
            // clmId
            // 
            this.clmId.DataPropertyName = "Id";
            this.clmId.HeaderText = "Id";
            this.clmId.Name = "clmId";
            this.clmId.Visible = false;
            // 
            // ItemPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 451);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.grvItems);
            this.Name = "ItemPage";
            this.Text = "ItemPage";
            this.Load += new System.EventHandler(this.ItemPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnBack;
        private Button btnSave;
        private Button btnDelete;
        private Button btnCreate;
        private DataGridView grvItems;
        private BindingSource bsItems;
        private DataGridViewTextBoxColumn clmCode;
        private DataGridViewTextBoxColumn clmDescription;
        private DataGridViewComboBoxColumn ClmItemType;
        private DataGridViewTextBoxColumn clmPrice;
        private DataGridViewTextBoxColumn clmCost;
        private DataGridViewTextBoxColumn clmId;
    }
}