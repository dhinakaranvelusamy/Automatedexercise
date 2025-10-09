using System;
using System.Collections.Generic;
using JasonLibrary;

namespace StudentinFormation
{
    class StudentInfoss
    {
        public JasonCRUD stud = new JasonCRUD();
        public void List()
        {
            do
            {
                Console.WriteLine();
                Console.WriteLine("===== SPHSS SCHOOL , PALANI =====");
                Console.WriteLine("ENTER THE ABOVE ANY  NUMBER ! !");
                Console.WriteLine("1. Create Student");
                Console.WriteLine("2. Read Students");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Search by Name");
                Console.WriteLine("6. Search by Roll Number");
                Console.WriteLine("7. Search by Mobile Number");
                Console.WriteLine("8. Exit");
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
                        ReadStudents();
                        continue;
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
                        SearchByRollNumber();
                        break;
                    case 7:
                        SearchByMobile();
                        break;
                    case 8:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }               
            } while (true);
        }

        public void AddStudent()
        {
            var info = new StudentInfo();

            Console.Write("Enter Name: ");
            info.Name = Console.ReadLine();

            Console.Write("Enter Roll No: ");
            info.Rollno = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Age: ");
            info.Age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Mobile: ");
            info.Mobile = Convert.ToInt64(Console.ReadLine());

            stud.AddJason(info);
            Console.WriteLine("Student added successfully.");

        }

        public void ReadStudents()
        {
            var students = stud.GetAll();

            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            Console.WriteLine($"{"Roll No",-10}{"Name",-20}{"Age",-5}{"Mobile"}");
            Console.WriteLine();
            foreach (var s in students)
            {
                Console.WriteLine($"{s.Rollno,-10}{s.Name,-20}{s.Age,-5}{s.Mobile}");
            }
        }

        public void UpdateStudent()
        {
            Console.Write("Enter Roll Number to update: ");
            int roll = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter New Name: ");
            string name = Console.ReadLine();
            

            Console.Write("Enter New Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter New Mobile: ");
            long mobile = Convert.ToInt64(Console.ReadLine());

            bool updated = stud.UpdateJason(roll, name, age, mobile);

            Console.WriteLine(updated ? "Student updated successfully." : "Student not found.");
        }

        public void DeleteStudent()
        {
            Console.Write("Enter Roll Number to delete: ");
            int roll = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            bool deleted = stud.DeleteJason(roll);

            Console.WriteLine(deleted ? "Student deleted successfully." : "Student not found.");
        }

        public void SearchByName()
        {
            Console.Write("Enter name to search: ");
            string name = Console.ReadLine();

            var results = stud.SearchByName(name);

            if (results.Count == 0)
            {
                Console.WriteLine("No matching students found.");
                return;
            }
            Console.WriteLine($"{"Roll No",-10}{"Name",-20}{"Age",-5}{"Mobile"}");
            Console.WriteLine();
            foreach (var s in results)
            {
                Console.WriteLine($"{s.Rollno,-10}{s.Name,-20}{s.Age,-5}{s.Mobile}");
            }
        }

        public void SearchByRollNumber()
        {
            Console.Write("Enter Roll Number to search: ");
            int roll = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            var student = stud.SearchByRollNo(roll);

            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.WriteLine($"{"Roll No",-10}{"Name",-20}{"Age",-5}{"Mobile"}");

            Console.WriteLine($"{student.Rollno,-10}{student.Name,-20}{student.Age,-5}{student.Mobile}");
        }

        public void SearchByMobile()
        {
            Console.Write("Enter Mobile Number to search: ");
            long mobile = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine();

            var student = stud.SearchByMobile(mobile);

            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }
            Console.WriteLine($"{"Roll No",-10}{"Name",-20}{"Age",-5}{"Mobile"}");
            Console.WriteLine();
            Console.WriteLine($"{student.Rollno,-10}{student.Name,-20}{student.Age,-5}{student.Mobile}");
        }
    }
}
