using System;
using System.Collections.Generic;

namespace Library
{

    public class ConsoleReceiver : IInputReceiver
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
