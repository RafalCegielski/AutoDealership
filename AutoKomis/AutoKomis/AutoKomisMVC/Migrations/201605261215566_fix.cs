namespace AutoKomisMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdvertPhotos", "AdvertismentID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AdvertPhotos", "AdvertismentID");
        }
    }
}
