using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Muesli.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderId { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Order date")]
        public DateTime OrderDate { get; set; }
        [Display(Name = "Order date")]
        public decimal OrderPrice { get; set; }
        public int? SubscriptionId { get; set; }


        public virtual ICollection<User_Order> User_Orders { get; set; }
    }
}