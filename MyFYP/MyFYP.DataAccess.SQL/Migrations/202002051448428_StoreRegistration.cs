namespace MyFYP.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoreRegistration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StoreRegistrations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        StoreID = c.String(),
                        StoreName = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        Eircode = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StoreRegistrations");
        }
    }
}
