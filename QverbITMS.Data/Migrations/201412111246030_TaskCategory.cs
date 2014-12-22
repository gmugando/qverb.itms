namespace QverbITMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaskCategory : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.TaskCategory");

            CreateTable(
                "dbo.TaskCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Descr = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TaskCategory");
        }
    }
}
