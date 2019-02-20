namespace HolidayApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class three : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parkings", "HotelId", c => c.Int(nullable: false));
            CreateIndex("dbo.Parkings", "HotelId");
            AddForeignKey("dbo.Parkings", "HotelId", "dbo.Hotels", "HotelId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parkings", "HotelId", "dbo.Hotels");
            DropIndex("dbo.Parkings", new[] { "HotelId" });
            DropColumn("dbo.Parkings", "HotelId");
        }
    }
}
