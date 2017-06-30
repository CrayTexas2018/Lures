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
            UserHelper userHelper = new UserHelper();
            User user = userHelper.findUserByEmail(email);
            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, user.password))
                {
                    setAuthCookie(email);
                    return true;
                }
            }
            return false;
        }

        public static bool isLoggedIn()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

        public static string getEmail()
        {
            return HttpContext.Current.User.Identity.Name;
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