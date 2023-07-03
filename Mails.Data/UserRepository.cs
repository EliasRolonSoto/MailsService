using Mails.Data;
using Mails.Entities;
using Microsoft.AspNetCore.Identity;
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
        public bool NewUser(User user)
        {
            if (IsEmailTaken(user.Email))
            {
                Console.WriteLine($"El email: {user.Email} ya esta en uso");
                return false;
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }
        private User? GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email.ToLower().Equals(email.ToLower()));
        }
        private bool IsEmailTaken(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }
        public bool LogIn(LogInRequest loginRequest)
        {
            var passwordHasher = new PasswordHasher<User>();
            var user = GetUserByEmail(loginRequest.Email);
            if (user != null)
            {
                var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginRequest.PasswordHash);
                if (result == PasswordVerificationResult.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
