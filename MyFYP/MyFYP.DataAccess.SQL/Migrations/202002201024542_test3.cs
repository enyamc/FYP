namespace MyFYP.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerItems", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.CustomerItems", new[] { "Customer_Id" });
            DropTable("dbo.CustomerItems");
            DropTable("dbo.StoreRegistrations");
        }
        
        public override void Down()
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
            
            CreateTable(
                "dbo.CustomerItems",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        Customer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateIndex("dbo.CustomerItems", "Customer_Id");
            AddForeignKey("dbo.CustomerItems", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
