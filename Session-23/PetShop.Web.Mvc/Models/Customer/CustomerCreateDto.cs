using System.ComponentModel.DataAnnotations;

namespace PetShop.Web.Mvc.Models.Customer {
    public class CustomerCreateDto {
        //[MaxLength(10, ErrorMessage = "")]
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Tin { get; set; } = null!;
    }
}
