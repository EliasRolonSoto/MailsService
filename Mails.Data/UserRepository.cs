using Mails.Data;
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

    }
}
