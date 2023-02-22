using FuelStation.Model;
using FuelStation.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Blazor.Shared.Item {
    public class ItemListDto {
        public int Id { get; set; }
        public int Code { get; set; }
        public string? Description { get; set; }
        public ItemType ItemType { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }

        public List<FuelStation.Model.TransactionLine> TransactionLiness { get; set; } = new List<FuelStation.Model.TransactionLine>();
    }
}
