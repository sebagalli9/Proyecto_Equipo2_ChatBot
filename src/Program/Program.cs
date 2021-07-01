using System;
using Library;
using LibraryAPI;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.IO;
using System.Text;


namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new FileReader();
            IPersonProfile user = PersonProfile.Instance;
            IInputReceiver input = new ConsoleReceiver();
            IMessageSender output = new ConsolePrinter();
            CoreBot optionsRound = new CoreBot(reader, user, input, output);

            optionsRound.Start();

            /* FindGift findG = new FindGift();
            findG.SearchGiftML(); */

            //TelegramGateway.RunTelegramAPI();
            
        }
    }
}