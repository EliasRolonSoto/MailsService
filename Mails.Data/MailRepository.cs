using Mails.Data;
using Mails.Entities;
using System.Diagnostics.Metrics;
using System.Drawing;

namespace Mails.Data
{
    public class MailRepository
    {
        private MailsContext _context;
        //construcctor asociado al mail loggeado
        public MailRepository(MailsContext context)
        {
            _context = context;
        }
        //General: Ordena por fecha mas reciente los correos
        private List<Mail> GetOrderedMails()
        {
            var mails = _context.Mails.OrderByDescending(e => e.Date);
            return mails.ToList();
        }
        //General: Trae todos los correos del inbox del Email loggeado
        public List<Mail> GetInbox(string email)
        {
            var result = from m in GetOrderedMails()
                         where m.Receiver.Contains(email)
                         select m;
            return result.ToList();
        }
        //Trae un correo filtrando busqueda por ID
        public Mail GetById(int id)
        {
            var mail = _context.Mails.FirstOrDefault(x => x.MailId == id);
            return mail;
        }
        //Treae la bandeja de salida filtrando por el Email loggeado
        public List<Mail> GetOutbox(string email)
        {
            var result = from m in GetOrderedMails()
                         where m.SenderEmail.Contains(email)
                         select m;
            return result.ToList();
        }
        //Trae la bandeja de entrada paginada
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
        //Trae la bandeja de salida paginada
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

        //Crea un nuevo correo y almacena en DB
        public void NewMail (Mail mail)
        {
            _context.Mails.Add(mail);
            _context.SaveChanges();
        }

        //Trae el inbox paginado y filtrado por busqueda de texto ingresado en txtTextToSearch(windform)
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
        //Trae el outbox paginado y filtrado por busqueda de texto ingresado en txtTextToSearch(windform)
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
        //Esto reemplazamos por script en MVC
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
        //Esto reemplazamos por script en MVC
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