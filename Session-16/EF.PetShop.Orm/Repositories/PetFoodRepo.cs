using Microsoft.EntityFrameworkCore;
using Session_11.EF.PetShopModel;
using Session_11.EF.PetShopOrm.Context;
using Session_11.EF.PetShopOrm.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.PetShop.Orm.Repositories {
    public class PetFoodRepo : IEntityRepo<PetFood> {
        public void Add(PetFood entity) {
            using var context = new AppDbContext();
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id) {
            using var context = new AppDbContext();
            var dbPetFood = context.Pets.Where(petFood => petFood.ID == id).SingleOrDefault();
            if (dbPetFood is null)
                return;
            context.Remove(dbPetFood);
            context.SaveChanges();
        }

        public IList<PetFood> GetAll() {
            using var context = new AppDbContext();
            return context.PetFoods
                .Include(petFood => petFood.AnimalType)
                .Include(petFood => petFood.PetFoodPrice)
                .Include(petFood => petFood.PetFoodCost)
                .ToList();
        }

        public PetFood? GetById(int id) {
            using var context = new AppDbContext();
            return context.PetFoods.Where(petFood => petFood.ID == id)
                .Include(petFood => petFood.AnimalType)
                .Include(petFood => petFood.PetFoodPrice)
                .Include(petFood => petFood.PetFoodCost)
                .SingleOrDefault();
        }

        public void Update(int id, PetFood entity) {
            using var context = new AppDbContext();
            var dbPetFood = context.PetFoods.Where(petFood => petFood.ID == id).SingleOrDefault();
            if (dbPetFood is null)
                return;
            dbPetFood.AnimalType = entity.AnimalType;
            dbPetFood.PetFoodPrice = entity.PetFoodPrice;
            dbPetFood.PetFoodCost = entity.PetFoodCost;
           
            context.SaveChanges();
        }
    }
}
