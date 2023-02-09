using Microsoft.EntityFrameworkCore;
using PetShop.EF.Context;
using PetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.EF.Repositories {
    public class PetFoodRepo : IEntityRepo<PetFood> {
        public void Add(PetFood entity) {
            using var context = new PetShopDbContext();
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id) {
            using var context = new PetShopDbContext();
            var dbPetFood = context.Pets.Where(petFood => petFood.Id == id).SingleOrDefault();
            if (dbPetFood is null)
                return;
            context.Remove(dbPetFood);
            context.SaveChanges();
        }

        public IList<PetFood> GetAll() {
            using var context = new PetShopDbContext();
            return context.PetFoods
                .Include(petFood => petFood.Transactions)
                .ToList();
        }

        public PetFood? GetById(int id) {
            using var context = new PetShopDbContext();
            return context.PetFoods.Where(petFood => petFood.Id == id)
                .Include(petFood => petFood.Transactions)
                .SingleOrDefault(petFood => petFood.Id == id);
        }

        public void Update(int id, PetFood entity) {
            using var context = new PetShopDbContext();
            var dbPetFood = context.PetFoods.Where(petFood => petFood.Id == id).SingleOrDefault();
            if (dbPetFood is null)
                return;
            dbPetFood.AnimalType = entity.AnimalType;
            dbPetFood.Price = entity.Price;
            dbPetFood.Cost = entity.Cost;

            context.SaveChanges();
        }
    }
}
