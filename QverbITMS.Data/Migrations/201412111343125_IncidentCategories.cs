namespace QverbITMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncidentCategories : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IncidentCategories", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.IncidentCategories", "Active");
        }
    }
}
