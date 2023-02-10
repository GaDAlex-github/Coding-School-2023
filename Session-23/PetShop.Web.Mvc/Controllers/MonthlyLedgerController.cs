using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.EF.Repositories;
using PetShop.Model;
using PetShop.Web.Mvc.Models.MonthlyLedger;

namespace PetShop.Web.Mvc.Controllers {
    public class MonthlyLedgerController : Controller {
        // GET: MonthlyLedgerController
        public ActionResult Index() {
            return View();
        }

        // GET: MonthlyLedgerController/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: MonthlyLedgerController/Create
        public ActionResult Create() {
            return View();
        }

        // POST: MonthlyLedgerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MonthlyLedgerCreateDto monthlyLedger) {
            if (!ModelState.IsValid) {
                return View();
            }

            var mLedger = new MonthlyLedger(monthlyLedger.Year, monthlyLedger.Month, monthlyLedger.Income, monthlyLedger.Expenses);
            
            return RedirectToAction("Index");
            return View();
        }

        // GET: MonthlyLedgerController/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: MonthlyLedgerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }

        // GET: MonthlyLedgerController/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: MonthlyLedgerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) {
            try {
                return RedirectToAction(nameof(Index));
            }
            catch {
                return View();
            }
        }
    }
}
