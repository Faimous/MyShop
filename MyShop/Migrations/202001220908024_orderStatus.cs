namespace MyShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderStatus = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        UserFullName = c.String(),
                        TelephoneNumer = c.String(),
                        Address = c.String(),
                        OrderDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderStatuses", t => t.OrderStatus, cascadeDelete: true)
                .Index(t => t.OrderStatus);
            
            CreateTable(
                "dbo.OrderStatuses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "ProductDescription", c => c.String());
            AddColumn("dbo.Products", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "OrderStatus", "dbo.OrderStatuses");
            DropIndex("dbo.Orders", new[] { "OrderStatus" });
            DropColumn("dbo.Products", "Price");
            DropColumn("dbo.Products", "ProductDescription");
            DropTable("dbo.OrderStatuses");
            DropTable("dbo.Orders");
        }
    }
}
