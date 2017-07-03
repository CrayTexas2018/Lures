using Lures.Helpers;
using Lures.Models;
using Newtonsoft.Json;
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
        public ActionResult PostSignup(User user)
        {
            // Create a new user
            UserHelper userHelper = new UserHelper();
            user = userHelper.createUser(user, Request);
            TempData["userId"] = user.id;
            return RedirectToAction("Cart");
        }

        // GET: /Checkout/Cart
        [HttpGet]
        public ActionResult Cart()
        {
            // Required
            UserHelper userHelper = new UserHelper();
            User u = userHelper.findUser((int)TempData["userId"]);

            ProductHelper productHelper = new ProductHelper();
            Product p = productHelper.findProduct(1);

            PaymentVM paymentVM = new PaymentVM
            {
                user = u,
                product = p,
                order = null
            };

            TempData.Keep();
            return View(paymentVM);
        }

        [HttpPost]
        public ActionResult postCart(PaymentVM paymentVm)
        {
            // Get total
            ProductHelper productHelper = new ProductHelper();
            //Product product = productHelper.findProduct(paymentVm.product.id);
            //decimal total = product.total;

            //
            Order order = new Order
            {
                billingAddress = paymentVm.order.billingAddress,
                billingAddress2 = paymentVm.order.billingAddress2,
                billingCity = paymentVm.order.billingCity,
                billingCountry = "US",
                billingFirstName = paymentVm.order.billingFirstName,
                billingLastName = paymentVm.order.billingLastName,
                billingState = paymentVm.order.billingState,
                billingZip = paymentVm.order.billingZip,

                shippingAddress = paymentVm.order.shippingAddress,
                shippingAddress2 = paymentVm.order.shippingAddress2,
                shippingCity = paymentVm.order.shippingCity,
                shippingCountry = "US",
                shippingFirstName = paymentVm.order.shippingFirstName,
                shippingLastName = paymentVm.order.shippingLastName,
                shippingState = paymentVm.order.shippingState,
                shippingZip = paymentVm.order.shippingZip,
                shippingEmailAddress = paymentVm.order.shippingEmailAddress,
                shipping = 0.0m,

                creditCardNumber = paymentVm.order.creditCardNumber,
                expireMonth = paymentVm.order.expireMonth,
                expireYear = paymentVm.order.expireYear,
                cvv = paymentVm.order.cvv,

                orderTotal = paymentVm.product.total,

                phone = paymentVm.user.phone,
                user = paymentVm.user,
                nextRecurringDate = DateTime.Today.AddDays(1 - DateTime.Today.Day),

                subTotal = paymentVm.product.subtotal,                
                salesTax = 0.00m,

                created = DateTime.Today.Date,
            };

            // Send order to LimeLight
            string json = JsonConvert.SerializeObject(order);
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