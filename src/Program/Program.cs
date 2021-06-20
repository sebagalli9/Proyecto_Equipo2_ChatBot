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
            TestAnswerReceiver fake = new TestAnswerReceiver("si");
            CoreBot optionsRound = new CoreBot(reader, user, input, output);
            
            optionsRound.Start();
        }
    }
}