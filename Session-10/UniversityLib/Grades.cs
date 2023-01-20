using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLib {
    public class Grades {
        public Guid ID { get; set; }
        public Guid StudentID { get; set; }
        public Guid CourseID { get; set; }
        public int grade { get; set; }

        public Grades() { }
        public Grades(Guid id) { ID = id; }
        public Grades(Guid id, Guid studentID) { 
            ID = id; 
            StudentID = studentID; 
        }

        public Grades(Guid id, Guid studentID, Guid courseID) {
            ID = id;
            StudentID = studentID;
            CourseID = courseID;
        }
        public Grades(Guid id, Guid studentID, Guid courseID, int grades) {
            ID = id;
            StudentID = studentID;
            CourseID = courseID;
            grade = grades;
        }


    }
}
