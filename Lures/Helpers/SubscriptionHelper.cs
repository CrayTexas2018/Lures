using Lures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lures.Helpers
{
    public class SubscriptionHelper
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public Subscription createOrUpdateSubscription(Subscription subscription)
        {
            db.Subscriptions.Add(subscription);
            db.SaveChanges();
            return subscription;
        }

        public Subscription findSubscription(int subscription_id)
        {
            return db.Subscriptions.Find(subscription_id);
        }

        public List<Subscription> getActiveSubscriptions()
        {
            return db.Subscriptions.Where(s => s.active == true).ToList();
        }

        public List<Subscription> getUserSubscriptions(int userId, bool active = true)
        {
            return db.Subscriptions.Where(s => s.user.id == userId).Where(s => s.active == active).ToList();
        }
    }
}