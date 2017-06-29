using Lures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lures.Helpers
{
    public class OrderHelper
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public Order createOrUpdateOrder(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();

            return order;
        }

        public Order findOrder(int order_id)
        {
            return db.Orders.Find(order_id);
        }

        public List<Order> getAllOrders()
        {
            return db.Orders.ToList();
        }

        public List<Order> getUserOrders(int userId)
        {
            return db.Orders.Where(o => o.user.id == userId).ToList();
        }
    }
}