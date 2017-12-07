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
            return View(new ViewModels.CartIndexViewModel
            {
                Cart = cart,                ReturnUrl = returnUrl
            });
        }



        private BreakfastContext db;

        public CartController()
        {
            db = new BreakfastContext();
        }

        public RedirectToRouteResult AddToCart(Cart cart, int Ingredients1, int quantity, string returnUrl)
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

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                /*Customer customer = new Customer
                {
                    Firstname = shippingDetails.Firstname,
                    Lastname = shippingDetails.Lastname,
                    Address = shippingDetails.Address,
                    Zip = shippingDetails.Zip,
                    Email = shippingDetails.Email
                };

                if (db.Customers.Any(c => c.Firstname == customer.Firstname && c.Lastname == customer.Lastname && c.Email == customer.Email))
                {
                    customer = db.Customers.Where(c => c.Firstname == customer.Firstname && c.Lastname == customer.Lastname && 
                    c.Email == customer.Email).First();
                    customer.Address = shippingDetails.Address;
                    customer.Zip = shippingDetails.Zip;
                    // ensure update instead of insert
                    db.Entry(customer).State = EntityState.Modified;
                }

                Invoice invoice = new Invoice(DateTime.Now, customer);

                foreach (CartLine cartline in cart.Lines)
                {
                    OrderItem orderItem = new OrderItem(cartline.Product, cartline.Quantity);
                    // price when item went into the basket
                    orderItem.Price = cartline.Price;
                    orderItem.ProductId = cartline.Product.ProductId;
                    orderItem.Product = null;
                    invoice.OrderItems.Add(orderItem);
                }
                db.Invoices.Add(invoice);*/


               // db.SaveChanges();

                // order processing logic
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
    }
}