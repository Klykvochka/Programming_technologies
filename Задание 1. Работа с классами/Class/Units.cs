using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_1._Работа_с_классами
{
    /// <summary>
    ///  Класс Установок
    /// </summary>
    public class Units
    {
        /// <summary>
        ///  Айди установок
        /// </summary>
        public Guid IdUnits { get; }
        /// <summary>
        ///  Имя установок
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///  Описание установок
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        ///  Айди Заводов
        /// </summary>
        public Guid IdFactories { get; }
        /// <summary>
        ///  Конструктор с параметрами
        /// </summary>
        /// <param name="name">Имя резервуара.</param>
        /// <param name="description">Описание резервуара.</param>
        /// <param name="factoryId">Айди заводов.</param>

        public Units(string name, string description, Guid factoryId)
        {
            IdUnits = Guid.NewGuid();
            Name = name;
            Description = description;
            if (factoryId == Guid.Empty)
                throw new ArgumentException("FactoryId cannot be empty.");


            IdFactories = factoryId;
        }
        /// <summary>
        ///  Метод возвращает массив установок
        /// </summary>
        /// <param name="factories"> массив Заводов.</param>
        public static Units[] GetUnits(Factories [] factories)
        {
            return new Units[]
            {
                new Units("ГФУ-2", "Газофракционирующая", factories[0].IdFactories),
                new Units("АВТ-6", "Атмосферно-вакуумная трубчатка",  factories[0].IdFactories),
                new Units("АВТ-10", "Атмосферно-вакуумная трубчатка",  factories[1].IdFactories)
            };
        }
        /// <summary>
        ///  Метод возвращает установку (Unit), которой принадлежит резервуар (Tank)
        /// </summary>
        /// <param name="units"> массив установок.</param>
        /// <param name="tank"> массив резервуаров.</param>
        /// <param name="name"> имя резервуара.</param>
        public static Units FindUnit(Units[] units, Tank[] tank, string name)
        {


            Tank Ftank = tank.FirstOrDefault(t=>(t.Name == name));
            if (Ftank == null)
            
                throw new ArgumentException("Нет такого Резервуара.");
            
            Units Funit = units.FirstOrDefault(u => (u.IdUnits == Ftank.IdUnits));
            if (Funit == null)
                throw new ArgumentException("Нет такой установки");
            
            return Funit;
        }
    }
}
