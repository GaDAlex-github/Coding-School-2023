using FuelStation.Blazor.Client.Pages.Customer;
using FuelStation.Blazor.Shared.Customer;
using FuelStation.EF.Repositories;
using FuelStation.Model;
using System.Net.Http;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Json;
using Azure;

namespace FuelStation.WinForm {
    public partial class CustomerPage : Form {

        private readonly IEntityRepo<Customer> _customerRepo;
        private List<CustomerListDto> customerList = new();


        public CustomerPage() {
            InitializeComponent();

        }

        private async void CustomerPage_Load(object sender, EventArgs e) {

            await LoadItemsFromServer();
            SetControllers();

        }

        public void SetControllers() {
            //var customerList = _customerRepo.GetAll();
            //customerRepoBs.DataSource = customerList;
            //grvCustomers.DataSource = customerRepoBs;
        }

        private void btnCreate_Click(object sender, EventArgs e) {
            Customer newCustomer = new Customer();
            bsCustomers.Add(newCustomer);
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            bsCustomers.RemoveCurrent();
        }

        private void btnSave_Click(object sender, EventArgs e) {

        }
        private void btnBack_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
        }
        //private static HttpClient sharedClient = new() {
        //    BaseAddress = new Uri("https://localhost:7157/customerlist")           
        //};
        private async Task LoadItemsFromServer() {
            //HttpClient httpClient = new HttpClient();
            //using HttpResponseMessage response = await httpClient.GetAsync("customer");
            // customerList = await client.GetFromJsonAsync<List<CustomerListDto>>("customer"); 
            //response.EnsureSuccessStatusCode();

            //var jsonResponse = await response.Content.ReadAsStringAsync();

        }
    }
}



