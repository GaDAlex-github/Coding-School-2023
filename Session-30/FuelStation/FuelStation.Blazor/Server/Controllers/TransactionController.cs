using FuelStation.Blazor.Client.Pages.UIs;
using FuelStation.Blazor.Shared.Customer;
using FuelStation.Blazor.Shared.Employee;
using FuelStation.Blazor.Shared.Transaction;
using FuelStation.Blazor.Shared.TransactionLine;
using FuelStation.EF.Repositories;
using FuelStation.Model;
using FuelStation.Model.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FuelStation.Blazor.Server.Controllers {

    [Route("[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase {

        private readonly IEntityRepo<Transaction> _transactionRepo;
        private readonly IEntityRepo<Customer> _customerRepo;
        private readonly IEntityRepo<Employee> _employeeRepo;

        public TransactionController(IEntityRepo<Transaction> transactionRepo, IEntityRepo<Customer> customerRepo, IEntityRepo<Employee> employeeRepo) {
            _transactionRepo = transactionRepo;
            _customerRepo = customerRepo;
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<TransactionListDto>> Get() {
            var transactions = _transactionRepo.GetAll();
            var transactionList = transactions.Select(transaction => new TransactionListDto {
                Id = transaction.Id,
                Date = transaction.Date,
                PaymentMethod = transaction.PaymentMethod,
                TotalValue = transaction.TotalValue,
                CustomerId = transaction.CustomerId,
                EmployeeId = transaction.EmployeeId,
                Customer = new CustomerListDto() {
                    Id = transaction.Customer.Id,
                    Name = transaction.Customer.FullName
                },
                Employee = new EmployeeListDto() {
                    Id = transaction.Employee.Id,
                    Name = transaction.Customer.FullName
                },
            });
            return transactionList;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id) {
            _transactionRepo.Delete(id);
        }

        [HttpPost]
        public async Task Post(TransactionEditDto transaction) {
            var newTransaction = new Transaction(transaction.PaymentMethod);
            newTransaction.CustomerId = transaction.CustomerId;
            newTransaction.EmployeeId = transaction.EmployeeId;
            newTransaction.TotalValue = 0;
            newTransaction.TransactionLines = new();
            _transactionRepo.Add(newTransaction);
        }

        [HttpPut]
        public async Task Put(TransactionEditDto transaction) {
            var transactionUpdate = _transactionRepo.GetById(transaction.Id);
            transactionUpdate.CustomerId = transaction.CustomerId;
            transactionUpdate.EmployeeId = transaction.EmployeeId;
            transactionUpdate.PaymentMethod = transaction.PaymentMethod;
            transactionUpdate.TotalValue = transaction.TotalValue;
            _transactionRepo.Update(transaction.Id, transactionUpdate);
        }

        [HttpGet("{id}")]
        public async Task<TransactionEditDto> GetById(int id) {

            var transactions = _transactionRepo.GetById(id);
            var customers = _customerRepo.GetAll();
            var employees = _employeeRepo.GetAll();
            var transaction = new TransactionEditDto {
                Id = id,
                Date = transactions.Date,
                CustomerId = transactions.CustomerId,
                EmployeeId = transactions.EmployeeId,
                PaymentMethod = transactions.PaymentMethod,
                TotalValue = transactions.TotalValue,                
                TransactionLines = transactions.TransactionLines.Select(transactionLine => new TransactionLineListDto {
                    Id = transactionLine.Id,
                    TransactionId = transactionLine.TransactionId,
                    ItemId = transactionLine.ItemId,
                    Quantity = transactionLine.Quantity,
                    ItemPrice = transactionLine.ItemPrice,
                    NetValue = transactionLine.NetValue,
                    DiscountPercent = transactionLine.DiscountPercent,
                    DiscountValue= transactionLine.DiscountValue,
                    TotalValue = transactionLine.TotalValue
                }).ToList()
            };
            return transaction;
        }
    }
}
