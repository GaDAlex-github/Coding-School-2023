using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FuelStation.Model {
    public class Customer {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string FullName {
            get {
                return string.Format("{0} {1}", Name, Surname);
            }
        }
        public string? CardNumber { get; set; }

        // Relations
        public List<Transaction> Transactions { get; set; }

        public Customer() {

        }
        public Customer(string name, string surname) {
            Name = name;
            Surname = surname;
            
            Transactions = new List<Transaction>();
        }
    }
}
