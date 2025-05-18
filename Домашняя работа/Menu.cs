using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Домашняя_работа;
/// <summary>
/// класс Меню
/// </summary>    
/// <summary>
/// Конструктор с парамеетрами
/// </summary>
/// <param name="statistic">Статистика</param>
/// <param name="game">Игра</param>
/// <param name="changee">Границы</param>
/// <param name="message">Ввод вывод сообщений</param>
public class Menu(IStatistic statistic, IGame game, IChangeRange changee, IInputAndOutputMessage message)
{

    /// <summary>
    /// Игра
    /// </summary>
    private IGame Game = game;

    /// <summary>
    /// Статистика
    /// </summary>
    private IStatistic Statatistic = statistic;

    /// <summary>
    /// Границы
    /// </summary>
    private IChangeRange Change = changee;

    /// <summary>
    /// Ввод/Вывод сообщения
    /// </summary>
    private IInputAndOutputMessage Message = message;

    /// <summary>
    /// Вывод меню на экран
    /// </summary>
    public void DisplayMenu()
    {


        Message.GetOutput("Menu:\t1. Изменить границы\n\t2. Играть\n\t3. Статистика\n\t4. Выход");
        Message.GetOutput("Введите номер");

    }
    /// <summary>
    /// Метод реализовывает меню
    /// </summary>
    public void Run()
    {
        while (true)
        {
            DisplayMenu();
            int choce = Message.GetInput();
            while (choce < 1 || choce > 4)
            {
                Message.GetOutput("Error! Input another number in [1;4].");
            }
            switch (choce)
            {
                case 1:
                    Change.ChangeRangee(Game);
                    break;
                case 2:
                    Game.ChooseDifficulty();
                    Game.Play();
                    break;
                case 3:
                    Statatistic.DisplayStatistics();
                    break;
                case 4:
                    Message.GetOutput("Выход из игры!");
                    return;
            }
        }

    }
}
