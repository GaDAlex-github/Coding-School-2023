﻿using FuelStation.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace FuelStation.Blazor.Shared.Item {
    public class ItemEditDto {
        public int Id { get; set; }        
        public string? Code { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Max 15 Characters.")]
        public string? Description { get; set; }
        [Required]
        [Range(0, 2)]
        public ItemType ItemType { get; set; }        
        [Required]
        [Range(1, 99999)]
        public decimal Price { get; set; }
        [Required]
        [Range(1, 99999)]        
        public decimal Cost { get; set; }
    }
}
