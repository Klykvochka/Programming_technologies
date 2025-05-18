using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Домашняя_работа;
/// <summary>
/// Класс изменения границ 
/// </summary>
public class ChangeRange(IInputAndOutputMessage message) : IChangeRange
{
    private IInputAndOutputMessage Message = message;

    /// <summary>
    /// Метод изменения границ 
    /// </summary>
    /// <param name="game">Игра</param>
    public void ChangeRangee(IGame game)
    {

        int minRange; int maxRange;

        Message.GetOutput("Изменение границ");

        Message.GetOutput("Минимальная граница:");

        do { minRange = Message.GetInput();
            
        }
        while (minRange < 1 || minRange > 99);

        Message.GetOutput("Максимальная граница");

        do { maxRange = Message.GetInput(); }
        while (maxRange < 1 || maxRange > 100 || minRange > maxRange);

        game.SetRange(minRange, maxRange);
    }
}

