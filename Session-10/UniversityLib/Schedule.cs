using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLib {
    public class Schedule {
        public Guid ID { get; set; }
        public Guid CourseID { get; set; }
        public Guid ProfessorID { get; set; }
        public DateTime Callendar { get; set; }

        public Schedule() { }
        public Schedule(Guid id) {
            ID = id;
        }
        public Schedule(Guid id,Guid courseID) {
            ID = id;
            CourseID = courseID;
        }
        public Schedule(Guid id,Guid courseID,Guid professorID) {
            ID = id;
            CourseID = courseID;
            ProfessorID = professorID;
        }
        public Schedule(Guid id, Guid courseID, Guid professorID, DateTime callendar) {
            ID = id;
            CourseID = courseID;
            ProfessorID = professorID;
            Callendar = callendar;
        }
    }
}
