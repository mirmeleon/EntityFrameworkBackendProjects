namespace BillPaymentSystem.ConsoleClient
{
    using BillsPaymentSystem.Data;
    using BillsPaymentSystem.Models;
    class Program
    {
        static void Main()
        {
            BillsContext context = new BillsContext();

            context.Users.Add(new User() {FirstName = "Eric", LastName = "Robadey"});
            context.BillingDetailses.Add(new BankAccount()
            {
                BankName = "UBS",
                Number = "UBS123454244",
                User = new User()
                {
                    FirstName = "Ana",
                    LastName = "Karenina"
                }
            });
            

            context.SaveChanges();
        }
    }
}
