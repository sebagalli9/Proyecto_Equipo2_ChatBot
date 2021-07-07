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
            
            if (messageText != null && ((messageText as string) == "/searchgift"))
            {
         
                IPersonProfile user = new PersonProfile(); 
                IMessageReceiver input = new TelegramGateway();
                IMessageSender output = new TelegramGateway();
                ISearchGift findG = new SearchGiftML(user,output);
                ConversationData storage = new ConversationData(); //HACER INTERFAZ DE CONVERSATIONDATA
                
                await Task.Run(() => Session.askInitialQuestionStateHandler.Handle(Session.userSessions[chatInfo.Id],Session.reader,user,input, output,findG,storage));
                
                return "searchgift Command";
            }
            else
            {
                return base.Handle(messageText, chatInfo);
            }
        }

    }
    
}