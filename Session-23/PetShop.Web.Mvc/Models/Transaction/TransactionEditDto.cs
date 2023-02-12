namespace PetShop.Web.Mvc.Models.Transaction {
    public class TransactionEditDto {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }        
        public int EmployeeId { get; set; }        
        public int PetId { get; set; }        
        public decimal PetPrice { get; set; }
        public int PetFoodId { get; set; }        
        public int PetFoodQty { get; set; }
        public decimal PetFoodPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
