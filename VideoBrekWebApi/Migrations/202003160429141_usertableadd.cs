namespace VideoBrekWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usertableadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Password = c.String(),
                        AccessToken = c.String(),
                        UserVerified = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Latitude = c.Double(),
                        Longitude = c.Double(),
                        CreateDtTm = c.String(),
                        VerifyDtTm = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserProfileConfig",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        UserVerified = c.Int(nullable: false),
                        ApplowLocation = c.Int(nullable: false),
                        AllowLocation = c.Boolean(nullable: false),
                        HideContinueWatchingRow = c.Boolean(nullable: false),
                        EnableLightTheme = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        DownloadOnlyOverWiFi = c.Boolean(nullable: false),
                        BeginPlaybackAutomatically = c.Boolean(nullable: false),
                        AutoplayNextVideo = c.Boolean(nullable: false),
                        BackgroundAudioPlayBack = c.Boolean(nullable: false),
                        CreateDtTm = c.String(),
                        StreamQualityId = c.Int(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StreamQuality", t => t.StreamQualityId)
                .ForeignKey("dbo.UserProfile", t => t.UserId, cascadeDelete: true)
                .Index(t => t.StreamQualityId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.StreamQuality",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreatQualityName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDtTm = c.String(),
                        CreatedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfileConfig", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.UserProfileConfig", "StreamQualityId", "dbo.StreamQuality");
            DropIndex("dbo.UserProfileConfig", new[] { "UserId" });
            DropIndex("dbo.UserProfileConfig", new[] { "StreamQualityId" });
            DropTable("dbo.StreamQuality");
            DropTable("dbo.UserProfileConfig");
            DropTable("dbo.UserProfile");
        }
    }
}
