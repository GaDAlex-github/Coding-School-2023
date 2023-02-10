using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.EF.Repositories;
using PetShop.Model;
using PetShop.Web.Mvc.Models.Pet;
using PetShop.Web.Mvc.Models.PetFood;
using System.Drawing;

namespace PetShop.Web.Mvc.Controllers {
    public class PetFoodController : Controller {

        private readonly IEntityRepo<PetFood> _petFoodRepo;
        public PetFoodController(IEntityRepo<PetFood> petFoodRepo) {
            _petFoodRepo = petFoodRepo;
        }
        // GET: PetFoodController
        public ActionResult Index() {

            var petFoods = _petFoodRepo.GetAll();
            return View(model: petFoods);
        }

        // GET: PetFoodController/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var petFood = _petFoodRepo.GetById(id.Value);
            if (petFood == null) {
                return NotFound();
            }

            var viewPetFood = new PetFoodDetailsDto {
                Id = petFood.Id,
                AnimalType = petFood.AnimalType,
                Price = petFood.Price,
                Cost = petFood.Cost
            };

            return View(model: viewPetFood);
        }

        // GET: PetFoodController/Create
        public ActionResult Create() {
            return View();
        }

        // POST: PetFoodController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PetFoodCreateDto petFood) {
            if (!ModelState.IsValid) {
                return View();
            }
            var dbPetFood = new PetFood(petFood.AnimalType, petFood.Price, petFood.Cost);
            _petFoodRepo.Add(dbPetFood);
            return RedirectToAction("Index");

        }

        // GET: PetFoodController/Edit/5
        public ActionResult Edit(int id) {
            var dbPetFood = _petFoodRepo.GetById(id);
            if (dbPetFood == null) {
                return NotFound();
            }

            var viewPetFood = new PetFoodEditDto {
                Id = dbPetFood.Id,
                AnimalType = dbPetFood.AnimalType,
                Price = dbPetFood.Price,
                Cost = dbPetFood.Cost
            };
            return View(model: viewPetFood);
        }

        // POST: PetFoodController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PetFoodEditDto petFood) {
            if (!ModelState.IsValid) {
                return View();
            }

            var dbFoodPet = _petFoodRepo.GetById(id);
            if (dbFoodPet == null) {
                return NotFound();
            }

            dbFoodPet.AnimalType = petFood.AnimalType;
            dbFoodPet.Price = petFood.Price;
            dbFoodPet.Cost = petFood.Cost;
            _petFoodRepo.Update(id, dbFoodPet);
            return RedirectToAction(nameof(Index));
        }

        // GET: PetFoodController/Delete/5
        public ActionResult Delete(int id) {
            var dbFoodPet = _petFoodRepo.GetById(id);
            if (dbFoodPet == null) {
                return NotFound();
            }

            var viewFoodPet = new PetFoodDeleteDto {
                Id = dbFoodPet.Id,
                AnimalType = dbFoodPet.AnimalType,
                Price = dbFoodPet.Price,
                Cost = dbFoodPet.Cost
            };
            return View(model: viewFoodPet);
        }

        // POST: PetFoodController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) {
            _petFoodRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
