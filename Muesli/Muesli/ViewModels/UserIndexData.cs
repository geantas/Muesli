using System.Collections.Generic;
using Muesli.Models;

namespace Muesli.ViewModels
{
    public class UserIndexData
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<User_Subscription> User_Subscriptions { get; set; }
        public IEnumerable<Subscription> Subscriptions { get; set; }
        public IEnumerable<User_Order> User_Orders { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Order_Ingredient> Order_Ingredients { get; set; }
        public IEnumerable<Ingredient> Ingredient { get; set; }
    }
}