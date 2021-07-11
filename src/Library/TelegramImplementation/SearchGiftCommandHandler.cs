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
        POLIMORFISMO: La clase SearchGiftCommandHandler tiene el método Handle 
        que implementa una operación polimórfica.
    */

    public class SearchGiftCommandHandler : AbstractCommandHandler
    {
        public async override Task<object> Handle(string messageText, long chatInfoID)
        {
            ITelegramBotClient client = TelegramBot.Instance.Client;
            
            if (messageText != null && ((messageText as string) == "/searchgift"))
            {
                IPersonProfile user = new PersonProfile(); 
                IMessageReceiver input = new TelegramGateway();
                IMessageSender output = new TelegramGateway();
                ISearchGift findG = new SearchGiftML(user,output);
                IStorage storage = new ConversationData(); 
                
                await Task.Run(() => CoreBot.Instance.AskInitialQuestionStateHandler.Handle(CoreBot.Instance.UserSessions[chatInfoID],user,input, output,findG,storage));
                
                return "searchgift Command";
            }
            else
            {
                return base.Handle(messageText, chatInfoID);
            }
        }
    } 
}