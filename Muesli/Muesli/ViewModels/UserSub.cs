using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Muesli.Models;

namespace Muesli.ViewModels
{
    public class UserSub
    {
        public List<User> Users { get; set; }
        public List<Subscription> Subscriptions { get; set; }
    }
}