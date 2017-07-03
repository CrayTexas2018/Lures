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

        public User createUser(User user,  HttpRequestBase request)
        {
            PasswordHelper passwordHelper = new PasswordHelper();
            user.password = passwordHelper.hashPassword(user.password);
            user.created = DateTime.Now.Date;
            user.updated = DateTime.Now.Date;
            user.country = "US";
            user.ipAddress = request.UserHostAddress;
            db.Users.Add(user);
            db.SaveChanges();
            // Log user in
            SessionHelper sh = new SessionHelper();
            sh.setAuthCookie(user.email);

            return user;
        }

        public User findUser(int userId)
        {
            return db.Users.Find(userId);
        }

        public User findUserByEmail(string email)
        {
            return db.Users.Where(u => u.email == email).FirstOrDefault();
        }

        public List<User> getUsers()
        {
            return db.Users.ToList();
        }
    }
}