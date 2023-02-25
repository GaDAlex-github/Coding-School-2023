using FuelStation.EF.Context;
using FuelStation.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Repositories {
    public class TransactionLineRepo : ITransactionLineRepo<TransactionLine> {
        public void Add(TransactionLine entity) {
            using var context = new FuelStationDbContext();
            context.Add(entity);
            context.SaveChanges();
        }
        public void Delete(int id) {
            using var context = new FuelStationDbContext();
            var TransactionLineDb = context.TransactionLines.Where(transactionLine => transactionLine.Id == id)
                .Include(transactionLine => transactionLine.Item)
                .Include(transactionLine => transactionLine.Transaction)
                
                .SingleOrDefault();
            if (TransactionLineDb is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found");
            context.Remove(TransactionLineDb);
            context.SaveChanges();
        }
        public IList<TransactionLine> GetAll() {
            using var context = new FuelStationDbContext();
            return context.TransactionLines
                .Include(transactionLine => transactionLine.Item)
                .Include(transactionLine => transactionLine.Transaction)                
                .ToList();
        }
        public IList<TransactionLine> GetAllWithTransactionID(int transactionId) {
            using var context = new FuelStationDbContext();
            return context.TransactionLines.Where(t => t.TransactionId == transactionId)
                .Include(transactionLine => transactionLine.Item)
                .ToList(); 
        }
        public TransactionLine? GetById(int id) {
            using var context = new FuelStationDbContext();
            return context.TransactionLines
                .Where(transactionLine => transactionLine.Id == id)
                .Include(transactionLine => transactionLine.Item)
                .Include(transactionLine => transactionLine.Transaction)
                .SingleOrDefault();
        }
        public void Update(int id, TransactionLine entity) {
            using var context = new FuelStationDbContext();
            var TransactionLineDb = context.TransactionLines.Where(transactionLine => transactionLine.Id == id)
                .Include(transactionLine => transactionLine.Item)
                .Include(transactionLine => transactionLine.Transaction)                
                .SingleOrDefault();
            if (TransactionLineDb is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found");
            TransactionLineDb.Quantity = entity.Quantity;
            TransactionLineDb.ItemPrice = entity.ItemPrice;
            TransactionLineDb.NetValue = entity.NetValue;
            TransactionLineDb.DiscountPercent = entity.DiscountPercent;
            TransactionLineDb.DiscountValue = entity.DiscountValue;
            TransactionLineDb.TotalValue = entity.TotalValue;
            context.SaveChanges();
        }
    }
}
