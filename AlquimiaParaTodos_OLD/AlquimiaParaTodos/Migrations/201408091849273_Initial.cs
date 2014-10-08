namespace AlquimiaParaTodos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CartOwnerID = c.String(),
                        Quantity = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Inci = c.String(),
                        Summary = c.String(),
                        SliderImageUrl = c.String(),
                        ImageUrl = c.String(),
                        ImageDescription = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stock = c.Int(nullable: false),
                        Offline = c.Boolean(nullable: false),
                        ProductOption_ID = c.Int(),
                        Product_ID = c.Int(),
                        Order_ID = c.Int(),
                        Order_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Option", t => t.ProductOption_ID)
                .ForeignKey("dbo.Product", t => t.Product_ID)
                .ForeignKey("dbo.Order", t => new { t.Order_ID, t.Order_UserID })
                .Index(t => t.ProductOption_ID)
                .Index(t => t.Product_ID)
                .Index(t => new { t.Order_ID, t.Order_UserID });
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Hours = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Option",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Color = c.String(),
                        Description = c.String(),
                        ExtraPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Code = c.String(),
                        Date = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExtraPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        State = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ID, t.UserID })
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        IsClient = c.Boolean(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CategoryProduct",
                c => new
                    {
                        CategoryID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CategoryID, t.ProductID })
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.ProductCourse",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.CourseID })
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", new[] { "Order_ID", "Order_UserID" }, "dbo.Order");
            DropForeignKey("dbo.Order", "UserID", "dbo.User");
            DropForeignKey("dbo.Cart", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Product", "Product_ID", "dbo.Product");
            DropForeignKey("dbo.Product", "ProductOption_ID", "dbo.Option");
            DropForeignKey("dbo.ProductCourse", "CourseID", "dbo.Course");
            DropForeignKey("dbo.ProductCourse", "ProductID", "dbo.Product");
            DropForeignKey("dbo.CategoryProduct", "ProductID", "dbo.Product");
            DropForeignKey("dbo.CategoryProduct", "CategoryID", "dbo.Category");
            DropIndex("dbo.Product", new[] { "Order_ID", "Order_UserID" });
            DropIndex("dbo.Order", new[] { "UserID" });
            DropIndex("dbo.Cart", new[] { "ProductID" });
            DropIndex("dbo.Product", new[] { "Product_ID" });
            DropIndex("dbo.Product", new[] { "ProductOption_ID" });
            DropIndex("dbo.ProductCourse", new[] { "CourseID" });
            DropIndex("dbo.ProductCourse", new[] { "ProductID" });
            DropIndex("dbo.CategoryProduct", new[] { "ProductID" });
            DropIndex("dbo.CategoryProduct", new[] { "CategoryID" });
            DropTable("dbo.ProductCourse");
            DropTable("dbo.CategoryProduct");
            DropTable("dbo.User");
            DropTable("dbo.Order");
            DropTable("dbo.Option");
            DropTable("dbo.Course");
            DropTable("dbo.Category");
            DropTable("dbo.Product");
            DropTable("dbo.Cart");
        }
    }
}
