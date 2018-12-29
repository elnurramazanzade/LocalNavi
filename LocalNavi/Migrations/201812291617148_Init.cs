namespace LocalNavi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "Login", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Admins", "Password", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Categories", "Icon", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Services", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Places", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Places", "Slogan", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Places", "Desc", c => c.String(nullable: false, storeType: "ntext"));
            AlterColumn("dbo.Places", "Address", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Places", "Phone", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Cities", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Cities", "Photo", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Comments", "Text", c => c.String(nullable: false, maxLength: 140));
            AlterColumn("dbo.CommentPhotoes", "Photo", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "Surname", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.PlacePhotoes", "Photo", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PlacePhotoes", "Photo", c => c.String(maxLength: 200));
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 100));
            AlterColumn("dbo.Users", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "Surname", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.CommentPhotoes", "Photo", c => c.String(maxLength: 200));
            AlterColumn("dbo.Comments", "Text", c => c.String());
            AlterColumn("dbo.Cities", "Photo", c => c.String(maxLength: 200));
            AlterColumn("dbo.Cities", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Places", "Phone", c => c.String(maxLength: 50));
            AlterColumn("dbo.Places", "Address", c => c.String(maxLength: 100));
            AlterColumn("dbo.Places", "Desc", c => c.String(storeType: "ntext"));
            AlterColumn("dbo.Places", "Slogan", c => c.String(maxLength: 100));
            AlterColumn("dbo.Places", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.Services", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Categories", "Icon", c => c.String(maxLength: 200));
            AlterColumn("dbo.Categories", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Admins", "Password", c => c.String(maxLength: 100));
            AlterColumn("dbo.Admins", "Login", c => c.String(maxLength: 50));
        }
    }
}
