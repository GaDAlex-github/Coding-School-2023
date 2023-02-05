using DevExpress.XtraGrid.Columns;
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


            List<Customer> customers = new List<Customer>();

            petShop = new PetShop();
            _petShopRepo = new PetShopRepo();
            _customerRepo = new CustomerRepo();
            _employeeRepo = new EmployeeRepo();
            _petRepo = new PetRepo();
            _petFoodRepo = new PetFoodRepo();
            _transactionRepo = new TransactionRepo();

            PopulateEmployee();
            PopulateCustomers();
            PopulatePets();
            PopulatePetFoods();
            SetBindings();
            SetControls();

            //PopulateLastChanges();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }


        public void PopulatePets() {

            var pets = new List<Pet>
            {
                new Pet {ID=1,AnimalType = Pet.AnimalTypeEnum.Dog,Status=Pet.PetStatusEnum.OK ,Price = 100, Cost = 70,Breed="French Bulldog"},
                new Pet {ID=2,AnimalType = Pet.AnimalTypeEnum.Dog,Status=Pet.PetStatusEnum.Recovering ,Price =80, Cost = 30,Breed="Akita"},
                new Pet {ID=3,AnimalType = Pet.AnimalTypeEnum.Dog,Status=Pet.PetStatusEnum.Unhealthy ,Price =0, Cost = 20,Breed="Beagle"},
                new Pet {ID=4,AnimalType = Pet.AnimalTypeEnum.Cat,Status=Pet.PetStatusEnum.OK, Price = 100, Cost = 80,Breed="Persian"},
                new Pet {ID=5,AnimalType = Pet.AnimalTypeEnum.Cat,Status=Pet.PetStatusEnum.Recovering, Price = 80, Cost = 60,Breed="Maine Coon"},
                new Pet {ID=6,AnimalType = Pet.AnimalTypeEnum.Cat,Status=Pet.PetStatusEnum.Unhealthy, Price = 0, Cost = 20,Breed="Ragdoll"},
                new Pet {ID=7,AnimalType = Pet.AnimalTypeEnum.Bird,Status=Pet.PetStatusEnum.OK, Price = 80, Cost = 50,Breed="Canary"},
                new Pet {ID=8,AnimalType = Pet.AnimalTypeEnum.Bird,Status=Pet.PetStatusEnum.Recovering, Price = 60, Cost = 40,Breed="Amazon Parrot"},
                new Pet {ID=9,AnimalType = Pet.AnimalTypeEnum.Bird,Status=Pet.PetStatusEnum.Unhealthy, Price = 30, Cost = 15,Breed="African Grey Parrot"}
            };
            petShop.Pets.AddRange(pets);
        }

        public void PopulatePetFoods() {
            var petsFood = new List<PetFood>
            {
                new PetFood {ID=1,AnimalType = PetFood.AnimalTypeEnum.Dog,PetFoodPrice = 9, PetFoodCost = 3},
                new PetFood {ID=2,AnimalType = PetFood.AnimalTypeEnum.Cat,PetFoodPrice = 6, PetFoodCost = 2},
                new PetFood {ID=3,AnimalType = PetFood.AnimalTypeEnum.Bird,PetFoodPrice = 3, PetFoodCost = 1},

            };
            petShop.PetFoods.AddRange(petsFood);
        }
        public void PopulateCustomers() {

            Customer Cust1 = new Customer() {

                Name = "Nikos",
                Surname = "Karamitos",
                Phone = "6978319532",
                TIN = "37482910",

            };
            Customer cust2 = new Customer() {

                Name = "Alex",
                Surname = "Gad",
                Phone = "6973132822",
                TIN = "38239102"
            };


            petShop.Customers.Add(Cust1);
            petShop.Customers.Add(cust2);

        }

        private void PopulateEmployee() {

            Employee employee1 = new Employee() {
                ID = 1,
                Name = "Fotis",
                Surname = "Chrysoulas",
                EmployeeType = Employee.EmployeeTypeEnum.Manager,
                SalaryPerMonth = 1000

            };

            Employee employee2 = new Employee() {
                ID = 2,
                Name = "Alex",
                Surname = "Gad",
                EmployeeType = Employee.EmployeeTypeEnum.Staff,
                SalaryPerMonth = 1000

            };
            petShop.Employees.Add(employee1);
            petShop.Employees.Add(employee2);
            bsEmployee.DataSource = petShop.Employees;

        }

        public void SetControls() {

            GridColumn colCustomer = grvTransactions.Columns["colCustomerName"] as GridColumn;
            //grvTransactions.CustomColumnDisplayText += GrvTransactions_CustomColumnDisplayText;
            // colCustomer.DataSource = petShop.Customers;
            //colCustomer.DisplayMember = "FullName";
            // colCustomer.ValueMember = "CustomerID";
            GridColumn colEmployee = grvTransactions.Columns["colEmployeeName"] as GridColumn;

            // colEmployee.DataSource = petShop.Employees;
            //  colEmployee.DisplayMember = "FullName";
            // colEmployee.ValueMember = "EmployeeID";
            GridColumn colAnimalType = grvTransactions.Columns["colPetID"] as GridColumn;
            //  colAnimalType.DataSource = petShop.Pets;
            // colAnimalType.DisplayMember = "AnimalBreed";
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
        
        private void button1_Click(object sender, EventArgs e) {
            Transaction tras = new Transaction();
            bsTransaction.Add(tras);
        }

        private void btnRemoveTrans_Click(object sender, EventArgs e) {
            bsTransaction.RemoveCurrent();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e) {
            Employee newEmployee = new Employee();
            bsEmployee.Add(newEmployee);
        }

        private void btnRemoveEmployee_Click(object sender, EventArgs e) {
            bsEmployee.RemoveCurrent();
        }
               
        private void btnAddPet_Click(object sender, EventArgs e) {
            Pet pet = new Pet();
            bsPet.Add(pet);
        }

        private void button2_Click(object sender, EventArgs e) {
            PetFood petFood = new PetFood();
            bsPetFood.Add(petFood);

        }       

        private void btnAddCustomer_Click(object sender, EventArgs e) {
            Customer newCust = new Customer();
            bsCustomer.Add(newCust);
        }

        private void btnLoad_Click_1(object sender, EventArgs e) {
            //Serializer serializer = new Serializer();
            //petShop = serializer.Deserialize<PetShop>("PetShop.json");
            SetBindings();
            grcCustomers.DataSource = _customerRepo.GetAll();
            grcEmployees.DataSource = _employeeRepo.GetAll();
            grcPets.DataSource = _petRepo.GetAll();
            grcPetFoods.DataSource = _petFoodRepo.GetAll();
            grcTransactions.DataSource = _transactionRepo.GetAll();

            MessageBox.Show("Data Load Correctly!");
        }

        private void btnSave_Click_1(object sender, EventArgs e) {
            Serializer serializer = new Serializer();
            serializer.SerializeToFile(petShop, "PetShop.json");
            _petShopRepo.Add(petShop);
        }
    }
}
