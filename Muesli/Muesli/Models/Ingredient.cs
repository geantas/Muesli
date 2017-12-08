using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Web.Mvc;
using Muesli.ViewModels;
using Muesli.Models;

namespace Muesli.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
       

        public virtual ICollection<Ingredient_Category> Ingredient_Categories { get; set; }
        //public SelectList DropDownList { get; internal set; }
        //public IEnumerable<SelectListItem> DropDownItems { get; set; }

    }

    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}