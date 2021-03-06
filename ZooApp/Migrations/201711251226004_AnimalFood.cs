namespace ZooApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnimalFood : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnimalFoods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnimalId = c.Int(nullable: false),
                        FoodId = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Animals", t => t.AnimalId, cascadeDelete: true)
                .ForeignKey("dbo.Foods", t => t.FoodId, cascadeDelete: true)
                .Index(t => t.AnimalId)
                .Index(t => t.FoodId);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Animals", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Animals", "Origin", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Animals", "Name", name: "Ix_AnimalName");
            CreateIndex("dbo.Animals", "Origin", name: "Ix_AnimalOrigin");
            DropColumn("dbo.Animals", "Food");
            DropColumn("dbo.Animals", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Animals", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Animals", "Food", c => c.String());
            DropForeignKey("dbo.AnimalFoods", "FoodId", "dbo.Foods");
            DropForeignKey("dbo.AnimalFoods", "AnimalId", "dbo.Animals");
            DropIndex("dbo.AnimalFoods", new[] { "FoodId" });
            DropIndex("dbo.AnimalFoods", new[] { "AnimalId" });
            DropIndex("dbo.Animals", "Ix_AnimalOrigin");
            DropIndex("dbo.Animals", "Ix_AnimalName");
            AlterColumn("dbo.Animals", "Origin", c => c.String());
            AlterColumn("dbo.Animals", "Name", c => c.String());
            DropTable("dbo.Foods");
            DropTable("dbo.AnimalFoods");
        }
    }
}
