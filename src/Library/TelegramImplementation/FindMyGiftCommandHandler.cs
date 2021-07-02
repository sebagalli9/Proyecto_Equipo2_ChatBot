using System;
using Library;
using LibraryAPI;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Library
{ 
    internal class SearchMyGiftCommandHandler : AbstractCommandHandler
    {
        public async override Task<object> Handle(string messageText, Chat chatInfo)
        {
            ITelegramBotClient client = TelegramBot.Instance.Client;
            
            if (messageText != null && ((messageText as string) == "/searchgift" || (messageText as string) == "/buscarregalo"))
            {
                IReader reader = new FileReader();
                IPersonProfile user = PersonProfile.Instance;
                IMessageReceiver input = new TelegramGateway();
                IMessageSender output = new TelegramGateway();
                CoreBot coreBot = new CoreBot(reader, user, input, output);
                await Task.Run(() => coreBot.Start());
               
                return "searchgift Command";
            }
            else
            {
                return base.Handle(messageText, chatInfo);
            }
        }

    }
    
}