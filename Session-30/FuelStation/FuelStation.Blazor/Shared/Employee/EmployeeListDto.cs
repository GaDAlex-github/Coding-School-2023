using FuelStation.Model;
using FuelStation.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Blazor.Shared.Employee {
    public class EmployeeListDto {
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

        public List<FuelStation.Model.Transaction> Transactions { get; set; } = new List<FuelStation.Model.Transaction>();
    }
}
