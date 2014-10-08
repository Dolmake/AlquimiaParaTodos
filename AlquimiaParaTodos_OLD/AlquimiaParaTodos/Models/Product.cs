using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace AlquimiaParaTodos.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Inci { get; set; }
        public string Summary { get; set; }
        public string SliderImageUrl { get; set; }
        public string ImageUrl { get; set; }
        public string ImageDescription { get; set; }
        public decimal Price { get; set; }
        public decimal BasePrice { get; set; }
        public decimal Weight { get; set; }
        public int Stock { get; set; }
        public bool Offline { get; set; }

        public virtual Option ProductOption { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }

    //public class ProductDBContext : DbContext
    //{
    //    public DbSet<Product> Products { get; set; }
    //}

}