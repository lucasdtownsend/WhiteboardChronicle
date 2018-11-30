namespace Whiteboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaggedWhiteboard",
                c => new
                    {
                        TaggedWhiteboardID = c.Int(nullable: false, identity: true),
                        TagID = c.Int(nullable: false),
                        WhiteboardItemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaggedWhiteboardID)
                .ForeignKey("dbo.Tag", t => t.TagID, cascadeDelete: true)
                .ForeignKey("dbo.WhiteboardItem", t => t.WhiteboardItemID, cascadeDelete: true)
                .Index(t => t.TagID)
                .Index(t => t.WhiteboardItemID);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        TagID = c.Int(nullable: false, identity: true),
                        TagName = c.String(),
                    })
                .PrimaryKey(t => t.TagID);
            
            CreateTable(
                "dbo.WhiteboardItem",
                c => new
                    {
                        WhiteboardItemID = c.Int(nullable: false, identity: true),
                        ImageURL = c.String(),
                        UserID = c.Int(nullable: false),
                        UploadDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.WhiteboardItemID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        TeamID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Team", t => t.TeamID, cascadeDelete: true)
                .Index(t => t.TeamID);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        TeamID = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                        Organization = c.String(),
                    })
                .PrimaryKey(t => t.TeamID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WhiteboardItem", "UserID", "dbo.User");
            DropForeignKey("dbo.User", "TeamID", "dbo.Team");
            DropForeignKey("dbo.TaggedWhiteboard", "WhiteboardItemID", "dbo.WhiteboardItem");
            DropForeignKey("dbo.TaggedWhiteboard", "TagID", "dbo.Tag");
            DropIndex("dbo.User", new[] { "TeamID" });
            DropIndex("dbo.WhiteboardItem", new[] { "UserID" });
            DropIndex("dbo.TaggedWhiteboard", new[] { "WhiteboardItemID" });
            DropIndex("dbo.TaggedWhiteboard", new[] { "TagID" });
            DropTable("dbo.Team");
            DropTable("dbo.User");
            DropTable("dbo.WhiteboardItem");
            DropTable("dbo.Tag");
            DropTable("dbo.TaggedWhiteboard");
        }
    }
}
