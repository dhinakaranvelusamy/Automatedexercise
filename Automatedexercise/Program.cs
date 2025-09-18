using AutomatedExercise;
using System;
using System.Net;
using System.Net.Mail;

namespace Automatedexercise
{
    class Program
    {
        static void Main(string[] args)
        {
            EmailSender obj = new EmailSender();
            obj.SendEmail();

            businessLayer obj = new businessLayer();


        }
    }
}
