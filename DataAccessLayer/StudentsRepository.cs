using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace DataAccessLayer
{
    public class StudentsRepository
    {
        private readonly string connectionString = "Server=DESKTOP-1U0BM0H\\SQLEXPRESS;Database=Bacth11SQLQuery;User Id=sa;Password=Anaiyaan@123;";


        public bool AddStudent(StudentDetails student)
        {
            try
            {
                 var connection = new SqlConnection(connectionString);
                var parameters = new
                {
                    Name = student.Name,
                    RollNumber = student.RollNumber,
                    Age = student.age,
                    MobileNumber = student.MobileNumber
                };
                connection.Open();
                int affected = connection.Execute("sp_AddStudent", parameters, commandType: CommandType.StoredProcedure);
                return affected > 0;
            }
            catch(SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in you  are give the details: {ex.InnerException}");
                return false;
            }
        }

        public List<StudentDetails> GetStudents()
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                connection.Open();
                return connection.Query<StudentDetails>("Getallstudent", commandType: CommandType.StoredProcedure).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                return new List<StudentDetails>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in you  are give the details: {ex.InnerException}");
                return new List<StudentDetails>();
            }
        }

        public StudentDetails GetStudentByID(int id)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                var parameters = new { StudentID = id };
                connection.Open();
                return connection.QueryFirstOrDefault<StudentDetails>("GetStudentByID", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in you  are give the details: {ex.InnerException}");
                return null;
            }
        }

        public bool UpdateStudent(StudentDetails student)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                var parameters = new
                {
                    StudentID = student.id,
                    Name = student.Name,
                    Age = student.age,
                    Rollnumber = student.RollNumber
                };
                connection.Open();
                int affected = connection.Execute("UpdateStudent", parameters, commandType: CommandType.StoredProcedure);
                return affected > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in you  are give the details: {ex.InnerException}");
                return false;
            }
        }

        public bool DeleteStudent(int id)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                var parameters = new { StudentID = id };
                connection.Open();
                int affected = connection.Execute("DeleteStudent", parameters, commandType: CommandType.StoredProcedure);
                return affected > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in you  are give the details: {ex.InnerException}");
                return false;
            }
        }

        public List<StudentDetails> SearchStudentsByName(string name)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                var parameters = new { SearchName = name };
                connection.Open();
                return connection.Query<StudentDetails>("SearchStudent", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                return new List<StudentDetails>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in you  are give the details: {ex.InnerException}");
                return new List<StudentDetails>();
            }
        }
        public StudentDetails SearchStudentByID(int id)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                var parameters = new { StudentID = id };
                connection.Open();
                return connection.QueryFirstOrDefault<StudentDetails>("SearchStudentByID", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in you  are give the details: {ex.InnerException}");
                return null;
            }
        }

    }
}
