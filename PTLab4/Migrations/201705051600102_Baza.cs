namespace PTLab4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Baza : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        Year = c.Int(nullable: false),
                        Engine_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Engines", t => t.Engine_Id)
                .Index(t => t.Engine_Id);
            
            CreateTable(
                "dbo.Engines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Displacement = c.Double(nullable: false),
                        HorsePower = c.Double(nullable: false),
                        Model = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "Engine_Id", "dbo.Engines");
            DropIndex("dbo.Cars", new[] { "Engine_Id" });
            DropTable("dbo.Engines");
            DropTable("dbo.Cars");
        }
    }
}
