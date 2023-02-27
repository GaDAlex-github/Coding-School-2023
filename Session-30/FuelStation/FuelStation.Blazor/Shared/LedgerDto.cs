namespace FuelStation.Blazor.Shared {
    public class LedgerDto {

        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Income { get; set; }
        public decimal Expenses { get; set; }
        public decimal Total { get; set; }

        public List<FuelStation.Model.Employee> Employees { get; set; } = new List<FuelStation.Model.Employee>();
       
        public LedgerDto(int year, int month, decimal income, decimal expenses) {
            Year = year;
            Month = month;
            Income = income;
            Expenses = expenses;
            Total = Income - Expenses;
        }
    }
}

