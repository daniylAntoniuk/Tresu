namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IitializeDB1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblUserFriends",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        FriendId = c.Int(nullable: false),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.tblUsers", t => t.Users_Id)
                .ForeignKey("dbo.tblUsers", t => t.FriendId, cascadeDelete: true)
                .ForeignKey("dbo.tblUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.FriendId)
                .Index(t => t.Users_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblUserFriends", "UserId", "dbo.tblUsers");
            DropForeignKey("dbo.tblUserFriends", "FriendId", "dbo.tblUsers");
            DropForeignKey("dbo.tblUserFriends", "Users_Id", "dbo.tblUsers");
            DropIndex("dbo.tblUserFriends", new[] { "Users_Id" });
            DropIndex("dbo.tblUserFriends", new[] { "FriendId" });
            DropIndex("dbo.tblUserFriends", new[] { "UserId" });
            DropTable("dbo.tblUserFriends");
        }
    }
}
