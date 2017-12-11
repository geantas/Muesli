using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Muesli.Models
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }
       // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Date_created { get; set; }
        public int Delivery_frequency { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<User_Subscription> User_Subscriptions { get; set; }
    }
}