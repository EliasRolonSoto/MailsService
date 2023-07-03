using Microsoft.AspNetCore.Mvc;

namespace MailServiceMVC.Controllers
{
    public class MailsController : Controller
    {
        public IActionResult MailsMenu()
        {
            return View("MailService", "MailsMenu");
        }
    }
}
