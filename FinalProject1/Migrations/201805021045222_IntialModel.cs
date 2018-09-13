namespace FinalProject1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.admins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.cars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CarType = c.String(),
                        CarColor = c.String(),
                        NumOfChair = c.Int(nullable: false),
                        CarModel = c.String(),
                        RentAmountOfCar = c.String(),
                        From = c.Int(nullable: false),
                        To = c.Int(nullable: false),
                        Availability = c.Boolean(nullable: false),
                        CarImage = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.clients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IsBlocked = c.Boolean(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Phone = c.Int(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(),
                        FavoriteCars = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.clients");
            DropTable("dbo.cars");
            DropTable("dbo.admins");
        }
    }
}
