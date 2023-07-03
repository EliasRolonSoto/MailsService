using Mails.Data;
using Mails.Business;
using Mails.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mails.WebAPI.Controllers
{
    
    [Route("api/mails")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        private MailBusiness _mailBusiness;
        public MailsController(MailBusiness mail) 
        {
            _mailBusiness = mail;
        }

        //[HttpPost("InBox")]
        //public Response<Mail> GetInBox(Search search) 
        //{
        //    return _mailBusiness.GetInbox(search);
        //}
        //[HttpPost("OutBox")]
        //public Response<Mail> GetOutBox(Search search)
        //{
        //    return _mailBusiness.GetOutbox(search);
        //}
        [HttpGet("{id}")]
        public Mail GetById(int id)
        {
            return _mailBusiness.GetById(id);
        }
        [HttpPost]
        public void NewMail(Mail mail)
        {
            _mailBusiness.NewMail(mail);
        }
        [HttpPost("inbox/{email}")]
        public Response<Mail> SearchInbox(Search search, string email)
        {
            return _mailBusiness.SearchInbox(search, email);
        }
        [HttpPost("outbox/{email}")]
        public Response<Mail> SearchOutbox(Search search, string email)
        {
            return _mailBusiness.SearchOutbox(search, email);
        }
        [HttpGet("all/inbox/{email}")]
        public List<Mail> GetInbox(string email)
        {
            return _mailBusiness.GetInbox(email);
        }
        [HttpGet("all/outbox/{email}")]
        public List<Mail> GetOutbox(string email)
        {
            return _mailBusiness.GetOutbox(email);
        }
    }
}
