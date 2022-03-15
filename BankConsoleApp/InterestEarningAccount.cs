using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankConsoleApp;
namespace BankConsoleApp
{
    public class InterestEarningAccount : BankAccount
    {

        public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
        {
            
        }


        /// override is part of Polymorphism

        public override void PerformMonthEndTransactions()
        {
            if(Balance > 500m)
            {
                decimal interest = Balance * 0.05m;
                MakeDeposit(interest, DateTime.Now, "Apply Monthly Interest");
            }
        }
    }
}
