using FuelStation.EF.Context;
using FuelStation.Model;
using FuelStation.Model.Enums;
using Microsoft.EntityFrameworkCore;

namespace FuelStation.EF.Repositories {

    public class EmployeeRepo : IEmployeeRepo<Employee>{
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
        public int ManagerCount() {
            using var context = new FuelStationDbContext();
            var managerCount = context.Employees.
                Where(employee => employee.EmployeeType == EmployeeType.Manager).Count();
            return managerCount;
        }
        public int StaffCount() {
            using var context = new FuelStationDbContext();
            var staffCount = context.Employees.
                Where(employee => employee.EmployeeType == EmployeeType.Staff).Count();
            return staffCount;
        }
        public int CashierCount() {
            using var context = new FuelStationDbContext();
            var cashierCount = context.Employees.
                Where(employee => employee.EmployeeType == EmployeeType.Cashier).Count();
            return cashierCount;
        }
    }
}



