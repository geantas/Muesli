﻿using Microsoft.AspNet.Identity.EntityFramework;

namespace Muesli.Models
{
    public class AppRole : IdentityRole
    {
        public AppRole() : base() { }
        public AppRole(string name) : base(name) { }
    }
}