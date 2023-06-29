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
        private List<Mail> GetInbox(string email)
        {
            var result = from m in _context.Mails
                         where m.Receiver.Contains(email)
                         select m;
            return result.ToList();
        }
        private List<Mail> GetOutbox(string email)
        {
            var result = from m in _context.Mails
                         where m.Receiver.Contains(email)
                         select m;
            return result.ToList();
        }
        public Response<Mail> GetInboxPaged(Search search)
        {
            var skipRows = ((search.PageIndex - 1) * search.PageSize);

            var query = from m in _context.Mails
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

            var query = from m in _context.Mails
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
    }
}