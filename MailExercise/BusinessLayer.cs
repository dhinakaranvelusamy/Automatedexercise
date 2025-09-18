using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailExercise
{
    class BusinessLayer
    {

        public class EmailService : AbstractEmailClass
        {
            public EmailService(string subject, string content) : base(subject, content)
            {
                string name = "";
            }
            protected void SendMail(string fromAddress, string toAdress, string subject, string content)
            {
                GetToAddress();
            }

            internal void SendSMS()
            {

            }

            protected internal void SendWhatsUP()
            {

            }

            public override void SendEmail(string subject, string content)
            {
                throw new NotImplementedException();
            }
        }
    }
}
 

