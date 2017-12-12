using Muesli.DAL;
using Muesli.Models;
using System.Linq;
using System.Web.Mvc;

namespace Muesli.Controllers
{
    public class LoginController : Controller
    {
        private BreakfastContext db;

        public LoginController()
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
                ModelState.AddModelError("Password", "Please enter your password");
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
                    return RedirectToAction("UserDashBoard");
                }
                else
                {
                    ModelState.AddModelError("key", "Invalid username or password");
                }
            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
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
            return RedirectToAction("Login", "Login");
        }
    }
}