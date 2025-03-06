using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOfBankAccount.Base;

namespace SystemOfBankAccount
{
    class GiftCartAccount : BankAccount
    {
        public GiftCartAccount(string owner, decimal InitialBalance) : base(owner, InitialBalance)
        {

        }

        public override void PerformMonthEndTransaction()
            => MakeWithdrawal(-Balance, DateTime.Now, ":(");
    }
}
