using System;
using System.Collections.Generic;
using SystemOfBankAccount.ValueObject;

namespace SystemOfBankAccount
{
    class BankAccount
    {
        private List<Transaction> _allTransaction = new List<Transaction>(); 
        private static int a_accountNumberSeed = 1000000000;
        public NumberOfBankAccount Number { get; }
        public string Owner { get; set; }
        public decimal Balance 
        { 
            get
            {
                decimal balance = 0;

                foreach(var item in _allTransaction)
                {
                    balance += item.Amount;
                    
                }
                return balance;
            }
        
        
        
        }

        public BankAccount(string owner, decimal InitialBalance)
        {
            Number = new NumberOfBankAccount(a_accountNumberSeed);
            a_accountNumberSeed++;
            Owner = owner;
            MakeDeposit(InitialBalance, DateTime.Now, "efsef");
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <=0) 
          
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive.");

                var deposit = new Transaction(amount, date, note);
                _allTransaction.Add(deposit);
            
        }
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive.");
            
            if(Balance - amount < 0)
                throw new InvalidOperationException("Not sufficient rubls for this");

                var deposit = new Transaction(-amount, date, note);
                _allTransaction.Add(deposit);
            
        }

        

    }
}
