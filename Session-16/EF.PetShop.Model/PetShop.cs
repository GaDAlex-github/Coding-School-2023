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

        //Relations
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public Pet Pet { get; set; }
        public PetFood PetFood { get; set; }
        public Transaction Transaction { get; set; }


                
       
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
