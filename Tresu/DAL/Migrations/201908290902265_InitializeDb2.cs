namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeDb2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblLock",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reason = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                        LockTime = c.DateTime(nullable: false),
                        UnlockTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            AddColumn("dbo.tblUser", "IsLocked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblLock", "UserId", "dbo.tblUser");
            DropIndex("dbo.tblLock", new[] { "UserId" });
            DropColumn("dbo.tblUser", "IsLocked");
            DropTable("dbo.tblLock");
        }
    }
}
