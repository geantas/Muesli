namespace Muesli.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedVersion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        OrderPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubscriptionId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.User_Order",
                c => new
                    {
                        User_Order_Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.User_Order_Id)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User_Order", "UserId", "dbo.User");
            DropForeignKey("dbo.User_Order", "OrderId", "dbo.Order");
            DropIndex("dbo.User_Order", new[] { "OrderId" });
            DropIndex("dbo.User_Order", new[] { "UserId" });
            DropTable("dbo.User_Order");
            DropTable("dbo.Order");
        }
    }
}
