namespace AutoKomisMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Requirments : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Advertisments", "BrandOfCar", c => c.String(nullable: false));
            AlterColumn("dbo.Advertisments", "ModelOfCar", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Advertisments", "ModelOfCar", c => c.String());
            AlterColumn("dbo.Advertisments", "BrandOfCar", c => c.String());
        }
    }
}
