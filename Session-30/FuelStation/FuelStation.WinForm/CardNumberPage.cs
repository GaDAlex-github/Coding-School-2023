using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuelStation.WinForm {
    public partial class CardNumberPage : Form {
        public CardNumberPage() {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }

        private void btnEnter_Click(object sender, EventArgs e) {
            this.Hide();
            TransactionPage transactionPage = new();
            transactionPage.ShowDialog();
            this.Show();
        }
    }
}
