using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Домашняя_работа;
/// <summary>
/// Класс статистики
/// </summary>
internal class Statistics : Istatistic
{
    private List<int> Attempts = new List<int>();

    /// <summary>
    /// Метод добавления попытки в список 
    /// </summary>
    /// <param name="attempts">Попытка</param>
    public void AddAttempt(int attempts)
    {
        Attempts.Add(attempts);
    }
    /// <summary>
    /// Метод получает максимальное число попыток
    /// </summary>
    public int MaxAttempts()
    {
        if (Attempts.Count == 0) return 0;
        return Attempts.Max();
    }
    /// <summary>
    /// Метод получает минимальное число попыток
    /// </summary>
    public int MinAttempts()
    {
        if (Attempts.Count == 0) return 0;
        return Attempts.Min();
    }
    /// <summary>
    /// Метод получает среднее число попыток
    /// </summary>
    public double AverageAttempts()
    {
        if (Attempts.Count == 0) return 0;
        return Attempts.Average();
    }
    /// <summary>
    /// Метод выводит статистику
    /// </summary>
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

