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
    internal class CommandsCommandHandler : AbstractCommandHandler
    {

        public async override Task<object> Handle(object sender, MessageEventArgs messageEventArgs)
        {
            ITelegramBotClient client = TelegramBot.Instance.Client;
            Message message = messageEventArgs.Message;
            Chat chatInfo = message.Chat;
            string messageText = message.Text.ToLower();          

            if (messageText != null && ((messageText as string) == "/commands" || (messageText as string) == "/comandos"))
            {
                
                StringBuilder commandsStringBuilder = new StringBuilder("Lista de Comandos:\n")
                                                                                .Append("/findGift\n")
                                                                                .Append("/about\n")
                                                                                .Append("/exit\n");

                await client.SendTextMessageAsync(chatId: chatInfo.Id, text: commandsStringBuilder.ToString());
                return "/commands Command";
            }
            else
            {
                return base.Handle(sender, messageEventArgs);
            }
        }

    }
    
}