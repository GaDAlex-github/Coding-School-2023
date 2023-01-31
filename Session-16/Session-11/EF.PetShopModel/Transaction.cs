using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Session_11.EF.PetShopModel
{
    public class Transaction : EntityBase {
        public int TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public int PetID { get; set; }
        public double PetPrice { get; set; }
        public int PetFoodID { get; set; }
        public double PetFoodQty { get; set; }
        public double PetFoodPrice { get; set; }
        public double TotalPrice { get; set; }

        public Transaction()
        {
          
        }
        public Transaction(int customerID, int employeeID, int petID, double petPrice, int petFoodID, double petFoodQty, double petFoodPrice, double totalPrice)
        {
            TransactionID = 1;
            TransactionDate = DateTime.Now;
            CustomerID = customerID;
            EmployeeID = employeeID;
            PetID = petID;
            PetPrice = petPrice;
            PetFoodID = petFoodID;
            PetFoodQty = petFoodQty;
            PetFoodPrice = petFoodPrice;
            TotalPrice = totalPrice;
        }
    }

}
