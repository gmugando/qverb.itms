namespace QverbITMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Task : DbMigration
    {
        public override void Up()
        {
            //MoveTable(name: "dbo.Incidents", newSchema: "wunc-za");
            //MoveTable(name: "dbo.IncidentCategories", newSchema: "wunc-za");
            //MoveTable(name: "dbo.Projects", newSchema: "wunc-za");
            //MoveTable(name: "dbo.TaskCategory", newSchema: "wunc-za");
            //CreateTable(
            //    "wunc-za.UserProfile",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            UserName = c.String(),
            //            Email = c.String(),
            //            Male = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);

            //AddColumn("wunc-za.TaskCategory", "Active", c => c.Boolean(nullable: false));
            //AlterColumn("wunc-za.IncidentCategories", "Descr", c => c.String(nullable: false));
        }

        public override void Down()
        {
            //AlterColumn("wunc-za.IncidentCategories", "Descr", c => c.String());
            //DropColumn("wunc-za.TaskCategory", "Active");
            //DropTable("wunc-za.UserProfile");
            //MoveTable(name: "wunc-za.TaskCategory", newSchema: "dbo");
            //MoveTable(name: "wunc-za.Projects", newSchema: "dbo");
            //MoveTable(name: "wunc-za.IncidentCategories", newSchema: "dbo");
            //MoveTable(name: "wunc-za.Incidents", newSchema: "dbo");
        }
    }
}
