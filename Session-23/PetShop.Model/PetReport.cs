using PetShop.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Model {
    public class PetReport
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public AnimalType AnimalType { get; set; }
        public int TotalSold { get; set; }
        // Relations
        public List<Transaction> Transactions { get; set; }

        public PetReport(int year, int month, AnimalType animalType, int totalSold)
        {
            Year = year;
            Month = month;
            AnimalType = animalType;
            TotalSold = totalSold;
        }

        public string ShowPetReport(AnimalType animalType, int totalSold)
        {
            string result = $"Year: {Year} Month: {Month} Animal Type: {animalType} Total Sold: {totalSold}";
            return result;
        }


        public List<string> CreatePetReport(List<Transaction> transactions, List<Pet> pets)
        {
            int totalBirdsSold = 0;
            int totalMammalsSold = 0;
            int totalReptilesSold = 0;
            int totalFishesSold = 0;
            foreach (Transaction transaction in transactions)
            {
                foreach (Pet pet in pets)
                {
                    switch (pet.AnimalType)
                    {
                        case AnimalType.Bird:
                            totalBirdsSold++;
                            break;
                        case AnimalType.Mammal:
                            totalMammalsSold++;
                            break;
                        case AnimalType.Reptile:
                            totalReptilesSold++;
                            break;
                        case AnimalType.Fish:
                            totalFishesSold++;
                            break;
                        default:
                           // MessageBox.Show("Invalid Animal Type");
                            break;
                    }
                }
            }
            List<string> petReport = new List<string>();
            petReport.Add(ShowPetReport(AnimalType.Bird, totalBirdsSold));
            petReport.Add(ShowPetReport(AnimalType.Mammal, totalMammalsSold));
            petReport.Add(ShowPetReport(AnimalType.Reptile, totalReptilesSold));
            petReport.Add(ShowPetReport(AnimalType.Fish, totalFishesSold));

            return petReport;
        }


    }

}
