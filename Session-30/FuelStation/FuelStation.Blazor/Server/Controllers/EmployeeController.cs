using FuelStation.Blazor.Shared.Employee;
using FuelStation.EF.Repositories;
using FuelStation.Model;
using FuelStation.Model.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FuelStation.Blazor.Server.Controllers {

    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase {

        private readonly IEmployeeRepo<Employee> _employeeRepo;
        private readonly int maxManagers = 3;
        private readonly int maxStaff = 10;
        private readonly int maxCashiers = 4;

        public EmployeeController(IEmployeeRepo<Employee> employeeRepo) {
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeListDto>> Get() {
            var employee = _employeeRepo.GetAll();
            return employee.Select(employee => new EmployeeListDto {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                HireDateStart = employee.HireDateStart,
                HireDateEnd = employee.HireDateEnd,
                SalaryPerMonth = employee.SalaryPerMonth,
                EmployeeType = employee.EmployeeType
            });
        }

        [HttpGet("{id}")]
        public async Task<EmployeeEditDto> GetById(int id) {
            var employee = _employeeRepo.GetById(id);
            return new EmployeeEditDto {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                HireDateStart = employee.HireDateStart,
                HireDateEnd = employee.HireDateEnd,
                SalaryPerMonth = employee.SalaryPerMonth,
                EmployeeType = employee.EmployeeType
                // Transactions = employee.Transactions
            };
        }
        [HttpPost]
        public async Task<ActionResult> Post(EmployeeEditDto employee) {
            int count = 1;
            switch (employee.EmployeeType) {
                case EmployeeType.Manager:
                    count += _employeeRepo.ManagerCount();                    
                    if (count > maxManagers)
                      return  StatusCode(StatusCodes.Status409Conflict, $"You cannot add more than {maxManagers} Managers");
                    break;
                case EmployeeType.Staff:
                    count += _employeeRepo.StaffCount();
                    if (count > maxStaff)
                        return StatusCode(StatusCodes.Status409Conflict, $"You cannot add more than {maxStaff} Staff");
                    break;
                case EmployeeType.Cashier:
                    count += _employeeRepo.CashierCount();
                    if (count > maxCashiers)
                        return StatusCode(StatusCodes.Status409Conflict, $"You cannot add more than {maxCashiers} Cashiers");
                    break;
            }
            var newEmployee = new Employee(employee.Name, employee.Surname, employee.SalaryPerMonth, employee.EmployeeType);
            _employeeRepo.Add(newEmployee);
            return StatusCode(StatusCodes.Status200OK, "Employee Added Successfully");
        }


        [HttpPut]
        public async Task<ActionResult> Put(EmployeeEditDto employee) {
            int count = 1;
            switch (employee.EmployeeType) {
                case EmployeeType.Manager:
                    count += _employeeRepo.ManagerCount();
                    if (count > maxManagers)
                        return StatusCode(StatusCodes.Status409Conflict, $"You cannot add more than {maxManagers} Managers");
                    break;
                case EmployeeType.Staff:
                    count += _employeeRepo.StaffCount();
                    if (count > maxStaff)
                        return StatusCode(StatusCodes.Status409Conflict, $"You cannot add more than {maxStaff} Staff");
                    break;
                case EmployeeType.Cashier:
                    count += _employeeRepo.CashierCount();
                    if (count > maxCashiers)
                        return StatusCode(StatusCodes.Status409Conflict, $"You cannot add more than {maxCashiers} Cashiers");
                    break;
            }
            var itemToUpdate = _employeeRepo.GetById(employee.Id);
            itemToUpdate.Id = employee.Id;
            itemToUpdate.Name = employee.Name;
            itemToUpdate.Surname = employee.Surname;
            itemToUpdate.SalaryPerMonth = employee.SalaryPerMonth;
            itemToUpdate.EmployeeType = employee.EmployeeType;
            _employeeRepo.Update(employee.Id, itemToUpdate);
            return StatusCode(StatusCodes.Status200OK, "Employee Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) {
            try {
                _employeeRepo.Delete(id);
                return Ok();
            }
            catch (DbUpdateException ex) {
                return BadRequest("This employee cannot be deleted!");
            }
            catch (KeyNotFoundException ex) {
                return BadRequest($"Employee with id {id} not found!");
            }
        }
    }
}
