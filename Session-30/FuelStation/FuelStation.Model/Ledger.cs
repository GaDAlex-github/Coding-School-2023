namespace FuelStation.Model {
    public class Ledger {
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Income { get; set; }
        public decimal Expenses { get; set; }
        public decimal Total { get; set; }


        // Relations
        public List<Transaction> Transactions { get; set; } 

        public Ledger() {

        }
        public Ledger(int year, int month,decimal income, decimal expenses) {
            Year = year;
            Month = month;
            Income = income;
            Expenses = expenses;
            Total = Income - Expenses;
        }
    }
}
