using Mails.Data;
using Mails.Entities;
using System.Diagnostics.Metrics;

namespace Mail.Data
{
    public class MailRepository
    {
        private MailContext _context;
        public MailRepository(MailContext context)
        {
            _context = context;
        }

        public Response<Mails.Entities.Mail> GetInbox(Search search)
        {
            var skipRows = ((search.PageIndex - 1) * search.PageSize);

            var query = from m in _context.Mails
                        where m.Receiver.Contains(search.TextToSearch)
                        select m;

            var count = query.Count();

            var response = new Response<Mails.Entities.Mail>()
            {
                Items = query.Skip(skipRows)
                             .Take(search.PageSize)
                             .ToList(),

                Total = count
            };

            return response;
        }
        public Response<Mails.Entities.Mail> GetOutbox(Search search)
        {
            var skipRows = ((search.PageIndex - 1) * search.PageSize);

            var query = from m in _context.Mails
                        where m.SenderEmail.Contains(search.TextToSearch)
                        select m;

            var count = query.Count();

            var response = new Response<Mails.Entities.Mail>()
            {
                Items = query.Skip(skipRows)
                             .Take(search.PageSize)
                             .ToList(),

                Total = count
            };

            return response;
        }

        public void NewMail (Mails.Entities.Mail mail)
        {
            _context.Mails.Add(mail);
            _context.SaveChanges();
        }
    }
}