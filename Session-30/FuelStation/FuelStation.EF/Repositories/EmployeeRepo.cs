using FuelStation.EF.Context;
using FuelStation.Model;
using Microsoft.EntityFrameworkCore;

namespace FuelStation.EF.Repositories {

    public class EmployeeRepo : IEntityRepo<Employee> {
        public void Add(Employee entity) {
            using var context = new FuelStationDbContext();
            context.Add(entity);
            context.SaveChanges();
        }
        public void Delete(int id) {
            using var context = new FuelStationDbContext();
            var EmployeeDb = context.Employees
                .Where(employee => employee.Id == id)
                .SingleOrDefault();
            if (EmployeeDb is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found");
            context.Remove(EmployeeDb);
            context.SaveChanges();
        }
        public IList<Employee> GetAll() {
            using var context = new FuelStationDbContext();
            return context.Employees
                .Include(employee => employee.Transactions)
                .ToList();
        }
        public Employee? GetById(int id) {
            using var context = new FuelStationDbContext();
            return context.Employees
                .Where(employee => employee.Id == id)
                .Include(employee => employee.Transactions)
                .SingleOrDefault();
        }
        public void Update(int id, Employee entity) {
            using var context = new FuelStationDbContext();
            var EmployeeDb = context.Employees
                .Where(employee => employee.Id == id)
                .SingleOrDefault();
            if (EmployeeDb is null) throw new KeyNotFoundException($"Given id '{id}' was not found");
            EmployeeDb.Name = entity.Name;
            EmployeeDb.Surname = entity.Surname;
            EmployeeDb.HireDateStart = entity.HireDateStart;
            EmployeeDb.HireDateEnd = entity.HireDateEnd;
            EmployeeDb.SalaryPerMonth = entity.SalaryPerMonth;
            EmployeeDb.EmployeeType = entity.EmployeeType;
            context.SaveChanges();
        }
    }
}



