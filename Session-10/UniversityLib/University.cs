using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLib {
    public class University : Institute{
        public Student[] Students { get; set; }
        public Courses[] Course { get; set; }
        public Grades[] Grade { get; set; }
        public Schedule[] ScheduledCourse { get; set; }

        public University() {  }

        public University(Guid id): base(id) { } //constructor with id Inheritance
        public University(Student[] student) {
            Students = student;
        }
        public University(Student[] student, Courses[] course) {
            Students = student;
            Course = course;
        }
        public University(Student[] student, Courses[] courses, Grades[] grade) {
            Students = student;
            Course = courses;
            Grade = grade;
        }
        public University(Student[] student, Courses[] courses, Grades[] grade, Schedule[] schedules) {
            Students = student;
            Course = courses;
            Grade = grade;
            ScheduledCourse = schedules;
        }
    public void GetStudents() { }
    public void GetCourses() { }
    public void GetGrades() { }
    public void SetSchedule(Courses courseID,Professor ProfessorID,DateTime datetime) { }

    
    }
}
