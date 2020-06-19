using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityApp
{
    class StudentEntity
    {

        public DataSet studentDataset;

        public SqlDataReader dr;

        public int stdId { get; set; }

        public string stdName { get; set; }

        public int crs_select_id;

        public StudentEntity()
        {
            studentDataset = new DataSet();
        }
 

        public void SetStdByName(string stdName, int crsId) // Method to insert student & courses to University data-base
        {
           
            DbConnection dbConnection = new DbConnection("spAddStudentWithCourses", "@std_name", stdName, "@crs_id" , crsId);
            dbConnection.con.Open();
            dbConnection.cmd.ExecuteNonQuery();
            dbConnection.con.Close();
            
        }


        public int GetCourseId(string courseName) // Method returned courses id from courses name in the ComboBox
        {
            // Create object of DbConnection class & pass stored procedure in with parameters 
            DbConnection dbConnection = new DbConnection("spGetCourseId", "@crs_name", courseName);
            dbConnection.con.Open();
            SqlDataReader dr = dbConnection.cmd.ExecuteReader();


            // looking for the id of selected course
            while (dr.Read())
            {
                crs_select_id = dr.GetInt32(0);
            }

            // closing reader connection before second query
            dbConnection.con.Close();
            // Return selected course id
            return crs_select_id;
        }



        public List<StudentEntity> GetStudents() // Method to get all members in students table
        {
            // Strat connection with database & excute the stored procedure
            DbConnection dbConnection = new DbConnection("spShowStudents");
            dbConnection.con.Open();
            dbConnection.cmd.ExecuteNonQuery();
            // Pass dataset to be filled
            dbConnection.FillData(studentDataset);

            // Create list to add each student information in
            List<StudentEntity> stdList = new List<StudentEntity>();

            foreach (DataRow dr in studentDataset.Tables[0].Rows)
            {
                // In each iteration create a new obj of student, add values, then push to list
                StudentEntity currentStd = new StudentEntity();
                currentStd.stdId = (int)dr[0];
                currentStd.stdName = (string)dr[1];
                stdList.Add(currentStd); // .Add(StudentEntity);
            }

            //Close connection with data-base
            dbConnection.con.Close();
            // return the list of students
            return stdList;
        }

    }
}
