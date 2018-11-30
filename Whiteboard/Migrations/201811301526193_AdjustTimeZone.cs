namespace Whiteboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustTimeZone : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WhiteboardItem", "UploadDate", c => c.DateTime(nullable: false, defaultValueSql: "SYSDATETIME()"));
        }

        public override void Down()
        {
        }
    }
}
