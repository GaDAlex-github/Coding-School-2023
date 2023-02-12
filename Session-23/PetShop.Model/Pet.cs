using PetShop.Model.Enums;
using System.Xml.Linq;

namespace PetShop.Model
{
    public class Pet : EntityBase {
        public Pet(string breed, AnimalType animalType, PetStatus petStatus, decimal price, decimal cost)
        {
            Breed = breed;
            AnimalType = animalType;
            PetStatus = petStatus;
            Price = price;
            Cost = cost;

            Transactions = new List<Transaction>();
        }

        public int Id { get; set; }
        public string Breed { get; set; }
        public AnimalType AnimalType { get; set; }
        public PetStatus PetStatus { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }

        public string AnimalBreed {
            get {
                return string.Format("{0} {1}",AnimalType,Breed);
            }
        }
        // Relations
        public List<Transaction> Transactions { get; set; }
    }
}
