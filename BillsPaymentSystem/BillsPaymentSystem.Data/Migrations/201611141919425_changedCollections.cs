namespace BillsPaymentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedCollections : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BillingDetails",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Number = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BankAccountTable",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        User_Id = c.Int(),
                        Number = c.String(),
                        BankName = c.String(),
                        SwiftCode = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.CreditCardTable",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        User_Id = c.Int(),
                        Number = c.String(),
                        CardType = c.String(),
                        ExpirationMonth = c.Int(nullable: false),
                        ExpirationYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditCardTable", "User_Id", "dbo.Users");
            DropForeignKey("dbo.BankAccountTable", "User_Id", "dbo.Users");
            DropIndex("dbo.CreditCardTable", new[] { "User_Id" });
            DropIndex("dbo.BankAccountTable", new[] { "User_Id" });
            DropTable("dbo.CreditCardTable");
            DropTable("dbo.BankAccountTable");
            DropTable("dbo.Users");
            DropTable("dbo.BillingDetails");
        }
    }
}
