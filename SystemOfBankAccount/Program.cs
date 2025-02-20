using System;
using SystemOfBankAccount;


namespace SystemOfB
{
    /// <summary>
    /// Основной класс программы
    /// </summary>
    class Program
    {
        /// <summary>
        /// Главный метод
        /// </summary>
        static void Main(string[] args)
        {
            var account1 = new BankAccount("Adqwd", 10000);
            Console.WriteLine($" Account {account1.Number.Value} was create for {account1.Owner} with {account1.Balance} initial balance.");
            account1.MakeDeposit(100m, DateTime.Now, "wefrwer");
            account1.MakeDeposit(2000000m, DateTime.Now, "rrwer");
            account1.MakeWithdrawal(1m, DateTime.Now, "wtwer");
            Console.WriteLine($" Account {account1.Number.Value} was create for {account1.Owner} with {account1.Balance} initial balance.");

        }
       
    }
}
