namespace Marketshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class City1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 150),
                        Countryid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Countries", t => t.Countryid, cascadeDelete: true)
                .Index(t => t.Countryid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cities", "Countryid", "dbo.Countries");
            DropIndex("dbo.Cities", new[] { "Countryid" });
            DropTable("dbo.Cities");
        }
    }
}
