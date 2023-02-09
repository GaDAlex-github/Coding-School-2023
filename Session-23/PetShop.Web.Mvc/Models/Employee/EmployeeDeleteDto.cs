using PetShop.Model.Enums;

namespace PetShop.Web.Mvc.Models.Employee {
    public class EmployeeDeleteDto {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public EmployeeType EmployeeType { get; set; }
        public int SalaryPerMonth { get; set; }
    }
}
