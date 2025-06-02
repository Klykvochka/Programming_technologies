using System;
using Microsoft.Extensions.DependencyInjection;

namespace Домашняя_работа
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            var serviceProvider = new ServiceCollection()
                .<IInputAndOutputMessage, InputAndOutputMessage>()
                .AddSingleton<IStatistic, Statistics>(provider =>
                    new Statistics(
                        provider.GetRequiredService<IInputAndOutputMessage>()))
                .AddSingleton<IChangeRange, ChangeRange>(provider =>
                    new ChangeRange(
                        provider.GetRequiredService<IInputAndOutputMessage>()))
                .AddSingleton<IGame, Game>(provider =>
                    new Game(
                        provider.GetRequiredService<IStatistic>(),
                        provider.GetRequiredService<IInputAndOutputMessage>())) 
                .AddSingleton<Menu>(provider =>
                    new Menu(
                        provider.GetRequiredService<IStatistic>(),
                        provider.GetRequiredService<IGame>(),
                        provider.GetRequiredService<IChangeRange>(),
                        provider.GetRequiredService<IInputAndOutputMessage>()))
                .BuildServiceProvider();

 
            var menu = serviceProvider.GetService<Menu>();
            menu?.Run();
        }
    }
}
