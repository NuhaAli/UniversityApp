using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace UniversityApp
{
    class DbConnection
    {
        string ConnectionString { get; set; }
        public SqlConnection con;
        public SqlCommand cmd;
        public SqlDataAdapter dataAdapter;

        public DbConnection(string _cmd) // Method to excute a query with no parametes
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["UniversityAppConnection"].ToString();
            con = new SqlConnection(ConnectionString);
            cmd = new SqlCommand(_cmd, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
           
        }

        public DbConnection(string _cmd, string sqlParameter, object parameterValue)
        // Method to excute a query with 1 paramete
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["UniversityAppConnection"].ToString();
            con = new SqlConnection(ConnectionString);
            cmd = new SqlCommand(_cmd, con);
            cmd.Parameters.AddWithValue(sqlParameter, parameterValue);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        }

        public DbConnection(string _cmd, string sqlParameter1, object parameterValue1, string sqlParameter2, object parameterValue2)
        // Method to excute a query with 2 parametes
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["UniversityAppConnection"].ToString(); 
            con = new SqlConnection(ConnectionString);
            cmd = new SqlCommand(_cmd , con);
            cmd.Parameters.AddWithValue(sqlParameter1, parameterValue1);
            cmd.Parameters.AddWithValue(sqlParameter2, parameterValue2);
            cmd.CommandType = System.Data.CommandType.StoredProcedure; 

        }


        public void FillData(DataSet dataset) // Method to fill dataset with results coming from excuting the stored procedure
        {
            dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dataset);
        }
        
    }
}
