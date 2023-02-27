using FuelStation.Model.Enums;

namespace FuelStation.Model {
    public class Transaction {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public decimal TotalValue { get; set; }

        // Relations
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
        public List<TransactionLine> TransactionLines { get; set; }
               
        public Transaction(PaymentMethod paymentMethod) {
            Date = DateTime.Now;
            PaymentMethod = paymentMethod;
            TotalValue = 0;
            TransactionLines = new List<TransactionLine>();
        }
    }

}
