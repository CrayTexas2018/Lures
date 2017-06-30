using Lures.Helpers;
using Lures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lures.Controllers
{
    public class CheckoutController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Checkout
        public ActionResult Index()
        {
            return RedirectToActionPermanent("Signup");
        }

        // GET: /Checkout/Signup
        [HttpGet]
        public ActionResult Signup(string productName)
        {
            // Find user to auto-fill fields
            User user = new User();
            if (SessionHelper.isLoggedIn())
            {
                UserHelper userHelper = new UserHelper();
                user = userHelper.findUserByEmail(SessionHelper.getEmail());
            }            
            return View(user);
        }

        [HttpPost]
        public ActionResult postSignup(User user)
        { 
            // Create a new user

            return RedirectToAction("Cart");
        }

        // GET: /Checkout/Cart
        [HttpGet]
        public ActionResult Cart()
        {
            return View();
        }

        [HttpPost]
        public ActionResult postCart()
        {
            return RedirectToAction("Confirmation");
        }

        // GET: /Checkout/Confirmation
        [HttpGet]
        public ActionResult Confirmation()
        {
            return View();
        }
    }
}