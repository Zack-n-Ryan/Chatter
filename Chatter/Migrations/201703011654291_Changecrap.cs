namespace Chatter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changecrap : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ChatFeeds", name: "ApplicationUser_Id", newName: "ApplicationUser02_Id");
            RenameIndex(table: "dbo.ChatFeeds", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUser02_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ChatFeeds", name: "IX_ApplicationUser02_Id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.ChatFeeds", name: "ApplicationUser02_Id", newName: "ApplicationUser_Id");
        }
    }
}
