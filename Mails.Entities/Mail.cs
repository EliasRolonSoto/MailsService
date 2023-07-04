using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mails.Entities
{
    public class Mail
    {
        public int MailId { get; set; }
        public string SenderEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Receiver { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"Sender: {SenderEmail}\nReceiver: {Receiver} \nSubject: {Subject} \nBody: {Body}";
        }
    }
}