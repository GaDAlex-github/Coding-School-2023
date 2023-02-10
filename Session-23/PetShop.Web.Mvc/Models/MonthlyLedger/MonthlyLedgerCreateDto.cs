namespace PetShop.Web.Mvc.Models.MonthlyLedger {
    public class MonthlyLedgerCreateDto {

        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Income { get; set; }
        public decimal Expenses { get; set; }
        public decimal Total { get; set; }
    }
}
