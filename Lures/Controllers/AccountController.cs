using Lures.Helpers;
using Lures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lures.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            SessionHelper sh = new SessionHelper();
            ViewData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult PostLogin(string email, string password, string returnUrl)
        {
            SessionHelper sessionHelper = new SessionHelper();                
            if (sessionHelper.login(email, password))
            {                    
                if (returnUrl != null)
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index");
            }                
            ViewData["loginError"] = "Could not match email and password. Please try again.";
            return RedirectToAction("Login");
        }

        public ActionResult Orders()
        {
            return View();
        }

        public ActionResult Subscriptions()
        {
            return View();
        }
    }
}