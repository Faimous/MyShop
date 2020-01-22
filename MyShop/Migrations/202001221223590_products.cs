namespace MyShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class products : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "UnitPrice", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Products", "UnitsInStock", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Products", "UnitsOnOrder", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Products", "Discontinued", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "LastSupply", c => c.DateTime(nullable: false));
            DropColumn("dbo.Products", "ProductDescription");
            DropColumn("dbo.Products", "ImageLink");
            DropColumn("dbo.Products", "Price");
            DropTable("dbo.ProductCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ProductCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "ImageLink", c => c.String());
            AddColumn("dbo.Products", "ProductDescription", c => c.String());
            DropColumn("dbo.Products", "LastSupply");
            DropColumn("dbo.Products", "Discontinued");
            DropColumn("dbo.Products", "UnitsOnOrder");
            DropColumn("dbo.Products", "UnitsInStock");
            DropColumn("dbo.Products", "UnitPrice");
        }
    }
}
