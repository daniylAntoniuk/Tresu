namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblGame",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 100),
                        Price = c.String(nullable: false, maxLength: 100),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblSkin",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Photo = c.String(),
                        Price = c.String(nullable: false, maxLength: 100),
                        GameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblGame", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.tblUserSkin",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SkinId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblSkin", t => t.SkinId, cascadeDelete: true)
                .Index(t => t.SkinId);
            
            CreateTable(
                "dbo.tblUserGame",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                        UserSkins_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblGame", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.tblUser", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.tblUserSkin", t => t.UserSkins_Id)
                .Index(t => t.UserId)
                .Index(t => t.GameId)
                .Index(t => t.UserSkins_Id);
            
            CreateTable(
                "dbo.tblUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Login = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblUserGame", "UserSkins_Id", "dbo.tblUserSkin");
            DropForeignKey("dbo.tblUserGame", "UserId", "dbo.tblUser");
            DropForeignKey("dbo.tblUserGame", "GameId", "dbo.tblGame");
            DropForeignKey("dbo.tblUserSkin", "SkinId", "dbo.tblSkin");
            DropForeignKey("dbo.tblSkin", "GameId", "dbo.tblGame");
            DropIndex("dbo.tblUserGame", new[] { "UserSkins_Id" });
            DropIndex("dbo.tblUserGame", new[] { "GameId" });
            DropIndex("dbo.tblUserGame", new[] { "UserId" });
            DropIndex("dbo.tblUserSkin", new[] { "SkinId" });
            DropIndex("dbo.tblSkin", new[] { "GameId" });
            DropTable("dbo.tblUser");
            DropTable("dbo.tblUserGame");
            DropTable("dbo.tblUserSkin");
            DropTable("dbo.tblSkin");
            DropTable("dbo.tblGame");
        }
    }
}
