using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_11.EF.PetShopModel
{
    public class PetFood : Pet
    {
        public int PetFoodID { get; set; }
        public AnimalTypeEnum AnimalType { get; set; }

        public double PetFoodPrice { get; set; }
        public double PetFoodCost { get; set; }


        public PetFood(int petFoodID, AnimalTypeEnum animalType, double petFoodPrice, double petFoodCost)
        {
            PetFoodID = petFoodID;
            AnimalType = animalType;
            PetFoodPrice = petFoodPrice;
            PetFoodCost = petFoodCost;
        }
        public PetFood()
        {
    
        }
    }
}
