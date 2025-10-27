using System.Threading.Tasks;
using System;
using System.Net;
using System.Net.Mail;
using JasonLibrary;
using DataAccessLayer;
using StudentInformation;
using StudentManage;
using System.Net.Http;
using System.Text.Json;
using MailExercise;
using AutomatedExercise;


namespace Automatedexercise
{
    class Program
    {
        public static void Main(string[] args)
        {
            //var Email = new EmailSender();
            //Email.Emailsend();

            var obj = new RestApiModel();
            obj.StudentRestService();
        }
    }
}



