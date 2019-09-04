namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeDb4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblGame", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblGame", "Description", c => c.String(maxLength: 100));
        }
    }
}
