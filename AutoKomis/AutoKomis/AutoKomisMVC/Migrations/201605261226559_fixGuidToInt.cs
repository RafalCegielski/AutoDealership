namespace AutoKomisMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixGuidToInt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AdvertPhotos", "Advertisment_AdvertismentID", "dbo.Advertisments");
            DropIndex("dbo.AdvertPhotos", new[] { "Advertisment_AdvertismentID" });
            DropColumn("dbo.AdvertPhotos", "AdvertismentID");
            RenameColumn(table: "dbo.AdvertPhotos", name: "Advertisment_AdvertismentID", newName: "AdvertismentID");
            AlterColumn("dbo.AdvertPhotos", "AdvertismentID", c => c.Int(nullable: false));
            AlterColumn("dbo.AdvertPhotos", "AdvertismentID", c => c.Int(nullable: false));
            CreateIndex("dbo.AdvertPhotos", "AdvertismentID");
            AddForeignKey("dbo.AdvertPhotos", "AdvertismentID", "dbo.Advertisments", "AdvertismentID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdvertPhotos", "AdvertismentID", "dbo.Advertisments");
            DropIndex("dbo.AdvertPhotos", new[] { "AdvertismentID" });
            AlterColumn("dbo.AdvertPhotos", "AdvertismentID", c => c.Int());
            AlterColumn("dbo.AdvertPhotos", "AdvertismentID", c => c.Guid(nullable: false));
            RenameColumn(table: "dbo.AdvertPhotos", name: "AdvertismentID", newName: "Advertisment_AdvertismentID");
            AddColumn("dbo.AdvertPhotos", "AdvertismentID", c => c.Guid(nullable: false));
            CreateIndex("dbo.AdvertPhotos", "Advertisment_AdvertismentID");
            AddForeignKey("dbo.AdvertPhotos", "Advertisment_AdvertismentID", "dbo.Advertisments", "AdvertismentID");
        }
    }
}
