using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Домашняя_работа;
    public interface IInputAndOutputMessage
{
    void GetOutput(string message);
    int GetInput();
}

