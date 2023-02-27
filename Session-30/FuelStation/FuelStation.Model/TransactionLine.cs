namespace FuelStation.Model {
    public class TransactionLine {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal NetValue { get; set; }
        public int DiscountPercent { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal TotalValue { get; set; }

        // Relations
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; } = null!;
        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;

        public TransactionLine(int quantity, decimal itemPrice, int discountPercent) {
            Quantity = quantity;
            ItemPrice = itemPrice;
            NetValue = Quantity * ItemPrice;
            DiscountPercent = discountPercent;
            DiscountValue = DiscountPercent * NetValue;
            TotalValue = NetValue - DiscountValue;
        }
    }
}
