namespace HolidayApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class One : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HolidayHomes",
                c => new
                    {
                        HolidayHomeId = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        numberofGuests = c.Int(nullable: false),
                        numberofBeds = c.Int(nullable: false),
                        doubleBed = c.Boolean(nullable: false),
                        petsAllowed = c.Boolean(nullable: false),
                        Kitchen = c.Boolean(nullable: false),
                        Toilet = c.Boolean(nullable: false),
                        numberofTelevisions = c.Int(nullable: false),
                        numberofFloors = c.Int(nullable: false),
                        ResortId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HolidayHomeId)
                .ForeignKey("dbo.Resorts", t => t.ResortId, cascadeDelete: true)
                .Index(t => t.ResortId);
            
            CreateTable(
                "dbo.Resorts",
                c => new
                    {
                        ResortId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        TelephoneNumber = c.String(),
                        ApplicationUserID = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ResortId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        HotelId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        TelephoneNumber = c.String(),
                        ApplicationUserID = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.HotelId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Parkings",
                c => new
                    {
                        ParkingId = c.Int(nullable: false, identity: true),
                        parkingPlaces = c.Int(nullable: false),
                        pricePerDay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Guarded = c.Boolean(nullable: false),
                        ResortId = c.Int(nullable: false),
                        HotelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ParkingId)
                .ForeignKey("dbo.Hotels", t => t.HotelId, cascadeDelete: true)
                .ForeignKey("dbo.Resorts", t => t.ResortId, cascadeDelete: true)
                .Index(t => t.ResortId)
                .Index(t => t.HotelId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        numberofGuests = c.Int(nullable: false),
                        numberofBeds = c.Int(nullable: false),
                        doubleBed = c.Boolean(nullable: false),
                        petsAllowed = c.Boolean(nullable: false),
                        Kitchen = c.Boolean(nullable: false),
                        Toilet = c.Boolean(nullable: false),
                        numberofTelevisions = c.Int(nullable: false),
                        ResortId = c.Int(nullable: false),
                        HotelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoomId)
                .ForeignKey("dbo.Hotels", t => t.HotelId, cascadeDelete: true)
                .ForeignKey("dbo.Resorts", t => t.ResortId, cascadeDelete: true)
                .Index(t => t.ResortId)
                .Index(t => t.HotelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HolidayHomes", "ResortId", "dbo.Resorts");
            DropForeignKey("dbo.Resorts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Rooms", "ResortId", "dbo.Resorts");
            DropForeignKey("dbo.Rooms", "HotelId", "dbo.Hotels");
            DropForeignKey("dbo.Parkings", "ResortId", "dbo.Resorts");
            DropForeignKey("dbo.Parkings", "HotelId", "dbo.Hotels");
            DropForeignKey("dbo.Hotels", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Rooms", new[] { "HotelId" });
            DropIndex("dbo.Rooms", new[] { "ResortId" });
            DropIndex("dbo.Parkings", new[] { "HotelId" });
            DropIndex("dbo.Parkings", new[] { "ResortId" });
            DropIndex("dbo.Hotels", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Resorts", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.HolidayHomes", new[] { "ResortId" });
            DropTable("dbo.Rooms");
            DropTable("dbo.Parkings");
            DropTable("dbo.Hotels");
            DropTable("dbo.Resorts");
            DropTable("dbo.HolidayHomes");
        }
    }
}
