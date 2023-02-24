using FuelStation.Blazor.Shared.Customer;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace FuelStation.WinForm {
    public partial class CustomerPage : Form {

        private readonly HttpClient httpClient;
        private List<CustomerListDto> customerList = new();

        public CustomerPage() {
            InitializeComponent();
            httpClient = new HttpClient();
            ConUri uri = new();
            httpClient.BaseAddress = new Uri(uri.GetUri());
        }

        private void CustomerPage_Load(object sender, EventArgs e) {            
            _ = SetControllers();
        }

        public async Task SetControllers() {
            var Customers = await GetCustomers();
            if (Customers != null) {
                bsCustomers.DataSource = Customers;
                grvCustomers.AutoGenerateColumns = false;
                grvCustomers.DataSource = bsCustomers;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e) {
            CustomerListDto newCustomer = new CustomerListDto();
            bsCustomers.Add(newCustomer);
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            CustomerListDto customer = (CustomerListDto)grvCustomers.CurrentRow.DataBoundItem;
            DeleteCustomer(customer.Id);
        }

        private void btnSave_Click(object sender, EventArgs e) {
            CustomerListDto customer = (CustomerListDto)grvCustomers.CurrentRow.DataBoundItem;
            if (customer.Id == 0) {
                _ = NewCustomer(customer);
            }
            else {
                _ = EditCustomer(customer);
            }            
        }

        private void btnBack_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
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
        private async Task NewCustomer(CustomerListDto? customer) {
            var response = await httpClient.PostAsJsonAsync("customer", customer);
            if (response.IsSuccessStatusCode) {
                MessageBox.Show("Customer Created!", "Success Message");
                _ = SetControllers();
            }
            else {
                MessageBox.Show("Error! Try again.", "Alert Message");
                _ = SetControllers();
            }
        }
        private async Task EditCustomer(CustomerListDto? customer) {

            var response = await httpClient.PutAsJsonAsync("customer", customer);

            if (response.IsSuccessStatusCode) {
                MessageBox.Show("Customer Edited!", "Success Message");
                _ = SetControllers();
            }
            else {
                MessageBox.Show("Error! Try again.", "Alert Message");
                _ = SetControllers();
            }
        }

        private async Task DeleteCustomer(int id) {
            var response = await httpClient.DeleteAsync($"customer/{id}");
            if (response.IsSuccessStatusCode) {
                MessageBox.Show("Customer Deleted!", "Success Message");
                _ = SetControllers();
            }
            else {
                MessageBox.Show("Error! Try again.", "Alert Message");
                _ = SetControllers();
            }
        }
    }
}



