using System;
using System.Collections.Generic;
using DataAccessLayer;
using StudentLibrary;

namespace StudentinFormation
{
    class DatabaseCrud
    {
        private readonly StudentsRepository stud = new StudentsRepository();

        public void List()
        {
            do
            {
                Console.WriteLine();
                Console.WriteLine("===== SPHSS SCHOOL, PALANI =====");
                Console.WriteLine("ENTER THE NUMBER BELOW:");
                Console.WriteLine("1. Create Student");
                Console.WriteLine("2. Read Students");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Search by Name");
                Console.WriteLine("6. Search by ID");
                Console.WriteLine("7. Exit");
                Console.Write("\nEnter Choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        DisplayStudents();
                        break;
                    case 3: 
                        UpdateStudent(); 
                        break;
                    case 4:
                        DeleteStudent(); 
                        break;
                    case 5:
                        SearchByName();
                        break;
                    case 6: 
                        SearchByID();
                        break;
                    case 7:
                        Console.WriteLine("Exiting..."); 
                        return;
                    default: Console.WriteLine("Invalid choice."); 
                        break;
                }
            } while (true);
        }

        public void AddStudent()
        {
            var student = new StudentDetails();

            Console.Write("Enter Name: ");
            student.Name = Console.ReadLine();

            Console.Write("Enter Roll Number: ");
            student.RollNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Age: ");
            student.age = Convert.ToInt32(Console.ReadLine());

            if (!long.TryParse(Console.ReadLine(), out long mobile))
            {
                Console.WriteLine("Invalid mobile number!");
                return; // stop execution or ask again
            }
            student.MobileNumber = mobile;

            bool added = stud.AddStudent(student);
            Console.WriteLine(added ? "Student added successfully." : "Failed to add student.");
        }

        public void DisplayStudents()
        {
            var students = stud.GetStudents();  // Get from database

            if (students == null || students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            Console.WriteLine("+---------+------------------+-----+-----------------+");
            Console.WriteLine("$Roll No           | Name             | Age | Mobile Number   |");
            Console.WriteLine("+---------+------------------+-----+-----------------+");

            foreach (var student in students)
            {
                Console.WriteLine(
                    $"| {student.RollNumber,-7} | {student.Name,-16} | {student.age,-3} | {student.MobileNumber,-15} |");
            }

            Console.WriteLine("+---------+------------------+-----+-----------------+");
        }

    


    public void UpdateStudent()
        {
            Console.Write("Enter Student ID to update: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var student = stud.GetStudentByID(id);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.Write("Enter New Name: ");
            student.Name = Console.ReadLine();

            Console.Write("Enter New Age: ");
            student.age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter New Roll Number: ");
            student.RollNumber = Convert.ToInt32(Console.ReadLine());

            if (!long.TryParse(Console.ReadLine(), out long mobile))
            {
                Console.WriteLine("Invalid mobile number!");
                return; // stop execution or ask again
            }
            student.MobileNumber = mobile;

            bool updated = stud.UpdateStudent(student);
            Console.WriteLine(updated ? "Student updated successfully." : "Failed to update student.");
        }

        public void DeleteStudent()
        {
            Console.Write("Enter Student ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool deleted = stud.DeleteStudent(id);
            Console.WriteLine(deleted ? "Student deleted successfully." : "Student not found.");
        }

        public void SearchByName()
        {
            Console.Write("Enter name to search: ");
            string name = Console.ReadLine();

            var results = stud.SearchStudentsByName(name);

            if (results.Count == 0)
            {
                Console.WriteLine("No matching students found.");
                return;
            }

            Console.WriteLine($"{"ID",-5}{"Roll No",-10}{"Name",-20}{"Age",-5}{"Mobile"}");
            foreach (var s in results)
            {
                Console.WriteLine($"{s.id,-5}{s.RollNumber,-10}{s.Name,-20}{s.age,-5}{s.MobileNumber}");
            }
        }

        public void SearchByID()
        {
            Console.Write("Enter Student ID to search: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var student = stud.GetStudentByID(id);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.WriteLine($"{"ID",-5}{"Roll No",-10}{"Name",-20}{"Age",-5}{"Mobile"}");
            Console.WriteLine($"{student.id,-5}{student.RollNumber,-10}{student.Name,-20}{student.age,-5}{student.MobileNumber}");
        }
    }
}
