using System;
using ДЗ1_классы.Class;

// ДЗ:
// 1. нормально прокоментировать
// 2. в стринг валидатор сделать проверку на числа в имени (чтобы были только буквы)
// 3. сделать провекру на параметры в конструкторе и доделать конструктор
namespace pr1_ivanov
{
    /// <summary>
    /// Основной класс программы
    /// </summary>
    class Program
    {
        /// <summary>
        /// Главный метод
        /// </summary>
        static void Main(string[] args)
        {
            DateTime birthday = new DateTime(2005, 7, 26);

            // Создаем объект класса Human с указанными параметрами
            Human human = new Human(167, 50, birthday, "Demushkina", "Polina");
            Console.WriteLine($"Человек: {human.FullName}, Дата рождения: {human.Birthday}, Рост: {human.Height}, Вес: {human.Weight}");
        }
    }
}
