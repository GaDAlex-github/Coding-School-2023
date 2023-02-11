using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Model;
using PetShop.Web.Mvc.Models.MonthlyLedger;
using PetShop.Web.Mvc.Models.PetReport;

namespace PetShop.Web.Mvc.Controllers {
    public class PetReportController : Controller {
        // GET: PetReportController
        public ActionResult Index() {
            return View();
        }

        // GET: PetReportController/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: PetReportController/Create
        public ActionResult Create() {
            return View();
        }

        // POST: PetReportController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PetReportCreateDto petReport) {
            if (!ModelState.IsValid) {
                return View();
            }

            var pReport = new PetReport(petReport.Year, petReport.Month, petReport.AnimalType, petReport.TotalSold);

            return RedirectToAction("Index");
        }

        // GET: PetReportController/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: PetReportController/Edit/5
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

        // GET: PetReportController/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: PetReportController/Delete/5
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
