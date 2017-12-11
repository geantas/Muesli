using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Muesli.Models
{

    public class User_Subscription
    {
        [Key]
        public int User_Subscription_Id { get; set; }
        public int SubscriptionId { get; set; }
        public int UserId { get; set; }
    
       // public int IngredientId { get; set; }
       // public int Quantity { get; set; }


        public virtual Subscription Subscription { get; set; }
        public virtual User User { get; set; }
      //  public virtual Ingredient Ingredient { get; set; }
        
        //public virtual Course Course { get; set; } // <----- used to add another connecting table

        //public virtual Ingredient Ingredient { get; set; } // <----- for future use
    }
}