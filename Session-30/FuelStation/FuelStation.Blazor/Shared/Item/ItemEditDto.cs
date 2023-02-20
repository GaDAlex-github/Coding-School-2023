﻿using FuelStation.Model.Enums;
using FuelStation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FuelStation.Blazor.Shared.Item {
    public class ItemEditDto {
        public int Id { get; set; }
        public int Code { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "The Description field can only contain Latin letters and digits")]
        [Required]
        public string? Description { get; set; }
        [Required]
        public ItemType ItemType { get; set; }
        [RegularExpression(@"[-+]?(\d{1,10}(\.\d{2})?)", ErrorMessage = "The Price field can only contain 2 decimals ")]
        [Required]
        public decimal Price { get; set; }
        [RegularExpression(@"[-+]?(\d{1,10}(\.\d{2})?)", ErrorMessage = "The Cost field can only contain 2 decimals ")]
        [Required]
        public decimal Cost { get; set; }

        public List<TransactionLine> TransactionLiness { get; set; } = new List<TransactionLine>();
    }
}