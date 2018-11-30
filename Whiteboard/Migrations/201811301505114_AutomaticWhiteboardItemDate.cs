namespace Whiteboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutomaticWhiteboardItemDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WhiteboardItem", "UploadDate", c => c.DateTime(nullable: false, defaultValueSql: "SYSDATETIME()"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WhiteboardItem", "UploadDate", c => c.DateTime(nullable: false));
        }
    }
}
