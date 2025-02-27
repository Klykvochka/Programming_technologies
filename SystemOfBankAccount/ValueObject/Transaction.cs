using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace SystemOfBankAccount.ValueObject
{
    /// <summary>
    ///  Транзакции
    /// </summary>
    struct Transaction
    {


        /// <summary>
        ///  Деньги
        /// </summary>
        public decimal Amount { get; }

        /// <summary>
        ///  Дата операции
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        ///  Заметки
        /// </summary>
        public string Note { get; }

        /// <summary>
        ///  Конструктор с параметрами
        /// </summary>
        /// <param name="amount">Сумма операции.</param>
        /// <param name="date">Дата операции.</param>
        /// <param name="note">Замека.</param>
        public Transaction(decimal amount, DateTime date, string note)
        {
            Amount = amount;
            Date = date;
            Note = note;
        }

        public override string ToString()
        {
            return $"Date: {Date}\tAmount: {Amount}\tNote:{Note}";
        }
    }
}
