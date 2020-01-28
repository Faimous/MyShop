namespace MyShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "FirstName", c => c.String());
            AddColumn("dbo.Orders", "LastName", c => c.String());
            AddColumn("dbo.Orders", "Address1", c => c.String());
            AddColumn("dbo.Orders", "Address2", c => c.String());
            AddColumn("dbo.Orders", "Email", c => c.String());
            AddColumn("dbo.Orders", "State", c => c.String());
            AddColumn("dbo.Orders", "PostCode", c => c.String());
            DropColumn("dbo.Orders", "UserId");
            DropColumn("dbo.Orders", "UserFullName");
            DropColumn("dbo.Orders", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Address", c => c.String());
            AddColumn("dbo.Orders", "UserFullName", c => c.String());
            AddColumn("dbo.Orders", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "PostCode");
            DropColumn("dbo.Orders", "State");
            DropColumn("dbo.Orders", "Email");
            DropColumn("dbo.Orders", "Address2");
            DropColumn("dbo.Orders", "Address1");
            DropColumn("dbo.Orders", "LastName");
            DropColumn("dbo.Orders", "FirstName");
        }
    }
}
