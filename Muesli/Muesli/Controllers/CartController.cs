using System.Linq;
using System.Web.Mvc;
using Muesli.Models;
using Muesli.ViewModels;
using Muesli.DAL;

namespace Muesli.Controllers
{
    public class CartController : Controller
    {

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,                ReturnUrl = returnUrl
            });
        }



        private BreakfastContext db;

        public CartController()
        {
            db = new BreakfastContext();
        }

        public RedirectToRouteResult AddToCart(Cart cart,  int Ingredients1, int quantity, string returnUrl)
        {
            Ingredient ingredient = db.Ingredients.FirstOrDefault(p => p.IngredientId == Ingredients1);
            if (ingredient != null)
            {
                cart.AddItem(ingredient, quantity);
            }
            return RedirectToAction("Index", new { controller = returnUrl.Substring(1) });
        }

        public RedirectToRouteResult AddToCart2(Cart cart, int Ingredients2, int quantity, string returnUrl)
        {
            Ingredient ingredient = db.Ingredients.FirstOrDefault(p => p.IngredientId == Ingredients2);
            if (ingredient != null)
            {
                cart.AddItem(ingredient, quantity);
            }
            return RedirectToAction("Index", new { controller = returnUrl.Substring(1) });
        }

        public RedirectToRouteResult AddToCart3(Cart cart, int Ingredients3, int quantity, string returnUrl)
        {
            Ingredient ingredient = db.Ingredients.FirstOrDefault(p => p.IngredientId == Ingredients3);
            if (ingredient != null)
            {
                cart.AddItem(ingredient, quantity);
            }
            return RedirectToAction("Index", new { controller = returnUrl.Substring(1) });
        }

        public RedirectToRouteResult AddToCart4(Cart cart, int Ingredients4, int quantity, string returnUrl)
        {
            Ingredient ingredient = db.Ingredients.FirstOrDefault(p => p.IngredientId == Ingredients4);
            if (ingredient != null)
            {
                cart.AddItem(ingredient, quantity);
            }
            return RedirectToAction("Index", new { controller = returnUrl.Substring(1) });
        }

        public RedirectToRouteResult AddToCart5(Cart cart, int Ingredients5, int quantity, string returnUrl)
        {
            Ingredient ingredient = db.Ingredients.FirstOrDefault(p => p.IngredientId == Ingredients5);
            if (ingredient != null)
            {
                cart.AddItem(ingredient, quantity);
            }
            return RedirectToAction("Index", new { controller = returnUrl.Substring(1) });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int IngredientId, string returnUrl)
        {
            Ingredient ingredient = db.Ingredients
            .FirstOrDefault(p => p.IngredientId == IngredientId);
            if (ingredient != null)
            {
                cart.RemoveItem(ingredient);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}