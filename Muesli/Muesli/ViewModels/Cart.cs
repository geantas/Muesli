using Muesli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Muesli.ViewModels;


namespace Muesli.ViewModels
{
    public class Cart
    {
        private List<CartLine> lines = new List<CartLine>();
        public decimal TotalPrice
        {
            // Linq syntax
            get { return lines.Sum(e => e.Ingredient.Price * e.Quantity); }
        }

        public decimal TotalWeight
        {
            // Linq syntax
            get { return lines.Sum(e => e.Quantity); }
        }
        public List<CartLine> Lines { get { return lines; } }
        // Constructor
        public Cart() { }
        public void AddItem(Ingredient ingredient, int quantity)
        {
            // Check to see if the ingredient is already in the cart
            CartLine item = lines.Where(p => p.Ingredient.IngredientId == ingredient.IngredientId).FirstOrDefault();
            if (item == null)
            {
                lines.Add(new CartLine { Ingredient = ingredient, Quantity = quantity });
            }
            else
            {
                item.Quantity += quantity;
            }
        }
        public void RemoveItem(Ingredient ingredient)
        {
            lines.RemoveAll(i => i.Ingredient.IngredientId == ingredient.IngredientId);
        }
        public void Clear()
        {
            lines.Clear();
        }
    }
    public class CartLine
    {
        public Ingredient Ingredient { get; set; }
        public int Quantity { get; set; }
    }
}