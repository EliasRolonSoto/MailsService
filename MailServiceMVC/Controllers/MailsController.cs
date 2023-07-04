using Mails.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MailServiceMVC.Controllers
{
    public class MailsController : Controller
    {
        private readonly Uri _baseAddress = new Uri("https://localhost:7007/api");
        private readonly HttpClient _client;

        public MailsController()
        {
            _client = new HttpClient();
            _client.BaseAddress = _baseAddress;
        }
        public IActionResult MailsMenu()
        {
            return View("MailsMenu");
        }
        public IActionResult Inbox()
        {
            string email =  HttpContext.Session.GetString("EmailSessionKey");
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/mails/all/inbox/" + email).Result;
            string data = response.Content.ReadAsStringAsync().Result;
            List<Mail> inbox = JsonConvert.DeserializeObject<List<Mail>>(data);
            if (inbox.Count.Equals(0))
            {
                return View();
            }
            return View(inbox);
        }
        public IActionResult Outbox()
        {
            string email = HttpContext.Session.GetString("EmailSessionKey")!;
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/mails/all/outbox/" + email).Result;
            string data = response.Content.ReadAsStringAsync().Result;
            List<Mail> outbox = JsonConvert.DeserializeObject<List<Mail>>(data);
            if (outbox.Count.Equals(0))
            {
                return View();
            }
            return View(outbox);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult NewMail(Mail mail)
        {
            string email = HttpContext.Session.GetString("EmailSessionKey")!;
            mail.SenderEmail = email;
            mail.Date = DateTime.Now;
            string data = JsonConvert.SerializeObject(mail);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/mails", content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["MailSentMessage"] = "Mail sent!";
                return View("MailsMenu");
            }
            return View("MailsMenu"); // -- ??
        }
        public IActionResult Details(int id)
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/mails/" + id).Result;
            string data = response.Content.ReadAsStringAsync().Result;
            Mail mail = JsonConvert.DeserializeObject<Mail>(data);
            return View(mail);
        }

    }
}
