namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialize : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblGame", "IconPhoto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblGame", "IconPhoto");
        }
    }
}
