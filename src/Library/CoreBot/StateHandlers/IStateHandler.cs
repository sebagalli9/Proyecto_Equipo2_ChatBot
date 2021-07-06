using System;

namespace Library
{ 
    public interface IStateHandler
    {
        IStateHandler SetNext(IStateHandler handler);
        
        object Handle(IReader reader, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, ConversationData storage);
    }
}