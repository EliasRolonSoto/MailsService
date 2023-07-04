using Mails.Data;
using Mails.Entities;
using System.Diagnostics.Metrics;
using System.Drawing;

namespace Mails.Data
{
    public class MailRepository
    {
        private MailsContext _context;
        public MailRepository(MailsContext context)
        {
            _context = context;
        }
        private List<Mail> GetOrderedMails()
        {
            var mails = _context.Mails.OrderByDescending(e => e.Date);
            return mails.ToList();
        }
        public List<Mail> GetInbox(string email)
        {
            var result = from m in GetOrderedMails()
                         where m.Receiver.Contains(email)
                         select m;
            return result.ToList();
        }
        public Mail GetById(int id)
        {
            var mail = _context.Mails.FirstOrDefault(x => x.MailId == id);
            return mail;
        }
        public List<Mail> GetOutbox(string email)
        {
            var result = from m in GetOrderedMails()
                         where m.SenderEmail.Contains(email)
                         select m;
            return result.ToList();
        }
        public Response<Mail> GetInboxPaged(Search search)
        {
            var skipRows = ((search.PageIndex - 1) * search.PageSize);

            var query = from m in GetOrderedMails()
                        where m.Receiver.Contains(search.TextToSearch)
                        select m;

            var count = query.Count();

            var response = new Response<Mail>()
            {
                Items = query.Skip(skipRows)
                             .Take(search.PageSize)
                             .ToList(),

                Total = count
            };

            return response;
        }
        public Response<Mail> GetOutboxPaged(Search search)
        {
            var skipRows = ((search.PageIndex - 1) * search.PageSize);

            var query = from m in GetOrderedMails()
                        where m.SenderEmail.Contains(search.TextToSearch)
                        select m;

            var count = query.Count();

            var response = new Response<Mail>()
            {
                Items = query.Skip(skipRows)
                             .Take(search.PageSize)
                             .ToList(),

                Total = count
            };

            return response;
        }

        public void NewMail (Mail mail)
        {
            _context.Mails.Add(mail);
            _context.SaveChanges();
        }

        public Response<Mail> SearchInbox(Search search, string email)
        {
            var skipRows = ((search.PageIndex - 1) * search.PageSize);
            var inBox = GetInbox(email);
            var query = from m in inBox
                        where m.Subject.Contains(search.TextToSearch) ||
                         m.SenderEmail.Contains(search.TextToSearch) ||
                          m.Body.Contains(search.TextToSearch) ||
                 m.Receiver.Contains(search.TextToSearch)
                        select m;
            var count = query.Count();
            var response = new Response<Mail>()
            {
                Items = query.Skip(skipRows)
                             .Take(search.PageSize)
                .ToList(),

                Total = count
            };
            return response;

        }
        public Response<Mail> SearchOutbox(Search search, string email)
        {
            var skipRows = ((search.PageIndex - 1) * search.PageSize);
            var outBox = GetOutbox(email);
            var query = from m in outBox
                        where m.Subject.Contains(search.TextToSearch) ||
                         m.SenderEmail.Contains(search.TextToSearch) ||
                         m.Body.Contains(search.TextToSearch) ||
                            m.Receiver.Contains(search.TextToSearch)
                        select m;
            var count = query.Count();
            var response = new Response<Mail>()
            {
                Items = query.Skip(skipRows)
                             .Take(search.PageSize)
                                .ToList(),

                Total = count
            };
            return response;

        }
        public List<Mail> SearchAllInbox(string textToSearch, string email)
        {
            var inBox = GetInbox(email);
            var query = from m in inBox
                        where m.Subject.Contains(textToSearch) ||
                         m.SenderEmail.Contains(textToSearch) ||
                          m.Body.Contains(textToSearch) ||
                 m.Receiver.Contains(textToSearch)
                        select m;
            
            return query.ToList();

        }
        public List<Mail> SearchAllOutbox(string textToSearch, string email)
        {
            var outBox = GetOutbox(email);
            var query = from m in outBox
                        where m.Subject.Contains(textToSearch) ||
                         m.SenderEmail.Contains(textToSearch) ||
                          m.Body.Contains(textToSearch) ||
                 m.Receiver.Contains(textToSearch)
                        select m;

            return query.ToList();

        }
    }
}