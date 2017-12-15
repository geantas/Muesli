using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Muesli.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Display(Name = "Username")]
        public string Username { get; set; }
        [Display(Name = " First name")]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        [Display(Name = "Zip code")]
        public string ZipCode { get; set; }
        public string City { get; set; }

        //public virtual Subscription Subscription { get; set; }
        public virtual ICollection<User_Subscription> User_Subscriptions { get; set; }
        public virtual ICollection<User_Order> User_Orders { get; set; }
    }
}