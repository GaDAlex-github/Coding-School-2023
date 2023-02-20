using FuelStation.Blazor.Shared.Employee;
using FuelStation.EF.Repositories;
using FuelStation.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace FuelStation.Blazor.Server.Controllers {

    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase {

        private readonly IEntityRepo<Employee> _employeeRepo;

        public EmployeeController(IEntityRepo<Employee> employeeRepo) {
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
        public async Task Post(EmployeeEditDto employee) {            
                var newEmployee = new Employee(employee.Name, employee.Surname, employee.SalaryPerMonth, employee.EmployeeType);
                _employeeRepo.Add(newEmployee);               
            }
        

        [HttpPut]
        public async Task Put(EmployeeEditDto employee) {           
                var itemToUpdate = _employeeRepo.GetById(employee.Id);
                itemToUpdate.Id = employee.Id;
                itemToUpdate.Name = employee.Name;
                itemToUpdate.Surname = employee.Surname;
                itemToUpdate.SalaryPerMonth = employee.SalaryPerMonth;
                itemToUpdate.EmployeeType = employee.EmployeeType;
                _employeeRepo.Update(employee.Id, itemToUpdate);   
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
