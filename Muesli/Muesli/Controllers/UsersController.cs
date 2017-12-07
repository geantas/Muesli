using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Muesli.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        [Authorize]
        // [AllowAnonymous]
        public ActionResult Index()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("Key", "Value");
            return View(data);
        }

    }
}