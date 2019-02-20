namespace HolidayApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dwaaaa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Parkings", "HotelId", "dbo.Hotels");
            DropIndex("dbo.Parkings", new[] { "HotelId" });
            DropColumn("dbo.Parkings", "HotelId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parkings", "HotelId", c => c.Int(nullable: false));
            CreateIndex("dbo.Parkings", "HotelId");
            AddForeignKey("dbo.Parkings", "HotelId", "dbo.Hotels", "HotelId", cascadeDelete: true);
        }
    }
}
