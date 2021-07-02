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
    internal class CommandNotFoundHandlder : AbstractCommandHandler
    {
        public async override Task<object> Handle(object sender, MessageEventArgs messageEventArgs)
        {
            ITelegramBotClient client = TelegramBot.Instance.Client;
            Message message = messageEventArgs.Message;
            Chat chatInfo = message.Chat;
            string messageText = message.Text.ToLower();

            if (messageText != null)
            {
                await client.SendTextMessageAsync(
                                              chatId: chatInfo.Id,
                                              text: $"{chatInfo.FirstName}, no logro entender lo que me estas diciendo 😕 Escribe /commands o /comandos para ver la lista de comandos "
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