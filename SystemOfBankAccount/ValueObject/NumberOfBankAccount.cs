using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOfBankAccount.ValueObject
{
    struct NumberOfBankAccount
    {

        private int value;
        public int Value { get; set; }
        public NumberOfBankAccount(int value)
        {
            if (value < 1000000000 || value >= 10000000000)
                throw new ArgumentOutOfRangeException(nameof(value), "Errror");

            Value = value;
        }

    }
}
