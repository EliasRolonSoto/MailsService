using Mail.Data;
using Mails.Business;
using Mails.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mails.WebAPI.Controllers
{
    //cambios
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        private MailBusiness _mailBusiness;
        public MailsController(MailBusiness mail) 
        {
            _mailBusiness = mail;
        }

        [HttpPost("/InBox")]
        public Response<Mails.Entities.Mail> GetInBox(Search search) 
        {
            return _mailBusiness.GetInbox(search);
        }
        [HttpPost("/OutBox")]
        public Response<Mails.Entities.Mail> GetOutBox(Search search)
        {
            return _mailBusiness.GetOutbox(search);
        }

        [HttpPost]
        public void NewMail(Mails.Entities.Mail mail)
        {
            _mailBusiness.NewMail(mail);
        }

    }
}
