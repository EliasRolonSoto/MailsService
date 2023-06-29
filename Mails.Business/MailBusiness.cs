using Mails.Data;
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

        public Response<Mail> GetInbox(Search search)
        {
            return _mailRepository.GetInboxPaged(search);
        }

        public Response<Mail> GetOutbox(Search search)
        {
            return _mailRepository.GetOutboxPaged(search);
        }

        public void NewMail(Mail mail)
        {
            _mailRepository.NewMail(mail);
        }


        //public MailBusiness()
        //{
        //    _mailRepository = new MailRepository();

        //}
    }
}