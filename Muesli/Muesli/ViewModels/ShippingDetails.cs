using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Muesli.ViewModels
{
    public class ShippingDetails
    {
        [Display(Name = "First name")]
        public string Firstname { get; set; }
        [Display(Name = "Last name")]
        public string Lastname { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        public string Address { get; set; }
        [Display(Name = "Zip code")]
        public string ZipCode { get; set; }
        public string City { get; set; }
        public bool SaveToSubs { get; set; }
    }
}