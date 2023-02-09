using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.EF.Repositories;
using PetShop.Model;
using PetShop.Web.Mvc.Models.Customer;
using PetShop.Web.Mvc.Models.Employee;

namespace PetShop.Web.Mvc.Controllers {
    public class EmployeeController : Controller {

        private readonly IEntityRepo<Employee> _employeeRepo;
        public EmployeeController(IEntityRepo<Employee> employeeRepo) {
            _employeeRepo = employeeRepo;
        }
            // GET: EmployeeController
        public ActionResult Index() {

            var employees = _employeeRepo.GetAll();
            return View(model: employees);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var employee = _employeeRepo.GetById(id.Value);
            if (employee == null) {
                return NotFound();
            }

            var viewEmployee = new EmployeeDetailsDto {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                EmployeeType = employee.EmployeeType,
                SalaryPerMonth = employee.SalaryPerMonth
            };

            return View(model: viewEmployee);
        }

        // GET: EmployeeController/Create
        public ActionResult Create() {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeCreateDto employee) {
            if (!ModelState.IsValid) {
                return View();
            }

            var dbEmployee = new Employee(employee.Name, employee.Surname, employee.EmployeeType, employee.SalaryPerMonth);
            _employeeRepo.Add(dbEmployee);
            return RedirectToAction("Index");
            return View();
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id) {
            var dbEmployee = _employeeRepo.GetById(id);
            if (dbEmployee == null) {
                return NotFound();
            }

            var viewEmployee = new EmployeeEditDto {
                Id = dbEmployee.Id,
                Name = dbEmployee.Name,
                Surname = dbEmployee.Surname,
                EmployeeType = dbEmployee.EmployeeType,
                SalaryPerMonth = dbEmployee.SalaryPerMonth
            };
            return View(model: viewEmployee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeEditDto employee) {
            if (!ModelState.IsValid) {
                return View();
            }

            var dbEmployee = _employeeRepo.GetById(id);
            if (dbEmployee == null) {
                return NotFound();
            }

            dbEmployee.Name = employee.Name;
            _employeeRepo.Update(id, dbEmployee);
            return RedirectToAction(nameof(Index));
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id) {
            var dbEmployee = _employeeRepo.GetById(id);
            if (dbEmployee == null) {
                return NotFound();
            }

            var viewCustomer = new EmployeeDeleteDto {
                Name = dbEmployee.Name,
                Surname = dbEmployee.Surname,
                EmployeeType = dbEmployee.EmployeeType,
                SalaryPerMonth = dbEmployee.SalaryPerMonth,
                Id = dbEmployee.Id
            };
            return View(model: viewCustomer);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) {
            _employeeRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
