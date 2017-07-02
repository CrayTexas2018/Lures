namespace Lures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        shippingFirstName = c.String(),
                        shippingLastName = c.String(),
                        shippingEmailAddress = c.String(),
                        shippingAddress = c.String(),
                        shippingAddress2 = c.String(),
                        shippingCity = c.String(),
                        shippingZip = c.String(),
                        shippingCountry = c.String(),
                        shippingState = c.String(),
                        phone = c.String(),
                        billingFirstName = c.String(),
                        billingLastName = c.String(),
                        billingAddress = c.String(),
                        billingAddress2 = c.String(),
                        billingCity = c.String(),
                        billingZip = c.String(),
                        billingCountry = c.String(),
                        billingState = c.String(),
                        nextRecurringDate = c.DateTime(nullable: false),
                        recurring = c.Boolean(nullable: false),
                        rebillDiscount = c.Int(nullable: false),
                        transactionId = c.String(),
                        authId = c.String(),
                        trackingNumber = c.String(),
                        status = c.String(),
                        shippingMethod = c.String(),
                        subTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        shipping = c.Decimal(nullable: false, precision: 18, scale: 2),
                        salesTax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        orderTotal = c.String(),
                        created = c.DateTime(nullable: false),
                        user_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.user_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        password = c.String(),
                        prospectId = c.Int(nullable: false),
                        customerId = c.Int(nullable: false),
                        firstName = c.String(maxLength: 64),
                        lastName = c.String(maxLength: 64),
                        address1 = c.String(maxLength: 64),
                        address2 = c.String(maxLength: 64),
                        city = c.String(maxLength: 32),
                        state = c.String(maxLength: 32),
                        zip = c.Int(nullable: false),
                        country = c.String(maxLength: 2),
                        phone = c.Int(nullable: false),
                        email = c.String(maxLength: 96),
                        ipAddress = c.String(maxLength: 15),
                        AFID = c.String(maxLength: 100),
                        SID = c.String(maxLength: 100),
                        AFFID = c.String(maxLength: 100),
                        C1 = c.String(maxLength: 100),
                        C2 = c.String(maxLength: 100),
                        C3 = c.String(maxLength: 100),
                        AID = c.String(maxLength: 100),
                        OPT = c.String(maxLength: 100),
                        click_id = c.String(maxLength: 255),
                        campaignId = c.Int(nullable: false),
                        notes = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        sku = c.String(),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        cogs = c.Decimal(nullable: false, precision: 18, scale: 2),
                        description = c.String(),
                        selfRecurring = c.Boolean(nullable: false),
                        shippingWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        declaredProductValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        active = c.Boolean(nullable: false),
                        created = c.DateTime(nullable: false),
                        updated = c.DateTime(nullable: false),
                        nextRecurringProduct_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Products", t => t.nextRecurringProduct_id)
                .Index(t => t.nextRecurringProduct_id);
            
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        start = c.DateTime(nullable: false),
                        next = c.DateTime(nullable: false),
                        active = c.Boolean(nullable: false),
                        order_id = c.Int(),
                        product_id = c.Int(),
                        user_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Orders", t => t.order_id)
                .ForeignKey("dbo.Products", t => t.product_id)
                .ForeignKey("dbo.Users", t => t.user_id)
                .Index(t => t.order_id)
                .Index(t => t.product_id)
                .Index(t => t.user_id);     
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subscriptions", "user_id", "dbo.Users");
            DropForeignKey("dbo.Subscriptions", "product_id", "dbo.Products");
            DropForeignKey("dbo.Subscriptions", "order_id", "dbo.Orders");
            DropForeignKey("dbo.Products", "nextRecurringProduct_id", "dbo.Products");
            DropForeignKey("dbo.Orders", "user_id", "dbo.Users");
            DropIndex("dbo.Subscriptions", new[] { "user_id" });
            DropIndex("dbo.Subscriptions", new[] { "product_id" });
            DropIndex("dbo.Subscriptions", new[] { "order_id" });
            DropIndex("dbo.Products", new[] { "nextRecurringProduct_id" });
            DropIndex("dbo.Orders", new[] { "user_id" });
            DropTable("dbo.Subscriptions");
            DropTable("dbo.Products");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
        }
    }
}
