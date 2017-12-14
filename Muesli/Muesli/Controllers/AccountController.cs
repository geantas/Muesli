using Muesli.DAL;
using Muesli.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Muesli.Controllers
{
    public class AccountController : Controller
    {
        private BreakfastContext db;

        public AccountController()
        {
            db = new BreakfastContext();
        }


        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User objUser)
        {

            if (string.IsNullOrEmpty(objUser.Username))
            {
                ModelState.AddModelError("Username", "Please enter your username"); // name of prop.
            }

            if (string.IsNullOrEmpty(objUser.Password))
            {
                ModelState.AddModelError("Password", "Password is required");
            }

            if (ModelState.IsValid)
            {
                var obj = db.Users.Where(a => a.Username.Equals(objUser.Username) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                if (obj != null)
                {
                    Session["UserID"] = obj.UserId.ToString();
                    Session["Username"] = obj.Username.ToString();
                    Session["Firstname"] = obj.FirstName.ToString();
                    Session["Lastname"] = obj.LastName.ToString();
                    Session["Email"] = obj.Email.ToString();
                    Session["Address"] = obj.Address.ToString();
                    Session["ZipCode"] = obj.ZipCode.ToString();
                    Session["City"] = obj.City.ToString();

                    return RedirectToAction("Account");
                }
                else
                {
                    ModelState.AddModelError("key", "Invalid username or password");
                }
            }
            return View(objUser);
        }

        public ActionResult Account()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User obj)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(obj.FirstName))
                {
                    ModelState.AddModelError("FirstName", "Please enter your First name");
                }
                if (string.IsNullOrEmpty(obj.LastName))
                {
                    ModelState.AddModelError("LastName", "Please enter your Last name");
                }
                if (string.IsNullOrEmpty(obj.Email))
                {
                    ModelState.AddModelError("Email", "Please enter your e-mail");
                }
                if (string.IsNullOrEmpty(obj.Username))
                {
                    ModelState.AddModelError("Username", "Please enter your username");
                }
                if (string.IsNullOrEmpty(obj.Password))
                {
                    ModelState.AddModelError("Password", "Password is required");
                }
                if (string.IsNullOrEmpty(obj.Address))
                {
                    ModelState.AddModelError("Address", "Please enter your address");
                }
                if (string.IsNullOrEmpty(obj.ZipCode))
                {
                    ModelState.AddModelError("ZipCode", "Please enter your zip code");
                }
                if (string.IsNullOrEmpty(obj.City))
                {
                    ModelState.AddModelError("City", "Please enter your city");
                }

                BreakfastContext db = new BreakfastContext();
                db.Users.Add(obj);
                db.SaveChanges();

                return Login(obj);
            }
            return View(obj);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Username,FirstName,LastName,Email,Password,Address,ZipCode,City")] User user)
        {
            if (ModelState.IsValid)
            {

                if (Session["UserID"] != null)
                {

                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    
                    Session["Username"] = user.Username.ToString();
                    Session["Firstname"] = user.FirstName.ToString();
                    Session["Lastname"] = user.LastName.ToString();
                    Session["Email"] = user.Email.ToString();
                    Session["Address"] = user.Address.ToString();
                    Session["ZipCode"] = user.ZipCode.ToString();
                    Session["City"] = user.City.ToString();
                    return RedirectToAction("Account");
                }
                else
                {
                    return RedirectToAction("Login");
                }

            }
            return View(user);
        }

    }
}