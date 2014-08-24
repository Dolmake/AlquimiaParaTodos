using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlquimiaParaTodos.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsClient { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Order> Orders {get; set; }
    }
}