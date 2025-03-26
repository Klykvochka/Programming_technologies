using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Домашняя_работа;
internal interface Istatistic
{
    void AddAttempt(int attempts);
    void DisplayStatistics();
    int MaxAttempts();
    int MinAttempts();
    double AverageAttempts();
}

