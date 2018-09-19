namespace SmartRoom.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullablevaluerelay : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reley", "Value", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reley", "Value", c => c.Boolean(nullable: false));
        }
    }
}
