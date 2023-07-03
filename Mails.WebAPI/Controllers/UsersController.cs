using Mails.Business;
using Mails.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Mails.WebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserBusiness _userBusiness;
        public UsersController(UserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }
        [HttpPost]
        public bool Post(User user)
        {
            return _userBusiness.NewUser(user);
        }
        [HttpGet]
        public List<User> GetUsers()
        {
            return _userBusiness.GetAll();
        }
        [HttpPost("login")]
        public bool LogIn(LogInRequest loginRequest)
        {
            return _userBusiness.LogIn(loginRequest);
        }

    }
}
