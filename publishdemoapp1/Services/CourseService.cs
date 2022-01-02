using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using publishdemoapp1.Models;

namespace publishdemoapp1.Services
{
    public class CourseService
    {
        // Ensure to change the below variables to reflect the connection details for your database
        private static string db_source = "dbserver10012.database.windows.net";
        private static string db_user = "rameshmutta";
        private static string db_password = "Ramesh@3125$$";
        private static string db_database = "demodatabase1";

        private SqlConnection GetConnection(string _connectionString)
        {
            // Here we are creating the SQL connection
            //var _builder = new SqlConnectionStringBuilder();
            //_builder.DataSource = db_source;
            //_builder.UserID = db_user;
            //_builder.Password = db_password;
            //_builder.InitialCatalog = db_database;
            return new SqlConnection(_connectionString);
        }

        public IEnumerable<Course> GetCourses(string _connectionString)
        {
            List<Course> _lst = new List<Course>();
            string _statement = "SELECT CourseId,Name_Course,Rating from appdemocoursetbl";
            SqlConnection _connection = GetConnection(_connectionString);
            // Let's open the connection
            _connection.Open();
            // We then construct the statement of getting the data from the Course table
            SqlCommand _sqlcommand = new SqlCommand(_statement, _connection);
            // Using the SqlDataReader class , we will read all the data from the Course table
            using (SqlDataReader _reader = _sqlcommand.ExecuteReader())
            {
                while (_reader.Read())
                {
                    Course _course = new Course()
                    {
                        CourseID = _reader.GetInt32(0),
                        CourseName = _reader.GetString(1),
                        Rating = _reader.GetDecimal(2)
                    };

                    _lst.Add(_course);
                }
            }
            _connection.Close();
            return _lst;
        }

    
}
}
