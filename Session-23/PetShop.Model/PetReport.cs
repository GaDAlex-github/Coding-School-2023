using PetShop.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Model {
    public class PetReport {
        public int Year { get; set; }
        public int Month { get; set; }
        public AnimalType AnimalType { get; set; }
        public int TotalSold { get; set; }
        // Relations
        public List<Transaction> Transactions { get; set; }

        public PetReport(AnimalType animalType, int totalSold) {
            int year = DateTime.Today.Year;
            int month = DateTime.Today.Month;
            AnimalType = animalType;
            TotalSold = totalSold;
        }

    }

}
