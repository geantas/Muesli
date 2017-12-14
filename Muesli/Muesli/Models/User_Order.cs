using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace Muesli.Models
{

    public class User_Order
    {
        [Key]
        public int User_Order_Id { get; set; }
        public int? UserId { get; set; }
        public int OrderId { get; set; }

        public virtual User User { get; set; }
        public virtual Order Order { get; set; }
    }
}