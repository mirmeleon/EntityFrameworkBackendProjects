namespace BusTicketSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        AccountNumber = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        HomeTown_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Towns", t => t.HomeTown_Id)
                .Index(t => t.HomeTown_Id);
            
            CreateTable(
                "dbo.Towns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BusStations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Town_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Towns", t => t.Town_Id)
                .Index(t => t.Town_Id);
            
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        BusCompany_Id = c.Int(),
                        DestinationBusStation_Id = c.Int(),
                        OriginBusStation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusCompanies", t => t.BusCompany_Id)
                .ForeignKey("dbo.BusStations", t => t.DestinationBusStation_Id)
                .ForeignKey("dbo.BusStations", t => t.OriginBusStation_Id)
                .Index(t => t.BusCompany_Id)
                .Index(t => t.DestinationBusStation_Id)
                .Index(t => t.OriginBusStation_Id);
            
            CreateTable(
                "dbo.BusCompanies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Nationality = c.String(),
                        Rating = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Grade = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BusStation_Id = c.Int(),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusStations", t => t.BusStation_Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.BusStation_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Seat = c.String(),
                        Customer_Id = c.Int(),
                        Trip_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Trips", t => t.Trip_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Trip_Id);
            
            CreateTable(
                "dbo.ReviewBusCompanies",
                c => new
                    {
                        Review_Id = c.Int(nullable: false),
                        BusCompany_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Review_Id, t.BusCompany_Id })
                .ForeignKey("dbo.Reviews", t => t.Review_Id, cascadeDelete: true)
                .ForeignKey("dbo.BusCompanies", t => t.BusCompany_Id, cascadeDelete: true)
                .Index(t => t.Review_Id)
                .Index(t => t.BusCompany_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Trip_Id", "dbo.Trips");
            DropForeignKey("dbo.Tickets", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.BankAccounts", "Id", "dbo.Customers");
            DropForeignKey("dbo.Customers", "HomeTown_Id", "dbo.Towns");
            DropForeignKey("dbo.BusStations", "Town_Id", "dbo.Towns");
            DropForeignKey("dbo.Trips", "OriginBusStation_Id", "dbo.BusStations");
            DropForeignKey("dbo.Trips", "DestinationBusStation_Id", "dbo.BusStations");
            DropForeignKey("dbo.Trips", "BusCompany_Id", "dbo.BusCompanies");
            DropForeignKey("dbo.Reviews", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Reviews", "BusStation_Id", "dbo.BusStations");
            DropForeignKey("dbo.ReviewBusCompanies", "BusCompany_Id", "dbo.BusCompanies");
            DropForeignKey("dbo.ReviewBusCompanies", "Review_Id", "dbo.Reviews");
            DropIndex("dbo.ReviewBusCompanies", new[] { "BusCompany_Id" });
            DropIndex("dbo.ReviewBusCompanies", new[] { "Review_Id" });
            DropIndex("dbo.Tickets", new[] { "Trip_Id" });
            DropIndex("dbo.Tickets", new[] { "Customer_Id" });
            DropIndex("dbo.Reviews", new[] { "Customer_Id" });
            DropIndex("dbo.Reviews", new[] { "BusStation_Id" });
            DropIndex("dbo.Trips", new[] { "OriginBusStation_Id" });
            DropIndex("dbo.Trips", new[] { "DestinationBusStation_Id" });
            DropIndex("dbo.Trips", new[] { "BusCompany_Id" });
            DropIndex("dbo.BusStations", new[] { "Town_Id" });
            DropIndex("dbo.Customers", new[] { "HomeTown_Id" });
            DropIndex("dbo.BankAccounts", new[] { "Id" });
            DropTable("dbo.ReviewBusCompanies");
            DropTable("dbo.Tickets");
            DropTable("dbo.Reviews");
            DropTable("dbo.BusCompanies");
            DropTable("dbo.Trips");
            DropTable("dbo.BusStations");
            DropTable("dbo.Towns");
            DropTable("dbo.Customers");
            DropTable("dbo.BankAccounts");
        }
    }
}
