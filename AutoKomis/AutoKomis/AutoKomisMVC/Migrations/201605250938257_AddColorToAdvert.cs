namespace AutoKomisMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColorToAdvert : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advertisments", "Color", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Advertisments", "Color");
        }
    }
}
