using FuelStation.Blazor.Shared.TransactionLine;
using FuelStation.Model.Enums;

namespace FuelStation.Blazor.Shared.Transaction {
    public class TransactionEditDto {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public decimal TotalValue { get; set; }

        public int CustomerId { get; set; }
        
        public int EmployeeId { get; set; }
        public List<TransactionLineListDto> TransactionLines { get; set; } = new();

    }
}
