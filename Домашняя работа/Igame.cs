using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Домашняя_работа;

/// <summary>
/// Интерфейс игры
/// </summary>
public interface IGame
{
    /// <summary>
    /// Изменить границы
    /// </summary>
    /// <param name="min">минимальная граница</param>
    /// <param name="max">максимальная граница</param>
    public void SetRange(int min, int max);

    /// <summary>
    /// Изменить количество попыток
    /// </summary>
    /// <param name="maxAttempts">Максимальное число попыток</param>
    public void SetMaxAttempts(int maxAttempts);

    /// <summary>
    /// Метод выбора сложности игры
    /// </summary>
    public void ChooseDifficulty();

    /// <summary>
    /// Метод игра
    /// </summary>
    public void Play();
}

