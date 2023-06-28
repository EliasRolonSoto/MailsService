using Mails.Business;
using Mails.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Mails.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserBusiness _userBusiness;
        public UsersController(UserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }
        [HttpPost]
        public void Post(User user)
        {
            _userBusiness.NewUser(user);
        }
        [HttpGet]
        public List<User> GetUsers()
        {
            return _userBusiness.GetAll();
        }
    }
}
