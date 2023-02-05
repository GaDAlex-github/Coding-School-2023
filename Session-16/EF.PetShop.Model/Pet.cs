using EF.PetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_11.EF.PetShopModel {
    public class Pet : EntityBase {
        public enum AnimalTypeEnum {
            Bird,
            Cat,
            Dog,
            None
        }
        public enum PetStatusEnum {
            OK,
            Unhealthy,
            Recovering
        }
        public AnimalTypeEnum AnimalType { get; set; }
        public string Breed { get; set; }
        public PetStatusEnum Status { get; set; }
        public double Price { get; set; }
        public double Cost { get; set; }


        public string AnimalBreed {
            get {
                return string.Format("{0} {1}", AnimalType, Breed);
            }
        }

        // Relations
        public int PetShopID { get; set; }
        public PetShop PetShop { get; set; } = null!;


        public Pet() {

            switch (AnimalType) {

                case AnimalTypeEnum.Cat:
                    Price = 100;
                    break;
                case AnimalTypeEnum.Dog:
                    Price = 120;
                    break;
                case AnimalTypeEnum.Bird:
                    Price = 200;
                    break;


            }
        }



        public Pet(string breed, AnimalTypeEnum animalType, PetStatusEnum status, double price, double cost) {
            Breed = breed;
            AnimalType = animalType;
            Status = status;
            Price = price;
            Cost = cost;
        }

    }
}

