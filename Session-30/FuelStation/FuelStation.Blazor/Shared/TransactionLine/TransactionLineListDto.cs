using FuelStation.Blazor.Shared.Item;

namespace FuelStation.Blazor.Shared.TransactionLine {
    public class TransactionLineListDto {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public int Quantity { get; set; }        
        public decimal ItemPrice { get; set; }
        public decimal NetValue { get; set; }
        public int DiscountPercent { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal TotalValue { get; set; }

        public int ItemId { get; set; }
        public ItemListDto Item { get; set; } = null!;

    }
}
