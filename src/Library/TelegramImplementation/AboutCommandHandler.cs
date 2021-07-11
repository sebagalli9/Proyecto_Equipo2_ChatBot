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
        POLIMORFISMO: La clase AboutCommandHandler tiene el método Handle 
        que implementa una operación polimórfica.
    */
    
    public class AboutCommandHandler : AbstractCommandHandler
    {
        public async override Task<object> Handle(string messageText, long chatInfoID)
        {
            ITelegramBotClient client = TelegramBot.Instance.Client;
            
            if (messageText != null && ((messageText as string) == "/about" || (messageText as string) == "/informacion"))
            {
                string info = CoreBot.Instance.Reader.ReadPlainText("../../Assets/About.txt");
                await client.SendTextMessageAsync(chatId: chatInfoID, text: info);
                return "About Command";
            }
            else
            {
                return base.Handle(messageText, chatInfoID);
            }
        }

    }
    
}