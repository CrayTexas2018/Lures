using Lures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lures.Helpers
{
    public class ProductHelper
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public Product createOrUpdateOrder(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();

            return product;
        }

        public Product findOrder(int product_id)
        {
            return db.Products.Find(product_id);
        }

        public List<Product> getActiveProducts()
        {
            return db.Products.Where(p => p.active == true).ToList();
        }
    }
}