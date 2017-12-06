using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Muesli.Models;
using Muesli.ViewModels;
using System.Data;
using System.Data.Entity;
using System.Net;
using Muesli.DAL;
using System.Collections.Generic;

namespace Muesli.Controllers
{
    public class HomeController : Controller
    {
        private BreakfastContext db = new BreakfastContext();

        // GET: Ingredient
        public ActionResult Index()
        {

            /****************** ITEMS 1 ************************/

            var ingredients1 = from i in db.Ingredients
                               join ic in db.Ingredient_Categories on i.IngredientId equals ic.IngredientId
                               where ic.CategoryId == 1
                               select i;

            List<SelectListItem> items1 = new List<SelectListItem>();

            items1.Add(new SelectListItem { Value = "0", Text = "Select grain", Selected = true });
            foreach (Ingredient ingredient in ingredients1)
            {

                items1.Add(new SelectListItem { Value = ingredient.IngredientId.ToString(), Text = ingredient.Name  });
            }
            ViewBag.Ingredients1 = items1;
            //ViewData.Clear();


            /***************** ITEMS 2 *************************/

            var ingredients2 = from i in db.Ingredients
                               join ic in db.Ingredient_Categories on i.IngredientId equals ic.IngredientId
                               where ic.CategoryId == 2
                               select i;

            List<SelectListItem> items2 = new List<SelectListItem>();

            items2.Add(new SelectListItem { Value = "0", Text = "Select fruit", Selected = true });
            foreach (Ingredient ingredient in ingredients2)
            {

                items2.Add(new SelectListItem { Value = ingredient.IngredientId.ToString(), Text = ingredient.Name });
            }
            ViewBag.Ingredients2 = items2;
            //ViewData.Clear();

            
            /***************** ITEMS 3*************************/

            var ingredients3 = from i in db.Ingredients
                               join ic in db.Ingredient_Categories on i.IngredientId equals ic.IngredientId
                               where ic.CategoryId == 3
                               select i;

            List<SelectListItem> items3 = new List<SelectListItem>();


            items3.Add(new SelectListItem { Value = "0", Text = "Select nuts", Selected = true });
            foreach (Ingredient ingredient in ingredients3)
            {

                items3.Add(new SelectListItem { Value = ingredient.IngredientId.ToString(), Text = ingredient.Name });
            }
            ViewBag.Ingredients3 = items3;
            //ViewData.Clear();


            /****************** ITEMS 4 ************************/

            var ingredients4 = from i in db.Ingredients
                               join ic in db.Ingredient_Categories on i.IngredientId equals ic.IngredientId
                               where ic.CategoryId == 4
                               select i;

            List<SelectListItem> items4 = new List<SelectListItem>();

            items4.Add(new SelectListItem { Value = "0", Text = "Select seeds", Selected = true });
            foreach (Ingredient ingredient in ingredients4)
            {

                items4.Add(new SelectListItem { Value = ingredient.IngredientId.ToString(), Text = ingredient.Name });
            }
            ViewBag.Ingredients4 = items4;
            //ViewData.Clear();


            /****************** ITEMS 5 ************************/

            var ingredients5 = from i in db.Ingredients
                               join ic in db.Ingredient_Categories on i.IngredientId equals ic.IngredientId
                               where ic.CategoryId == 5
                               select i;

            List<SelectListItem> items5 = new List<SelectListItem>();

            items5.Add(new SelectListItem { Value = "0", Text = "Select others", Selected = true });
            foreach (Ingredient ingredient in ingredients5)
            {

                items5.Add(new SelectListItem { Value = ingredient.IngredientId.ToString(), Text = ingredient.Name });
            }
            ViewBag.Ingredients5 = items5;
            //ViewData.Clear();


            return View();
        }

        /*var bunnies = db.Bunnies.Where(p => p.Color == "white")
                        .Select(x => new SelectListItem
                        {
                            Value = x.Id.ToString(),
                            Text = x.Name,
                        });*/

        /*using (var ctx = new SchoolDBEntities())
        {
            var studentList = ctx.Students.SqlQuery("Select * from Student").ToList<Student>();

        }*/





        /*public System.Collections.Generic.List<IngredientsByCategory> IngredientsByCategory()
        {
            var temp = (from i in db.Ingredients
                        join ic in db.Ingredient_Categories on i.IngredientId equals ic.IngredientId
                        join c in db.Categories on ic.CategoryId equals c.CategoryId
                        select new IngredientsByCategory
                        {
                            CategoryName = c.CatName,
                            IngredientName = i.Name,
                            IngredientCategory = c.CatName
                        });

            return temp.ToList();

        }*/



        /*public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            var ingredients = from s in db.Ingredients
                              select s;
            switch (sortOrder)
            {
                case "name_desc":
                    ingredients = ingredients.OrderByDescending(s => s.Name);
                    break;
                case "Price":
                    ingredients = ingredients.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    ingredients = ingredients.OrderByDescending(s => s.Price);
                    break;
                default:
                    ingredients = ingredients.OrderBy(s => s.Name);
                    break;
            }
            return View(ingredients.ToList());
        }

        // GET: Ingredient/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = db.Ingredients.Find(id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }

        // GET: Ingredient/Create
        public ActionResult Create()
        {
            return View();
        }

        /*protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }*/

    }
}
