using FuelStation.Model.Enums;

namespace FuelStation.Model {
    public class Employee {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string FullName {
            get {
                return string.Format("{0} {1}", Name, Surname);
            }
        }
        public DateTime HireDateStart { get; set; }
        public DateTime HireDateEnd { get; set; }
        public int SalaryPerMonth { get; set; }
        public EmployeeType EmployeeType { get; set; }


        // Relations
        public List<Transaction> Transactions { get; set; }

        public Employee(string name, string surname, int salaryPerMonth,EmployeeType employeeType ) {
            HireDateStart = DateTime.Now;
            Name = name;
            Surname = surname;
            SalaryPerMonth = salaryPerMonth;
            EmployeeType = employeeType;

            Transactions = new List<Transaction>();
        }
    }
}
