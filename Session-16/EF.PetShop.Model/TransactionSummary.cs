using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_11.EF.PetShopModel
{
    public class TransactionSummary
    {

        public int TransactionID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public double PetPrice { get; set; }
        public double PetFoodPrice { get; set; }
        public int PetID { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public int PetFoodID { get; set; }

    }
}
