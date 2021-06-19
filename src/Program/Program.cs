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
            FakeAnswerReceiver fake = new FakeAnswerReceiver("si");
            CoreBot optionsRound = new CoreBot(reader,user,input);
                  
            optionsRound.Start();
               

        }
    }
}