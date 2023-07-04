using Mails.Data;
using Mails.Entities;
using Microsoft.EntityFrameworkCore;
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
        public Mail GetById(int id)
        {
            return _mailRepository.GetById(id);
        }
        public void NewMail(Mail mail)
        {
            _mailRepository.NewMail(mail);
        }
        public Response<Mail> SearchInbox(Search search, string email)
        {
            return _mailRepository.SearchInbox(search, email);

        }
        public Response<Mail> SearchOutbox(Search search, string email)
        {
            return _mailRepository.SearchOutbox(search, email);

        }
        public List<Mail> GetInbox(string email)
        {
            return _mailRepository.GetInbox(email);
        }
        public List<Mail> GetOutbox(string email)
        {
            return _mailRepository.GetOutbox(email);
        }
        public List<Mail> SearchAllInbox(string textToSearch, string email)
        {
            return _mailRepository.SearchAllInbox(textToSearch, email);

        }
        public List<Mail> SearchAllOutbox(string textToSearch, string email)
        {
            return _mailRepository.SearchAllOutbox(textToSearch, email);

        }
    }
}