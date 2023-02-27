using FuelStation.Blazor.Shared.Customer;
using FuelStation.Blazor.Shared.Employee;
using FuelStation.Blazor.Shared.TransactionLine;
using FuelStation.Model.Enums;

namespace FuelStation.Blazor.Shared.Transaction {
    public class TransactionListDto
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
		public PaymentMethod PaymentMethod { get; set; }
		public decimal TotalValue { get; set; }

		public int CustomerId { get; set; }
        public CustomerListDto Customer { get; set; } = null!;
        public int EmployeeId { get; set; }
        public EmployeeListDto Employee { get; set; } = null!;
        public List<TransactionLineListDto> TransactionLines { get; set; } = new();

    }
}
