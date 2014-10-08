namespace AlquimiaParaTodos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCartTableMigration : DbMigration
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
            
            AddColumn("dbo.Order", "State", c => c.Int(nullable: false));
            DropColumn("dbo.Order", "RequestState");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "RequestState", c => c.Int(nullable: false));
            DropForeignKey("dbo.Cart", "ProductID", "dbo.Product");
            DropIndex("dbo.Cart", new[] { "ProductID" });
            DropColumn("dbo.Order", "State");
            DropTable("dbo.Cart");
        }
    }
}
