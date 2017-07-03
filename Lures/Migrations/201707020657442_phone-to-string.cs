namespace Lures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class phonetostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "phone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "phone", c => c.Int(nullable: false));
        }
    }
}
