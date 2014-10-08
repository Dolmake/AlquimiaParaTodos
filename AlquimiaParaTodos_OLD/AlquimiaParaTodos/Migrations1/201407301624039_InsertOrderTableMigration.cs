namespace AlquimiaParaTodos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertOrderTableMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Request", "UserID", "dbo.User");
            DropForeignKey("dbo.Product", "Request_UserID", "dbo.Request");
            DropIndex("dbo.Request", new[] { "UserID" });
            DropIndex("dbo.Product", new[] { "Request_UserID" });
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
                        RequestState = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ID, t.UserID })
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            AddColumn("dbo.Product", "Order_ID", c => c.Int());
            AddColumn("dbo.Product", "Order_UserID", c => c.Int());
            CreateIndex("dbo.Product", new[] { "Order_ID", "Order_UserID" });
            AddForeignKey("dbo.Product", new[] { "Order_ID", "Order_UserID" }, "dbo.Order", new[] { "ID", "UserID" });
            DropColumn("dbo.Product", "Request_UserID");
            DropTable("dbo.Request");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Request",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        ID = c.Int(nullable: false),
                        Code = c.String(),
                        Date = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExtraPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RequestState = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            AddColumn("dbo.Product", "Request_UserID", c => c.Int());
            DropForeignKey("dbo.Product", new[] { "Order_ID", "Order_UserID" }, "dbo.Order");
            DropForeignKey("dbo.Order", "UserID", "dbo.User");
            DropIndex("dbo.Product", new[] { "Order_ID", "Order_UserID" });
            DropIndex("dbo.Order", new[] { "UserID" });
            DropColumn("dbo.Product", "Order_UserID");
            DropColumn("dbo.Product", "Order_ID");
            DropTable("dbo.Order");
            CreateIndex("dbo.Product", "Request_UserID");
            CreateIndex("dbo.Request", "UserID");
            AddForeignKey("dbo.Product", "Request_UserID", "dbo.Request", "UserID");
            AddForeignKey("dbo.Request", "UserID", "dbo.User", "ID");
        }
    }
}
