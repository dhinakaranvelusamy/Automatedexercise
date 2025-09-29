using AutomatedExercise;
using MailExercise;
using System;
using System.Net;
using System.Net.Mail;
using JasonLibrary;
using StudentinFormation;


namespace Automatedexercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //EmailSender obj = new EmailSender();
            //obj.SendEmail();


            StudentInfos student = new StudentInfos();
            student.List();



            
        }
    }
}
    

