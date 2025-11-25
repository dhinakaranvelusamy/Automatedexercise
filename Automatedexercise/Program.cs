using System;
using JasonLibrary;
using DataAccessLayer;
using StudentInformation;
using StudentManage;
using System.Net.Http;
using MailExercise;
using StudentinFormation;
using AutomatedExercise;

namespace Automatedexercise
{
    class Program
    {
        public static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("\n===== AUTOMATED SCHOOL SYSTEM =====");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Json CRUD Operations");
                Console.WriteLine("2. Send Email");
                Console.WriteLine("3. REST API Student Service");
                Console.WriteLine("4. JSON Student Operations");
                Console.WriteLine("5. Exit");

                Console.Write("\nEnter choice: ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        var database = new DatabaseCrud();
                        database.List();
                        break;
                    case 2:
                        var email = new EmailSender();
                        email.Emailsend();
                        break;
                    case 3:
                        var api = new RestApiModel();
                        api.StudentRestService();
                        break;
                    case 4:
                        var jsonObj = new StudentInfoss();
                        jsonObj.List();
                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }

            } while (true);
        }
    }
}
