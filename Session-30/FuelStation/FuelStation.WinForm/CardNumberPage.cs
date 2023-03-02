using FuelStation.Blazor.Shared.Customer;
using Newtonsoft.Json;

namespace FuelStation.WinForm {
    public partial class CardNumberPage : Form {

        private readonly HttpClient httpClient;        
        IEnumerable<CustomerListDto> customers;
        public CardNumberPage() {
            InitializeComponent();
            httpClient = new HttpClient();
            ConUri uri = new();
            httpClient.BaseAddress = new Uri(uri.GetUri());
        }

        private async void CardNumberPage_Load(object sender, EventArgs e) {

        }

        private void btnBack_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }
        private async void btnEnter_Click(object sender, EventArgs e) {
            customers = await GetCustomers();
            bool doesntExist = true;
            foreach (var customer in customers) {
                if (customer.CardNumber == inputCardNumber.Text) {
                    this.Hide();
                    TransactionPage transactionPage = new();
                    transactionPage.ShowDialog();
                    this.Show();
                    doesntExist = false;
                    if (customer.CardNumber == inputCardNumber.Text)
                        break;
                }                
            }
            if (doesntExist) {
                this.Hide();
                CustomerPage customerPage = new();
                customerPage.ShowDialog();
                this.Show();
            }
        }
        private async Task<List<CustomerListDto?>> GetCustomers() {
            var response = await httpClient.GetAsync("customer");
            if (response.IsSuccessStatusCode) {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<CustomerListDto?>>(data);
            }
            else {
                return null;
            }
        }
    }
}
