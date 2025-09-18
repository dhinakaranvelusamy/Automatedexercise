using System;

namespace MailExercise
{
    public abstract class AbstractEmailClass
    {

        public string Emailadress;
        public string Toadress;
        public string Subject;
        public string Content;

        public AbstractEmailClass(string Email, string Toadress)
        {
            this.Emailadress = Email;
            this.Toadress = Toadress;
        }
        public void Fromaddress()
        {
            Console.WriteLine("enter the From email Id");
           Emailadress= Console.ReadLine();
        }
        public void GetToAddress()
        
        {
            Console.WriteLine("Enyter To address");
            Toadress = Console.ReadLine();
        }

        public virtual void GetSubject()
        {
            Console.WriteLine("Enter the  subject");
            Subject =Console.ReadLine();
        }

        public virtual void GetContent()
        {
            Console.WriteLine("EnyterFrom Address");
            Content = Console.ReadLine();
        }


        public static void ISValidEmailAdress(string email)
        { }
        public abstract void SendEmail(string subject, string content);

    }
}



    