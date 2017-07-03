using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lures.Models
{
    public partial class CreditCard
    {
        public int number { get; set; }

        public int expirationMonth { get; set; }

        public int expirationYear { get; set; }

        public int cvv { get; set; }
    }
}