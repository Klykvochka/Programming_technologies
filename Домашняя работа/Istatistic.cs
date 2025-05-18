using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Домашняя_работа;
/// <summary>
/// Интерфейс статистики
/// </summary>
public interface IStatistic
{
    /// <summary>
    /// Метод добавления попытки в список 
    /// </summary>
    /// <param name="attempts">Попытка</param>
    void AddAttempt(int attempts);
    /// <summary>
    /// Метод вывода статистики
    /// </summary>
    void DisplayStatistics();
    /// <summary>
    /// Метод получает максимальное число попыток
    /// </summary>
    int MaxAttempts();
    /// <summary>
    /// Метод получает минимальнное число попыток
    /// </summary>
    int MinAttempts();
    /// <summary>
    /// Метод получает среднее число попыток
    /// </summary>
    double AverageAttempts();
}

