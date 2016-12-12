namespace BusTicketSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeUpdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trips", "DepartureTime", c => c.DateTime());
            AddColumn("dbo.Trips", "ArrivalTime", c => c.DateTime());
            AddColumn("dbo.Reviews", "PublishedIn", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "PublishedIn");
            DropColumn("dbo.Trips", "ArrivalTime");
            DropColumn("dbo.Trips", "DepartureTime");
        }
    }
}
