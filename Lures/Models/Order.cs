using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lures.Models
{
    public class Order
    {
        public User user { get; set; }

        public string transactionID { get; set; }

        public string authId { get; set; }
    }
}