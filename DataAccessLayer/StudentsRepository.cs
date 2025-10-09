using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace DataAccessLayer
{
    public class StudentsRepository
    {
        private string connectionString = "Server=DESKTOP-1U0BM0H\\SQLEXPRESS;Database=Bacth11SQLQuery;User Id=sa;Password=Anaiyaan@123;";
        private readonly string Sql = "SELECT * FROM StudentDetails";
        // Create
        public bool AddStudent(StudentDetails student)
        {
                var connection = new SqlConnection(connectionString);
                var sql = "INSERT INTO StudentDetails (Name, RollNumber, Age, MobileNumber) VALUES (@Name, @RollNumber, @Age, @MobileNumber)";
                connection.Open();
                var affected = connection.Execute(sql, student);
                connection.Close();
                return affected > 0;
          
        }

        // Read all
        public List<StudentDetails> GetStudents()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var sql = "SELECT * FROM StudentDetails";
            connection.Close();
            return connection.Query<StudentDetails>(sql).ToList();
        
        }   

        // Read by ID
        public StudentDetails GetStudentByID(int id)
        {
            var connection = new SqlConnection(connectionString);

                connection.Open();
               var sql = "SELECT * FROM StudentDetails WHERE Id = @Id";
                connection.Close();
                return connection.QueryFirstOrDefault<StudentDetails>(sql, new { Id = id });
            
        }

        // Update
        public bool UpdateStudent(StudentDetails student)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "UPDATE StudentDetails SET Name=@Name, RollNumber=@RollNumber, Age=@Age, MobileNumber=@MobileNumber WHERE Id=@Id";
                connection.Open();
                var affected = connection.Execute(sql, student);
                connection.Close();
                return affected > 0;
            }
        }

        // Delete
        public bool DeleteStudent(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "DELETE FROM StudentDetails WHERE Id=@Id";
                connection.Open();
                var affected = connection.Execute(sql, new { Id = id });
                connection.Close();
                return affected > 0;
            }
        }

        // Search by name
        public List<StudentDetails> SearchStudentsByName(string name)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var sql = "SELECT * FROM StudentDetails WHERE Name LIKE @Name";
            connection.Close();
            return connection.Query<StudentDetails>(sql, new { Name = "%" + name + "%" }).ToList();
        }
    }
}
