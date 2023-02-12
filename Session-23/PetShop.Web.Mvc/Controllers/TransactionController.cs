using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.EF.Repositories;
using PetShop.Model;
using PetShop.Model.Enums;
using PetShop.Web.Mvc.Models.Transaction;

namespace PetShop.Web.Mvc.Controllers {
    public class TransactionController : Controller {

        private readonly IEntityRepo<Transaction> _transactionRepo;
        private readonly IEntityRepo<Customer> _customerRepo;
        private readonly IEntityRepo<Employee> _employeeRepo;
        private readonly IEntityRepo<Pet> _petRepo;
        private readonly IEntityRepo<PetFood> _petFoodRepo;
        public TransactionController(IEntityRepo<Transaction> transactionRepo, IEntityRepo<Customer> customerRepo,
                 IEntityRepo<Employee> employeeRepo, IEntityRepo<Pet> petRepo, IEntityRepo<PetFood> petFoodRepo) {
            _transactionRepo = transactionRepo;
            _customerRepo = customerRepo;
            _employeeRepo = employeeRepo;
            _petRepo = petRepo;
            _petFoodRepo = petFoodRepo;
        }

        // GET: TransactionController
        public ActionResult Index() {
            var transaction = _transactionRepo.GetAll(); 
            var transactions = transaction.ToList();            
            return View(model: transactions);
        }

        // GET: TransactionController/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var transaction = _transactionRepo.GetById(id.Value);
            if (transaction == null) {
                return NotFound();
            }

            var viewTransaction = new TransactionDetailsDto {
                Id = transaction.Id,                
                CustomerId = transaction.CustomerId,
                EmployeeId = transaction.EmployeeId,
                PetId = transaction.PetId,
                PetPrice = transaction.PetPrice,
                PetFoodId = transaction.PetFoodId,
                PetFoodQty = transaction.PetFoodQty,
                PetFoodPrice = transaction.PetFoodPrice,
                TotalPrice = transaction.TotalPrice
            };
            return View(model: viewTransaction);
        }

        // GET: TransactionController/Create
        public ActionResult Create() {
            var newTrasaction = new TransactionCreateDto();
            var customers = _customerRepo.GetAll();
            foreach(var customer in customers) {
                newTrasaction.Customers.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem(customer.Name +" "+customer.Surname, customer.Id.ToString()));
            }
            var employees = _employeeRepo.GetAll();
            foreach (var employee in employees) {
                newTrasaction.Employees.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem(employee.Name +" "+employee.Surname, employee.Id.ToString()));
            }
            var pets = _petRepo.GetAll();
            foreach (var pet in pets) {
                if(pet.PetStatus == PetStatus.Unhealthy) {
                   
                }
                newTrasaction.Pets.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem(pet.AnimalType.ToString()+" "+pet.Breed, pet.Id.ToString()));
            }
            var petFoods = _petFoodRepo.GetAll();
            foreach (var petFood in petFoods) {
                newTrasaction.PetFoods.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem(petFood.AnimalType.ToString(), petFood.Id.ToString()));
            }
            return View(model: newTrasaction);
        }

        // POST: TransactionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionCreateDto transaction) {
            if (!ModelState.IsValid) {
                return View();
            }

            var dbTransaction = new Transaction(transaction.PetPrice, transaction.PetFoodQty, transaction.PetFoodPrice) {
                CustomerId = transaction.CustomerId,
                EmployeeId = transaction.EmployeeId,
                PetId = transaction.PetId,
                PetFoodId = transaction.PetFoodId
            };            
            _transactionRepo.Add(dbTransaction);
            //_petRepo.Delete(dbTransaction.PetId);
            return RedirectToAction("Index");
        }

        // GET: TransactionController/Edit/5
        public ActionResult Edit(int id) {
            var dbTransaction = _transactionRepo.GetById(id);
            if (dbTransaction == null) {
                return NotFound();
            }

            var viewTransaction = new TransactionEditDto {
                CustomerId = dbTransaction.CustomerId,
                EmployeeId = dbTransaction.EmployeeId,
                PetId = dbTransaction.PetId,
                PetPrice = dbTransaction.PetPrice,
                PetFoodId = dbTransaction.PetFoodId,
                PetFoodQty = dbTransaction.PetFoodQty,
                PetFoodPrice = dbTransaction.PetFoodPrice,
                TotalPrice = dbTransaction.TotalPrice,
                Id = dbTransaction.Id
            };
            return View(model: viewTransaction);
        }

        // POST: TransactionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TransactionEditDto transaction) {
            if (!ModelState.IsValid) {
                return View();
            }

            var dbTransaction = _transactionRepo.GetById(id);
            if (dbTransaction == null) {
                return NotFound();
            }

            dbTransaction.CustomerId = transaction.CustomerId;
            dbTransaction.EmployeeId = transaction.EmployeeId;
            dbTransaction.PetId = transaction.PetId;
            dbTransaction.PetPrice = transaction.PetPrice;
            dbTransaction.PetFoodId = transaction.PetFoodId;
            dbTransaction.PetFoodQty = transaction.PetFoodQty;
            dbTransaction.PetFoodPrice = transaction.PetFoodPrice;
            dbTransaction.TotalPrice = transaction.TotalPrice;

            _transactionRepo.Update(id, dbTransaction);
            return RedirectToAction(nameof(Index));
        }

        // GET: TransactionController/Delete/5
        public ActionResult Delete(int id) {
            var dbTransaction = _transactionRepo.GetById(id);
            if (dbTransaction == null) {
                return NotFound();
            }

            var viewTransaction = new TransactionDeleteDto {
                CustomerId = dbTransaction.CustomerId,
                EmployeeId = dbTransaction.EmployeeId,
                PetId = dbTransaction.PetId,
                PetPrice = dbTransaction.PetPrice,
                PetFoodId = dbTransaction.PetFoodId,
                PetFoodQty = dbTransaction.PetFoodQty,
                PetFoodPrice = dbTransaction.PetFoodPrice,
                TotalPrice = dbTransaction.TotalPrice,
                Id = dbTransaction.Id
            };
            return View(model: viewTransaction);
        }

        // POST: TransactionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) {
            _transactionRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
