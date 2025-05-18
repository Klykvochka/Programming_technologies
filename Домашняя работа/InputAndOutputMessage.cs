using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Домашняя_работа;
public class InputAndOutputMessage : IInputAndOutputMessage
{

    public void GetOutput(string message) => Console.WriteLine(message);


    public int GetInput()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int result))
                return result;
            Console.WriteLine("Введите корректное число!");
        }
    }
}
