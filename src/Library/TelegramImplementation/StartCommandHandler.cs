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
    /*
        POLIMORFISMO: La clase StartCommandHandler tiene el método Handle 
        que implementa una operación polimórfica.
    */

    public class StartCommandHandler : AbstractCommandHandler
    {
        public async override Task<object> Handle(string messageText, long chatInfoID)
        {
            ITelegramBotClient client = TelegramBot.Instance.Client;
 
            if (messageText != null && (messageText as string) == "/start")
            {
                string info = CoreBot.Instance.Reader.ReadPlainText("../../Assets/Welcome.txt");
                await client.SendTextMessageAsync(chatId: chatInfoID, text: info);
               
                return "Start";
            }
            else
            {
                return base.Handle(messageText, chatInfoID);
            }
        }
    } 
}