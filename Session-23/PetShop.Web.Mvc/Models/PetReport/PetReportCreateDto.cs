using PetShop.Model.Enums;

namespace PetShop.Web.Mvc.Models.PetReport {
    public class PetReportCreateDto {
        public int Year { get; set; }
        public int Month { get; set; }
        public AnimalType AnimalType { get; set; }
        public int TotalSold { get; set; }
    }
}
