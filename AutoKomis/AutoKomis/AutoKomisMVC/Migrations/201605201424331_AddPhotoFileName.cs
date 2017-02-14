namespace AutoKomisMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhotoFileName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advertisments", "PhotoFileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Advertisments", "PhotoFileName");
        }
    }
}
