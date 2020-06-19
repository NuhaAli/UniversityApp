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
    public partial class ShowStudents : Form
    {
        public ShowStudents()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void ShowStudents_Load(object sender, EventArgs e)
        {
            // Create object from StudentEntity to access GetStudent method
            StudentEntity studentEntity = new StudentEntity();
            // Create new list to save the students list returned from GetStudents method
            List<StudentEntity> stdList = studentEntity.GetStudents();
            // Show the content of student list on DataGridView
            dataGridView1.DataSource = stdList;
        }

     
        private void button2_Click(object sender, EventArgs e)
        {
            // Move back to main window (starting window)
            this.Hide();
            StartingPage strt = new StartingPage();
            strt.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
