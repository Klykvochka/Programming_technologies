using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Домашняя_работа;

internal class Menu
{


    public Game Game { set; get; }
    public Istatistic Statatistic { set; get; }
    public ChangeRange change { set; get; }
    public Menu(Istatistic statistic, ChangeRange changee)
    {
        Statatistic = statistic;
        change = changee;
        Game = new Game(statistic);
    }

    public void DisplayMenu()
    {


        Console.WriteLine("Menu:\t1. Изменить границы\n\t2. Играть\n\t3. Статистика\n\t4. Выход");
        Console.WriteLine("Введите номер");

    }
    public void Run()
    {
        while (true)
        {
            DisplayMenu();
            int choce;
            while (!int.TryParse(Console.ReadLine(), out choce) || choce < 1 || choce > 4)
            {
                Console.WriteLine("Error! Input another number in [1;4].");
            }
            switch (choce)
            {
                case 1:
                    change.ChangeRangee(Game);
                    break;
                case 2:
                    Game.ChooseDifficulty();
                    Game.Play();
                    break;
                case 3:
                    Statatistic.DisplayStatistics();
                    break;
                case 4:
                    Console.WriteLine("Выход из игры!");
                    return;
            }
        }

    }
}
