namespace SmartRoom.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class r : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TmpSensor", "ReleyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TmpSensor", "ReleyId", c => c.Int(nullable: false));
        }
    }
}
