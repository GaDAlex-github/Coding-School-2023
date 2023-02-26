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
        public async Task<List<LedgerDto>> Get() {
            List<LedgerDto> LedgerList = new();
            var employees = _employeeRepo.GetAll();
            var trans = _transactionRepo.GetAll();
            for (int i = 1; i <= 12; i++) {
                LedgerList.Add(new LedgerDto {
                    Year = 2023,
                    Month = i
                });
            }
            foreach (LedgerDto Ledger in LedgerList) {
                if (Ledger.Month <= DateTime.Now.Month) {
                    LedgerIncome(Ledger, trans);
                    LedgerExpenses(Ledger, employees);
                    Ledger.Total = Ledger.Income - Ledger.Expenses;
                }
            }
            return LedgerList;
        }

        private static void LedgerIncome(LedgerDto Ledger, IList<Transaction> transactions) {
            Ledger.Income = 0;
            foreach (Transaction tran in transactions) {
                int year = tran.Date.Year;
                int month = tran.Date.Month;
                if (Ledger.Year == year && Ledger.Month == month) {
                    Ledger.Income += tran.TotalValue;
                }
            }
        }

        private static void LedgerExpenses(LedgerDto Ledger, IList<Employee> employees) {
            var rent = 5000;
            Ledger.Expenses = rent;

            foreach (Employee employee in employees)
                Ledger.Expenses += employee.SalaryPerMonth;
        }
    }
}
