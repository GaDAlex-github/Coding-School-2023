using EF.PetShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_11.EF.PetShopModel
{
    public class Employee : EntityBase {
        public string Name { get; set; }
        public string Surname { get; set; }
        public enum EmployeeTypeEnum
        {
            Manager,
            Staff
        }
        public double SalaryPerMonth { get; set; }
        public EmployeeTypeEnum EmployeeType { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", Name, Surname);
            }
        }

        public Employee()
        {
   
        }

        // Relations
        public int PetShopID { get; set; }
        public PetShop PetShop { get; set; } = null!;
        //public List<Transaction> Transactions { get; set; }


    }
}
