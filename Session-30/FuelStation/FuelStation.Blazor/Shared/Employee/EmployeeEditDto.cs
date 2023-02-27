using FuelStation.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace FuelStation.Blazor.Shared.Employee {
    public class EmployeeEditDto {
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
        [Required]
        public DateTime HireDateStart { get; set; }
        [Required]
        public DateTime HireDateEnd { get; set; }        
        [Required]
        [Range(1, 9999)]
        public int SalaryPerMonth { get; set; }
        [Required]
        [Range(0, 2)]
        public EmployeeType EmployeeType { get; set; }
        public List<FuelStation.Model.Transaction> Transactions { get; set; } = new List<FuelStation.Model.Transaction>();
    }
}
