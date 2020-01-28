namespace MyShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable_decimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShoppingCartTables", "UnitPrice", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.ShoppingCartTables", "Quantity", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShoppingCartTables", "Quantity", c => c.Int(nullable: false));
            AlterColumn("dbo.ShoppingCartTables", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
