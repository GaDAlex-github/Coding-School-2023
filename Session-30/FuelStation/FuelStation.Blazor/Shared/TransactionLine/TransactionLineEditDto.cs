using FuelStation.Blazor.Shared.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Blazor.Shared.TransactionLine {
    public class TransactionLineEditDto {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public int Quantity { get; set; }    
        public decimal ItemPrice { get; set; }
        public decimal NetValue { get; set; }
        public int DiscountPercent { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal TotalValue { get; set; }

        public int ItemId { get; set; }
        public List<ItemListDto> Items { get; set; } = null!;
        public List<TransactionLineListDto> TransactionLines { get; set; } = new();
    }
}
