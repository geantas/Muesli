using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Muesli.Models
{

    public class Ingredient_Category
    {
        [Key]
        public int Ingredient_Category_Id { get; set; }
        public int IngredientId { get; set; }
        public int CategoryId { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual Category Category { get; set; }

    }
}