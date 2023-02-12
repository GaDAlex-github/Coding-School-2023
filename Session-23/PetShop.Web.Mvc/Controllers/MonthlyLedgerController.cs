using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.EF.Repositories;
using PetShop.Model;
using PetShop.Web.Mvc.Models.MonthlyLedger;
using System.Linq;

namespace PetShop.Web.Mvc.Controllers {

    public class MonthlyLedgerController : Controller {

        private readonly IEntityRepo<Transaction> _transactionRepo;
        private readonly IEntityRepo<Pet> _petRepo;
        private readonly IEntityRepo<PetFood> _petFoodRepo;
        private readonly IEntityRepo<Employee> _employeeRepo;

        public MonthlyLedgerController(IEntityRepo<Transaction> transactionRepo, IEntityRepo<Pet> petRepo, IEntityRepo<PetFood> petFoodRepo, IEntityRepo<Employee> EmployeeRepo) {
            _transactionRepo = transactionRepo;
            _petRepo = petRepo;
            _petFoodRepo = petFoodRepo;
            _employeeRepo = EmployeeRepo;
        }


        // GET: MonthlyLedgerController
        public ActionResult Index() {
            var monthlyLedger = new MonthlyLedgerCreateDto();
            var transactions = _transactionRepo.GetAll();           
            var pets = _petRepo.GetAll();            
            var petFoods = _petFoodRepo.GetAll();
            var employees = _employeeRepo.GetAll();
            decimal StaffSalary=0;
            decimal petFoodCost = 0;
            decimal petCost = 0;

            decimal Rent = 2000;
            foreach(Employee employee in employees) 
                 StaffSalary += employee.SalaryPerMonth;
            foreach (PetFood petFood in petFoods)
                petFoodCost += petFood.Cost;
            foreach (Pet pet in pets)
                petCost += pet.Cost;
             
            foreach (Transaction transaction in transactions) {
                monthlyLedger.Expenses +=  transaction.PetFoodQty * petFoodCost + StaffSalary + petCost;
                monthlyLedger.Income += (transaction.PetFoodQty - 1) * transaction.PetFoodPrice + transaction.PetPrice;
            }
            monthlyLedger.Expenses += Rent;
            monthlyLedger.Total = monthlyLedger.Income - monthlyLedger.Expenses;
            string result = $"Year: {monthlyLedger.Year} Month: {monthlyLedger.Month} Income: {monthlyLedger.Income} " +
                $"Expenses: {monthlyLedger.Expenses} Total Profit: {monthlyLedger.Total}";
            return View(result);
        }

    }
       
}
