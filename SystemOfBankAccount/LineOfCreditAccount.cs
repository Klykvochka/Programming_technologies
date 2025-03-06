using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOfBankAccount.Base;
using SystemOfBankAccount.ValueObject;

namespace SystemOfBankAccount
{
    class LineOfCreditAccount : BankAccount
    {
        public decimal MinimumBalance {  get; private set; }
        public LineOfCreditAccount(string owner, decimal minimumBalance) : base(owner, 0m)
        {
            if(minimumBalance <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(minimumBalance), "MinimumBalance of credit card must be positive."); 
            }

            MinimumBalance = minimumBalance; 
        }
        public override void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)

                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive.");

            if (Balance - amount < -MinimumBalance)
                throw new InvalidOperationException("Not sufficient rubls for this");

            _allTransaction.Add(new Transaction(-amount, date, note)); 
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
