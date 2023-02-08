using Microsoft.EntityFrameworkCore;
using PetShop.EF.Context;
using PetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.EF.Repositories {
    public class PetRepo : IEntityRepo<Pet> {
        public void Add(Pet entity) {
            using var context = new PetShopDbContext();
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id) {
            using var context = new PetShopDbContext();
            var dbPet = context.Pets.Where(pet => pet.ID == id).SingleOrDefault();
            if (dbPet is null)
                return;
            context.Remove(dbPet);
            context.SaveChanges();
        }

        public IList<Pet> GetAll() {
            using var context = new PetShopDbContext();
            return context.Pets
                .Include(pet => pet.AnimalType)
                .Include(pet => pet.Breed)
                .Include(pet => pet.PetStatus)
                .Include(pet => pet.Price)
                .Include(pet => pet.Cost)
                .ToList();
        }

        public Pet? GetById(int id) {
            using var context = new PetShopDbContext();
            return context.Pets.Where(pet => pet.ID == id)
                .Include(pet => pet.AnimalType)
                .Include(pet => pet.Breed)
                .Include(pet => pet.PetStatus)
                .Include(pet => pet.Price)
                .Include(pet => pet.Cost)
                .SingleOrDefault();
        }

        public void Update(int id, Pet entity) {
            using var context = new PetShopDbContext();
            var dbPet = context.Pets.Where(pet => pet.ID == id).SingleOrDefault();
            if (dbPet is null)
                return;
            dbPet.AnimalType = entity.AnimalType;
            dbPet.Breed = entity.Breed;
            dbPet.PetStatus = entity.PetStatus;
            dbPet.Price = entity.Price;
            dbPet.Cost = entity.Cost;

            context.SaveChanges();
        }
    }
}
