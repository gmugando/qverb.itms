namespace QverbITMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncidentColumns : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Incidents");

            CreateTable(
                "dbo.Incidents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Descr = c.String(nullable: false, maxLength: 500),
                        LoggedDate = c.DateTime(nullable: false),
                        LoggedBy = c.String(),
                        PercentageComplete = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        IncidentDate = c.DateTime(nullable: false),
                        IncidentTime = c.DateTime(nullable: false),
                        Priority = c.Int(nullable: false),
                        Location = c.String(nullable: false),
                        ActionTaken = c.String(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IncidentCategories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.IncidentCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        Descr = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Incidents", "Category_Id", "dbo.IncidentCategories");
            DropIndex("dbo.Incidents", new[] { "Category_Id" });
            DropTable("dbo.IncidentCategories");
            DropTable("dbo.Incidents");
        }
    }
}
