using System;
using System.Collections.Generic;
using SystemOfBankAccount.ValueObject;

namespace SystemOfBankAccount
{

    /// <summary>
    ///  Класс Банковского аккаунта
    /// </summary>
    class BankAccount
    {
        private List<Transaction> _allTransaction = new List<Transaction>(); 
        private static int a_accountNumberSeed = 1000000000;
        /// <summary>
        /// Номер банковского счета
        /// </summary>
        public NumberOfBankAccount Number { get; }
        /// <summary>
        ///  Владелец счета
        /// </summary>
        public string Owner { get; set; }
        /// <summary>
        ///  Баланс счета
        /// </summary>
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

        /// <summary>
        ///  Конструктор с параметрами
        /// </summary>
        /// <param name="owner">Владелец счета.</param>
        /// <param name="InitialBalance">Баланс на счету.</param>
        public BankAccount(string owner, decimal InitialBalance)
        {
            Number = new NumberOfBankAccount(a_accountNumberSeed);
            a_accountNumberSeed++;
            Owner = owner;
            MakeDeposit(InitialBalance, DateTime.Now, "efsef");
        }

        /// <summary>
        ///  Метод для пополнения счета
        /// </summary>
        /// <param name="amount">Сумма операции.</param>
        /// <param name="date">Дата операции.</param>
        /// <param name="note">Замека.</param>
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <=0) 
          
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive.");

                var deposit = new Transaction(amount, date, note);
                _allTransaction.Add(deposit);
            
        }


        /// <summary>
        ///  Метод для вывода суммы с чета
        /// </summary>
        /// <param name="amount">Сумма операции.</param>
        /// <param name="date">Дата операции.</param>
        /// <param name="note">Замека.</param>
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
