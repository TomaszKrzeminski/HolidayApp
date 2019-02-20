namespace HolidayApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Four : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HolidayHomes", "ResortId", "dbo.Resorts");
            DropForeignKey("dbo.Parkings", "ResortId", "dbo.Resorts");
            DropForeignKey("dbo.Rooms", "ResortId", "dbo.Resorts");
            DropForeignKey("dbo.Parkings", "HotelId", "dbo.Hotels");
            DropForeignKey("dbo.Rooms", "HotelId", "dbo.Hotels");
            DropIndex("dbo.HolidayHomes", new[] { "ResortId" });
            DropIndex("dbo.Parkings", new[] { "ResortId" });
            DropIndex("dbo.Parkings", new[] { "HotelId" });
            DropIndex("dbo.Rooms", new[] { "ResortId" });
            DropIndex("dbo.Rooms", new[] { "HotelId" });
            RenameColumn(table: "dbo.HolidayHomes", name: "ResortId", newName: "Resort_ResortId");
            RenameColumn(table: "dbo.Parkings", name: "ResortId", newName: "Resort_ResortId");
            RenameColumn(table: "dbo.Rooms", name: "ResortId", newName: "Resort_ResortId");
            RenameColumn(table: "dbo.Parkings", name: "HotelId", newName: "Hotel_HotelId");
            RenameColumn(table: "dbo.Rooms", name: "HotelId", newName: "Hotel_HotelId");
            AlterColumn("dbo.HolidayHomes", "Resort_ResortId", c => c.Int());
            AlterColumn("dbo.Parkings", "Resort_ResortId", c => c.Int());
            AlterColumn("dbo.Parkings", "Hotel_HotelId", c => c.Int());
            AlterColumn("dbo.Rooms", "Resort_ResortId", c => c.Int());
            AlterColumn("dbo.Rooms", "Hotel_HotelId", c => c.Int());
            CreateIndex("dbo.HolidayHomes", "Resort_ResortId");
            CreateIndex("dbo.Parkings", "Hotel_HotelId");
            CreateIndex("dbo.Parkings", "Resort_ResortId");
            CreateIndex("dbo.Rooms", "Hotel_HotelId");
            CreateIndex("dbo.Rooms", "Resort_ResortId");
            AddForeignKey("dbo.HolidayHomes", "Resort_ResortId", "dbo.Resorts", "ResortId");
            AddForeignKey("dbo.Parkings", "Resort_ResortId", "dbo.Resorts", "ResortId");
            AddForeignKey("dbo.Rooms", "Resort_ResortId", "dbo.Resorts", "ResortId");
            AddForeignKey("dbo.Parkings", "Hotel_HotelId", "dbo.Hotels", "HotelId");
            AddForeignKey("dbo.Rooms", "Hotel_HotelId", "dbo.Hotels", "HotelId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "Hotel_HotelId", "dbo.Hotels");
            DropForeignKey("dbo.Parkings", "Hotel_HotelId", "dbo.Hotels");
            DropForeignKey("dbo.Rooms", "Resort_ResortId", "dbo.Resorts");
            DropForeignKey("dbo.Parkings", "Resort_ResortId", "dbo.Resorts");
            DropForeignKey("dbo.HolidayHomes", "Resort_ResortId", "dbo.Resorts");
            DropIndex("dbo.Rooms", new[] { "Resort_ResortId" });
            DropIndex("dbo.Rooms", new[] { "Hotel_HotelId" });
            DropIndex("dbo.Parkings", new[] { "Resort_ResortId" });
            DropIndex("dbo.Parkings", new[] { "Hotel_HotelId" });
            DropIndex("dbo.HolidayHomes", new[] { "Resort_ResortId" });
            AlterColumn("dbo.Rooms", "Hotel_HotelId", c => c.Int(nullable: false));
            AlterColumn("dbo.Rooms", "Resort_ResortId", c => c.Int(nullable: false));
            AlterColumn("dbo.Parkings", "Hotel_HotelId", c => c.Int(nullable: false));
            AlterColumn("dbo.Parkings", "Resort_ResortId", c => c.Int(nullable: false));
            AlterColumn("dbo.HolidayHomes", "Resort_ResortId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Rooms", name: "Hotel_HotelId", newName: "HotelId");
            RenameColumn(table: "dbo.Parkings", name: "Hotel_HotelId", newName: "HotelId");
            RenameColumn(table: "dbo.Rooms", name: "Resort_ResortId", newName: "ResortId");
            RenameColumn(table: "dbo.Parkings", name: "Resort_ResortId", newName: "ResortId");
            RenameColumn(table: "dbo.HolidayHomes", name: "Resort_ResortId", newName: "ResortId");
            CreateIndex("dbo.Rooms", "HotelId");
            CreateIndex("dbo.Rooms", "ResortId");
            CreateIndex("dbo.Parkings", "HotelId");
            CreateIndex("dbo.Parkings", "ResortId");
            CreateIndex("dbo.HolidayHomes", "ResortId");
            AddForeignKey("dbo.Rooms", "HotelId", "dbo.Hotels", "HotelId", cascadeDelete: true);
            AddForeignKey("dbo.Parkings", "HotelId", "dbo.Hotels", "HotelId", cascadeDelete: true);
            AddForeignKey("dbo.Rooms", "ResortId", "dbo.Resorts", "ResortId", cascadeDelete: true);
            AddForeignKey("dbo.Parkings", "ResortId", "dbo.Resorts", "ResortId", cascadeDelete: true);
            AddForeignKey("dbo.HolidayHomes", "ResortId", "dbo.Resorts", "ResortId", cascadeDelete: true);
        }
    }
}
