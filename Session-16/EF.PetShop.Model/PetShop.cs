using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Session_11.EF.PetShopModel
{
    public class PetShop : IEntityBase
    {
       
        public int PetShopID { get; set; }
        public List<Pet> Pets { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Employee> Employees { get; set; }
        public List<PetFood> PetFoods { get; set; }
        public List<Transaction> Transactions { get; set; }
        public List<MonthlyLedger> MonthlyLedgers { get; set; }
        public Stock stock { get; set; }


        private void Initialize() {
            Stock stock = new Stock();
            Employee staffEmployee = CreateEmployee();
            Customer customer = CreateCustomer();
            Pet pet = CreatePet("Poodle");
            double petFoodQty = 12.5;
            double petFoodCost = 9.2;
            double petFoodPrice = petFoodQty * petFoodCost;
        }
        private Pet CreatePet(string breed) {

            Pet pet = new Pet() {
                PetID = 1,
                Breed = breed,
                AnimalType = Pet.AnimalTypeEnum.Dog,
                Status = Pet.PetStatusEnum.OK,
                Price = 200,
                Cost = 100
            };
            return pet;
        }
        private Customer CreateCustomer() {
            Customer customer = new Customer() {
                CustomerID = 1,
                Name = "John",
                Surname = "Doe",
                Phone = "1234567890",
                TIN = "987654321"
            };
            return customer;
        }
        private Employee CreateEmployee() {
            Employee employee = new Employee() {
                EmployeeID = 2,
                Name = "Jane",
                Surname = "Dewey",
                SalaryPerMonth = 619,
                EmployeeType = Employee.EmployeeTypeEnum.Staff
            };
            return employee;
        }
        private void AddTransaction(Employee employee, Customer customer, Pet pet, PetFood petFood, double petFoodQty, double profit) {
            List<Transaction> transactions = new List<Transaction>();
            Transaction transaction = CreateTransaction(employee, customer, pet, petFood, petFoodQty, profit);
            transactions.Add(transaction);
        }
        public Transaction CreateTransaction(Employee employee, Customer customer, Pet pet, PetFood petFood, double petFoodQty, double profit) {

            double petFoodPrice = petFood.PetFoodCost * petFoodQty + profit;

            Transaction transaction = new Transaction() { //customerID, employeeID, petID,  petPrice, petFoodID,  petFoodQty,  petFoodPrice,  totalPrice
                CustomerID = customer.CustomerID,
                EmployeeID = employee.EmployeeID,
                PetID = pet.PetID,
                PetPrice = pet.Price,
                PetFoodID = petFood.PetFoodID,
                PetFoodQty = petFoodQty,
                PetFoodPrice = petFoodPrice
            };
            return transaction;
        }
        public PetShop() {
            Pets = new List<Pet>();
            Customers = new List<Customer>();
            Employees = new List<Employee>();
            PetFoods = new List<PetFood>();
            Transactions = new List<Transaction>();
            MonthlyLedgers = new List<MonthlyLedger>();
            stock = new Stock();
        }
    }
}
