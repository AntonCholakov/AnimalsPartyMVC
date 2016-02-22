namespace AnimalsParty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cats",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PersonID = c.Int(nullable: false),
                        FurColor = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.People", t => t.PersonID, cascadeDelete: true)
                .Index(t => t.PersonID);
            
            CreateTable(
                "dbo.Dogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PersonID = c.Int(nullable: false),
                        Breed = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.People", t => t.PersonID, cascadeDelete: true)
                .Index(t => t.PersonID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DogCats",
                c => new
                    {
                        Dog_ID = c.Int(nullable: false),
                        Cat_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Dog_ID, t.Cat_ID })
                .ForeignKey("dbo.Dogs", t => t.Dog_ID, cascadeDelete: false)
                .ForeignKey("dbo.Cats", t => t.Cat_ID, cascadeDelete: false)
                .Index(t => t.Dog_ID)
                .Index(t => t.Cat_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dogs", "PersonID", "dbo.People");
            DropForeignKey("dbo.Cats", "PersonID", "dbo.People");
            DropForeignKey("dbo.DogCats", "Cat_ID", "dbo.Cats");
            DropForeignKey("dbo.DogCats", "Dog_ID", "dbo.Dogs");
            DropIndex("dbo.DogCats", new[] { "Cat_ID" });
            DropIndex("dbo.DogCats", new[] { "Dog_ID" });
            DropIndex("dbo.Dogs", new[] { "PersonID" });
            DropIndex("dbo.Cats", new[] { "PersonID" });
            DropTable("dbo.DogCats");
            DropTable("dbo.People");
            DropTable("dbo.Dogs");
            DropTable("dbo.Cats");
        }
    }
}
