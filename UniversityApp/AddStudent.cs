using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.ComponentModel.Design;

namespace UniversityApp
{
    public partial class AddStudent : Form
    {
        
        public AddStudent()
        {
            InitializeComponent();
            // Create obj from courseEntity to call FillCourses method
            CourseEntity courseEntity = new CourseEntity();
            // Method to fill courses comboBox once page loaded
            coursesComboBox.DataSource = courseEntity.FillCoursesComboBox(); 
        }


        private void AddStudent_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // create object from student entity
            StudentEntity studentEntity = new StudentEntity();
            // Get course id to inesrt it to database
            int crsId = studentEntity.GetCourseId(coursesComboBox.Text);
            // Passing student name to the object along with course id
            studentEntity.SetStdByName(txtStdName.Text, crsId);
            // Confirm to user
            MessageBox.Show("Student added successfully!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Move back to main window (starting window)
            this.Hide();
            StartingPage strt = new StartingPage();
            strt.ShowDialog();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
  
    }
}
