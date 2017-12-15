namespace Muesli.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CatName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Ingredient_Category",
                c => new
                    {
                        Ingredient_Category_Id = c.Int(nullable: false, identity: true),
                        IngredientId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Ingredient_Category_Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Ingredient", t => t.IngredientId, cascadeDelete: true)
                .Index(t => t.IngredientId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Ingredient",
                c => new
                    {
                        IngredientId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IngredientId);
            
            CreateTable(
                "dbo.Order_Ingredient",
                c => new
                    {
                        Order_Ingredient_Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(),
                        IngredientId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Order_Ingredient_Id)
                .ForeignKey("dbo.Ingredient", t => t.IngredientId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.OrderId)
                .Index(t => t.OrderId)
                .Index(t => t.IngredientId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
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
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Address = c.String(),
                        ZipCode = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.User_Subscription",
                c => new
                    {
                        User_Subscription_Id = c.Int(nullable: false, identity: true),
                        SubscriptionId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.User_Subscription_Id)
                .ForeignKey("dbo.Subscription", t => t.SubscriptionId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.SubscriptionId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Subscription",
                c => new
                    {
                        SubscriptionId = c.Int(nullable: false, identity: true),
                        Date_created = c.DateTime(nullable: false),
                        Delivery_frequency = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SubscriptionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User_Subscription", "UserId", "dbo.User");
            DropForeignKey("dbo.User_Subscription", "SubscriptionId", "dbo.Subscription");
            DropForeignKey("dbo.User_Order", "UserId", "dbo.User");
            DropForeignKey("dbo.User_Order", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order_Ingredient", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Order_Ingredient", "IngredientId", "dbo.Ingredient");
            DropForeignKey("dbo.Ingredient_Category", "IngredientId", "dbo.Ingredient");
            DropForeignKey("dbo.Ingredient_Category", "CategoryId", "dbo.Category");
            DropIndex("dbo.User_Subscription", new[] { "UserId" });
            DropIndex("dbo.User_Subscription", new[] { "SubscriptionId" });
            DropIndex("dbo.User_Order", new[] { "OrderId" });
            DropIndex("dbo.User_Order", new[] { "UserId" });
            DropIndex("dbo.Order_Ingredient", new[] { "IngredientId" });
            DropIndex("dbo.Order_Ingredient", new[] { "OrderId" });
            DropIndex("dbo.Ingredient_Category", new[] { "CategoryId" });
            DropIndex("dbo.Ingredient_Category", new[] { "IngredientId" });
            DropTable("dbo.Subscription");
            DropTable("dbo.User_Subscription");
            DropTable("dbo.User");
            DropTable("dbo.User_Order");
            DropTable("dbo.Order");
            DropTable("dbo.Order_Ingredient");
            DropTable("dbo.Ingredient");
            DropTable("dbo.Ingredient_Category");
            DropTable("dbo.Category");
        }
    }
}
