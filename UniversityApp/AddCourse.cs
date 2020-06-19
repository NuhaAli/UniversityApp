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
    public partial class AddCourse : Form
    {
        
        public AddCourse()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }
        public void connectDB()
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // create object from CourseEntity
            CourseEntity courseEntity = new CourseEntity();
            // Passing course name to the object 
            courseEntity.SetCrsByName(txtCrsName.Text);
            // Confirm to user
            MessageBox.Show("Course added successfully!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Move back to main window (starting window)
            this.Hide();
            StartingPage strt = new StartingPage();
            strt.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddCourse_Load(object sender, EventArgs e)
        {

        }
    }
}
