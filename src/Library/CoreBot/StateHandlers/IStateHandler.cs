using System;

namespace Library
{ 
    public interface IStateHandler
    {
        IStateHandler SetNext(IStateHandler handler);
        IStateHandler SetPrevious(IStateHandler handler);
        
        object Handle(Request request, IReader reader, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, ConversationData storage);
    }
}