//using System;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Net.Http.Json;
//using System.Threading.Tasks;
//using JasonLibrary;
//using StudentLibrary;
//using StudentConsoleApp;

//namespace StudentManage
//{
//    class RestApiModel
//    {
//        public void StudentRestService()
//        {
//            var api = new StudentApiClient();

//            while (true)
//            {
//                Console.WriteLine("\n==== Student Management (REST API Client) ====");
//                Console.WriteLine("1. List Students");
//                Console.WriteLine("2. Add Student");
//                Console.WriteLine("3. Update Student");
//                Console.WriteLine("4. Delete Student");
//                Console.WriteLine("5. Search by Name");
//                Console.WriteLine("6. Search by Roll No");
//                Console.WriteLine("7. Search by Mobile");
//                Console.WriteLine("8. Exit");
//                Console.Write("Choose: ");
//                var choice = Console.ReadLine();

//                switch (choice)
//                {
//                    case "1":
//                        var students = api.GetAll();
//                        if (students.Count == 0)
//                        {
//                            Console.WriteLine("No students found.");
//                        }
//                        else
//                        {
//                            foreach (var s in students)
//                                Console.WriteLine($"{s.Id}: {s.Name} ({s.Rollno}) - Age: {s.Age}, Mobile: {s.Mobileno}");
//                        }
//                        break;

//                    case "2":
//                        var newStudent = new StudentInfo();
//                        Console.Write("Name: "); newStudent.Name = Console.ReadLine();
//                        Console.Write("Roll No: "); newStudent.Rollno = int.Parse(Console.ReadLine());
//                        Console.Write("Age: "); newStudent.Age = int.Parse(Console.ReadLine());
//                        Console.Write("Mobile: "); newStudent.Mobileno = long.Parse(Console.ReadLine());
//                        api.Create(newStudent);
//                        Console.WriteLine("✅ Student added.");
//                        break;

//                    case "3":
//                        Console.Write("Enter ID to update: ");
//                        int id = int.Parse(Console.ReadLine());
//                        var updated = new StudentInfo();
//                        Console.Write("New Name: "); updated.Name = Console.ReadLine();
//                        Console.Write("New Roll No: "); updated.Rollno = int.Parse(Console.ReadLine());
//                        Console.Write("New Age: "); updated.Age = int.Parse(Console.ReadLine());
//                        Console.Write("New Mobile: "); updated.Mobileno = long.Parse(Console.ReadLine());
//                        api.Update(id, updated);
//                        Console.WriteLine("✅ Student updated.");
//                        break;

//                    case "4":
//                        Console.Write("Enter ID to delete: ");
//                        int delId = int.Parse(Console.ReadLine());
//                        api.Delete(delId);
//                        Console.WriteLine("✅ Student deleted.");
//                        break;

//                    // 🔍 Search Options
//                    case "5":
//                        Console.Write("Enter Name to search: ");
//                        string name = Console.ReadLine();
//                        var results = api.SearchByName(name);
//                        if (results.Count == 0)
//                            Console.WriteLine("No students found.");
//                        else
//                            foreach (var s in results)
//                                Console.WriteLine($"{s.Id}: {s.Name} ({s.Rollno}) - Age: {s.Age}, Mobile: {s.Mobileno}");
//                        break;

//                    case "6":
//                        Console.Write("Enter Roll No to search: ");
//                        int roll = int.Parse(Console.ReadLine());
//                        var rollResult = api.SearchByRollNo(roll);
//                        if (rollResult == null)
//                            Console.WriteLine("No student found with that Roll No.");
//                        else
//                            Console.WriteLine($"{rollResult.Id}: {rollResult.Name} ({rollResult.Rollno}) - Age: {rollResult.Age}, Mobile: {rollResult.Mobileno}");
//                        break;

//                    case "7":
//                        Console.Write("Enter Mobile to search: ");
//                        long mobile = long.Parse(Console.ReadLine());
//                        var mobileResult = api.SearchByMobile(mobile);
//                        if (mobileResult == null)
//                            Console.WriteLine("No student found with that Mobile.");
//                        else
//                            Console.WriteLine($"{mobileResult.Id}: {mobileResult.Name} ({mobileResult.Rollno}) - Age: {mobileResult.Age}, Mobile: {mobileResult.Mobileno}");
//                        break;

//                    case "8":
//                        Console.WriteLine("Exiting...");
//                        return;

//                    default:
//                        Console.WriteLine("Invalid choice. Try again.");
//                        break;
//                }
//            }
//        }
//    }
//}
