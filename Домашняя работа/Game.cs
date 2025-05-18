using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Домашняя_работа;

/// <summary>
/// Класс игра "Угадай число"
/// </summary>
///<param name="statistics">Статистика</param>
///<param name="minRange">минимальная граница</param>
///<param name="maxRange">максимальная граница</param>
///<param name="MaxAttempts">максимальное число попыток</param>
///<param name="message">Ввод вывод сообщений</param>
public class Game(IStatistic statistic, IInputAndOutputMessage message) : IGame
{

    private IStatistic Statistics = statistic;
    private int minRange = 1;
    private int maxRange = 100;
    private int MaxAttempts = -1;
    /// <summary>
    /// Ввод/Вывод сообщения
    /// </summary>
    private IInputAndOutputMessage Message = message;


    /// <summary>
    /// Изменить границы
    /// </summary>
    /// <param name="min">минимальная граница</param>
    /// <param name="max">максимальная граница</param>
    public void SetRange(int min, int max)
    {
        minRange = min;
        maxRange = max;
    }

    /// <summary>
    /// Изменить количество попыток
    /// </summary>
    /// <param name="maxAttempts">Максимальное число попыток</param>
    public void SetMaxAttempts(int maxAttempts)
    {
        MaxAttempts = maxAttempts;
    }

    /// <summary>
    /// Метод выбора сложности игры
    /// </summary>
    public void ChooseDifficulty()
    {
        Message.GetOutput("\nВыберите сложность:");
        Message.GetOutput("1. Легкая (без ограничений)");
        Message.GetOutput("2. Средняя (10 попыток)");
        Message.GetOutput("3. Сложная (5 попыток)");
        Message.GetOutput("Ваш выбор: ");


        int difficulty;

        do { difficulty = Message.GetInput(); }
        while (difficulty < 1 || difficulty > 3);

        switch (difficulty)
        {
            case 1:
                SetMaxAttempts(-1);
                Message.GetOutput("Выбрана легкая сложность.\n");
                break;
            case 2:
                SetMaxAttempts(10);
                Message.GetOutput("Выбрана средняя сложность.\n");
                break;
            case 3:
                SetMaxAttempts(5);
                Message.GetOutput("Выбрана тяжелая сложность.\n");
                break;
        }
    }

    /// <summary>
    /// Метод игра
    /// </summary>
    public void Play()
    {

        int attempts = 0;
        int guess, number = new Random().Next(minRange, maxRange + 1);
        for (; ; )
        {
            attempts++;
            Message.GetOutput("Введите число");

            do { guess = Message.GetInput(); }
            while (guess < minRange || guess > maxRange);
            //{
            //    Message.GetOutput($"Error! Input another number in [{minRange};{maxRange}]");
            //}
            if (guess == number)
            {
                Message.GetOutput("You are win!\n");
                Statistics.AddAttempt(attempts);
                break;
            }

            if (guess > number) Message.GetOutput("Your number is larger.\n");
            else Message.GetOutput("Your number is less.\n");

            if (MaxAttempts != -1 && attempts >= MaxAttempts)
            {
                Message.GetOutput($"Вы исчерпали все {MaxAttempts} попыток. Загаданное число было {number}.");
                return;
            }
        }
    }
}

