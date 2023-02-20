namespace FuelStation.WinForm {
    partial class FuelStation {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.ChooseRole = new System.Windows.Forms.Label();
            this.btnManager = new System.Windows.Forms.Button();
            this.btnStaff = new System.Windows.Forms.Button();
            this.btnCashier = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChooseRole
            // 
            this.ChooseRole.AutoSize = true;
            this.ChooseRole.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChooseRole.Location = new System.Drawing.Point(251, 116);
            this.ChooseRole.Name = "ChooseRole";
            this.ChooseRole.Size = new System.Drawing.Size(136, 21);
            this.ChooseRole.TabIndex = 0;
            this.ChooseRole.Text = "Choose your Role:";
            // 
            // btnManager
            // 
            this.btnManager.Location = new System.Drawing.Point(99, 165);
            this.btnManager.Name = "btnManager";
            this.btnManager.Size = new System.Drawing.Size(114, 41);
            this.btnManager.TabIndex = 1;
            this.btnManager.Text = "Manager";
            this.btnManager.UseVisualStyleBackColor = true;
            this.btnManager.Click += new System.EventHandler(this.btnManager_Click);
            // 
            // btnStaff
            // 
            this.btnStaff.Location = new System.Drawing.Point(264, 165);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Size = new System.Drawing.Size(114, 41);
            this.btnStaff.TabIndex = 2;
            this.btnStaff.Text = "Staff";
            this.btnStaff.UseVisualStyleBackColor = true;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // btnCashier
            // 
            this.btnCashier.Location = new System.Drawing.Point(434, 165);
            this.btnCashier.Name = "btnCashier";
            this.btnCashier.Size = new System.Drawing.Size(114, 41);
            this.btnCashier.TabIndex = 3;
            this.btnCashier.Text = "Cashier";
            this.btnCashier.UseVisualStyleBackColor = true;
            this.btnCashier.Click += new System.EventHandler(this.btnCashier_Click);
            // 
            // FuelStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 451);
            this.Controls.Add(this.btnCashier);
            this.Controls.Add(this.btnStaff);
            this.Controls.Add(this.btnManager);
            this.Controls.Add(this.ChooseRole);
            this.Name = "FuelStation";
            this.Text = "FuelStation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label ChooseRole;
        private Button btnManager;
        private Button btnStaff;
        private Button btnCashier;
    }
}