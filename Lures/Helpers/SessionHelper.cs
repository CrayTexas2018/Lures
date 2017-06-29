using Lures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Lures.Helpers
{
    public class SessionHelper
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public bool login(string email, string password)
        {
            if (db.Users.Where(u => u.email == email).Where(u => u.password == password).FirstOrDefault() != null)
            {
                setAuthCookie(email);
                return true;
            }
            return false;
        }

        public void setAuthCookie(string email)
        {            
            FormsAuthentication.SetAuthCookie(email, true);
        }

        public void logOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}