namespace AdminCRUD_03_March_2019.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPricingTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pricings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Duration = c.String(nullable: false, maxLength: 50),
                        PhotosCount = c.String(nullable: false, maxLength: 50),
                        Place = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pricings");
        }
    }
}
