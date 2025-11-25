using System;
using System.Collections.Generic;
using DataAccessLayer;

namespace StudentInformation
{
    class DatabaseCrud
    {
        private readonly StudentsRepository stud = new StudentsRepository();

        public void List()
        {
            do
            {
                Console.WriteLine("\n===== SPHSS SCHOOL, PALANI =====");
                Console.WriteLine("1. Create Student");
                Console.WriteLine("2. Read Students");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Search by ID");
                Console.WriteLine("6. Exit");
                Console.Write("Enter Choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                switch (choice)
                {
                    case 1: AddStudent(); break;
                    case 2: DisplayStudents(); break;
                    case 3: UpdateStudent(); break;
                    case 4: DeleteStudent(); break;
                    case 5: SearchByID(); break;
                    case 6: return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            } while (true);
        }

        private void AddStudent()
        {
            var student = new StudentData();
            Console.Write("Enter Name: "); student.Name = Console.ReadLine();
            Console.Write("Enter Age: "); student.Age = int.Parse(Console.ReadLine());
            Console.Write("Enter Mobile: "); student.Mobileno = long.Parse(Console.ReadLine());

            bool added = stud.AddStudent(student);
            Console.WriteLine(added ? "Added successfully." : "Failed to add.");
        }

        private void DisplayStudents()
        {
            var students = stud.GetStudents();
            if (students.Count == 0) { Console.WriteLine("No students found."); return; }

            Console.WriteLine($"{"RollNo",-5} {"Name",-20} {"Age",-5} {"Mobile",-15}");
            foreach (var s in students)
            {
                Console.WriteLine($"{s.Rollno,-5} {s.Name,-20} {s.Age,-5} {s.Mobileno,-15}");
            }
        }

        private void UpdateStudent()
        {
            Console.Write("Enter RollNo to update: ");
            int id = int.Parse(Console.ReadLine());
            var student = stud.GetStudentByID(id);
            if (student == null) { Console.WriteLine("Student not found."); return; }

            Console.Write("Enter New Name: "); student.Name = Console.ReadLine();
            Console.Write("Enter New Age: "); student.Age = int.Parse(Console.ReadLine());
            Console.Write("Enter New Mobile: "); student.Mobileno = long.Parse(Console.ReadLine());

            bool updated = stud.UpdateStudent(student);
            Console.WriteLine(updated ? "Updated successfully." : "Failed to update.");
        }

        private void DeleteStudent()
        {
            Console.Write("Enter RollNo to delete: ");
            int id = int.Parse(Console.ReadLine());
            bool deleted = stud.DeleteStudent(id);
            Console.WriteLine(deleted ? "Deleted successfully." : "Student not found.");
        }

        private void SearchByID()
        {
            Console.Write("Enter RollNo to search: ");
            int id = int.Parse(Console.ReadLine());
            var student = stud.GetStudentByID(id);
            if (student == null) { Console.WriteLine("Student not found."); return; }

            Console.WriteLine($"RollNo: {student.Rollno}, Name: {student.Name}, Age: {student.Age}, Mobile: {student.Mobileno}");
        }
    }
}
