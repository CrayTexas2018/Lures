using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Lures.Helpers
{
    public class SessionHelper
    {
        public void login(string email)
        {
            FormsAuthentication.SetAuthCookie(email, true);
        }

        public void logOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}