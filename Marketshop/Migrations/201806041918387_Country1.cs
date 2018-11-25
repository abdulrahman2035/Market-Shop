namespace Marketshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Country1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Countries");
        }
    }
}
