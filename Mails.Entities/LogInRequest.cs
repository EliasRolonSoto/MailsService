﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mails.Entities
{
    public class LogInRequest
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }

    }
}
