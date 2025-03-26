using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Домашняя_работа
{
    internal class Game : Igame
    {
        private Istatistic statistics { set; get; }
        private int minRange = 1;
        private int maxRange = 100;
        private int MaxAttempts = -1;

        public Game(Istatistic statistic) { statistics = statistic; }
        public void SetRange(int min, int max)
        {
            minRange = min;
            maxRange = max;
        }

        public void SetMaxAttempts(int maxAttempts)
        {
            MaxAttempts = maxAttempts;
        }

        public void ChooseDifficulty()
        {
            Console.WriteLine("\nВыберите сложность:");
            Console.WriteLine("1. Легкая (без ограничений)");
            Console.WriteLine("2. Средняя (10 попыток)");
            Console.WriteLine("3. Сложная (5 попыток)");
            Console.WriteLine("Ваш выбор: ");

            int difficulty;

            while (!int.TryParse(Console.ReadLine(), out difficulty) || difficulty < 1 || difficulty > 3)
            {
                Console.WriteLine("Error! Input another number in [1;4].");
            }
            switch (difficulty)
            {
                case 1:
                    SetMaxAttempts(-1);
                    Console.WriteLine("Выбрана легкая сложность.\n");
                    break;
                case 2:
                    SetMaxAttempts(10);
                    Console.WriteLine("Выбрана средняя сложность.\n");
                    break;
                case 3:
                    SetMaxAttempts(5);
                    Console.WriteLine("Выбрана тяжелая сложность.\n");
                    break;
            }
        }
        public void Play()
        {

            int attempts = 0;
            int guess, number = new Random().Next(minRange, maxRange + 1);
            for (; ; )
            {
                attempts++;
                Console.WriteLine("Введите число");

                while (!int.TryParse(Console.ReadLine(), out guess) || guess < minRange || guess > maxRange)
                {
                    Console.WriteLine($"Error! Input another number in [{minRange};{maxRange}]");
                }
                if (guess == number)
                {
                    Console.WriteLine("You are win!");
                    statistics.AddAttempt(attempts);
                    break;
                }
                if (guess > number) Console.WriteLine("Your number is larger.");
                else Console.WriteLine("Your number is less.");


                if (MaxAttempts != -1 && attempts >= MaxAttempts)
                {
                    Console.WriteLine($"Вы исчерпали все {MaxAttempts} попыток. Загаданное число было {number}.");
                    return;
                }
            }
        }
    }
}
