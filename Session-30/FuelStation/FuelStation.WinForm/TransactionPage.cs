﻿using FuelStation.Blazor.Shared.Customer;
using FuelStation.Blazor.Shared.Employee;
using FuelStation.Blazor.Shared.Item;
using FuelStation.Blazor.Shared.Transaction;
using FuelStation.Blazor.Shared.TransactionLine;
using FuelStation.Model;
using FuelStation.Model.Enums;
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
            grvTransactionLines.CellValueChanged += GrvTransactionLines_CellValueChanged;
        }

        private async void GrvTransactionLines_CellValueChanged(object? sender, DataGridViewCellEventArgs e) {
            TransactionLineListDto transactionLine = (TransactionLineListDto)grvTransactionLines.CurrentRow.DataBoundItem;
            var x = bsTransactionLines.Current;
            TransactionListDto transaction = (TransactionListDto)grvTransactions.CurrentRow.DataBoundItem;
            bool updateTransactionTotalValue = false;
            if (e.ColumnIndex == 1) { //column Quantity
                CalculateAllValues(transactionLine);
                updateTransactionTotalValue = true;
            }
            if (e.ColumnIndex == 0) { //column Item
                //if (FuelExists(grvTransactionLines.DataSource as List<TransactionLineListDto>))
                //    return;
                var items = await GetItems();
                var it = items.Where(item => item.Id == transactionLine.ItemId).FirstOrDefault();
                transactionLine.Item = it;
                transactionLine.ItemPrice = it.Price;
                transactionLine.Quantity = 1;
                transactionLine.NetValue = 0;
                transactionLine.DiscountPercent = 0;
                transactionLine.DiscountValue = 0;
                transactionLine.TotalValue = transactionLine.ItemPrice;
                CalculateAllValues(transactionLine);
                updateTransactionTotalValue = true;
                grvTransactionLines.Update();
                grvTransactionLines.Refresh();
            }
            if (updateTransactionTotalValue) {
                transaction.TotalValue = grvTransactionLines.Rows
                    .OfType<DataGridViewRow>()
                    .Select(row => Convert.ToDecimal(row.Cells[6].Value)).ToList().Sum();
                if (transaction.TotalValue > 50) {
                    transaction.PaymentMethod = PaymentMethod.Cash;
                    clmPaymentMethod.ReadOnly = true;
                }
                else
                    clmPaymentMethod.ReadOnly = false;
                grvTransactions.Update();
                grvTransactions.Refresh();
            }
        }

        public async Task SetControllers() {
            var transactions = await GetTransactions();
            var customers = await GetCustomers();
            var employees = await GetEmployees();
            try {
                if (transactions != null) {

                    bsTransactions.DataSource = transactions;
                    grvTransactions.AutoGenerateColumns = false;
                    grvTransactions.DataSource = bsTransactions;

                    clmCustomer.DataSource = new BindingSource() { DataSource = customers };
                    clmCustomer.DataPropertyName = "CustomerId";
                    clmCustomer.DisplayMember = "FullName";
                    clmCustomer.ValueMember = "Id";

                    clmEmployee.DataSource = new BindingSource() { DataSource = employees };
                    clmEmployee.DataPropertyName = "EmployeeId";
                    clmEmployee.DisplayMember = "FullName";
                    clmEmployee.ValueMember = "Id";

                    clmPaymentMethod.DataPropertyName = "PaymentMethod";
                    clmPaymentMethod.DataSource = Enum.GetValues(typeof(PaymentMethod));
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private void grvTransactions_CellClick(object sender, DataGridViewCellEventArgs e) {
            LoadTransactionLines();
        }

        private async void LoadTransactionLines() {
            TransactionListDto transaction = (TransactionListDto)grvTransactions.CurrentRow.DataBoundItem;
            var transactionLines = await GetTransactionLines(transaction.Id);
            if (transactionLines == null)
                return;
            var items = await GetItems();
            if (transactionLines != null) {
                bsTransactionLines.DataSource = transactionLines;
                grvTransactionLines.AutoGenerateColumns = false;
                grvTransactionLines.DataSource = bsTransactionLines;

                clmItem.DataSource = new BindingSource() { DataSource = items };
                clmItem.DataPropertyName = "ItemId";
                clmItem.DisplayMember = "Description";
                clmItem.ValueMember = "Id";

                clmItemPrice.DataPropertyName = "ItemPrice";
            }
        }

        private void btnCreate_Click(object sender, EventArgs e) {
            TransactionListDto newTransaction = new TransactionListDto();
            bsTransactions.Add(newTransaction);
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            if (ConfirmDelete()) {
                TransactionListDto transaction = (TransactionListDto)grvTransactions.CurrentRow.DataBoundItem;
                DeleteTransaction(transaction.Id);
                grvTransactions.Update();
                grvTransactions.Refresh();
            }
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
            if (ConfirmDeleteTL()) {
                TransactionLineListDto transactionLine = (TransactionLineListDto)grvTransactionLines.CurrentRow.DataBoundItem;
                DeleteTransactionLine(transactionLine.Id);
                _ = SetControllers();
            }
        }

        private void btnTLSave_Click(object sender, EventArgs e) {
            try {
                TransactionLineListDto transactionLine = (TransactionLineListDto)grvTransactionLines.CurrentRow.DataBoundItem;
                if (transactionLine.Id == 0) {
                    _ = NewTransactionLine(transactionLine);
                }
                else {
                    _ = EditTransactionLine(transactionLine);
                }
                _ = SetControllers();
            }
            catch (Exception exe) {
                MessageBox.Show(exe.Message);
            }
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
                _ = SetControllers();
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
                _ = SetControllers();
            }
            else {
                MessageBox.Show("Error! Try again.", "Alert Message");
                _ = SetControllers();
            }
        }
        private bool ConfirmDelete() {
            var result = MessageBox.Show(this, "Procceed Deleting Selected Transaction?",
                this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return result == DialogResult.Yes;
        }

        private async Task DeleteTransaction(int id) {
            var response = await httpClient.DeleteAsync($"transaction/{id}");
            if (response.IsSuccessStatusCode) {
                MessageBox.Show("Transaction Deleted!", "Success Message");
                _ = SetControllers();
            }
            else {
                MessageBox.Show("Error! Try again.", "Alert Message");
                _ = SetControllers();
            }
        }

        private async Task<List<TransactionLineListDto?>> GetTransactionLines(int id) {
            var response = await httpClient.GetAsync($"transactionLine/{id}");
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
                _ = SetControllers();
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
                _ = SetControllers();
            }
            else {
                MessageBox.Show("Error! Try again.", "Alert Message");
                _ = SetControllers();
            }
        }
        private bool ConfirmDeleteTL() {
            var result = MessageBox.Show(this, "Procceed Deleting Selected TransactionLine?",
                this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return result == DialogResult.Yes;
        }

        private async Task DeleteTransactionLine(int id) {
            var response = await httpClient.DeleteAsync($"transactionLine/{id}");
            if (response.IsSuccessStatusCode) {
                MessageBox.Show("TransactionLine Deleted!", "Success Message");
                _ = SetControllers();
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

        public void CalculateAllValues(TransactionLineListDto transactionLine) {

            transactionLine.NetValue = transactionLine.Quantity * transactionLine.ItemPrice;
            if (transactionLine.Item.ItemType == ItemType.Fuel && transactionLine.NetValue > 20) {
                transactionLine.DiscountPercent = 10;
                transactionLine.DiscountValue = Decimal.Round(transactionLine.NetValue * (decimal)0.1, 2);
            }
            transactionLine.TotalValue = transactionLine.NetValue - transactionLine.DiscountValue;
        }

        public bool FuelExists(List<TransactionLineListDto> transactionLines) {
            if (transactionLines.Where(line => line.Item.ItemType == ItemType.Fuel).Count() > 1) {
                MessageBox.Show("Error! Cant Add More Fuel-Type");
                return true;
               // _ = SetControllers();
            }
            return false;
        }

        private void grvTransactions_DataError(object sender, DataGridViewDataErrorEventArgs e) {
            e.Cancel = false;
        }

        private void grvTransactionLines_DataError(object sender, DataGridViewDataErrorEventArgs e) {
            e.Cancel = false;
        }
    }
}
