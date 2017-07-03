namespace Lures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creditcard : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "creditCardNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "expireMonth", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "expireYear", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "cvv", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "cvv");
            DropColumn("dbo.Orders", "expireYear");
            DropColumn("dbo.Orders", "expireMonth");
            DropColumn("dbo.Orders", "creditCardNumber");
        }
    }
}
