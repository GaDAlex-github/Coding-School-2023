using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_06 {
    public class Student : Person{
        public int RegistrationNumber { get; set; }
        public Courses[] Courses { get; set; }

        public Student(){ }

        public Student(Guid id) : base(id) { } //constructor with id Inheritance
        public Student(int registrationNumber){ 
            RegistrationNumber = registrationNumber; 
        }
        public Student(int registrationNumber, Courses[] courses) {
            RegistrationNumber = registrationNumber;
            Courses = courses;
        }
        public void Attend(Courses course,DateTime dateTime) { }
        public void WriteExam(Courses course,DateTime dateTime) { }
    }
}
