namespace Muesli.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class i_hate_my_life : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subscription", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subscription", "UserId");
        }
    }
}
