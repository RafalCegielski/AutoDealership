namespace AutoKomisMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Error : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AdvertPhotos", "AdvertismentID", "dbo.Advertisments");
            DropIndex("dbo.AdvertPhotos", new[] { "AdvertismentID" });
            RenameColumn(table: "dbo.AdvertPhotos", name: "AdvertismentID", newName: "Advertisment_AdvertismentID");
            AddColumn("dbo.AdvertPhotos", "advertID", c => c.Int(nullable: false));
            AlterColumn("dbo.AdvertPhotos", "Advertisment_AdvertismentID", c => c.Int());
            CreateIndex("dbo.AdvertPhotos", "Advertisment_AdvertismentID");
            AddForeignKey("dbo.AdvertPhotos", "Advertisment_AdvertismentID", "dbo.Advertisments", "AdvertismentID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdvertPhotos", "Advertisment_AdvertismentID", "dbo.Advertisments");
            DropIndex("dbo.AdvertPhotos", new[] { "Advertisment_AdvertismentID" });
            AlterColumn("dbo.AdvertPhotos", "Advertisment_AdvertismentID", c => c.Int(nullable: false));
            DropColumn("dbo.AdvertPhotos", "advertID");
            RenameColumn(table: "dbo.AdvertPhotos", name: "Advertisment_AdvertismentID", newName: "AdvertismentID");
            CreateIndex("dbo.AdvertPhotos", "AdvertismentID");
            AddForeignKey("dbo.AdvertPhotos", "AdvertismentID", "dbo.Advertisments", "AdvertismentID", cascadeDelete: true);
        }
    }
}
