using UniversityLib;
using System.Windows.Forms;


namespace Session_10 {
    public partial class Form1 : Form {

        List<Student> students;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

            SetControlProperties();
            PopulateStudents();

        }

        private void PopulateStudents() {

            University unis = GetUniversity();

            students = new List<Student>();

            Student student1 = new Student() {
                Name = "Dimitris",
                Age = 40,
                RegistrationNumber = 1,
                UniversityName = unis.Name
            };
            students.Add(student1);

            Student student2 = new Student() {
                Name = "Fotis",
                Age = 44,
                RegistrationNumber = 2,
                UniversityName = unis.Name
            };
            students.Add(student2);


            bsStudents.DataSource = students;
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

            //DataGridViewComboBoxColumn colGender = grvStudents.Columns["colGender"] as DataGridViewComboBoxColumn;
            //colGender.Items.Add(Student.GenderEnum.Male);
            //colGender.Items.Add(Student.GenderEnum.Female);
            //colGender.Items.Add(Student.GenderEnum.Other);

            //DataGridViewComboBoxColumn colUniversity1 = grvStudents.Columns["colUniversity"] as DataGridViewComboBoxColumn;
            //colUniversity1.DataSource = GetUniversity();
            //colUniversity1.DisplayMember = "Name";
            //colUniversity1.ValueMember = "ID";

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
    }
}