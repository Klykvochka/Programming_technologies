using System;


namespace Домашняя_работа;
class Program
{
    public static void Main(string[] args)
    {
        Istatistic statistic = new Statistics();
        ChangeRange changeRange = new ChangeRange();
        Menu menu = new Menu(statistic, changeRange);
        menu.Run();
    }
}
