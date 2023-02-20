using FuelStation.Blazor.Client.Pages.Customer;
using FuelStation.Blazor.Shared.Customer;
using FuelStation.EF.Repositories;
using FuelStation.Model;
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

namespace FuelStation.WinForm {
    public partial class CustomerPage : Form {

        private readonly IEntityRepo<Customer> _customerRepo;
        private List<CustomerListDto> customerList = new();
       

        public CustomerPage() {
            InitializeComponent();
            //LoadItemsFromServer();
        }

        private void CustomerPage_Load(object sender, EventArgs e) {

            //customerList = await HttpClient.GetFromJsonAsync<List<CustomerListDto>>("customer");
            //List<Customer> customers = new List<Customer>();
            SetControllers();
        }
        //private async Task LoadItemsFromServer() {
        //    customerList = await httpClient.GetFromJsonAsync<List<CustomerListDto>>("customer");
        //}

        public void SetControllers() {
        //var customerList = _customerRepo.GetAll();
        //customerRepoBs.DataSource = customerList;
        //grvCustomers.DataSource = customerRepoBs;
    }
        //public async Task<IEnumerable<CustomerListDto>> Get() {
        //    var customerList = _customerRepo.GetAll();
        //    return customerList.Select(customer => new CustomerListDto {
        //        Id = customer.Id,
        //        Name = customer.Name,
        //        Surname = customer.Surname,
        //        CardNumber = customer.CardNumber
        //    });
        //}

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
}
}
