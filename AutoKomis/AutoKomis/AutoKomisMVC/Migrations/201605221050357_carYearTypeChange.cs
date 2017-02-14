namespace AutoKomisMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carYearTypeChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advertisments", "YearOfCreate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Advertisments", "YearOfCreate");
        }
    }
}
