using FuelStation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Blazor.Shared.Customer {
    public class CustomerListDto {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string FullName {
            get {
                return string.Format("{0} {1}", Name, Surname);
            }
        }
        public string? CardNumber { get; set; }

        public List<FuelStation.Model.Transaction> Transactions { get; set; } = new List<FuelStation.Model.Transaction>();

       
    }
}
