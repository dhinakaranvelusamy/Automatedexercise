using AutomatedExercise;
using MailExercise;
using System;
using System.Net;
using System.Net.Mail;
using JasonLibrary;


namespace Automatedexercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //EmailSender obj = new EmailSender();
            //obj.SendEmail();




            var crud = new JasonCRUD();

            // Add student
            crud.AddJason("ravi", 14, 9);
            crud.AddJason("gobi", 15, 10);

            // Show all students
            var students = crud.GetAll();
            foreach (var s in students)
            {
                Console.WriteLine($"{s.Rollno}: {s.Name}, Age: {s.Age}, Standard: {s.Standard}");
            }

            // Search
            var results = crud.SearchByName("bob");
            Console.WriteLine("Search Results:");
            foreach (var s in results)
            {
                Console.WriteLine($"{s.Rollno}: {s.Name}");
            }
        }
    }
}
    

