namespace BillsPaymentSystem.Data
{
    using System.ComponentModel.DataAnnotations.Schema;
    using BillsPaymentSystem.Models;
    using System.Data.Entity;

    public class BillsContext : DbContext
    {
        
        public BillsContext()
            : base("name=BillsContext")
        {
          
        }

       public virtual DbSet<BillingDetails> BillingDetailses { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BankAccount>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("BankAccountTable");
            });

            modelBuilder.Entity<CreditCard>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("CreditCardTable");
            });

           
            modelBuilder.Entity<BillingDetails>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }

}