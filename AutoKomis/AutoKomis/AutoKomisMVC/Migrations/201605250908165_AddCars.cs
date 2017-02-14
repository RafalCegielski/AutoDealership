namespace AutoKomisMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCars : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarsID = c.Int(nullable: false, identity: true),
                        BrandOfCar = c.String(),
                    })
                .PrimaryKey(t => t.CarsID);
            
            CreateTable(
                "dbo.ModelOfCars",
                c => new
                    {
                        ModelOfCarID = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        Car_CarsID = c.Int(),
                    })
                .PrimaryKey(t => t.ModelOfCarID)
                .ForeignKey("dbo.Cars", t => t.Car_CarsID)
                .Index(t => t.Car_CarsID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ModelOfCars", "Car_CarsID", "dbo.Cars");
            DropIndex("dbo.ModelOfCars", new[] { "Car_CarsID" });
            DropTable("dbo.ModelOfCars");
            DropTable("dbo.Cars");
        }
    }
}
