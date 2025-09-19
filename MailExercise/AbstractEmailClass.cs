using System;

namespace MailExercise
{
    public abstract class AbstractEmailClass
    {

        public string FromAddress;
        public string Toaddress;
        public string Subject;
        public string Content;

        public AbstractEmailClass(string fromaddress, string toaddress,string subject,string content)
        {
            this.FromAddress = fromaddress;
            this.Toaddress = toaddress;
            this.Content = content; 
            this.Subject = subject;
        }

        public abstract void SendEmail();
       


    }
}



   