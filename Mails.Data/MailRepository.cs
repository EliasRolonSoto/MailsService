using Mails.Data;
using Mails.Entities;
using System.Diagnostics.Metrics;

namespace Mails.Data
{
    public class MailRepository
    {
        private MailsContext _context;
        public MailRepository(MailsContext context)
        {
            _context = context;
        }

        public Response<Mail> GetInbox(Search search)
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
        public Response<Mail> GetOutbox(Search search)
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
    }
}