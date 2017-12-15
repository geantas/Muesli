using System.Linq;
using System.Web.Mvc;
using Muesli.Models;
using Muesli.ViewModels;
using Muesli.DAL;
using System;
using System.Data.Entity;

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

        public ViewResult Checkout([Bind(Include = "UserID,Username,FirstName,LastName,Email,Address,ZipCode,City")] User user)
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Your cart is empty!");
            }

            if (string.IsNullOrEmpty(shippingDetails.Firstname))
            {
                ModelState.AddModelError("FirstName", "Please enter your First name");
            }
            if (string.IsNullOrEmpty(shippingDetails.Lastname))
            {
                ModelState.AddModelError("LastName", "Please enter your Last name");
            }
            if (string.IsNullOrEmpty(shippingDetails.Email))
            {
                ModelState.AddModelError("Email", "Please enter your e-mail");
            }
            if (string.IsNullOrEmpty(shippingDetails.Address))
            {
                ModelState.AddModelError("Address", "Please enter your address");
            }
            if (string.IsNullOrEmpty(shippingDetails.ZipCode))
            {
                ModelState.AddModelError("ZipCode", "Please enter your zip code");
            }
            if (string.IsNullOrEmpty(shippingDetails.City))
            {
                ModelState.AddModelError("City", "Please enter your city");
            }


            if (ModelState.IsValid)
            {


                if (Session["UserID"] != null)
                {
                    User user = new User
                    {
                        UserId = Convert.ToInt32(Session["UserId"]),
                        Username = Session["Username"].ToString(),
                        FirstName = shippingDetails.Firstname,
                        LastName = shippingDetails.Lastname,
                        Email = shippingDetails.Email,
                        Address = shippingDetails.Address,
                        ZipCode = shippingDetails.ZipCode,
                        City = shippingDetails.City
                    };

                }
                else
                {
                    User user = new User
                    {
                       // UserId = 0,
                        Username = "0",
                        FirstName = shippingDetails.Firstname,
                        LastName = shippingDetails.Lastname,
                        Email = shippingDetails.Email,
                        Address = shippingDetails.Address,
                        ZipCode = shippingDetails.ZipCode,
                        City = shippingDetails.City
                    };

                }

                if (shippingDetails.SaveToSubs == true) //if user saves it as subscription
                {
                    Subscription subscription = new Subscription { Date_created = DateTime.Now, Delivery_frequency = shippingDetails.Frequency, Price = cart.TotalPrice };
                    User_Subscription user_subscription = new User_Subscription { UserId = Convert.ToInt32(Session["UserID"]), SubscriptionId = subscription.SubscriptionId };
                    Order order = new Order { OrderDate = DateTime.Now, OrderPrice = cart.TotalPrice, SubscriptionId = subscription.SubscriptionId };
                    User_Order user_order = new User_Order { UserId = Convert.ToInt32(Session["UserID"]), OrderId = order.OrderId };

                    
                    db.Subscriptions.Add(subscription);
                    db.User_Subscriptions.Add(user_subscription);
                    db.Orders.Add(order);
                    db.User_Orders.Add(user_order);
                    db.SaveChanges();

                    foreach (CartLine cartline in cart.Lines)
                    {
                        Order_Ingredient order_ingredient = new Order_Ingredient { OrderId = order.OrderId, IngredientId = cartline.Ingredient.IngredientId, Quantity = cartline.Quantity };
                        db.Order_Ingredients.Add(order_ingredient);
                        db.SaveChanges();
                    }


                } else //if user does not save subscription (should be applied as guest user, too)
                {
                    Order order = new Order { OrderDate = DateTime.Now, OrderPrice = cart.TotalPrice };
                    db.Orders.Add(order);
                    db.SaveChanges();

                    if (Session["UserID"] != null)
                    {
                        User_Order user_order = new User_Order { UserId = Convert.ToInt32(Session["UserID"]), OrderId = order.OrderId };
                        db.User_Orders.Add(user_order);
                        db.SaveChanges();
                    }
                    else
                    {
                        User_Order user_order = new User_Order { OrderId = order.OrderId };
                        db.User_Orders.Add(user_order);
                        db.SaveChanges();
                    }

                    
                    

                    foreach (CartLine cartline in cart.Lines)
                    {
                        Order_Ingredient order_ingredient = new Order_Ingredient { OrderId = order.OrderId, IngredientId = cartline.Ingredient.IngredientId, Quantity = cartline.Quantity };
                        db.Order_Ingredients.Add(order_ingredient);
                        db.SaveChanges();
                    }
                }
                


                //User_Order user_order = new User_Order { UserId = Convert.ToInt32(Session["UserID"]), OrderId = order.OrderId };
                //db.Orders.Add(order);
                //db.User_Orders.Add(user_order);
                //db.SaveChanges();

                /*foreach (CartLine cartline in cart.Lines)
                {
              
                    Order_Ingredient order_ingredient = new Order_Ingredient { OrderId = order.OrderId, IngredientId = cartline.Ingredient.IngredientId, Quantity = cartline.Quantity };
                    db.Order_Ingredients.Add(order_ingredient);
                    db.SaveChanges();
                }*/


                /*if (db.Users.Any(c => c.Username == user.Username))
                {
                    user = db.Users.Where(c => c.Username == user.Username || c.UserId == user.UserId).First();
                    //user.ZipCode = shippingDetails.ZipCode;
                    //order = db.Orders.Where(c => c.OrderPrice == ViewModels.TotalPrice)

                    // ensure update instead of insert
                    db.Entry(user).State = EntityState.Modified;
                }*/


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
                    customer = db.Customers.Where(c => c.Firstname == customer.Firstname && c.Lastname == customer.Lastname && c.Email == customer.Email).First();
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


                db.SaveChanges();

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

