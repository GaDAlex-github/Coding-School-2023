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
    public class PetRepo : IEntityRepo<Pet> {
        public void Add(Pet entity) {
            using var context = new AppDbContext();
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id) {
            using var context = new AppDbContext();
            var dbPet = context.Pets.Where(pet => pet.ID == id).SingleOrDefault();
            if (dbPet is null)
                return;
            context.Remove(dbPet);
            context.SaveChanges();
        }

        public IList<Pet> GetAll() {
            using var context = new AppDbContext();
            return context.Pets
                .Include(pet => pet.AnimalType)
                .Include(pet => pet.Breed)
                .Include(pet => pet.Status)
                .Include(pet => pet.Price)
                .Include(pet => pet.Cost)
                .ToList();
        }

        public Pet? GetById(int id) {
            using var context = new AppDbContext();
            return context.Pets.Where(pet => pet.ID == id)
                .Include(pet => pet.AnimalType)
                .Include(pet => pet.Breed)
                .Include(pet => pet.Status)
                .Include(pet => pet.Price)
                .Include(pet => pet.Cost)
                .SingleOrDefault();
        }

        public void Update(int id, Pet entity) {
            using var context = new AppDbContext();
            var dbPet = context.Pets.Where(pet => pet.ID == id).SingleOrDefault();
            if (dbPet is null)
                return;
            dbPet.AnimalType = entity.AnimalType;
            dbPet.Breed = entity.Breed;
            dbPet.Status = entity.Status;
            dbPet.Price = entity.Price;
            dbPet.Cost = entity.Cost;

            context.SaveChanges();
        }
    }
}
