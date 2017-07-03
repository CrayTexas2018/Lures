namespace Lures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "updated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "updated");
            DropColumn("dbo.Users", "created");
        }
    }
}
