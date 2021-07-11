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
        POLIMORFISMO: La clase CommandNotFoundCommandHandler tiene el método Handle 
        que implementa una operación polimórfica.
    */
    
    public class CommandNotFoundHandlder : AbstractCommandHandler
    {
        public async override Task<object> Handle(string messageText, long chatInfoID)
        {
            ITelegramBotClient client = TelegramBot.Instance.Client;

            if (messageText != null)
            {
                await client.SendTextMessageAsync(
                                              chatId: chatInfoID,
                                              text: $"No logro entender lo que me estas diciendo 😕 Escribe /commands o /comandos para ver la lista de comandos "
                                            );
                return "Command Not Found";
            }
            else
            {
                return null;
            }
        }
    }
}