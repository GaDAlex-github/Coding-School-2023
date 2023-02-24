using FuelStation.Blazor.Shared.Customer;
using FuelStation.Blazor.Shared.Employee;
using FuelStation.Blazor.Shared.Item;
using FuelStation.Blazor.Shared.Transaction;
using FuelStation.Blazor.Shared.TransactionLine;
using Newtonsoft.Json;
using System.Data;

namespace FuelStation.WinForm {
    public partial class TransactionPage : Form {

        private readonly HttpClient httpClient;
        public TransactionPage() {
            InitializeComponent();
            httpClient = new HttpClient();
            ConUri uri = new();
            httpClient.BaseAddress = new Uri(uri.GetUri());
        }

        private void TransactionPage_Load(object sender, EventArgs e) {
            _ = SetControllers();
        }
        public async Task SetControllers() {
            var transactions = await GetTransactions();
            var customers = await GetCustomers();
            var employees = await GetEmployees();
            if (transactions != null) {
                bsTransactions.DataSource = transactions;
                grvTransactions.AutoGenerateColumns = false;
                grvTransactions.DataSource = bsTransactions;

                DataGridViewComboBoxColumn clmCustomer = grvTransactions.Columns["clmCustomer"] as DataGridViewComboBoxColumn;
                clmCustomer.DataSource = customers;
                clmCustomer.DisplayMember = "FullName";
                clmCustomer.ValueMember = "CustomerId";
                DataGridViewComboBoxColumn clmEmployee = grvTransactions.Columns["clmEmployee"] as DataGridViewComboBoxColumn;
                clmEmployee.DataSource = employees;
                clmEmployee.DisplayMember = "FullName";
                clmEmployee.ValueMember = "EmployeeId";
            }
            var transactionLines = await GetTransactionLines();
            var items = await GetItems();
            if (transactionLines != null) {
                bsTransactionLines.DataSource = transactionLines;
                grvTransactionLines.AutoGenerateColumns = false;
                grvTransactionLines.DataSource = bsTransactionLines;

                DataGridViewComboBoxColumn clmItem = grvTransactionLines.Columns["clmItem"] as DataGridViewComboBoxColumn;
                clmItem.DataSource = items;
                clmItem.DisplayMember = "FullName";
                clmItem.ValueMember = "EmployeeId";
            }
        }

        private void btnCreate_Click(object sender, EventArgs e) {
            TransactionListDto newTransaction = new TransactionListDto();
            bsTransactions.Add(newTransaction);
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            TransactionListDto transaction = (TransactionListDto)grvTransactions.CurrentRow.DataBoundItem;
            DeleteTransaction(transaction.Id);
            _ = SetControllers();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            TransactionListDto transaction = (TransactionListDto)grvTransactions.CurrentRow.DataBoundItem;
            if (transaction.Id == 0) {
                _ = NewTransaction(transaction);
            }
            else {
                _ = EditTransaction(transaction);
            }
            _ = SetControllers();
        }

        private void btnTLCreate_Click(object sender, EventArgs e) {
            TransactionLineListDto newTransactionLine = new TransactionLineListDto();
            bsTransactionLines.Add(newTransactionLine);
        }

        private void btnTLDelete_Click(object sender, EventArgs e) {
            TransactionLineListDto transactionLine = (TransactionLineListDto)grvTransactionLines.CurrentRow.DataBoundItem;
            DeleteTransactionLine(transactionLine.Id);
            _ = SetControllers();
        }

        private void btnTLSave_Click(object sender, EventArgs e) {
            TransactionLineListDto transactionLine = (TransactionLineListDto)grvTransactionLines.CurrentRow.DataBoundItem;
            if (transactionLine.Id == 0) {
                _ = NewTransactionLine(transactionLine);
            }
            else {
                _ = EditTransactionLine(transactionLine);
            }
            _ = SetControllers();
        }
        private void btnBack_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }

        private async Task<List<TransactionListDto?>> GetTransactions() {
            var response = await httpClient.GetAsync("transaction");
            if (response.IsSuccessStatusCode) {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<TransactionListDto?>>(data);
            }
            else {
                return null;
            }
        }
        private async Task NewTransaction(TransactionListDto? transaction) {
            var response = await httpClient.PostAsJsonAsync("transaction", transaction);
            if (response.IsSuccessStatusCode) {
                MessageBox.Show("Transaction Created!", "Success Message");
            }
            else {
                MessageBox.Show("Error! Try again.", "Alert Message");
                _ = SetControllers();
            }
        }
        private async Task EditTransaction(TransactionListDto? transaction) {

            var response = await httpClient.PutAsJsonAsync("transaction", transaction);

            if (response.IsSuccessStatusCode) {
                MessageBox.Show("Transaction Edited!", "Success Message");
            }
            else {
                MessageBox.Show("Error! Try again.", "Alert Message");
                _ = SetControllers();
            }
        }

        private async Task DeleteTransaction(int id) {
            var response = await httpClient.DeleteAsync($"transaction/{id}");
            if (response.IsSuccessStatusCode) {
                MessageBox.Show("Transaction Deleted!", "Success Message");
            }
            else {
                MessageBox.Show("Error! Try again.", "Alert Message");
                _ = SetControllers();
            }
        }

        private async Task<List<TransactionLineListDto?>> GetTransactionLines() {
            var response = await httpClient.GetAsync("transactionLine");
            if (response.IsSuccessStatusCode) {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<TransactionLineListDto?>>(data);
            }
            else {
                return null;
            }
        }
        private async Task NewTransactionLine(TransactionLineListDto? transactionLine) {
            var response = await httpClient.PostAsJsonAsync("transactionLine", transactionLine);
            if (response.IsSuccessStatusCode) {
                MessageBox.Show("TransactionLine Created!", "Success Message");
            }
            else {
                MessageBox.Show("Error! Try again.", "Alert Message");
                _ = SetControllers();
            }
        }
        private async Task EditTransactionLine(TransactionLineListDto? transactionLine) {

            var response = await httpClient.PutAsJsonAsync("transactionLine", transactionLine);

            if (response.IsSuccessStatusCode) {
                MessageBox.Show("TransactionLine Edited!", "Success Message");
            }
            else {
                MessageBox.Show("Error! Try again.", "Alert Message");
                _ = SetControllers();
            }
        }

        private async Task DeleteTransactionLine(int id) {
            var response = await httpClient.DeleteAsync($"transactionLine/{id}");
            if (response.IsSuccessStatusCode) {
                MessageBox.Show("TransactionLine Deleted!", "Success Message");
            }
            else {
                MessageBox.Show("Error! Try again.", "Alert Message");
                _ = SetControllers();
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

        private async Task<List<EmployeeListDto?>> GetEmployees() {
            var response = await httpClient.GetAsync("employee");
            if (response.IsSuccessStatusCode) {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<EmployeeListDto?>>(data);
            }
            else {
                return null;
            }
        }
        private async Task<List<ItemListDto?>> GetItems() {
            var response = await httpClient.GetAsync("item");
            if (response.IsSuccessStatusCode) {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ItemListDto?>>(data);
            }
            else {
                return null;
            }
        }
    }
}
