using AlquimiaParaTodos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace AlquimiaParaTodos.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AlquimiaParaTodos.DAL.AlquimiaParaTodosDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AlquimiaParaTodos.DAL.AlquimiaParaTodosDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var products = new List<Product>
            {
                new Product 
                { 
                    Title = "Aceite de Rosa Mosqueta", 
                    Inci="Aceite Rosa Mosq.", 
                    Summary="Aceite para dejar suave.", 
                    ImageUrl="/img/products/p1.png", 
                    SliderImageUrl="/img/products/p1_800x300.png",
                    ImageDescription="Rosa Mosqueta",
                    Price= Decimal.Parse("12.23"),
                    BasePrice = 10,
                    Weight=Decimal.Parse("12"),
                    Stock=5,
                    Offline=false
                },
                new Product
                { 
                    Title = "Aceite de Almendras dulces", 
                    Inci="Aceite Almendras.", 
                    Summary="Aceite para dejar más suave.", 
                    ImageUrl="/img/products/p2.png", 
                    SliderImageUrl="/img/products/p2_800x300.png",
                    ImageDescription="Aceite de Almendras",
                    Price= Decimal.Parse("11.21"),
                    BasePrice = 11,
                    Weight=Decimal.Parse("11"),
                    Stock=43,
                    Offline=false
                },
                new Product
                { 
                    Title = "Elastina Soluble", 
                    Inci="Elastin Sol.", 
                    Summary="Elastina.", 
                    ImageUrl="/img/products/p3.png", 
                    SliderImageUrl="/img/products/p3_800x300.png",
                    ImageDescription="Elastina Soluble",
                    Price= Decimal.Parse("22"),
                    BasePrice = 23,
                    Weight=Decimal.Parse("24"),
                    Stock=41,
                    Offline=false
                }

            };

            products.ForEach(s => context.Products.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();

            var categories = new List<Category>
            {
                new Category
                {
                    Name="Aceites", Products = new List<Product>()
                },
                new Category
                {
                    Name="Aceites Esenciales", Products = new List<Product>()
                },
                new Category
                {
                    Name="Alimentación", Products = new List<Product>()
                },
                new Category
                {
                    Name="Bellas Artes y Restauración", Products = new List<Product>()
                },
                new Category
                {
                    Name="Cosmética", Products = new List<Product>()
                },
                new Category
                {
                    Name="Disolventes", Products = new List<Product>()
                },
                new Category
                {
                    Name="Efectos Especiales", Products = new List<Product>()
                },
                new Category
                {
                    Name="Envases", Products = new List<Product>()
                },
                new Category
                {
                    Name="Esencias y Aromas", Products = new List<Product>()
                },
                new Category
                {
                    Name="Hogar y Jardín", Products = new List<Product>()
                },
                new Category
                {
                    Name="Jabones", Products = new List<Product>()
                },
                new Category
                {
                    Name="Material de Laboratorio", Products = new List<Product>()
                },
                new Category
                {
                    Name="Novedades", Products = new List<Product>()
                },
                new Category
                {
                    Name="Pigmentos", Products = new List<Product>()
                },             
                new Category
                {
                    Name="Piscinas", Products = new List<Product>()
                },
                new Category
                {
                    Name="Productos químicos", Products = new List<Product>()
                },
                new Category
                {
                    Name="Promociones especiales", Products = new List<Product>()
                },
                new Category
                {
                    Name="Purpurinas", Products = new List<Product>()
                }
             
            };

            categories.ForEach(s => context.Categories.AddOrUpdate(c => c.Name, s));
            context.SaveChanges();

            AddOrUpdateCategory(context, "Aceites", "Aceite Rosa Mosq.");
            AddOrUpdateCategory(context, "Aceites", "Aceite Almendras.");
            AddOrUpdateCategory(context, "Productos químicos", "Elastin Sol.");

            context.SaveChanges();

            //context.Products.AddOrUpdate(p => p.Title, )
        }

        void AddOrUpdateCategory(AlquimiaParaTodos.DAL.AlquimiaParaTodosDBContext context, string categoryName, string inciCode)
        {
            var crs = context.Categories.SingleOrDefault(c => c.Name.Equals(categoryName));
            var product = crs.Products.SingleOrDefault(i => i.Inci.Equals(inciCode));
            if (product == null)
                crs.Products.Add(context.Products.Single(i => i.Inci.Equals(inciCode)));
        }
    }  
}
