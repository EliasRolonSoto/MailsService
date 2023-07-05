using MailServiceMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MailServiceMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //Vista del index
        public IActionResult Index()
        {
            return View();
        }
        //Vista de la pestaña Privacy
        public IActionResult Privacy()
        {
            return View();
        }
        //Vista del LogIn
        public IActionResult LogInMenu() { 
            return View();
        }
        //Vista de SignUP
        public IActionResult SignUp()
        {
            return View();
        }
        
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //Vista de errores
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}