using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Домашняя_работа
{
    internal class ChangeRange
    {

        public void ChangeRangee(Game game)
        {
            int minRange; int maxRange;
            Console.WriteLine("Изменение границ");
            Console.WriteLine("Минимальная граница:");
            while (!int.TryParse(Console.ReadLine(), out minRange) || minRange < 1 || minRange > 100)
            {
                Console.WriteLine("Error! Input another number.");
            }
            Console.WriteLine("Максимальная граница");
            while (!int.TryParse(Console.ReadLine(), out maxRange) || maxRange < 1 || maxRange > 100)
            {
                Console.WriteLine("Error! Input another number.");
            }
            if (minRange > maxRange)
                Console.WriteLine("Error! Некорректный ввод границ.");
            game.SetRange(minRange, maxRange);
        }
    }
}
