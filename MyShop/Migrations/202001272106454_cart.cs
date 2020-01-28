namespace MyShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cart : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartItemTables", "ProductId", "dbo.Products");
            DropIndex("dbo.CartItemTables", new[] { "ProductId" });
            CreateTable(
                "dbo.ShoppingCartTables",
                c => new
                    {
                        TempOrderID = c.Int(nullable: false, identity: true),
                        PID = c.Int(nullable: false),
                        PName = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TempOrderID);
            
            DropTable("dbo.CartItemTables");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CartItemTables",
                c => new
                    {
                        ItemId = c.String(nullable: false, maxLength: 128),
                        CartId = c.String(),
                        Quantity = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId);
            
            DropTable("dbo.ShoppingCartTables");
            CreateIndex("dbo.CartItemTables", "ProductId");
            AddForeignKey("dbo.CartItemTables", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
