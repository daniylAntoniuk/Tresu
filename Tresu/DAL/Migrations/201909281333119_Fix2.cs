namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblUser", "TwoFactorAunteficationEnabled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblUser", "TwoFactorAunteficationEnabled");
        }
    }
}
