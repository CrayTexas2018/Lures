using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lures.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }

        public string sku { get; set; }

        public decimal price { get; set; }

        public decimal cogs { get; set; }

        public string description { get; set; }

        Product nextRecurringProduct { get; set; }

        public bool selfRecurring { get; set; }

        public decimal shippingWeight { get; set; }

        public decimal declaredProductValue { get; set; }

        public bool active { get; set; }

        public DateTime created { get; set; }

        public DateTime updated { get; set; }
    }
}