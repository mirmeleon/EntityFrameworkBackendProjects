namespace BillsPaymentSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    

    internal sealed class Configuration : DbMigrationsConfiguration<BillsPaymentSystem.Data.BillsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BillsPaymentSystem.Data.BillsContext context)
        {
           
        }
    }
}
