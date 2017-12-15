using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Muesli.Models
{

    public class User_Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_Order_Id { get; set; }
        public int? UserId { get; set; }
        public int OrderId { get; set; }

        public virtual User User { get; set; }
        public virtual Order Order { get; set; }
    }
}