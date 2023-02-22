using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Blazor.Shared.TransactionLine {
    public class TransactionLineEditDto {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public decimal Quantity { get; set; }    
        public decimal ItemPrice { get; set; }
        public decimal NetValue { get; set; }
        public decimal DisountPercent { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal TotalValue { get; set; }

        public int ItemId { get; set; }
        public List<TransactionLineListDto> TransactionLines { get; set; } = new();
    }
}
