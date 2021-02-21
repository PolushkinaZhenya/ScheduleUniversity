namespace ScheduleImplementations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auditoriums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(nullable: false),
                        Capacity = c.Int(nullable: false),
                        EducationalBuildingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EducationalBuildings", t => t.EducationalBuildingId, cascadeDelete: true)
                .Index(t => t.EducationalBuildingId);
            
            CreateTable(
                "dbo.EducationalBuildings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Auditoriums", "EducationalBuildingId", "dbo.EducationalBuildings");
            DropIndex("dbo.Auditoriums", new[] { "EducationalBuildingId" });
            DropTable("dbo.EducationalBuildings");
            DropTable("dbo.Auditoriums");
        }
    }
}
