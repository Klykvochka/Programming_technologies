using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Домашняя_работа;
internal class Statistics : Istatistic
{
    private List<int> Attempts = new List<int>();

    public void AddAttempt(int attempts)
    {
        Attempts.Add(attempts);
    }
    public int MaxAttempts()
    {
        if (Attempts.Count == 0) return 0;
        return Attempts.Max();
    }
    public int MinAttempts()
    {
        if (Attempts.Count == 0) return 0;
        return Attempts.Min();
    }
    public double AverageAttempts()
    {
        if (Attempts.Count == 0) return 0;
        return Attempts.Average();
    }
    public void DisplayStatistics()
    {
        int max = MaxAttempts();
        int min = MinAttempts();
        double average = AverageAttempts();
        Console.WriteLine($"Максимальное число попыток = {max}\n" +
                $"Минимальное количество попыток = {min}\n" +
                $"Среднее число попыток = {average}\n");
    }


}

