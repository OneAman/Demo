using System;
using BankConsoleApp;

namespace BankConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
                var name = Console.ReadLine();
                int InitialBal = Convert.ToInt32(Console.ReadLine());
                //int withdrawalAmt = Convert.ToInt32(Console.ReadLine());
                var account = new BankAccount(name, InitialBal);
                Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");
                Console.WriteLine(account.GetAccountHistory());
            
            // Test that the initial balances must be positive.
            BankAccount invalidAccount;
            try
            {
                invalidAccount = new BankAccount("invalid", InitialBal);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
                return;
            }
           
            //account.MakeDeposite(550, DateTime.Now, "Depositing my fund");
           // Console.WriteLine("Account balance after deposit: {0}", account.Balance);

            try
            {
                account.MakeWithdrawal(50, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }
            var giftCard = new GiftCardAccount("gift card", 100, 50);
            giftCard.MakeWithdrawal(20, DateTime.Now, "Get coffee");
            giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries");
            giftCard.PerformMonthEndTransactions();

            //Make additional deposit:

            giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
            Console.WriteLine(giftCard.GetAccountHistory());

            var saving = new InterestEarningAccount("Saving account", 10000);
            saving.MakeDeposit(750, DateTime.Now, "save some money");
            saving.MakeDeposit(1250, DateTime.Now, "Add more savings");
            saving.MakeWithdrawal(250, DateTime.Now, "Needed to pay monthly bills");
            saving.PerformMonthEndTransactions();
            Console.WriteLine(saving.GetAccountHistory());
        }
    }
}
