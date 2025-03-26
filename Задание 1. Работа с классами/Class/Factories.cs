using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_1._Работа_с_классами;

/// <summary>
///  Класс Заводов
/// </summary>
public class Factories(string name, string description)
{
    /// <summary>
    ///  Айди заводов
    /// </summary>
    public Guid IdFactories { get; } = Guid.NewGuid();
    /// <summary>
    ///  Имя заводов
    /// </summary>
    public string Name { get; set; } = name;
    /// <summary>
    ///  Описание заводов
    /// </summary>
    public string Description { get; set; } = description;

    /// <summary>
    ///  Метод возвращает массив заводов
    /// </summary>
    public static Factories[] GetFactories()
    {
        return new Factories[]
        {
                new Factories("НПЗ№1", "Первый нефтеперерабатывающийй завод"),
                new Factories("НПЗ№2", "Второй нефтеперерабатывающийй завод")
        };
    }

    /// <summary>
    ///  Метод возвращает объект завода, соответствующий установке
    /// </summary>
    /// <param name="factories"> массив Заводов.</param>
    /// <param name="unit"> установка.</param>
    public static Factories FindFactories(Factories[] factories, Units unit)
    {

        string n = "";
        // LINQ
        Factories Fact = factories.FirstOrDefault(f => (f.IdFactories == unit.IdFactories));
        if (Fact == null)

            throw new ArgumentException("Нет такого Завода.");

        return Fact;
    }
}

