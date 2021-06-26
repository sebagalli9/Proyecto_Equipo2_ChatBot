using System;
using Library;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new FileReader();
            IPersonProfile user = new PersonProfile();
            IInputReceiver input = new ConsoleReceiver();
            IMessageSender output = new ConsolePrinter();
            CoreBot optionsRound = new CoreBot(reader, user, input, output);
            
            optionsRound.Start();
            foreach(string key in user.ProductSearcherKeyWords)
            {
                Console.WriteLine(key);
            }
        }
    }
}