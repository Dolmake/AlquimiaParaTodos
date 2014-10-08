using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlquimiaParaTodos.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Hours { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}