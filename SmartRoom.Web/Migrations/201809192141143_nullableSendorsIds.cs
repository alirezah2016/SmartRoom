namespace SmartRoom.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableSendorsIds : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Reley", new[] { "LightSensorId" });
            DropIndex("dbo.Reley", new[] { "TmpSensorId" });
            AlterColumn("dbo.Reley", "LightSensorId", c => c.Int());
            AlterColumn("dbo.Reley", "TmpSensorId", c => c.Int());
            CreateIndex("dbo.Reley", "LightSensorId");
            CreateIndex("dbo.Reley", "TmpSensorId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Reley", new[] { "TmpSensorId" });
            DropIndex("dbo.Reley", new[] { "LightSensorId" });
            AlterColumn("dbo.Reley", "TmpSensorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Reley", "LightSensorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reley", "TmpSensorId");
            CreateIndex("dbo.Reley", "LightSensorId");
        }
    }
}
