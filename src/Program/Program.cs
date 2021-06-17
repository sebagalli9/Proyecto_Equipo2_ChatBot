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
            CoreBot optionsRound = new CoreBot(reader,user);

            optionsRound.Start();
               

        }
    }
}