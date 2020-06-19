using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityApp
{
    public partial class ShowCourses : Form
    {
        public ShowCourses()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void ShowCourses_Load(object sender, EventArgs e)
        {
            // Create object from CourseEntity to access GetCoursesTeacherStduents method
            CourseEntity courseEntity = new CourseEntity();
            // Create list to save the list returend from Get.. methond
            List<CourseEntity> crsList = courseEntity.GetCoursesTeachersStudents();
            // Show the content of course list on DataGridView
            dataGridView2.DataSource = crsList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Move back to main window (starting window)
            this.Hide();
            StartingPage strt = new StartingPage();
            strt.ShowDialog();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
