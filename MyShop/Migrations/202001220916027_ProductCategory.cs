namespace MyShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ProductCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.OrderStatuses", "OrderName", c => c.String());
            DropColumn("dbo.OrderStatuses", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderStatuses", "Name", c => c.String());
            DropColumn("dbo.OrderStatuses", "OrderName");
            DropTable("dbo.ProductCategories");
        }
    }
}
