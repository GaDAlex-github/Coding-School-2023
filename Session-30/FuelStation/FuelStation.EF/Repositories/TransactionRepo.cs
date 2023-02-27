using FuelStation.EF.Context;
using FuelStation.Model;
using Microsoft.EntityFrameworkCore;

namespace FuelStation.EF.Repositories {
    public class TransactionRepo : IEntityRepo<Transaction> {
        public void Add(Transaction entity) {
            using var context = new FuelStationDbContext();
            context.Add(entity);
            context.SaveChanges();
        }
        public void Delete(int id) {
            using var context = new FuelStationDbContext();
            var TransactionDb = context.Transactions
                .Where(transaction => transaction.Id == id)
                .Include(transaction => transaction.TransactionLines)
                .Include(transaction => transaction.Customer)
                .Include(transaction => transaction.Employee)
                .SingleOrDefault();
            if (TransactionDb is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found");
            context.Remove(TransactionDb);
            context.SaveChanges();
        }
        public IList<Transaction> GetAll() {
            using var context = new FuelStationDbContext();
            return context.Transactions

                .Include(transaction => transaction.Customer)
                .Include(transaction => transaction.Employee)
                .Include(transaction => transaction.TransactionLines)
                    .ThenInclude(transactionLine => transactionLine.Item)
                .ToList();
        }
        public Transaction? GetById(int id) {
            using var context = new FuelStationDbContext();
            return context.Transactions
                .Where(transaction => transaction.Id == id)

                .Include(transaction => transaction.Customer)
                .Include(transaction => transaction.Employee)
                .Include(transaction => transaction.TransactionLines)
                    .ThenInclude(transactionLine => transactionLine.Item)
                .SingleOrDefault();
        }
        public void Update(int id, Transaction entity) {
            using var context = new FuelStationDbContext();
            var TransactionDb = context.Transactions
                .Where(transaction => transaction.Id == id)
                .SingleOrDefault();
            if (TransactionDb is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found");
            TransactionDb.Date = entity.Date;
            TransactionDb.CustomerId = entity.CustomerId;
            TransactionDb.EmployeeId = entity.EmployeeId;
            TransactionDb.PaymentMethod = entity.PaymentMethod;
            TransactionDb.TotalValue = entity.TotalValue;
            context.SaveChanges();
        }
    }
}
