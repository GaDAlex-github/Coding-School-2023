using Microsoft.AspNetCore.Mvc.Rendering;
using PetShop.Model;

namespace PetShop.Web.Mvc.Models.Transaction {
    public class TransactionCreateDto {
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public string CustomerFullName { get; set; } = null!;
        public List<SelectListItem> Customers { get; } = new List<SelectListItem>();
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public List<SelectListItem> Employees { get; } = new List<SelectListItem>();
        public int PetId { get; set; }
        public List<SelectListItem> Pets { get; } = new List<SelectListItem>();
        public decimal PetPrice { get; set; }
        public int PetFoodId { get; set; }
        public List<SelectListItem> PetFoods { get; } = new List<SelectListItem>();
        public int PetFoodQty { get; set; }
        public decimal PetFoodPrice { get; set; }
        public decimal TotalPrice { get; set; }

        
    }
}
