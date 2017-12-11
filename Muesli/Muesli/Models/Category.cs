using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Muesli.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CategoryId { get; set; }
        public string CatName { get; set; }
       

        public virtual ICollection<Ingredient_Category> Ingredient_Categories { get; set; }
    }
}