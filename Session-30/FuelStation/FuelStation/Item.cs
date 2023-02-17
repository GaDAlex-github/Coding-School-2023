using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FuelStation.Model.Enums {
    public class Item {
        public int Id { get; set; }
        public int Code { get; set; }
        public string? Description { get; set; }
        public ItemType ItemType { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }

        // Relations
        public List<TransactionLine> TransactionLines { get; set; }

        public Item(int code, string? description, ItemType itemType, decimal price, decimal cost) {

            Code = code;
            Description = description;
            ItemType = itemType;
            Price = price;
            Cost = cost;

            TransactionLines = new List<TransactionLine>();
        }
    }
}
