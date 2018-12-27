namespace LocalNavi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NaviDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Icon = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoryServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        ServiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.ServiceID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlaceServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlaceID = c.Int(nullable: false),
                        ServiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Places", t => t.PlaceID, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceID, cascadeDelete: true)
                .Index(t => t.PlaceID)
                .Index(t => t.ServiceID);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 100),
                        Slogan = c.String(maxLength: 100),
                        Desc = c.String(storeType: "ntext"),
                        Address = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 50),
                        Website = c.String(maxLength: 50),
                        Lat = c.String(maxLength: 50),
                        Lng = c.String(maxLength: 50),
                        CategoryID = c.Int(nullable: false),
                        CityID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.CityID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.CityID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Photo = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Short(nullable: false),
                        Text = c.String(),
                        Date = c.DateTime(nullable: false),
                        PlaceID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Places", t => t.PlaceID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: false)
                .Index(t => t.PlaceID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.CommentPhotoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentID = c.Int(nullable: false),
                        Photo = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comments", t => t.CommentID, cascadeDelete: true)
                .Index(t => t.CommentID);
            
            CreateTable(
                "dbo.Reactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Type = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comments", t => t.CommentID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: false)
                .Index(t => t.CommentID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Password = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlacePhotoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Photo = c.String(maxLength: 200),
                        PlaceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Places", t => t.PlaceID, cascadeDelete: true)
                .Index(t => t.PlaceID);
            
            CreateTable(
                "dbo.WorkHours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DayNo = c.Int(nullable: false),
                        OpenHour = c.Time(nullable: false, precision: 7),
                        CloseHour = c.Time(nullable: false, precision: 7),
                        PlaceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Places", t => t.PlaceID, cascadeDelete: true)
                .Index(t => t.PlaceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlaceServices", "ServiceID", "dbo.Services");
            DropForeignKey("dbo.WorkHours", "PlaceID", "dbo.Places");
            DropForeignKey("dbo.PlaceServices", "PlaceID", "dbo.Places");
            DropForeignKey("dbo.PlacePhotoes", "PlaceID", "dbo.Places");
            DropForeignKey("dbo.Reactions", "UserID", "dbo.Users");
            DropForeignKey("dbo.Places", "UserID", "dbo.Users");
            DropForeignKey("dbo.Comments", "UserID", "dbo.Users");
            DropForeignKey("dbo.Reactions", "CommentID", "dbo.Comments");
            DropForeignKey("dbo.Comments", "PlaceID", "dbo.Places");
            DropForeignKey("dbo.CommentPhotoes", "CommentID", "dbo.Comments");
            DropForeignKey("dbo.Places", "CityID", "dbo.Cities");
            DropForeignKey("dbo.Places", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.CategoryServices", "ServiceID", "dbo.Services");
            DropForeignKey("dbo.CategoryServices", "CategoryID", "dbo.Categories");
            DropIndex("dbo.WorkHours", new[] { "PlaceID" });
            DropIndex("dbo.PlacePhotoes", new[] { "PlaceID" });
            DropIndex("dbo.Reactions", new[] { "UserID" });
            DropIndex("dbo.Reactions", new[] { "CommentID" });
            DropIndex("dbo.CommentPhotoes", new[] { "CommentID" });
            DropIndex("dbo.Comments", new[] { "UserID" });
            DropIndex("dbo.Comments", new[] { "PlaceID" });
            DropIndex("dbo.Places", new[] { "UserID" });
            DropIndex("dbo.Places", new[] { "CityID" });
            DropIndex("dbo.Places", new[] { "CategoryID" });
            DropIndex("dbo.PlaceServices", new[] { "ServiceID" });
            DropIndex("dbo.PlaceServices", new[] { "PlaceID" });
            DropIndex("dbo.CategoryServices", new[] { "ServiceID" });
            DropIndex("dbo.CategoryServices", new[] { "CategoryID" });
            DropTable("dbo.WorkHours");
            DropTable("dbo.PlacePhotoes");
            DropTable("dbo.Users");
            DropTable("dbo.Reactions");
            DropTable("dbo.CommentPhotoes");
            DropTable("dbo.Comments");
            DropTable("dbo.Cities");
            DropTable("dbo.Places");
            DropTable("dbo.PlaceServices");
            DropTable("dbo.Services");
            DropTable("dbo.CategoryServices");
            DropTable("dbo.Categories");
        }
    }
}
