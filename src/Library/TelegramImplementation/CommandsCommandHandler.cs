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
        POLIMORFISMO: La clase CommandsCommandHandler tiene el método Handle 
        que implementa una operación polimórfica.
    */
    
    public class CommandsCommandHandler : AbstractCommandHandler
    {
        public async override Task<object> Handle(string messageText, long chatInfoID)
        {
            ITelegramBotClient client = TelegramBot.Instance.Client;   

            if (messageText != null && ((messageText as string) == "/commands" || (messageText as string) == "/comandos"))
            {
                
                StringBuilder commandsStringBuilder = new StringBuilder("Lista de Comandos:\n")
                                                                                .Append("/searchgift\n")
                                                                                .Append("/about\n")
                                                                                ;

                await client.SendTextMessageAsync(chatId: chatInfoID, text: commandsStringBuilder.ToString());
                return "/commands Command";
            }
            else
            {
                return base.Handle(messageText, chatInfoID);
            }
        }
    }
}