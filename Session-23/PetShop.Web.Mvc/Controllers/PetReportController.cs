using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.EF.Repositories;
using PetShop.Model;
using PetShop.Model.Enums;
using PetShop.Web.Mvc.Models.MonthlyLedger;
using PetShop.Web.Mvc.Models.PetReport;
using PetShop.Web.Mvc.Models.Transaction;

namespace PetShop.Web.Mvc.Controllers {
    public class PetReportController : Controller {

        private readonly IEntityRepo<Transaction> _transactionRepo;
        private readonly IEntityRepo<Pet> _petRepo;
        public PetReportController(IEntityRepo<Transaction> transactionRepo, IEntityRepo<Pet> petRepo) {
            _transactionRepo = transactionRepo;
            _petRepo = petRepo;
        }

        // GET: PetReportController
        public ActionResult Index() {
            var newPetReport = new PetReportCreateDto();
            var transactions = _transactionRepo.GetAll();
            var pets = _petRepo.GetAll();
            int totalBirdsSold = 0;
            int totalMammalsSold = 0;
            int totalReptilesSold = 0;
            int totalFishesSold = 0;

            //foreach (Transaction transaction in transactions) {
            //    foreach (Pet pet in pets) {
            //        switch (pet.AnimalType) {
            //            case AnimalType.Bird:
            //                totalBirdsSold++;
            //                break;
            //            case AnimalType.Mammal:
            //                totalMammalsSold++;
            //                break;
            //            case AnimalType.Reptile:
            //                totalReptilesSold++;
            //                break;
            //            case AnimalType.Fish:
            //                totalFishesSold++;
            //                break;
            //            default:
            //                break;
            //        }
            //    }

            //}
            string result = $"Year: {newPetReport.Year} Month: {newPetReport.Month} Animal Type: {newPetReport.AnimalType} Total Sold: {newPetReport.TotalSold}";
            return View(model: result);

        }


        
    }
}


