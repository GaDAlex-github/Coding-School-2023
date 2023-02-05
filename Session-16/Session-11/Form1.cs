using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using EF.PetShop.Orm.Repositories;
using Session_11.EF.PetShopModel;
using Session_11.EF.PetShopOrm.Repositories;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace Session_11 {
    public partial class Form1 : Form {


        public Transaction transaction;
        public PetShop petShop;
        public Customer customer;
        public MonthlyLedgerReport monthlyLedgerReport;

        private PetShopRepo _petShopRepo;
        private CustomerRepo _customerRepo;
        private EmployeeRepo _employeeRepo;
        private PetRepo _petRepo;
        private PetFoodRepo _petFoodRepo;
        private TransactionRepo _transactionRepo;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

            _petShopRepo = new PetShopRepo();
            petShop = _petShopRepo.GetById(1);
            _customerRepo = new CustomerRepo();
            _employeeRepo = new EmployeeRepo();
            _petRepo = new PetRepo();
            _petFoodRepo = new PetFoodRepo();
            _transactionRepo = new TransactionRepo();
            SetBindings();
            SetControls();
            //List<Transaction> transactions = petShop.Transactions;
            //monthlyLedgerReport.CreateMonthlyLedgerReport(transactions);
        }

        public TransactionSummary newTransaction(Employee employee, Pet pet, PetFood petFood, Customer customer) {
            Transaction transaction = new Transaction();
            transaction.ID = 1;
            transaction.EmployeeID = employee.ID;
            transaction.CustomerID = customer.ID;
            transaction.PetPrice = pet.Price;
            transaction.PetFoodPrice = petFood.PetFoodPrice;
            transaction.PetID = pet.ID;
            transaction.TransactionDate = DateTime.Now;
            transaction.PetFoodID = petFood.ID;

            petShop.Transactions.Add(transaction);

            TransactionSummary summary = new TransactionSummary();
            summary.TransactionID = transaction.ID;
            summary.EmployeeID = transaction.EmployeeID;
            summary.EmployeeName = employee.Name;
            summary.CustomerID = transaction.CustomerID;
            summary.CustomerName = customer.Name;
            summary.PetPrice = transaction.PetPrice;
            summary.PetFoodPrice = transaction.PetFoodPrice;
            summary.PetID = transaction.PetID;
            summary.TransactionDateTime = transaction.TransactionDate;
            summary.PetFoodID = transaction.PetFoodID;

            return summary;
        }
        public void SetControls() {

            //GridColumn colCustomer = grvTransactions.Columns["colCustomerName"] as GridColumn;            
            //GridColumn colEmployee = grvTransactions.Columns["colEmployeeName"] as GridColumn;
            //GridColumn colAnimalType = grvTransactions.Columns["colPetID"] as GridColumn;
            
        }

        //private void GrvTransactions_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e) {
        //    GridColumn col = e.Column;
        //    if (e.Column.FieldName == "CustomerID") {
        //        var x = bsCustomer.DataSource as List<Customer>;
        //        var z = x.Where(y => y.CustomerID == (e.Value) as Guid);
        //        //    e.DisplayText = 
        //    }
        //}

        public void SetBindings() {
            bsCustomer.DataSource = petShop.Customers;
            bsPet.DataSource = petShop.Pets;
            bsPetFood.DataSource = petShop.PetFoods;
            bsEmployee.DataSource = petShop.Employees;
            bsTransaction.DataSource = petShop.Transactions;
            //   monthlyLedgerBindingSource.DataSource = petShop.MonthlyLedgers;
        }


        private void btnLoad_Click_1(object sender, EventArgs e) {
            //Serializer serializer = new Serializer();
            //petShop = serializer.Deserialize<PetShop>("PetShop.json");
            //SetBindings();
            //grcCustomers.DataSource = _customerRepo.GetAll();
            //grcEmployees.DataSource = _employeeRepo.GetAll();
            //grcPets.DataSource = _petRepo.GetAll();
            //grcPetFoods.DataSource = _petFoodRepo.GetAll();
            //grcTransactions.DataSource = _transactionRepo.GetAll();

            MessageBox.Show("Data Load Correctly!");
        }

        private void btnSave_Click_1(object sender, EventArgs e) {
            //Serializer serializer = new Serializer();
            //serializer.SerializeToFile(petShop, "PetShop.json");
            if (petShop == null)
                _petShopRepo.Add(petShop);
            else
                _petShopRepo.Update(1, petShop);
        }
    }
}
