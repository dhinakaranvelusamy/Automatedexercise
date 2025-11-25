
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
        private readonly string connectionString =
            "Server=DESKTOP-1U0BM0H\\SQLEXPRESS;Database=Bacth11SQLQuery;User Id=sa;Password=Anaiyaan@123;";

        // ADD
        public bool AddStudent(StudentDetails student)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);

                var param = new
                {
                    Name = student.Name,
                    RollNumber = student.RollNumber,
                    Age = student.age,
                    MobileNumber = student.MobileNumber
                };

                int affected = connection.Execute("AddStudent", param, commandType: CommandType.StoredProcedure);
                return affected > 0;
            }
            catch
            {
                return false;
            }
        }

        // GET ALL
        public List<StudentDetails> GetStudents()
        {
            using var connection = new SqlConnection(connectionString);
            return connection.Query<StudentDetails>(
                "GetAllStudent",
                commandType: CommandType.StoredProcedure
            ).ToList();
        }

        // GET BY ID
        public StudentDetails GetStudentByID(int id)
        {
            using var connection = new SqlConnection(connectionString);

            return connection.QueryFirstOrDefault<StudentDetails>(
                "SearchStudentByID",
                new { StudentID = id },
                commandType: CommandType.StoredProcedure
            );
        }

        // SEARCH BY NAME
        public List<StudentDetails> SearchStudentsByName(string name)
        {
            using var connection = new SqlConnection(connectionString);

            return connection.Query<StudentDetails>(
                "SearchStudent",
                new { SearchName = name },
                commandType: CommandType.StoredProcedure
            ).ToList();
        }

        // UPDATE
        public bool UpdateStudent(StudentDetails student)
        {
            using var connection = new SqlConnection(connectionString);

            var param = new
            {
                StudentID = student.id,
                Name = student.Name,
                Age = student.age,
                Rollnumber = student.RollNumber,  // MUST MATCH SP EXACTLY!
                MobileNumber = student.MobileNumber
            };

            int result = connection.Execute("UpdateStudent", param, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        // DELETE
        public bool DeleteStudent(int id)
        {
            using var connection = new SqlConnection(connectionString);

            int result = connection.Execute(
                "DeleteStudent",
                new { StudentID = id },
                commandType: CommandType.StoredProcedure
            );

            return result > 0;
        }
    }
}
