using System;
using Library;
using LibraryAPI;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new FileReader();
            IPersonProfile user = PersonProfile.Instance;
            IMessageReceiver input = new ConsoleReceiver();
            IMessageSender output = new ConsolePrinter();
            IMessageSender telegramPrinter = new TelegramGateway();
            CoreBot coreBot = new CoreBot(reader, user, input, telegramPrinter);

            TelegramGateway.RunTelegramAPI();
            //reader.ReadInitialQuestions(@"..\..\Assets\InitialQuestions.txt");
            //coreBot.AskInitialQuestions();

            //coreBot.Start();

            //FindGift findG = new FindGift();
            //findG.SearchGiftML();

            
            
        }
    }
}