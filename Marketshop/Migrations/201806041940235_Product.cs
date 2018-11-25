namespace Marketshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Product : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Price = c.Single(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Image = c.String(maxLength: 200),
                        Categoryid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.Categoryid, cascadeDelete: true)
                .Index(t => t.Categoryid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Categoryid", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Categoryid" });
            DropTable("dbo.Products");
        }
    }
}
