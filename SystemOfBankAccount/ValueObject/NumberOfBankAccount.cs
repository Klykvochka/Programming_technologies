using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOfBankAccount.ValueObject
{
    /// <summary>
    ///  Номер банковского счета
    /// </summary>
    struct NumberOfBankAccount
    {

        private int value;
        /// <summary>
        ///  Значение содержащее номер БС.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        ///  Валидация номера БС
        /// </summary>
        /// <param name="value">Значение содержащее номер БС.</param>

        public NumberOfBankAccount(int value)
        {
            if (value < 1000000000 || value >= 10000000000)
                throw new ArgumentOutOfRangeException(nameof(value), "Errror");

            Value = value;
        }

    }
}
