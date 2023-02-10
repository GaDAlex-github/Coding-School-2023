using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.EF.Repositories;
using PetShop.Model;
using PetShop.Web.Mvc.Models.Transaction;

namespace PetShop.Web.Mvc.Controllers {
    public class TransactionController : Controller {

        private readonly IEntityRepo<Transaction> _transactionRepo;
        public TransactionController(IEntityRepo<Transaction> transactionRepo) {
            _transactionRepo = transactionRepo;
        }

        // GET: TransactionController
        public ActionResult Index() {
            var transactions = _transactionRepo.GetAll();            
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
                Date = transaction.Date,
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
            return View();
        }

        // POST: TransactionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionCreateDto transaction) {
            if (!ModelState.IsValid) {
                return View();
            }
            
            var dbTransaction = new Transaction(transaction.CustomerId, transaction.EmployeeId, transaction.PetId, transaction.PetPrice, transaction.PetFoodId, transaction.PetFoodQty, transaction.PetFoodPrice, transaction.TotalPrice);
            _transactionRepo.Add(dbTransaction);
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
