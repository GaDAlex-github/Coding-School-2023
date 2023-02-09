using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.EF.Repositories;
using PetShop.Model;
using PetShop.Web.Mvc.Models.Customer;
using PetShop.Web.Mvc.Models.Pet;
using System.Drawing;

namespace PetShop.Web.Mvc.Controllers {
    public class PetController : Controller {

        private readonly IEntityRepo<Pet> _petRepo;
        public PetController(IEntityRepo<Pet> petRepo) {
            _petRepo = petRepo;
        }
        // GET: PetController
        public ActionResult Index() {

            var pets = _petRepo.GetAll();
            return View(model: pets);
        }

        // GET: PetController/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var pet = _petRepo.GetById(id.Value);
            if (pet == null) {
                return NotFound();
            }

            var viewPet = new PetDetailsDto {
                Id = pet.Id,
                Breed = pet.Breed,
                AnimalType = pet.AnimalType,                
                PetStatus = pet.PetStatus,
                Price = pet.Price,
                Cost = pet.Cost
            };

            return View(model: viewPet);
        }

        // GET: PetController/Create
        public ActionResult Create() {
            return View();
        }

        // POST: PetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PetCreateDto pet) {
            if (!ModelState.IsValid) {
                return View();
            }

            var dbPet = new Pet(pet.Breed, pet.AnimalType, pet.PetStatus, pet.Price, pet.Cost);
            _petRepo.Add(dbPet);
            return RedirectToAction("Index");
         
        }

        // GET: PetController/Edit/5
        public ActionResult Edit(int id) {
            var dbPet = _petRepo.GetById(id);
            if (dbPet == null) {
                return NotFound();
            }

            var viewPet = new PetEditDto {
                Id = dbPet.Id,
                Breed = dbPet.Breed,
                AnimalType = dbPet.AnimalType,                
                PetStatus = dbPet.PetStatus,
                Price = dbPet.Price,
                Cost = dbPet.Cost
            };
            return View(model: viewPet);
        }

        // POST: PetController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PetEditDto pet) {
            if (!ModelState.IsValid) {
                return View();
            }

            var dbPet = _petRepo.GetById(id);
            if (dbPet == null) {
                return NotFound();
            }

            dbPet.AnimalType = pet.AnimalType;
            dbPet.Breed = pet.Breed;
            dbPet.PetStatus = pet.PetStatus;
            dbPet.Price = pet.Price;
            dbPet.Cost = pet.Cost;
            _petRepo.Update(id, dbPet);
            return RedirectToAction(nameof(Index));
        }

        // GET: PetController/Delete/5
        public ActionResult Delete(int id) {
            var dbPet = _petRepo.GetById(id);
            if (dbPet == null) {
                return NotFound();
            }

            var viewPet = new PetDeleteDto {
                Id = dbPet.Id,
                AnimalType = dbPet.AnimalType,
                Breed = dbPet.Breed,
                PetStatus = dbPet.PetStatus,
                Price = dbPet.Price,
                Cost = dbPet.Cost
            };
            return View(model: viewPet);
        }

        // POST: PetController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) {
            _petRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
