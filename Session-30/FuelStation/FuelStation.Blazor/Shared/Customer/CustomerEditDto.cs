using System.ComponentModel.DataAnnotations;

namespace FuelStation.Blazor.Shared.Customer {
    public class CustomerEditDto {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "Name must have max length 50 letters.")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "The Name field can only contain Latin letters ")]
        [Required]
        public string? Name { get; set; }
        [MaxLength(50, ErrorMessage = "Name must have max length 50 letters.")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "The Surname field can only contain Latin letters ")]
        [Required]
        public string? Surname { get; set; }
        public string FullName {
            get {
                return string.Format("{0} {1}", Name, Surname);
            }
        }
        public string? CardNumber { get; set; }
        public List<FuelStation.Model.Transaction> Transactions { get; set; } = new List<FuelStation.Model.Transaction>();
    }
}

