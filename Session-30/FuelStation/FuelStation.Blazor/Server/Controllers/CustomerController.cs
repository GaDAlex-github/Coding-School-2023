using FuelStation.Blazor.Shared.Employee;
using FuelStation.EF.Repositories;
using FuelStation.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using FuelStation.Blazor.Shared.Customer;

namespace FuelStation.Blazor.Server.Controllers {

    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase {

        private readonly IEntityRepo<Customer> _customerRepo;

        public CustomerController(IEntityRepo<Customer> customerRepo) {
            _customerRepo = customerRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerListDto>> Get() {
            var customer = _customerRepo.GetAll();
            return customer.Select(customer => new CustomerListDto {
                Id = customer.Id,
                Name = customer.Name,
                Surname = customer.Surname,
                CardNumber = customer.CardNumber
            });
        }

        [HttpGet("{id}")]
        public async Task<CustomerEditDto> GetById(int id) {
            var customer = _customerRepo.GetById(id);
            return new CustomerEditDto {
                Id = customer.Id,
                Name = customer.Name,
                Surname = customer.Surname,
                CardNumber = customer.CardNumber
                // Transactions = customer.Transactions
            };
        }
        [HttpPost]
        public async Task Post(CustomerEditDto customer) {
            var newCustomer = new Customer(customer.Name, customer.Surname);
            _customerRepo.Add(newCustomer);
        }

        [HttpPut]
        public async Task Put(CustomerEditDto customer) {
            var itemToUpdate = _customerRepo.GetById(customer.Id);
            itemToUpdate.Id = customer.Id;
            itemToUpdate.Name = customer.Name;
            itemToUpdate.Surname = customer.Surname;
            itemToUpdate.CardNumber = customer.CardNumber;
            _customerRepo.Update(customer.Id, itemToUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) {
            try {
                _customerRepo.Delete(id);
                return Ok();
            }
            catch (DbUpdateException ex) {
                return BadRequest("This customer cannot be deleted!");
            }
            catch (KeyNotFoundException ex) {
                return BadRequest($"Customer with id {id} not found!");
            }
        }
    }
}
