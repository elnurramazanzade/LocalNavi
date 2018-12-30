namespace LocalNavi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Admins", "Surname", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Comments", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Status");
            DropColumn("dbo.Comments", "Status");
            DropColumn("dbo.Admins", "Surname");
            DropColumn("dbo.Admins", "Name");
        }
    }
}
