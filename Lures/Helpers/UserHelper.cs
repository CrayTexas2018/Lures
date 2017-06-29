using Lures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lures.Helpers
{
    public class UserHelper
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public User createOrUpdateUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user;
        }

        public User findUser(int userId)
        {
            return db.Users.Find(userId);
        }

        public List<User> getUsers()
        {
            return db.Users.ToList();
        }
    }
}