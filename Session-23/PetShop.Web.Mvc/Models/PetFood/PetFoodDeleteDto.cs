using PetShop.Model.Enums;

namespace PetShop.Web.Mvc.Models.PetFood {
    public class PetFoodDeleteDto {
        public int Id { get; set; }
        public AnimalType AnimalType { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
    }
}
