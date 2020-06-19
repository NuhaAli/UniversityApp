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

namespace UniversityApp
{
  
    public partial class AddTeacher : Form
    {
        
        public AddTeacher()
        {
            InitializeComponent();
            // Create obj from courseEntity to call FillCourses method
            CourseEntity courseEntity = new CourseEntity();
            // Method to fill courses comboBox once page loaded
            coursesComboBox.DataSource = courseEntity.FillCoursesComboBox();
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void AddTeacher_Load(object sender, EventArgs e)
        {
            
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddTeacher_Load_1(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // create object from TeacherEntity
            TeacherEnitity tachertEntity = new TeacherEnitity();
            // Get course id to inesrt it to database
            int crsId = tachertEntity.GetCourseId(coursesComboBox.Text);
            // Passing teacher name to the object along with course id
            tachertEntity.SetTchByName(txtTchName.Text, crsId);
            // Confirm to user
            MessageBox.Show("Teacher added successfully!");          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Move back to main window (starting window)
            this.Hide();
            StartingPage strt = new StartingPage();
            strt.ShowDialog();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
