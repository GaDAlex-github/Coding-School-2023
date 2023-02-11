using Microsoft.EntityFrameworkCore;
using PetShop.EF.Context;
using PetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PetShop.EF.Repositories {
    public class TransactionRepo : IEntityRepo<Transaction> {
        public void Add(Transaction entity) {
            using var context = new PetShopDbContext();
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id) {
            using var context = new PetShopDbContext();
            var dbTransaction = context.Transactions.Where(transaction => transaction.Id == id).SingleOrDefault();
            if (dbTransaction is null)
                return;
            context.Remove(dbTransaction);
            context.SaveChanges();
        }

        public IList<Transaction> GetAll() {
            using var context = new PetShopDbContext();
            return context.Transactions
                .Include(transaction => transaction.Customer)
                .Include(transaction => transaction.Employee)
                .Include(transaction => transaction.Pet)
                .Include(transaction => transaction.PetFood)
                .ToList();
        }

        public Transaction? GetById(int id) {
            using var context = new PetShopDbContext();
            return context.Transactions.Where(transaction => transaction.Id == id)
                .Include(transaction => transaction.Customer)
                .Include(transaction => transaction.Employee)
                .Include(transaction => transaction.Pet)
                .Include(transaction => transaction.PetFood)
                .SingleOrDefault(transaction => transaction.Id == id);
        }

        public void Update(int id, Transaction entity) {
            using var context = new PetShopDbContext();
            var dbTransaction = context.Transactions.Where(transaction => transaction.Id == id).SingleOrDefault();
            if (dbTransaction is null)
                return;
            dbTransaction.Date = entity.Date;
            dbTransaction.CustomerId = entity.CustomerId;
            dbTransaction.EmployeeId = entity.EmployeeId;
            dbTransaction.PetId = entity.PetId;
            dbTransaction.PetPrice = entity.PetPrice;
            dbTransaction.PetFoodId = entity.PetFoodId;
            dbTransaction.PetFoodQty = entity.PetFoodQty;
            dbTransaction.PetFoodPrice = entity.PetFoodPrice;
            dbTransaction.TotalPrice = entity.TotalPrice;

            context.SaveChanges();
        }
    }
}
