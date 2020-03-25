namespace VideoBrek.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MediaCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryCode = c.String(),
                        CategoryName = c.String(),
                        CreateDtTm = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MediaCategories");
        }
    }
}
