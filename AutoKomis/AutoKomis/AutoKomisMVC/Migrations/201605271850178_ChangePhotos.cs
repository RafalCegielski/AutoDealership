namespace AutoKomisMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePhotos : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AdvertPhotos", "advertID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AdvertPhotos", "advertID", c => c.Int(nullable: false));
        }
    }
}
