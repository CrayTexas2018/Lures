using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lures.Models
{
    public class Subscription
    {
        public User user { get; set; }
        
        public Order order { get; set; }

        public Product product { get; set; }

        public DateTime start { get; set; }

        public DateTime next { get; set; }

        public bool active { get; set; }
    }
}