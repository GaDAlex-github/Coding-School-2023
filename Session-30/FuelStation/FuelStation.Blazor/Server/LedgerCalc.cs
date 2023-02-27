using FuelStation.Blazor.Shared;
using FuelStation.Model;

namespace FuelStation.Blazor.Server {
    public class LedgerCalc {
        public List<LedgerDto> GetAllLedgers(IList<Employee> employees, IList<Transaction> transactions) {
            int startedYear = 2023;
            int startedMonth = 1;
            int monthNow = DateTime.Now.Month;
            int yearNow = DateTime.Now.Year;
            decimal income, expenses;
            List<LedgerDto> Ledgers = new();

            for (int year = startedYear; year <= yearNow; year++) {
                for (int month = 1; month <= 12; month++) {
                    if (year == startedYear && startedMonth > 1)
                        month = startedMonth;
                    if (year == yearNow && month > monthNow)
                        break;
                    income = LedgerIncome(year,month,transactions);
                    expenses = LedgerExpenses(Ledgers, employees);

                    LedgerDto ledger = new LedgerDto(year,month,income,expenses);
                    Ledgers.Add(ledger);
                }                
            }
            return Ledgers;
        }
        public decimal LedgerIncome(int year,int month, IList<Transaction> transactions) {
            decimal income = 0;
            foreach (Transaction tran in transactions) {
                int transYear = tran.Date.Year;
                int transMonth = tran.Date.Month;
                    if (transYear == year && transMonth == month) {
                        income += tran.TotalValue;
                    }
            }
            return income;
        }
        public decimal LedgerExpenses(List<LedgerDto> ledgers, IList<Employee> employees) {            
            decimal expenses = 0;
            foreach (LedgerDto ledger in ledgers) {
                foreach (Employee employee in employees)
                    expenses += employee.SalaryPerMonth;
            }
            return expenses;
        }
    }
}
