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
            var dbTodo = context.PetShops.Where(petShop => petShop.PetShopID == id).SingleOrDefault();
            if (dbTodo is null)
                return;
            context.Remove(dbTodo);
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
            return context.PetShops.Where(petShop => petShop.PetShopID == id)
                .Include(petShop => petShop.Customers)
                .Include(petShop => petShop.Employees)
                .Include(petShop => petShop.Pets)
                .Include(petShop => petShop.PetFoods)
                .Include(petShop => petShop.Transactions)
                .SingleOrDefault();
        }

        public void Update(int id, PetShop entity) {
            using var context = new AppDbContext();
            var dbTodo = context.PetShops.Where(petShop => petShop.PetShopID == id).SingleOrDefault();
            if (dbTodo is null)
                return;
            dbTodo.Customers = entity.Customers;
            dbTodo.Employees = entity.Employees;
            dbTodo.Pets = entity.Pets;
            dbTodo.PetFoods = entity.PetFoods;
            dbTodo.Transactions = entity.Transactions;
            context.SaveChanges();
        }
    }
}
