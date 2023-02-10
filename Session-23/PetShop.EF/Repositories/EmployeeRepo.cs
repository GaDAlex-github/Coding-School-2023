using Microsoft.EntityFrameworkCore;
using PetShop.EF.Context;
using PetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.EF.Repositories {
    public class EmployeeRepo : IEntityRepo<Employee> {
        public void Add(Employee entity) {
            using var context = new PetShopDbContext();
            context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id) {
            using var context = new PetShopDbContext();
            var dbEmployee = context.Employees.Where(employee => employee.Id == id).SingleOrDefault();
            if (dbEmployee is null)
                return;
            context.Remove(dbEmployee);
            context.SaveChanges();
        }

        public IList<Employee> GetAll() {
            using var context = new PetShopDbContext();
            return context.Employees.ToList();
        }

        public Employee? GetById(int id) {
            using var context = new PetShopDbContext();
            return context.Employees.Where(Employee => Employee.Id == id)
                .SingleOrDefault(employee => employee.Id == id);
        }

        public void Update(int id, Employee entity) {
            using var context = new PetShopDbContext();
            var dbEmployee = context.Employees.Where(employee => employee.Id == id).SingleOrDefault();
            if (dbEmployee is null)
                return;
            dbEmployee.Name = entity.Name;
            dbEmployee.Surname = entity.Surname;
            dbEmployee.EmployeeType = entity.EmployeeType;
            dbEmployee.SalaryPerMonth = entity.SalaryPerMonth;
            context.SaveChanges();
        }
    }
}
