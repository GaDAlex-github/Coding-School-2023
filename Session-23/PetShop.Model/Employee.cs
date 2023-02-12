using PetShop.Model.Enums;

namespace PetShop.Model
{
    public class Employee : EntityBase {
        public Employee(string name, string surname, EmployeeType employeeType, int salaryPerMonth)
        {
            Name = name;
            Surname = surname;
            EmployeeType = employeeType;
            SalaryPerMonth = salaryPerMonth;

            Transactions = new List<Transaction>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public int SalaryPerMonth { get; set; }

        public string FullName {
            get {
                return string.Format("{0} {1}", Name, Surname);
            }
        }
        // Relations
        public List<Transaction> Transactions { get; set; }
    }
}
