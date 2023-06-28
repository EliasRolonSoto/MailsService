using Mails.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mail.Data
{
    public class UserRepository
    {
        private MailContext _context; 
        public UserRepository(MailContext context) 
        {
            _context = context;
        }

    }
}
