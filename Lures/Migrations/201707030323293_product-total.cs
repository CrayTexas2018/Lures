namespace Lures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class producttotal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "subtotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Products", "shipping", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "shipping");
            DropColumn("dbo.Products", "subtotal");
        }
    }
}
