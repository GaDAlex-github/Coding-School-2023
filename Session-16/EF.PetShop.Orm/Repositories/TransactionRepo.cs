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
    public class TransactionRepo : IEntityRepo<Transaction> {
        public void Add(Transaction entity) {
            using var context = new AppDbContext();
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id) {
            using var context = new AppDbContext();
            var dbTransaction = context.Transactions.Where(transaction => transaction.ID == id).SingleOrDefault();
            if (dbTransaction is null)
                return;
            context.Remove(dbTransaction);
            context.SaveChanges();
        }

        public IList<Transaction> GetAll() {
            using var context = new AppDbContext();
            return context.Transactions
                .Include(transaction => transaction.TransactionDate)
                .Include(transaction => transaction.CustomerID)
                .Include(transaction => transaction.EmployeeID)
                .Include(transaction => transaction.PetID)
                .Include(transaction => transaction.PetPrice)
                .Include(transaction => transaction.PetFoodID)
                .Include(transaction => transaction.PetFoodQty)
                .Include(transaction => transaction.PetFoodPrice)
                .Include(transaction => transaction.TotalPrice)

                .ToList();
        }

        public Transaction? GetById(int id) {
            using var context = new AppDbContext();
            return context.Transactions.Where(transaction => transaction.ID == id)
                .Include(transaction => transaction.TransactionDate)
                .Include(transaction => transaction.CustomerID)
                .Include(transaction => transaction.EmployeeID)
                .Include(transaction => transaction.PetID)
                .Include(transaction => transaction.PetPrice)
                .Include(transaction => transaction.PetFoodID)
                .Include(transaction => transaction.PetFoodQty)
                .Include(transaction => transaction.PetFoodPrice)
                .Include(transaction => transaction.TotalPrice)
                .SingleOrDefault();
        }

        public void Update(int id, Transaction entity) {
            using var context = new AppDbContext();
            var dbTransaction = context.Transactions.Where(transaction => transaction.ID == id).SingleOrDefault();
            if (dbTransaction is null)
                return;
            dbTransaction.TransactionDate = entity.TransactionDate;
            dbTransaction.CustomerID = entity.CustomerID;
            dbTransaction.EmployeeID = entity.EmployeeID;
            dbTransaction.PetID = entity.PetID;
            dbTransaction.PetPrice = entity.PetPrice;
            dbTransaction.PetFoodID = entity.PetFoodID;
            dbTransaction.PetFoodQty = entity.PetFoodQty;
            dbTransaction.PetFoodPrice = entity.PetFoodPrice;
            dbTransaction.TotalPrice = entity.TotalPrice;

            context.SaveChanges();
        }
    }
}
