namespace AutoKomisMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeImages : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Advertisments", "PhotoFileName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Advertisments", "PhotoFileName", c => c.String());
        }
    }
}
