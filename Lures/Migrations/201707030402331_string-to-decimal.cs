namespace Lures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stringtodecimal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "orderTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Products", "price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "orderTotal", c => c.String());
            DropColumn("dbo.Products", "total");
        }
    }
}
