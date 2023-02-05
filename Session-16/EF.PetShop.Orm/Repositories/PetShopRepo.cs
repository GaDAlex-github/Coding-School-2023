using Microsoft.EntityFrameworkCore;
using Session_11.EF.PetShopModel;
using Session_11.EF.PetShopOrm.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_11.EF.PetShopOrm.Repositories {
    public class PetShopRepo : IEntityRepo<PetShop> {
        public void Add(PetShop entity) {
            using var context = new AppDbContext();
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id) {
            using var context = new AppDbContext();
            var dbPetShop = context.PetShops.Where(petShop => petShop.ID == id).SingleOrDefault();
            if (dbPetShop is null)
                return;
            context.Remove(dbPetShop);
            context.SaveChanges();
        }

        public IList<PetShop> GetAll() {
            using var context = new AppDbContext();
            return context.PetShops
                .Include(petShop => petShop.Customers)
                .Include(petShop => petShop.Employees)
                .Include(petShop => petShop.Pets)
                .Include(petShop => petShop.PetFoods)
                .Include(petShop => petShop.Transactions)
                .ToList();
        }

        public PetShop? GetById(int id) {
            using var context = new AppDbContext();
            return context.PetShops.Where(petShop => petShop.ID == id)
                .Include(petShop => petShop.Customers)
                .Include(petShop => petShop.Employees)
                .Include(petShop => petShop.Pets)
                .Include(petShop => petShop.PetFoods)
                .Include(petShop => petShop.Transactions)
                .SingleOrDefault();
        }

        public void Update(int id, PetShop entity) {
            using var context = new AppDbContext();
            var dbPetShop = context.PetShops.Where(petShop => petShop.ID == id).SingleOrDefault();
            if (dbPetShop is null)
                return;
            dbPetShop.Customers = entity.Customers;
            dbPetShop.Employees = entity.Employees;
            dbPetShop.Pets = entity.Pets;
            dbPetShop.PetFoods = entity.PetFoods;
            dbPetShop.Transactions = entity.Transactions;
            context.SaveChanges();
        }
    }
}
