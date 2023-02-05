using EF.PetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_11.EF.PetShopModel {
    public class PetFood : EntityBase {
        public enum AnimalTypeEnum {
            Bird,
            Cat,
            Dog,
            None
        }
        public AnimalTypeEnum AnimalType { get; set; }
        public double PetFoodPrice { get; set; }
        public double PetFoodCost { get; set; }


        public PetFood(AnimalTypeEnum animalType, double petFoodPrice, double petFoodCost) {
            AnimalType = animalType;
            PetFoodPrice = petFoodPrice;
            PetFoodCost = petFoodCost;
        }
        public PetFood() {

        }
        // Relations
        public int PetShopID { get; set; }
        public PetShop PetShop { get; set; } = null!;
    }
}
