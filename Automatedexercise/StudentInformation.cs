using System;
using DataAccessLayer;
using System.Collections.Generic;

namespace StudentInFormation
{
    public class StudentInformation
    {
        private readonly StudentsRepository studRepo = new StudentsRepository();

        public void List()
        {
            int choice;
            do
            {
                Console.WriteLine("===== SPHSS SCHOOL - PALANI =====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display All Students");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Search Students by Name");
                Console.WriteLine("6, Search Students By Id");
                Console.WriteLine("7. Exit");
                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    break;
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
                        SearchStudentByID();
                        break;                    
                    case 7:
                       Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        continue;
                }
            } while (choice != 6);
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

            bool added = studRepo.AddStudent(student);
            Console.WriteLine(added ? "Student added successfully." : "Failed to add student.");
        }

        private void DisplayAllStudents()
        {
            var students = studRepo.GetStudents();

            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            Console.WriteLine($"{"Id",-5} {"Name",-20} {"RollNo",-10} {"Age",-5} {"MobileNumber",-15}");
            Console.WriteLine(new string('-', 60));

            foreach (var s in students)
            {
               string name = s.Name.Length > 20 ? s.Name.Substring(0, 17) + "..." : s.Name;
                Console.WriteLine($"{s.id,-5} {name,-20} {s.RollNumber,-10} {s.age,-5} {s.MobileNumber,-15}");
            }
        }

        private void UpdateStudent()
        {
            Console.Write("Enter Id of student to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Id.");
                return;
            }

            var student = studRepo.GetStudentByID(id);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.Write($"Enter new name (current: {student.Name}): ");
            string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
                student.Name = name;

            Console.Write($"Enter new roll number (current: {student.RollNumber}): ");
            string rollInput = Console.ReadLine();
            if (int.TryParse(rollInput, out int roll)) student.RollNumber = roll;

            Console.Write($"Enter new age (current: {student.age}): ");
            string ageInput = Console.ReadLine();
            if (short.TryParse(ageInput, out short age)) student.age = age;

            Console.Write($"Enter new mobile number (current: {student.MobileNumber}): ");
            string mobileInput = Console.ReadLine();
            if (long.TryParse(mobileInput, out long mobile)) student.MobileNumber = mobile;

            bool updated = studRepo.UpdateStudent(student);
            Console.WriteLine(updated ? "Student updated." : "Failed to update student.");
        }

        private void DeleteStudent()
        {
            Console.Write("Enter Id of student to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Id.");
                return;
            }

            bool deleted = studRepo.DeleteStudent(id);
            Console.WriteLine(deleted ? "Student deleted." : "Student not found.");
        }

        private void SearchStudentsByName()
        {
            Console.Write("Enter name to search: ");
            string name = Console.ReadLine();

            var results = studRepo.SearchStudentsByName(name);
            if (results.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            Console.WriteLine($"{"Id",-5} {"Name",-20} {"RollNo",-10} {"Age",-5} {"MobileNumber",-15}");
            Console.WriteLine(new string('-', 60));
            foreach (var s in results)
            {
                string Name = s.Name.Length > 20 ? s.Name.Substring(0, 17) + "..." : s.Name;
                Console.WriteLine($"{s.id,-5} {Name,-20} {s.RollNumber,-10} {s.age,-5} {s.MobileNumber,-15}");
            }
        }
        private void SearchStudentByID()
        {
            Console.Write("Enter Student ID to search: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }
            
            var student = studRepo.SearchStudentByID(id);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
            }
            else
            {
                Console.WriteLine($"{"Id",-5} {"Name",-20} {"RollNo",-10} {"Age",-5} {"MobileNumber",-15}");
                Console.WriteLine(new string('-', 60));
                string Name = student.Name.Length > 20 ? student.Name.Substring(0, 17) + "..." : student.Name;
                Console.WriteLine($"{student.id,-5} {Name,-20} {student.RollNumber,-10} {student.age,-5} {student.MobileNumber,-15}");
            }
        }

    }
}
