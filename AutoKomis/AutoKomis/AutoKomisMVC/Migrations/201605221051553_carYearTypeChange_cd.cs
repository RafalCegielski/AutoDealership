namespace AutoKomisMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carYearTypeChange_cd : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Advertisments", "CreateYear");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Advertisments", "CreateYear", c => c.DateTime(nullable: false));
        }
    }
}
