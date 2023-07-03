using Mails.Data;
using Mails.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mails.Business
{
    public class UserBusiness
    {
        private UserRepository _userRepository;

        public UserBusiness(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool NewUser(User user)
        {
            return _userRepository.NewUser(user);
        }
        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }
        public bool LogIn (LogInRequest request)
        {
            return _userRepository.LogIn(request);
        }
    }
}
