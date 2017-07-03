using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lures.Models
{
    public partial class PaymentVM
    {
        public User user { get; set; }

        public Order order { get; set; }
        
        public Product product { get; set; }
    }
}