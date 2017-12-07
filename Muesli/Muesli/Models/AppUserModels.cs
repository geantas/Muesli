using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Muesli.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

