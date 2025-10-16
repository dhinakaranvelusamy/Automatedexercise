//using System;       
//using System.Net;
//using System.Net.Mail;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using MailExercise;
//using MailKit;

//namespace AutomatedExercise
//{
//    public class EmailSender
//    {
//        // Your generated App Password goes here
//        public string gmailAppPassword = "geeg ypmd mbai icxo";
//        public string fromAddress = "velusamy.dhina@gmail.com";
        
//        public void SendEmail()
//        {
//            Console.WriteLine("enter the To Email.address");
//            string toaddress = Console.ReadLine();
//            Console.WriteLine();
//            Console.WriteLine("type the subject");
//            Console.WriteLine();
//            string subject = Console.ReadLine();
//            Console.WriteLine("enter the content of your message");
//            string content = Console.ReadLine();

//            //SentEmailToAddress Email = new SentEmailToAddress( fromAddress, toaddress, subject, content,  gmailAppPassword);

//            //Email.SendEmail();
//            //Console.WriteLine();
//            var email = new MailKitEmailServises(fromAddress, toaddress, subject, content, gmailAppPassword);
//            email.SendEmail();
//        }
//    }


//geeg ypnd mbai icxo
