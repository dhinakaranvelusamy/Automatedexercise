using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using JasonLibrary;
using System.Threading.Tasks;

namespace StudentinFormation
{

    class StudentInfos
    {

        public JasonCRUD stud = new JasonCRUD();

        public void list()
        {
            do

            {
                Console.WriteLine("===== XYZ SCHOOL , PALANI=====");
                Console.WriteLine("enter the any numbers");
                Console.WriteLine("1. Create Student");
                Console.WriteLine("2. Read Students");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Serchstudent");
                Console.WriteLine("6. Exit");
                Console.Write("Enter Choice: ");
                Console.WriteLine();
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("invaild the option enter to vaild number");
                    Console.ReadKey();
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        Addstudent();
                        break;
                    case 2:
                        Readstudent();
                        break;
                    case 3:
                        Updatestudent();
                        break;
                    case 4:
                        DeleteStudent();
                        break;
                    case 5:
                        SearchStdudent();
                        break;
                    case 6:
                    case 7:
                    case 8:
                    case 9:

                        Console.WriteLine("EXIT");
                        Console.WriteLine("exiting the class");
                        return;
                    default:
                        Console.WriteLine("enter invaild number ,  please enetr the vaild number given above");
                        break;
                }
            } while (true);
        }
        public void Addstudent()
        {
            var info = new StudentInfo();
            Console.WriteLine("enter the name ");
            info.Name = Console.ReadLine();
            Console.WriteLine("enter the roll no");
            info.Rollno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the  age");
            info.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the  mobile");
            info.Mobile = Convert.ToInt32(Console.ReadLine());
            stud.AddJason(info);
           
            Console.WriteLine("students are add successfully");
        }
        public void Readstudent()
        {
            var students = stud.GetAll();

            Console.WriteLine("\n--- Student List ---");

            Console.WriteLine(students.Count == 0 ? "! No records found."  : "");
            Console.WriteLine($"{"Roll No",-10}{"Name",-20}{"Age",-5}{"Mobile"}");
            foreach (var s in students)
            {
                Console.WriteLine($"{s.Rollno,-10}{s.Name,-20}{s.Age,-5}{s.Mobile}");
                Console.WriteLine();
            }
        }
        public void Updatestudent()
        {
            Console.Write("Enter Roll Number to Update: ");

            int roll = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Enter New Name: ");
            string newName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Enter New Age: ");
            int newAge = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Enter New Mobile: ");
            int newMobile = Convert.ToInt32(Console.ReadLine());

            bool success = stud.UpdateJason(roll, newName, newAge, newMobile);

            Console.WriteLine(success  ? " Student updated successfully.": " Student not found.");
        }
        public void DeleteStudent()
        {
            Console.Write("Enter Roll Number to Delete: ");
            int roll = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine();
            bool Delete = stud.DeleteJason(roll);
            
           

            Console.WriteLine(Delete ? "Student deleted successfully.": " Student not found.");
        }
        public void SearchStdudent()
        {
            Console.Write("Enter name or part of name to search: ");
            string keyword = Console.ReadLine();

            var results = stud.SearchByName(keyword);

            Console.WriteLine(results.Count == 0? " No matching students found." : $" Found {results.Count} student(s):");
            Console.WriteLine($"{"Roll No",-10}{"Name",-20}{"Age",-5}{"Mobile"}");

            foreach (var s in results)
            {
                Console.WriteLine($"{s.Rollno,-10}{s.Name,-20}{s.Age,-5}{s.Mobile}");
                Console.WriteLine();
            }

        }
    }       
}
