using Mail.Data;
using Mails.Entities;
using Microsoft.Identity.Client;

namespace Mails.Business
{
    public class MailBusiness
    {
        private MailRepository _mailRepository;

        public MailBusiness(MailRepository mailRepository) 
        { 
            _mailRepository = mailRepository;
        }

        public Response<Mails.Entities.Mail> GetInbox(Search search)
        {
            return _mailRepository.GetInbox(search);
        }

        public Response<Mails.Entities.Mail> GetOutbox(Search search)
        {
            return _mailRepository.GetOutbox(search);
        }

        public void NewMail(Mails.Entities.Mail mail)
        {
            _mailRepository.NewMail(mail);
        }


        //public MailBusiness()
        //{
        //    _mailRepository = new MailRepository();

        //}
    }
}