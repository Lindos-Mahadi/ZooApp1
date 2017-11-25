namespace ZooApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnimalFood1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "quantity", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Animals", "quantity");
        }
    }
}
