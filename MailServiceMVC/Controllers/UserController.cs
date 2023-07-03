using Mails.Entities;
using MailServiceMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics.Eventing.Reader;
using System.Reflection;

namespace MailServiceMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly Uri _baseAddress = new Uri("https://localhost:7007/api");
        private readonly HttpClient _client;

        public UserController()
        {
            _client = new HttpClient();
            _client.BaseAddress = _baseAddress;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogIn(string email, string password)
        {
            LogInRequest logInRequest = new LogInRequest()
            {
                Email = email,
                PasswordHash = password
            };

            string data = JsonConvert.SerializeObject(logInRequest);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/users/login", content).Result;
            
            if (response.IsSuccessStatusCode && response.Content.ReadAsStringAsync().Result.Equals("true"))
            {
                return RedirectToAction("MailsMenu", "Mails");
                //return View("MailsMenu", "MailService");
            }
            else
            {
                TempData["ErrorMessage"] = "ERROR! - Email or Password doesn't match.";
                return RedirectToAction("LogInMenu", "Home");
            }
            
        }
        public IActionResult SignUp(string name , string email, string password)
        {
            var passwordHasher = new PasswordHasher<string>();
            var user = new User()
            {
                Email = email,
                Name = name
            };
            user.PasswordHash = passwordHasher.HashPassword(null!, password);
            string data = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/users", content).Result;

            if (response.IsSuccessStatusCode && response.Content.ReadAsStringAsync().Result.Equals("true"))
            {
                TempData["SuccessMessage"] = "User created!";
                return RedirectToAction("LogInMenu", "Home");
            }
            else
            {
                TempData["ErrorMessage"] = "ERROR! - Email taken.";
                return RedirectToAction("SignUp", "Home");
            }

        }
    }
}
