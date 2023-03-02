using FuelStation.EF.Context;
using FuelStation.Model;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace FuelStation.EF.Repositories {

    public class CustomerRepo : ICustomerRepo<Customer> {
        public void Add(Customer entity) {
            using var context = new FuelStationDbContext();
            context.Add(entity);
            context.SaveChanges();
        }
        public void Delete(int id) {
            using var context = new FuelStationDbContext();
            var CustomerDb = context.Customers
                .Where(customer => customer.Id == id)
                .SingleOrDefault();
            if (CustomerDb is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found");
            context.Remove(CustomerDb);
            context.SaveChanges();
        }
        public IList<Customer> GetAll() {
            using var context = new FuelStationDbContext();
            return context.Customers
                .Include(customer => customer.Transactions)
                .ToList();
        }
        public Customer? GetById(int id) {
            using var context = new FuelStationDbContext();
            return context.Customers
                .Where(customer => customer.Id == id)
                .SingleOrDefault();
        }
        public void Update(int id, Customer entity) {
            using var context = new FuelStationDbContext();
            var CustomerDb = context.Customers
                .Where(customer => customer.Id == id)
                .SingleOrDefault();
            if (CustomerDb is null) throw new KeyNotFoundException($"Given id '{id}' was not found");
            CustomerDb.Name = entity.Name;
            CustomerDb.Surname = entity.Surname;
            CustomerDb.CardNumber = entity.CardNumber;
            context.SaveChanges();
        }
        public string CardNumberCreate() {
            using var context = new FuelStationDbContext();
            var max = context.Customers.Max(customer => customer.CardNumber);
            if (max == null)
                max = "A1000000";
            max = Regex.Replace(max, "\\d+",
            m => (int.Parse(m.Value) + 1).ToString(new string('0', m.Value.Length)));
            return max;
        }
    }
}
