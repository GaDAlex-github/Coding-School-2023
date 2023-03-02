using FuelStation.EF.Repositories;
using FuelStation.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FuelStation.Blazor.Shared.Customer;
using System.Text.RegularExpressions;

namespace FuelStation.Blazor.Server.Controllers {

    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase {

        private readonly ICustomerRepo<Customer> _customerRepo;

        public CustomerController(ICustomerRepo<Customer> customerRepo) {
            _customerRepo = customerRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerListDto>> Get() {
            var customers = _customerRepo.GetAll();
            return customers.Select(customer => new CustomerListDto {
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
            };
        }
        [HttpPost]
        public async Task Post(CustomerEditDto customer) {
            var newCustomer = new Customer(customer.Name, customer.Surname);
            newCustomer.CardNumber = _customerRepo.CardNumberCreate();
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
