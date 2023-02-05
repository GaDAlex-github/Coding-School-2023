using Microsoft.EntityFrameworkCore;
using Session_11.EF.PetShopModel;
using Session_11.EF.PetShopOrm.Context;
using Session_11.EF.PetShopOrm.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_11.EF.PetShopOrm.Repositories {
    public class CustomerRepo : IEntityRepo<Customer> {
        public void Add(Customer entity) {
            using var context = new AppDbContext();
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id) {
            using var context = new AppDbContext();
            var dbCustomer = context.Customers.Where(customer => customer.ID == id).SingleOrDefault();
            if (dbCustomer is null)
                return;
            context.Remove(dbCustomer);
            context.SaveChanges();
        }

        public IList<Customer> GetAll() {
            using var context = new AppDbContext();
            return context.Customers
                .Include(customer => customer.Name)
                .Include(customer => customer.Surname)
                .Include(customer => customer.Phone)
                .Include(customer => customer.TIN)
                .ToList();
        }

        public Customer? GetById(int id) {
            using var context = new AppDbContext();
            return context.Customers.Where(customer => customer.ID == id)
               .Include(customer => customer.Name)
                .Include(customer => customer.Surname)
                .Include(customer => customer.Phone)
                .Include(customer => customer.TIN)
                .SingleOrDefault();
        }

        public void Update(int id, Customer entity) {
            using var context = new AppDbContext();
            var dbCustomer = context.Customers.Where(customer => customer.ID == id).SingleOrDefault();
            if (dbCustomer is null)
                return;
            dbCustomer.Name = entity.Name;
            dbCustomer.Surname = entity.Surname;
            dbCustomer.Phone = entity.Phone;
            dbCustomer.TIN = entity.TIN;
            context.SaveChanges();
        }
    }
}
