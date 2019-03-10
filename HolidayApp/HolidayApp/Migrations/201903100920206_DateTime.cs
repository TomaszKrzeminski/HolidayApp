namespace HolidayApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTime : DbMigration
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
                        Resort_ResortId = c.Int(),
                    })
                .PrimaryKey(t => t.HolidayHomeId)
                .ForeignKey("dbo.Resorts", t => t.Resort_ResortId)
                .Index(t => t.Resort_ResortId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        HolidayHome_HolidayHomeId = c.Int(),
                        Resort_ResortId = c.Int(),
                        Parking_ParkingId = c.Int(),
                        Room_RoomId = c.Int(),
                        Hotel_HotelId = c.Int(),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.HolidayHomes", t => t.HolidayHome_HolidayHomeId)
                .ForeignKey("dbo.Resorts", t => t.Resort_ResortId)
                .ForeignKey("dbo.Parkings", t => t.Parking_ParkingId)
                .ForeignKey("dbo.Rooms", t => t.Room_RoomId)
                .ForeignKey("dbo.Hotels", t => t.Hotel_HotelId)
                .Index(t => t.HolidayHome_HolidayHomeId)
                .Index(t => t.Resort_ResortId)
                .Index(t => t.Parking_ParkingId)
                .Index(t => t.Room_RoomId)
                .Index(t => t.Hotel_HotelId);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        HotelId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        TelephoneNumber = c.Int(nullable: false),
                        ApplicationUserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.HotelId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Resorts",
                c => new
                    {
                        ResortId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        TelephoneNumber = c.Int(nullable: false),
                        ApplicationUserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ResortId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);
            
            CreateTable(
                "dbo.Parkings",
                c => new
                    {
                        ParkingId = c.Int(nullable: false, identity: true),
                        parkingPlaces = c.Int(nullable: false),
                        pricePerDay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Guarded = c.Boolean(nullable: false),
                        Hotel_HotelId = c.Int(),
                        Resort_ResortId = c.Int(),
                    })
                .PrimaryKey(t => t.ParkingId)
                .ForeignKey("dbo.Hotels", t => t.Hotel_HotelId)
                .ForeignKey("dbo.Resorts", t => t.Resort_ResortId)
                .Index(t => t.Hotel_HotelId)
                .Index(t => t.Resort_ResortId);
            
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
                        Hotel_HotelId = c.Int(),
                        Resort_ResortId = c.Int(),
                    })
                .PrimaryKey(t => t.RoomId)
                .ForeignKey("dbo.Hotels", t => t.Hotel_HotelId)
                .ForeignKey("dbo.Resorts", t => t.Resort_ResortId)
                .Index(t => t.Hotel_HotelId)
                .Index(t => t.Resort_ResortId);
            
            CreateTable(
                "dbo.ReserveObjects",
                c => new
                    {
                        ReserveObjectId = c.Int(nullable: false, identity: true),
                        bookingFrom = c.DateTime(nullable: false),
                        bookingToo = c.DateTime(nullable: false),
                        totalHours = c.Int(nullable: false),
                        totalDays = c.Int(nullable: false),
                        HolidayHome_HolidayHomeId = c.Int(),
                        Room_RoomId = c.Int(),
                    })
                .PrimaryKey(t => t.ReserveObjectId)
                .ForeignKey("dbo.HolidayHomes", t => t.HolidayHome_HolidayHomeId)
                .ForeignKey("dbo.Rooms", t => t.Room_RoomId)
                .Index(t => t.HolidayHome_HolidayHomeId)
                .Index(t => t.Room_RoomId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Images", "Hotel_HotelId", "dbo.Hotels");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Rooms", "Resort_ResortId", "dbo.Resorts");
            DropForeignKey("dbo.ReserveObjects", "Room_RoomId", "dbo.Rooms");
            DropForeignKey("dbo.ReserveObjects", "HolidayHome_HolidayHomeId", "dbo.HolidayHomes");
            DropForeignKey("dbo.Images", "Room_RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "Hotel_HotelId", "dbo.Hotels");
            DropForeignKey("dbo.Parkings", "Resort_ResortId", "dbo.Resorts");
            DropForeignKey("dbo.Images", "Parking_ParkingId", "dbo.Parkings");
            DropForeignKey("dbo.Parkings", "Hotel_HotelId", "dbo.Hotels");
            DropForeignKey("dbo.Images", "Resort_ResortId", "dbo.Resorts");
            DropForeignKey("dbo.HolidayHomes", "Resort_ResortId", "dbo.Resorts");
            DropForeignKey("dbo.Resorts", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Hotels", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Images", "HolidayHome_HolidayHomeId", "dbo.HolidayHomes");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.ReserveObjects", new[] { "Room_RoomId" });
            DropIndex("dbo.ReserveObjects", new[] { "HolidayHome_HolidayHomeId" });
            DropIndex("dbo.Rooms", new[] { "Resort_ResortId" });
            DropIndex("dbo.Rooms", new[] { "Hotel_HotelId" });
            DropIndex("dbo.Parkings", new[] { "Resort_ResortId" });
            DropIndex("dbo.Parkings", new[] { "Hotel_HotelId" });
            DropIndex("dbo.Resorts", new[] { "ApplicationUserID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Hotels", new[] { "ApplicationUserID" });
            DropIndex("dbo.Images", new[] { "Hotel_HotelId" });
            DropIndex("dbo.Images", new[] { "Room_RoomId" });
            DropIndex("dbo.Images", new[] { "Parking_ParkingId" });
            DropIndex("dbo.Images", new[] { "Resort_ResortId" });
            DropIndex("dbo.Images", new[] { "HolidayHome_HolidayHomeId" });
            DropIndex("dbo.HolidayHomes", new[] { "Resort_ResortId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.ReserveObjects");
            DropTable("dbo.Rooms");
            DropTable("dbo.Parkings");
            DropTable("dbo.Resorts");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Hotels");
            DropTable("dbo.Images");
            DropTable("dbo.HolidayHomes");
        }
    }
}
