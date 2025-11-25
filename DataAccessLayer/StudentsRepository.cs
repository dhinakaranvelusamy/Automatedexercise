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
            using var connection = new SqlConnection(connectionString);

            var param = new
            {
                Name = student.Name,
                RollNumber = student.RollNumber,
                Age = student.Age,
                MobileNumber = student.MobileNumber
            };

            int affected = connection.Execute("AddStudent", param, commandType: CommandType.StoredProcedure);
            return affected > 0;
        }

        // GET ALL
        public List<StudentDetails> GetStudents()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open(); // IMPORTANT

                var students = connection.Query<StudentDetails>(
                    "GetAllStudent",
                    commandType: CommandType.StoredProcedure
                ).ToList();

                return students;
            }
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

        // UPDATE
        public bool UpdateStudent(StudentDetails student)
        {
            using var connection = new SqlConnection(connectionString);

            var param = new
            {
                StudentID = student.ID,
                Name = student.Name,
                RollNumber = student.RollNumber,
                Age = student.Age,
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
