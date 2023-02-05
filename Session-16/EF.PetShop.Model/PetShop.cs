using EF.PetShop.Model;
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
    public class PetShop : EntityBase
    {
        // Relations
        public List<Pet> Pets { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Employee> Employees { get; set; }
        public List<PetFood> PetFoods { get; set; }
        public List<Transaction> Transactions { get; set; }
        
               
       
        private void AddTransaction(Employee employee, Customer customer, Pet pet, PetFood petFood, double petFoodQty, double profit) {
            List<Transaction> transactions = new List<Transaction>();
            Transaction transaction = CreateTransaction(employee, customer, pet, petFood, petFoodQty, profit);
            transactions.Add(transaction);
        }
        public Transaction CreateTransaction(Employee employee, Customer customer, Pet pet, PetFood petFood, double petFoodQty, double profit) {

            double petFoodPrice = petFood.PetFoodCost * petFoodQty + profit;

            Transaction transaction = new Transaction() { //customerID, employeeID, petID,  petPrice, petFoodID,  petFoodQty,  petFoodPrice,  totalPrice
                CustomerID = customer.ID,
                EmployeeID = employee.ID,
                PetID = pet.ID,
                PetPrice = pet.Price,
                PetFoodID = petFood.ID,
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
          }
    }
}
