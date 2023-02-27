namespace FuelStation.WinForm {
    public partial class FuelStation : Form {
        public FuelStation() {
            InitializeComponent();
        }

        private void btnManager_Click(object sender, EventArgs e) {
            this.Hide();
            ManagerPage managerPage = new();
            managerPage.ShowDialog();
            this.Show();
        }
        private void btnStaff_Click(object sender, EventArgs e) {
            this.Hide();
            ItemPage itemPage = new();
            itemPage.ShowDialog();
            this.Show();
        }
        private void btnCashier_Click(object sender, EventArgs e) {
            this.Hide();
            CashierPage cashierPage = new();
            cashierPage.ShowDialog();
            this.Show();
        }
    }
}