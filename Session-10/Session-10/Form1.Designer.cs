namespace Session_10 {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.grvStudents = new System.Windows.Forms.DataGridView();
            this.colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUniversity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsStudents = new System.Windows.Forms.BindingSource(this.components);
            this.grvGrades = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCourse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grvCourses = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grvScheduledCourses = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.bsGrades = new System.Windows.Forms.BindingSource(this.components);
            this.bsCourses = new System.Windows.Forms.BindingSource(this.components);
            this.bsScheduledCourses = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grvStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGrades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvScheduledCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGrades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsScheduledCourses)).BeginInit();
            this.SuspendLayout();
            // 
            // grvStudents
            // 
            this.grvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumber,
            this.colName,
            this.colAge,
            this.colUniversity});
            this.grvStudents.Location = new System.Drawing.Point(12, 33);
            this.grvStudents.Name = "grvStudents";
            this.grvStudents.RowTemplate.Height = 25;
            this.grvStudents.Size = new System.Drawing.Size(776, 108);
            this.grvStudents.TabIndex = 0;
            this.grvStudents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvStudents_CellContentClick_1);
            // 
            // colNumber
            // 
            this.colNumber.DataPropertyName = "RegistrationNumber";
            this.colNumber.HeaderText = "Reg. Number";
            this.colNumber.Name = "colNumber";
            this.colNumber.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.Width = 120;
            // 
            // colAge
            // 
            this.colAge.DataPropertyName = "Age";
            this.colAge.HeaderText = "Age";
            this.colAge.Name = "colAge";
            this.colAge.Width = 60;
            // 
            // colUniversity
            // 
            this.colUniversity.DataPropertyName = "UniversityName";
            this.colUniversity.HeaderText = "University";
            this.colUniversity.Name = "colUniversity";
            this.colUniversity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colUniversity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // grvGrades
            // 
            this.grvGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvGrades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.colCourse,
            this.colGrade});
            this.grvGrades.Location = new System.Drawing.Point(12, 161);
            this.grvGrades.Name = "grvGrades";
            this.grvGrades.RowTemplate.Height = 25;
            this.grvGrades.Size = new System.Drawing.Size(776, 114);
            this.grvGrades.TabIndex = 1;
            this.grvGrades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "colStudentName";
            this.dataGridViewTextBoxColumn1.HeaderText = "Student";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // colCourse
            // 
            this.colCourse.HeaderText = "Course";
            this.colCourse.Name = "colCourse";
            // 
            // colGrade
            // 
            this.colGrade.HeaderText = "Grade";
            this.colGrade.Name = "colGrade";
            this.colGrade.ReadOnly = true;
            // 
            // grvCourses
            // 
            this.grvCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvCourses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.colSubject});
            this.grvCourses.Location = new System.Drawing.Point(12, 296);
            this.grvCourses.Name = "grvCourses";
            this.grvCourses.RowTemplate.Height = 25;
            this.grvCourses.Size = new System.Drawing.Size(776, 114);
            this.grvCourses.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "colCourse";
            this.dataGridViewTextBoxColumn4.HeaderText = "Course";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // colSubject
            // 
            this.colSubject.HeaderText = "Subject";
            this.colSubject.Name = "colSubject";
            this.colSubject.Width = 220;
            // 
            // grvScheduledCourses
            // 
            this.grvScheduledCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvScheduledCourses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.grvScheduledCourses.Location = new System.Drawing.Point(12, 441);
            this.grvScheduledCourses.Name = "grvScheduledCourses";
            this.grvScheduledCourses.RowTemplate.Height = 25;
            this.grvScheduledCourses.Size = new System.Drawing.Size(776, 114);
            this.grvScheduledCourses.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "colCourse";
            this.dataGridViewTextBoxColumn7.HeaderText = "Course";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 120;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "colProfessor";
            this.dataGridViewTextBoxColumn8.HeaderText = "Professor";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "colCalendar";
            this.dataGridViewTextBoxColumn9.HeaderText = "Calendar";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 575);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(94, 31);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(129, 575);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 31);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 630);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.grvScheduledCourses);
            this.Controls.Add(this.grvCourses);
            this.Controls.Add(this.grvGrades);
            this.Controls.Add(this.grvStudents);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGrades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCourses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvScheduledCourses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGrades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCourses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsScheduledCourses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView grvStudents;
        private BindingSource bsStudents;
        private DataGridView grvGrades;
        private DataGridView grvCourses;
        private DataGridView grvScheduledCourses;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn colCourse;
        private DataGridViewTextBoxColumn colGrade;
        private DataGridViewTextBoxColumn colNumber;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colAge;
        private DataGridViewTextBoxColumn colUniversity;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn colSubject;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private Button btnLoad;
        private Button btnSave;
        private BindingSource bsGrades;
        private BindingSource bsCourses;
        private BindingSource bsScheduledCourses;
    }
}