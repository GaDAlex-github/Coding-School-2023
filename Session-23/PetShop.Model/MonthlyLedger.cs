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

        decimal Rent = 2000;
        decimal StaffSalary = 700;
        // Relations
        public List<Transaction> Transactions { get; set; }
        public List<Pet> Pets { get; set; }
        public List<PetFood> PetFoods { get; set; }


        public MonthlyLedger(int year, int month, decimal income, decimal expenses)
        {
            Year = year;
            Month = month;
            Income = income;
            Expenses = expenses;
            Total = income - expenses;
        }

        public string ShowMonthlyLedger()
        {
            string result = $"Year: {Year} Month: {Month} Income: {Income} Expenses: {Expenses} Total Profit: {Total}";
            return result;
        }
               
        public void CreateMonthlyLedgerReport(List<Transaction> transactions) {
            int year = DateTime.Today.Year;
            int month = DateTime.Today.Month;
            decimal income = CalculateIncome(transactions);
            decimal expenses = CalculateExpenses(transactions);
            MonthlyLedger monthlyLedger = new MonthlyLedger(year, month, income, expenses);
            monthlyLedger.ShowMonthlyLedger();


        }

        private decimal CalculateExpenses(List<Transaction> transactions) {

            decimal sumExpenses = 0;
            foreach (Transaction transaction in transactions) {
               // sumExpenses += Rent + transaction.PetFoodQty * .PetFoods.Cost + StaffSalary + Pets.Cost;
            }
            return sumExpenses;
        }

        private decimal CalculateIncome(List<Transaction> transactions) {
            decimal sumIncome = 0;
            foreach (Transaction transaction in transactions) {
                sumIncome += (transaction.PetFoodQty - 1) * transaction.PetFoodPrice + transaction.PetPrice;
            }
            return sumIncome;
        }
    }
}
