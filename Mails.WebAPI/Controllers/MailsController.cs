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

    }
}
