using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLib {
    public class University : Institute {
        public List<Student> Students { get; set; }
        public List<Courses> Course { get; set; }
        public List<Grades> Grade { get; set; }
        public List<Schedule> ScheduledCourse { get; set; }

        public University(Guid id) : base(id) {
            Students = new List<Student>();
        }
        public University() {
            Students = new List<Student>();
        }


        public University(List<Student> student, List<Courses> courses, List<Grades> grade, List<Schedule> schedules) {
            Students = student;
            Course = courses;
            Grade = grade;
            ScheduledCourse = schedules;
        }
        public void GetStudents() { }
        public void GetCourses() { }
        public void GetGrades() { }
        public void SetSchedule(Courses courseID, Professor ProfessorID, DateTime datetime) { }


    }
}
