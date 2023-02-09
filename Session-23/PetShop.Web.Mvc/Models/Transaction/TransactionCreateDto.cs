namespace PetShop.Web.Mvc.Models.Transaction {
    public class TransactionCreateDto {
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        //public Customer Customer { get; set; } = null!;
        public int EmployeeId { get; set; }
       // public Employee Employee { get; set; } = null!;
        public int PetId { get; set; }
       // public Pet Pet { get; set; } = null!;
        public decimal PetPrice { get; set; }
        public int PetFoodId { get; set; }
       // public PetFood PetFood { get; set; } = null!;
        public int PetFoodQty { get; set; }
        public decimal PetFoodPrice { get; set; }
        public decimal TotalPrice { get; set; }       
    
    }
}
