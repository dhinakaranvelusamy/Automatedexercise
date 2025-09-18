using System;       
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedExercise
{
    public class EmailSender
    {
        public void SendEmail()
        {
            // Your generated App Password goes here
            string gmailAppPassword = "tbcr maff sfzh srdx";
            string fromAddress = "velusamy.dhina@gmail.com";
            string toAddress = "v.dinakaran488@gmail.com";

            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(fromAddress);
                    mail.To.Add(toAddress);
                    mail.Subject = "Test Email from C#";
                    mail.Body = "<h1>Hello!</h1><p>This is a test email sent from C# using the Gmail SMTP server.</p>";
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential(fromAddress, gmailAppPassword);
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;

                        smtp.Send(mail);
                        Console.WriteLine("Email sent successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to send email: " + ex.Message);
            }
        }
    }

}
