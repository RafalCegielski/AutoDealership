namespace AutoKomisMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImagesList_ForgotDbSET : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdvertPhotos",
                c => new
                    {
                        AdvertPhotosID = c.Int(nullable: false, identity: true),
                        PhotoFileName = c.String(),
                        Advertisment_AdvertismentID = c.Int(),
                    })
                .PrimaryKey(t => t.AdvertPhotosID)
                .ForeignKey("dbo.Advertisments", t => t.Advertisment_AdvertismentID)
                .Index(t => t.Advertisment_AdvertismentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdvertPhotos", "Advertisment_AdvertismentID", "dbo.Advertisments");
            DropIndex("dbo.AdvertPhotos", new[] { "Advertisment_AdvertismentID" });
            DropTable("dbo.AdvertPhotos");
        }
    }
}
