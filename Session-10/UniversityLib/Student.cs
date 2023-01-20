using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLib {
    public class Student : Person{
        public int RegistrationNumber { get; set; }
        public List<Courses> Courses { get; set; }

        public string UniversityName { get; set; }

        public Student(){ }

        public Student(Guid id) : base(id) { } //constructor with id Inheritance
        public Student(int registrationNumber){ 
            RegistrationNumber = registrationNumber; 
        }
        public Student(int registrationNumber,List<Courses> courses) {
            RegistrationNumber = registrationNumber;
            Courses = courses;
        }
        public void Attend(Courses course,DateTime dateTime) { }
        public void WriteExam(Courses course,DateTime dateTime) { }
    }
}
