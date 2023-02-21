using FuelStation.Blazor.Shared.Customer;
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

        IEnumerable<CustomerListDto> customers;
        public CardNumberPage() {
            InitializeComponent();
        }

        private async void CardNumberPage_Load(object sender, EventArgs e) {

        }

        private void btnBack_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }

        private async void btnEnter_Click(object sender, EventArgs e) {
            customers = await LoadItemsFromServer();
            foreach (var customer in customers) {
                if (customer.CardNumber == inputCardNumber.Text) {
                    this.Hide();
                    TransactionPage transactionPage = new();
                    transactionPage.ShowDialog();
                    this.Show();
                }
            }
            this.Hide();
            CustomerPage customerPage = new();
            customerPage.ShowDialog();
            this.Show();
        }
        private async Task<IEnumerable<CustomerListDto>> LoadItemsFromServer() {
            using (HttpClient client = new HttpClient()) {
                var response = await client.GetAsync("https://localhost:7157/customer");
                var customers = await response.Content.ReadAsAsync<IEnumerable<CustomerListDto>>();
                return customers;
            }
        }


    }
}
