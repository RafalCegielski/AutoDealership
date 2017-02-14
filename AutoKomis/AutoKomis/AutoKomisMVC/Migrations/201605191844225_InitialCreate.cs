namespace AutoKomisMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advertisments",
                c => new
                    {
                        AdvertismentID = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BrandOfCar = c.String(),
                        ModelOfCar = c.String(),
                        CreateYear = c.DateTime(nullable: false),
                        EngineCapacity = c.Int(nullable: false),
                        FluelType = c.String(),
                        Gearbox = c.String(),
                        BodyType = c.String(),
                        EnginePower = c.Int(nullable: false),
                        Mileage = c.Int(nullable: false),
                        NumberOfDoor = c.Int(nullable: false),
                        Equipment = c.String(),
                        Description = c.String(),
                        AdvertCreateDare = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AdvertismentID);
            
            CreateTable(
                "dbo.BasicInformations",
                c => new
                    {
                        BasicInformationID = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(),
                        OpenedFrom = c.DateTime(nullable: false),
                        OpenedTo = c.DateTime(nullable: false),
                        SaturdayOpenedFrom = c.DateTime(nullable: false),
                        SaturdayOpenedTo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BasicInformationID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BasicInformations");
            DropTable("dbo.Advertisments");
        }
    }
}
