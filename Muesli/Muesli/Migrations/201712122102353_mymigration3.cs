namespace Muesli.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mymigration3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false),
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
                "dbo.Subscription",
                c => new
                    {
                        SubscriptionId = c.Int(nullable: false, identity: true),
                        Date_created = c.DateTime(nullable: false),
                        Delivery_frequency = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SubscriptionId);
            
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
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User_Subscription", "UserId", "dbo.User");
            DropForeignKey("dbo.User_Subscription", "SubscriptionId", "dbo.Subscription");
            DropForeignKey("dbo.Ingredient_Category", "IngredientId", "dbo.Ingredient");
            DropForeignKey("dbo.Ingredient_Category", "CategoryId", "dbo.Category");
            DropIndex("dbo.User_Subscription", new[] { "UserId" });
            DropIndex("dbo.User_Subscription", new[] { "SubscriptionId" });
            DropIndex("dbo.Ingredient_Category", new[] { "CategoryId" });
            DropIndex("dbo.Ingredient_Category", new[] { "IngredientId" });
            DropTable("dbo.User");
            DropTable("dbo.User_Subscription");
            DropTable("dbo.Subscription");
            DropTable("dbo.Ingredient");
            DropTable("dbo.Ingredient_Category");
            DropTable("dbo.Category");
        }
    }
}
