using Mails.Data;
using Mails.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mails.Data
{
    public class UserRepository
    {
        private MailsContext _context; 
        public UserRepository(MailsContext context) 
        {
            _context = context;
        }
        public void NewUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }
    }
}
