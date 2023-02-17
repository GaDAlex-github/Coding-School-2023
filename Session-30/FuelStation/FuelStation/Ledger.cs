using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Model {
    public class Ledger {
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Income { get; set; }
        public decimal Expenses { get; set; }
        public decimal Total { get; set; }


        // Relations
        public List<Transaction> Transactions { get; set; } 

        public Ledger() {

        }
        public Ledger(int year, int month) {
            Year = year;
            Month = month;
            Income = 0;
            Expenses = 0;
            Total = 0;
        }
    }
}
