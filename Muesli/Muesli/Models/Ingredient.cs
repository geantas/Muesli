using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Muesli.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Ingredient_Category> Ingredient_Categories { get; set; }
    }
}