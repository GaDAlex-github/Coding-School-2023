using PetShop.Model.Enums;

namespace PetShop.Web.Mvc.Models.Pet {
    public class PetDeleteDto {
        public int Id { get; set; }
        public string Breed { get; set; } = null!;
        public AnimalType AnimalType { get; set; }
        public PetStatus PetStatus { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
    }
}
