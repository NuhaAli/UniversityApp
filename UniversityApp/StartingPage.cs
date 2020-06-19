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
    public partial class StartingPage : Form
    {


        public StartingPage()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Go to show students page
            this.Hide();
            ShowStudents std = new ShowStudents();
            std.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Go to show courses page
            this.Hide();
            ShowCourses crs = new ShowCourses();
            crs.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Go to show teachers page
            this.Hide();
            _ٍShowTeach tech = new _ٍShowTeach();
            tech.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Go to add students page
            this.Hide();
            AddStudent addstd = new AddStudent();
            addstd.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Go to add teacher page
            this.Hide();
            AddTeacher addtech = new AddTeacher();
            addtech.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Go to add courses page
            this.Hide();
            AddCourse addcrs = new AddCourse();
            addcrs.ShowDialog();
        }

        private void StartingPage_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
