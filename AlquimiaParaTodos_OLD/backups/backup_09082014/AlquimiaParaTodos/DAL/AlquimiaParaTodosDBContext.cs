using AlquimiaParaTodos.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AlquimiaParaTodos.DAL
{
    public class AlquimiaParaTodosDBContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }

        /// <summary>
        /// To Add new entities to the data model. Is this case, it is added a many-to-many relationship
        /// between Product and Category and between Product and Course.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Product>()
                .HasMany(c => c.Courses).WithMany(i => i.Products)
                .Map(t => t.MapLeftKey("ProductID")
                    .MapRightKey("CourseID")
                    .ToTable("ProductCourse"));

            modelBuilder.Entity<Category>()
               .HasMany(c => c.Products).WithMany(i => i.Categories)
               .Map(t => t.MapLeftKey("CategoryID")
                   .MapRightKey("ProductID")
                   .ToTable("CategoryProduct"));

        }
    }
}