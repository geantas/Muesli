using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Muesli.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int ID { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }

        public virtual ICollection<User_Subscription> User_Subscriptions { get; set; }
    }
}