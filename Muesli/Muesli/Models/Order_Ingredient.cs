using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Muesli.Models
{

    public class Order_Ingredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Order_Ingredient_Id { get; set; }
        public int? OrderId { get; set; }
        public int IngredientId { get; set; }
        public int Quantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual Ingredient Ingredient { get; set; }

    }
}