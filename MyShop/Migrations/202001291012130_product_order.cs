namespace MyShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product_order : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders_Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(),
                        TotalSale = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders_Products", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Orders_Products", "OrderID", "dbo.Orders");
            DropIndex("dbo.Orders_Products", new[] { "ProductId" });
            DropIndex("dbo.Orders_Products", new[] { "OrderID" });
            DropTable("dbo.Orders_Products");
        }
    }
}
