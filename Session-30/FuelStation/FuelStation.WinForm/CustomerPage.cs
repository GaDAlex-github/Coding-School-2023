using FuelStation.Blazor.Client.Pages.Customer;
using FuelStation.Blazor.Shared.Customer;
using FuelStation.Blazor.Server.Controllers;
using FuelStation.EF.Repositories;
using FuelStation.Model;
using System.Net.Http;
using System.Net.Http.Headers;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Azure;
using Microsoft.JSInterop;

namespace FuelStation.WinForm {
    public partial class CustomerPage : Form {

        private List<CustomerListDto> customerList = new();
        //private CustomerListDto customer;

        public CustomerPage() {
            InitializeComponent();

        }

        private async void CustomerPage_Load(object sender, EventArgs e) {

            await LoadItemsFromServer();
            SetControllers();

        }

        public void SetControllers() {           
            grvCustomers.AutoGenerateColumns = false;
            grvCustomers.DataSource = bsCustomers;
        }

        private void btnCreate_Click(object sender, EventArgs e) {
            CustomerListDto newCustomer = new CustomerListDto();
            bsCustomers.Add(newCustomer);            
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            
        }

        private async void btnSave_Click(object sender, EventArgs e) {
            //var customer = bsCustomers.Current;
            //await DeleteItem(customer);

        }
        private void btnBack_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }      

        private async Task LoadItemsFromServer() {
            using (HttpClient client = new HttpClient()) {
                var response = await client.GetAsync("https://localhost:7157/customer");
                var data = await response.Content.ReadAsAsync<IEnumerable<CustomerListDto>>();
                grvCustomers.DataSource = data;
                bsCustomers.DataSource = data;
            }
        }
        private async Task DeleteItem(CustomerListDto customer) {
            using (HttpClient client = new HttpClient()) {
                DialogResult dialogResult = MessageBox.Show("Sure", "Are you sure you want to delete that Customer?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) {
                    bsCustomers.RemoveCurrent();
                    var response = await client.DeleteAsync($"customer/{customer.Id}");
                    response.EnsureSuccessStatusCode();
                    await LoadItemsFromServer();
                }
            }
        }
    }
}



