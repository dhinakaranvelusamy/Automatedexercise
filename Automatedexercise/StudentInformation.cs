using System;
using DataAccessLayer;
using System.Collections.Generic;

namespace StudentinFormation
{
    class StudentInfromation
    {
        private readonly StudentsRepository join = new StudentsRepository();

        public void List()
        {
            while (true)
            {
                Console.WriteLine("===== SPHSS SCHOOL - PALANI =====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display All Students");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Search Students by Name");
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        DisplayAllStudents();
                        break;
                    case 3:
                        UpdateStudent();
                        break;
                    case 4:
                        DeleteStudent();
                        break;
                    case 5:
                        SearchStudentsByName();
                        break;
                    case 6:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        private void AddStudent()
        {
            var student = new StudentDetails();

            Console.Write("Enter Name: ");
            student.Name = Console.ReadLine();

            Console.Write("Enter Roll Number: ");
            student.RollNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter Age: ");
            student.age = short.Parse(Console.ReadLine());

            Console.Write("Enter Mobile Number: ");
            student.MobileNumber = long.Parse(Console.ReadLine());

            bool added = join.AddStudent(student);
            Console.WriteLine(added ? "Student added successfully." : "Failed to add student.");
        }

        private void DisplayAllStudents()
        {
            var students = join.GetStudents();
            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            // Header with clear and consistent column widths
            Console.WriteLine($"{"Id",-5} {"Name",-20} {"RollNo",-10} {"Age",-5} {"MobileNumber",-15}");
            Console.WriteLine(new string('-', 60)); // separator line

            foreach (var s in students)
            {
                // Pad or truncate strings to fixed width for alignment
                string name = s.Name.Length > 20 ? s.Name.Substring(0, 17)  : s.Name;

                Console.WriteLine($"{s.id,-5} {name,-20} {s.RollNumber,-10} {s.age,-5} {s.MobileNumber,-15}");
            }
        }

        private void UpdateStudent()
        {
            Console.Write("Enter Id of student to update: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine();


            var student = join.GetStudentByID(id);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.Write($"Enter new name (current:{student.Name}):");
            string name = Console.ReadLine();
            Console.WriteLine();

            if (!string.IsNullOrEmpty(name)) student.Name = name;

            Console.Write($"Enter new roll number (current:{student.RollNumber}):");
            string rollInput = Console.ReadLine();
            if (int.TryParse(rollInput, out int roll)) student.RollNumber = roll;
            Console.WriteLine();

            Console.Write($"Enter new age (current:{student.age}):");
            string ageInput = Console.ReadLine();
            if (short.TryParse(ageInput, out short age)) student.age = age;
            Console.WriteLine();

            Console.Write($"Enter new mobile number (current: {student.MobileNumber}): ");
            string mobileInput = Console.ReadLine();
            Console.WriteLine();

            if (long.TryParse(mobileInput, out long mobile)) student.MobileNumber = mobile;

            bool updated = join.UpdateStudent(student);
            Console.WriteLine(updated ? "Student updated." : "Failed to update student.");
            Console.WriteLine();

        }

        private void DeleteStudent()
        {
            Console.Write("Enter Id of student to delete: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine();

            bool deleted = join.DeleteStudent(id);
            Console.WriteLine(deleted ? "Student deleted." : "Student not found.");
        }

        private void SearchStudentsByName()
        {
            Console.Write("Enter name to search: ");
            string name = Console.ReadLine();
            Console.WriteLine();

            var results = join.SearchStudentsByName(name);
            if (results.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            Console.WriteLine($"{"Id",-5} {"Name",-20} {"RollNo",-8} {"Age",-5} {"MobileNumber"}");
            foreach (var s in results)
            {
                Console.WriteLine($"{s.id,-5} {s.Name,-20} {s.RollNumber,-8} {s.age,-5} {s.MobileNumber}");
            }
        }
    }
}
    