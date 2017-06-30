using Lures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lures.Helpers
{
    public class PasswordHelper
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public string hashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool verifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);          
        }

        public void changePassword(User user, string newPassword)
        {
            user.password = hashPassword(newPassword);
            db.Users.Add(user);
            db.SaveChanges();
        }
    }
}