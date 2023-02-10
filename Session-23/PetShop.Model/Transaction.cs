using System.Transactions;

namespace PetShop.Model
{
    public class Transaction : EntityBase {
        public Transaction(int customerId,int employeeId,int petId, decimal petPrice,int petFoodId, int petFoodQty, decimal petFoodPrice, decimal totalPrice)
        {
            Date = DateTime.Now;
            CustomerId = customerId;
            EmployeeId = employeeId;
            PetId = petId;
            PetPrice = petPrice;
            PetFoodId = petFoodId;
            PetFoodPrice = petFoodPrice;
            PetFoodQty = petFoodQty;
            TotalPrice = totalPrice;
        }
        // public List<Transaction> Transactions { get; set; }
     
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal PetPrice { get; set; }
        public int PetFoodQty { get; set; }
        public decimal PetFoodPrice { get; set; }
        public decimal TotalPrice { get; set; }

        // Relations
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public int PetId { get; set; }
        public Pet Pet { get; set; } = null!;

        public int PetFoodId { get; set; }
        public PetFood PetFood { get; set; } = null!;

        public decimal SetTotalPrice(Transaction transaction, decimal transTotalPrice) {
           
            //foreach (Transaction trans in Transactions)
              //  transTotalPrice += transaction.TotalPrice;
            return transTotalPrice;
        }
        
    }
}
