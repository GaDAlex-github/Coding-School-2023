using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_11.EF.PetShopModel {
    public class Customer : EntityBase {
        public int CustomerID { get; set; }
        public string Phone { get; set; }
        public string TIN { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        public string FullName {
            get {
                return string.Format("{0} {1}", Name, Surname);
            }
        }
        public Customer() {

        }
        // Relations
        public int PetShopID { get; set; }
        public PetShop PetShop { get; set; } = null!;
    }





}

