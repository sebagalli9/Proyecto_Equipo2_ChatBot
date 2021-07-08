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
    internal class StartCommandHandler : AbstractCommandHandler
    {
        public async override Task<object> Handle(string messageText, Chat chatInfo)
        {
            ITelegramBotClient client = TelegramBot.Instance.Client;
 
            if (messageText != null && (messageText as string) == "/start")
            {
                FileReader fileReader = new FileReader();
                string info = fileReader.ReadPlainText("../../Assets/Welcome.txt");
                await client.SendTextMessageAsync(chatId: chatInfo.Id, text: info);
               
                return "About Command";
            }
            else
            {
                return base.Handle(messageText, chatInfo);
            }
        }
    } 
}