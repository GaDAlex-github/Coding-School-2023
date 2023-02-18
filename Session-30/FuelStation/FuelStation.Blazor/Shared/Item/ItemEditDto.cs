using FuelStation.Model.Enums;
using FuelStation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Blazor.Shared.Item {
    public class ItemEditDto {
        public int Id { get; set; }
        public int Code { get; set; }
        public string? Description { get; set; }
        public ItemType ItemType { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }

        public List<TransactionLine> TransactionLiness { get; set; } = new List<TransactionLine>();
    }
}
