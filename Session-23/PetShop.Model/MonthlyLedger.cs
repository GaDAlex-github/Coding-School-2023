//using DevExpress.CodeParser;
//using DevExpress.XtraRichEdit.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Schema;

namespace PetShop.Model {
    public class MonthlyLedger
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Income { get; set; }
        public decimal Expenses { get; set; }
        public decimal Total { get; set; }

        
        // Relations
        public List<Transaction> Transactions { get; set; }
        public List<Pet> Pets { get; set; }
        public List<PetFood> PetFoods { get; set; }


        public MonthlyLedger(decimal income, decimal expenses)
        {
            int year = DateTime.Today.Year;
            int month = DateTime.Today.Month;
            Income = income;
            Expenses = expenses;
            Total = income - expenses;
        }

        
    }
}
