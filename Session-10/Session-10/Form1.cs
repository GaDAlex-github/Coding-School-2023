using UniversityLib;
using System.Windows.Forms;


namespace Session_10 {
    public partial class Form1 : Form {

        public University university;
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

            SetControlProperties();
            PopulateStudents();
            PopulateGrades();
            PopulateCourses();
            PopulateScheduledCourses();

        }

        private void PopulateStudents() {

            university = GetUniversity();

            Student student1 = new Student() {
                Name = "Dimitris",
                Age = 40,
                RegistrationNumber = 1
            };
            university.Students.Add(student1);

            Student student2 = new Student() {
                Name = "Fotis",
                Age = 44,
                RegistrationNumber = 2
            };
            university.Students.Add(student2);
            bsStudents.DataSource = university.Students;
        }

        private void PopulateGrades() {


            Grades grade1 = new Grades() {
                grade = 8
            };
            university.Grade.Add(grade1);

            Grades grade2 = new Grades() {
                grade = 9
            };
            university.Grade.Add(grade2);
            bsGrades.DataSource = university.Grade;
        }
        private void PopulateCourses() {


            Courses course1 = new Courses() {
                Code = "Maths"
            };
            university.Course.Add(course1);

            Courses course2 = new Courses() {
                Code = "Geography"
            };
            university.Course.Add(course2);
            bsCourses.DataSource = university.Course;
        }

        private void PopulateScheduledCourses() {


            Schedule schCourse1 = new Schedule() {
                CourseID = Guid.NewGuid()
            };
            university.ScheduledCourse.Add(schCourse1);

            Schedule schCourse2 = new Schedule() {
                CourseID = Guid.NewGuid()
            };
            university.ScheduledCourse.Add(schCourse2);
            bsScheduledCourses.DataSource = university.ScheduledCourse;
        }




        private University GetUniversity() {


            Guid id = Guid.Parse("{72F9974A-370C-4FCE-AD99-9A73FC089E60}");

            University uni1 = new University(id) {
                Name = "TeiCrete"
            };

            return uni1;
        }





        private void SetControlProperties() {

            grvStudents.AutoGenerateColumns = false;
            grvStudents.DataSource = bsStudents;

            grvGrades.AutoGenerateColumns = false;
            grvGrades.DataSource = bsGrades;

            grvCourses.AutoGenerateColumns = false;
            grvCourses.DataSource = bsCourses;

            grvScheduledCourses.AutoGenerateColumns = false;
            grvScheduledCourses.DataSource = bsScheduledCourses;


            grvStudents.CellContentClick += GrvStudents_CellContentClick;

        }

        private void GrvStudents_CellContentClick(object? sender, DataGridViewCellEventArgs e) {

            var grv = (DataGridView)sender;


            DataGridViewButtonColumn col = grv.Columns[e.ColumnIndex] as DataGridViewButtonColumn;

            if (col != null && col.Name == "colShowID" && e.RowIndex >= 0) {
                Student student = grv.CurrentRow.DataBoundItem as Student;
                MessageBox.Show($"The ID of student {student.Name} is {student.ID}");
            }
        }


        private void grvStudents_CellContentClick_1(object sender, DataGridViewCellEventArgs e) {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            Serializer serializer = new Serializer();
            university = serializer.Deserialize<University>("test.json");
        }

        private void btnSave_Click(object sender, EventArgs e) {
            Serializer serializer = new Serializer();
            serializer.SerializeToFile(university, "test.json");
        }

        private void bsGrades_CurrentChanged(object sender, EventArgs e) {

        }
    }
}