using System;
using System.Collections.Generic;
using Models;
using RestAPIClient;

namespace StudentManage
{
    class RestApiModel
    {
        public void StudentRestService()
        {
            var api = new StudentApiClient(); // synchronous calls using GetAwaiter().GetResult()

            while (true)
            {
                Console.WriteLine("\n==== Student Management (REST API Client) ====");
                Console.WriteLine("1. List Students");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Search by Name");
                Console.WriteLine("6. Search by Roll No");
                Console.WriteLine("7. Search by Mobile");
                Console.WriteLine("8. Exit");
                Console.Write("Choose: ");
                var choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            var students = api.GetAllAsync().GetAwaiter().GetResult();
                            DisplayStudents(students);
                            break;

                        case "2":
                            var newStudent = new StudentInfo
                            {
                                Name = ReadString("Name: "),
                                Rollno = ReadInt("Roll No: "),
                                Age = ReadInt("Age: "),
                                Mobileno = ReadLong("Mobile: ")
                            };
                            api.CreateAsync(newStudent).GetAwaiter().GetResult();
                            Console.WriteLine("✅ Student added.");
                            break;

                        case "3":
                            int id = ReadInt("Enter ID to update: ");
                            var updated = new StudentInfo
                            {
                                Name = ReadString("New Name: "),
                                Rollno = ReadInt("New Roll No: "),
                                Age = ReadInt("New Age: "),
                                Mobileno = ReadLong("New Mobile: ")
                            };
                            api.UpdateAsync(id, updated).GetAwaiter().GetResult();
                            Console.WriteLine("✅ Student updated.");
                            break;

                        case "4":
                            int delId = ReadInt("Enter ID to delete: ");
                            api.DeleteAsync(delId).GetAwaiter().GetResult();
                            Console.WriteLine("✅ Student deleted.");
                            break;

                        case "5":
                            string name = ReadString("Enter Name to search: ");
                            var results = api.SearchByNameAsync(name).GetAwaiter().GetResult();
                            DisplayStudents(results);
                            break;

                        case "6":
                            int roll = ReadInt("Enter Roll No to search: ");
                            var rollResult = api.SearchByRollNoAsync(roll).GetAwaiter().GetResult();
                            if (rollResult == null)
                                Console.WriteLine("No student found with that Roll No.");
                            else
                                DisplayStudents(new List<StudentInfo> { rollResult });
                            break;

                        case "7":
                            long mobile = ReadLong("Enter Mobile to search: ");
                            var mobileResult = api.SearchByMobileAsync(mobile).GetAwaiter().GetResult();
                            if (mobileResult == null)
                                Console.WriteLine("No student found with that Mobile.");
                            else
                                DisplayStudents(new List<StudentInfo> { mobileResult });
                            break;

                        case "8":
                            Console.WriteLine("Exiting...");
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Error: {ex.Message}");
                }
            }
        }

        private string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        private int ReadInt(string prompt)
        {
            Console.Write(prompt);
            return int.Parse(Console.ReadLine());
        }

        private long ReadLong(string prompt)
        {
            Console.Write(prompt);
            return long.Parse(Console.ReadLine());
        }

        private void DisplayStudents(List<StudentInfo> students)
        {
            if (students.Count == 0)
                Console.WriteLine("No students found.");
            else
                foreach (var s in students)
                    Console.WriteLine($"{s.Id}: {s.Name} ({s.Rollno}) - Age: {s.Age}, Mobile: {s.Mobileno}");
        }
    }
}
