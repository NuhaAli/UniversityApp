using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp
{
    class CourseEntity
    {
        public DataSet coursesDataset;

        public SqlDataReader dr;

        public string crsName { get; set; }

        public string techName { get; set; }

        public string stdName { get; set; }


        public CourseEntity()
        {
            coursesDataset = new DataSet();
        }


        public void SetCrsByName(string crsName) // Method to insert course by name to University data-base
        {
            DbConnection dbConnection = new DbConnection("spAddCourse", "@crs_name", crsName);
            dbConnection.con.Open();
            dbConnection.cmd.ExecuteNonQuery();
            dbConnection.con.Close();

        }


        public List<CourseEntity> GetCoursesTeachersStudents() // Method to show all courses with techers & students registered in
        {
            // Strat connection with database & excute the query
            DbConnection dbConnection = new DbConnection("GetCoursesTeachersStudents");
            dbConnection.con.Open();
            dbConnection.cmd.ExecuteNonQuery();
            // Pass dataset to be filled
            dbConnection.FillData(coursesDataset);
            // Create list of courses type to push the result in
            List<CourseEntity> crsList = new List<CourseEntity>();

            foreach (DataRow dr in coursesDataset.Tables[0].Rows)
            {
                // In each iteration push courses, teachers, students to list
                CourseEntity currenEnt = new CourseEntity();
                currenEnt.crsName = (string)dr[0];
                currenEnt.techName = (string)dr[1].ToString();
                currenEnt.stdName = (string)dr[2].ToString();
                crsList.Add(currenEnt); 
            }

            // Close connection before moving to another query
            dbConnection.con.Close();
            // return the list of students
            return crsList;
        }

        public List<string> FillCoursesComboBox() // Method to fill courses comboBox in AddStudent/AddTeacher pages
        {
            // Create connection object & pass the procedure of show courses(query)
            DbConnection dbConnection = new DbConnection("spListCourses");
            dbConnection.con.Open();
            // initialize data reader & excute stored procedure
            dr = dbConnection.cmd.ExecuteReader();

            // Create list to add courses in
            List<string> coursesList = new List<string>();

            while (dr.Read())
            {
                // Add each course to courses list
                coursesList.Add(dr.GetString(1));
            }

            // close connection after getting courses names
            dbConnection.con.Close();
            // Return courses list to fill the courses comboBox
            return coursesList;
        }
    }
}
