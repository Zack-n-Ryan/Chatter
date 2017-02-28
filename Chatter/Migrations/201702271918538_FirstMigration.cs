namespace Chatter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChatFeeds",
                c => new
                    {
                        TweetID = c.Int(nullable: false, identity: true),
                        TweetContent = c.String(),
                        TweetDate = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TweetID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChatFeeds", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ChatFeeds", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ChatFeeds");
        }
    }
}
