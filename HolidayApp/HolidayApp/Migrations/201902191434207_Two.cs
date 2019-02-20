namespace HolidayApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Two : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Resorts", "TelephoneNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Hotels", "TelephoneNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Hotels", "TelephoneNumber", c => c.String());
            AlterColumn("dbo.Resorts", "TelephoneNumber", c => c.String());
        }
    }
}
