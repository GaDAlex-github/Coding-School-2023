using FuelStation.Blazor.Client.Pages;
using FuelStation.Blazor.Client.Pages.UIs;
using FuelStation.Blazor.Shared;
using FuelStation.EF.Repositories;
using FuelStation.Model;
using Microsoft.AspNetCore.Mvc;

namespace FuelStation.Blazor.Server.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class LedgerController : ControllerBase {

        private readonly IEntityRepo<Employee> _employeeRepo;
        private readonly IEntityRepo<Transaction> _transactionRepo;

        public LedgerController(IEntityRepo<Employee> employeeRepo, IEntityRepo<Transaction> transactionRepo) {
            _employeeRepo = employeeRepo;
            _transactionRepo = transactionRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<LedgerDto>> Get() {
            List<LedgerDto> LedgerList = new();
            var employees = _employeeRepo.GetAll();
            var trans = _transactionRepo.GetAll();
            LedgerList = new LedgerCalc().GetAllLedgers(employees, trans);
            return LedgerList;
        }       
    }
}
