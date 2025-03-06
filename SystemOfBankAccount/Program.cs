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
            var account1 = new InterestEarningAccount("Adqwd", 10000);
            Console.WriteLine($" Account {account1.Number.Value} was create for {account1.Owner} with {account1.Balance} initial balance.");
            account1.MakeDeposit(1000m, DateTime.Now, "wefrwer");
            account1.MakeDeposit(20m, DateTime.Now, "rrwer");
            account1.MakeWithdrawal(10m, DateTime.Now, "wtwer");

            var account2 = new LineOfCreditAccount("KJBuyvf", 14300);
            Console.WriteLine($" Account {account2.Number.Value} was create for {account2.Owner} with {account2.Balance} initial balance.");
            account2.MakeDeposit(1000m, DateTime.Now, "wefrwer");
            account2.MakeDeposit(20m, DateTime.Now, "rrwer");
            account2.MakeWithdrawal(1000m, DateTime.Now, "wtwer");



            Console.WriteLine(account1.GetAccountHistory());
            Console.WriteLine(account2.GetAccountHistory());
            try
            {
                account1.MakeWithdrawal(2000m, DateTime.Now, "aadfasd");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message, e.ParamName);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message, e.ToString);
            }

            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message, e.ToString);
            }
        }

    }
}
