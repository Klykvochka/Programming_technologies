using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_1._Работа_с_классами
{
    /// <summary>
    ///  Класс Резервуаров
    /// </summary>
    public class Tank
    {
        /// <summary>
        ///  Айди резервуаров
        /// </summary>
        public Guid IdTank { get; }
        /// <summary>
        ///  Имя резервуаров
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///  Описание резервуаров
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        ///  Вместительность резервуаров
        /// </summary>
        public int Volume { get; set; }
        /// <summary>
        ///  Максимальная заполненность резервуаров
        /// </summary>
        public int MaxVolume { get; set; }
        /// <summary>
        ///  Айди установок
        /// </summary>
        public Guid IdUnits { get; }

        /// <summary>
        ///  Конструктор с параметрами
        /// </summary>
        /// <param name="name">Имя резервуара.</param>
        /// <param name="description">Описание резервуара.</param>
        /// <param name="volume">заполненность резервуаров.</param>
        /// <param name="maxVolume">Максимальная заполненность резервуаров.</param>
        public Tank(string name, string description, int volume, int maxVolume,Guid unitsId)
        {
            IdTank = Guid.NewGuid();
            Name = name;
            Description = description;
            Volume = volume;
            MaxVolume = maxVolume;
            if (unitsId == Guid.Empty)
                throw new ArgumentException("UnitsId cannot be empty.");

            IdUnits = unitsId;
        }
        /// <summary>
        ///  Метод возвращает массив резервуаров
        /// </summary>
        /// <param name="units"> массив Установок.</param>
        public static Tank[] GetTanks(Units [] units)
        {
            return new Tank[]
            {
                new Tank("Резервуар 1", "Надземный-вертикальный", 1500, 2000,units[0].IdUnits),
                new Tank("Резервуар 2", "Надземный-вертикальный", 2500, 3000,units[0].IdUnits),
                new Tank("Резервуар 24", "Надземный-вертикальный", 3000, 3000,units[1].IdUnits),
                new Tank("Резервуар 35", "Надземный-вертикальный", 3000, 3000,units[1].IdUnits),
                new Tank("Резервуар 47", "Надземный-вертикальный", 4000, 5000,units[1].IdUnits),
                new Tank("Резервуар 256", "Надземный-вертикальный", 500, 500,units[2].IdUnits)
            };
        }
        /// <summary>
        ///  Метод возвращает суммарный объем резервуаров в массиве
        /// </summary>
        /// <param name="t"> Массив резервуаров.</param>
        public static int GetTotalVolume(Tank[] t)
        {
            int sum = 0;
            foreach(Tank tank in t)
            {
            sum+= tank.MaxVolume;
            }
            return sum;
        }


    }
}
