using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lures.Models
{
    public class Order
    {
        [Key]
        public int id { get; set; }

        public User user { get; set; }

        public string shippingFirstName { get; set; }

        public string shippingLastName { get; set; }

        public string shippingEmailAddress { get; set; }

        public string shippingAddress { get; set; }

        public string shippingAddress2 { get; set; }

        public string shippingCity { get; set; }

        public string shippingZip { get; set; }

        public string shippingCountry { get; set; }

        public string shippingState { get; set; }

        public string phone { get; set; }

        public string billingFirstName { get; set; }

        public string billingLastName { get; set; }

        public string billingAddress { get; set; }

        public string billingAddress2 { get; set; }

        public string billingCity { get; set; }

        public string billingZip { get; set; }

        public string billingCountry { get; set; }

        public string billingState { get; set; }

        public DateTime nextRecurringDate { get; set; }

        public bool recurring { get; set; }

        public int rebillDiscount { get; set; }

        public string transactionId { get; set; }

        public string authId { get; set; }

        public string trackingNumber { get; set; }

        public string status { get; set; }

        public string shippingMethod { get; set; }

        public decimal subTotal { get; set; }

        public decimal shipping { get; set; }

        public decimal salesTax { get; set; }

        public string orderTotal { get; set; }

        public DateTime created { get; set; }
    }
}