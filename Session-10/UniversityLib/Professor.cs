using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLib {
    public class Professor : Person {
        public string? Rank { get; set; }
        public Courses[] Courses { get; set; }

        public Professor() { }
        public Professor(Guid id) : base(id){ } //constructor with id Inheritance
        public Professor(string? rank){
            Rank = rank;
        }
        public Professor(string? rank, Courses[] courses){
            Rank = rank;
            Courses = courses;
        }

        public void Teach(Courses course,DateTime datetime) { }
        public void SetGrade(Guid studentID, Guid courserID,Grades grade) { }
        public void GetName() { }
    }
}
