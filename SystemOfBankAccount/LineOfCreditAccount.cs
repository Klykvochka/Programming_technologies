using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOfBankAccount.Base;

namespace SystemOfBankAccount
{
    internal class LineOfCreditAccount : BankAccount
    {
        public LineOfCreditAccount(string owner, decimal InitialBalance) : base(owner, InitialBalance)
        {

        }

        public override void PerformMonthEndTransaction()
        {
            if(Balance < 0)
            {
                MakeWithdrawal(-Balance * 0.07m, DateTime.Now, "Chatrge monthy interest");
            }
        }
    }
}
