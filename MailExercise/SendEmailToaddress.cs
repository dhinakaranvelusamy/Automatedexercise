using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using MailExercise;



namespace MailExercise
{
    public class SentEmailToAddress: AbstractEmailClass
    {
        string GmailAppPassword = null;
        public SentEmailToAddress(string fromaddress, string toaddress, string subject, string content,  string gmailAppPassword) : base(fromaddress, toaddress, subject, content)
        {
            GmailAppPassword = gmailAppPassword;

        }

        public override void SendEmail()

        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(FromAddress);
                    mail.To.Add(Toaddress);
                    mail.Subject = Subject;
                    mail.Body = Content;
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential(FromAddress, GmailAppPassword);
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
