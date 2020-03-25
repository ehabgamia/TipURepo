namespace VideoBrek.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mediadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CloudMediaUrl = c.String(),
                        Title = c.String(),
                        Thumbnail = c.String(),
                        MediaDesc = c.String(),
                        SearchTags = c.String(),
                        FileSizeMb = c.Int(),
                        Duration = c.String(),
                        CreateDtTm = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        MediaTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MediaTypes", t => t.MediaTypeId, cascadeDelete: true)
                .Index(t => t.MediaTypeId);
            
            CreateTable(
                "dbo.MediaTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MediaTypeName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreateDtTm = c.String(),
                        CreatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Media", "MediaTypeId", "dbo.MediaTypes");
            DropIndex("dbo.Media", new[] { "MediaTypeId" });
            DropTable("dbo.MediaTypes");
            DropTable("dbo.Media");
        }
    }
}
