using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp
{
    class TeacherEnitity
    {
        public DataSet teacherDataset;

        public SqlDataReader dr;

        public int tchId { get; set; }

        public string tchName { get; set; }

        public int crs_select_id;

        public TeacherEnitity()
        {
            teacherDataset = new DataSet();
        }


        public void SetTchByName(string tchName, int crsId) // Method to insert teacher & courses to University data-base
        {
            DbConnection dbConnection = new DbConnection("spAddTeacherWithCourses", "@tech_name", tchName, "@crs_id", crsId);
            dbConnection.con.Open();
            dbConnection.cmd.ExecuteNonQuery();
            dbConnection.con.Close();

        }


        public int GetCourseId(string courseName) // Method returned courses id from courses name in the ComboBox
        {
            // Create object of DbConnection class & excute the stored procedure
            DbConnection dbConnection = new DbConnection("spGetCourseId", "@crs_name", courseName);
            dbConnection.con.Open();
            SqlDataReader dr = dbConnection.cmd.ExecuteReader();


            // looking for the index of selected item
            while (dr.Read())
            {
                crs_select_id = dr.GetInt32(0);
            }
            // closing reader connection before second query
            dbConnection.con.Close();
            // Return selected course id
            return crs_select_id;
        }



        public List<TeacherEnitity> GetTeachers() // Method to get all members in students table
        {
            // Strat connection with database
            DbConnection dbConnection = new DbConnection("spShowTeachers");
            dbConnection.con.Open();
            //DataSet dataSet = new DataSet();
            dbConnection.cmd.ExecuteNonQuery();
            dbConnection.FillData(teacherDataset);
            // Create list to add teachers in
            List<TeacherEnitity> tchList = new List<TeacherEnitity>();

            // Loop to add teachers to the list
            foreach (DataRow dr in teacherDataset.Tables[0].Rows)
            {
                // In each iteration create a new obj of teacher, add values, then push to list
                TeacherEnitity currentTech = new TeacherEnitity();
                currentTech.tchId = (int)dr[0];
                currentTech.tchName = (string)dr[1];
                tchList.Add(currentTech); 
            }

            //Close connection with data-base
            dbConnection.con.Close();
            // return the list of teachers
            return tchList;
        }
    }
}
