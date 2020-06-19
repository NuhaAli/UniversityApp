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
    public partial class _ٍShowTeach : Form
    {
        public _ٍShowTeach()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Move back to main window (starting window)
            this.Hide();
            StartingPage strt = new StartingPage();
            strt.ShowDialog();
        }

        private void _ٍShowTeach_Load(object sender, EventArgs e)
        {
            // Create object from TeacherEntity to access GetTeacher method
            TeacherEnitity teacherEntity = new TeacherEnitity();
            // Create new list to save the teacher list returned from GetTeacher method
            List<TeacherEnitity> techList = teacherEntity.GetTeachers();
            // Show the content of teacher list on DataGridView
            dataGridView2.DataSource = techList;

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
