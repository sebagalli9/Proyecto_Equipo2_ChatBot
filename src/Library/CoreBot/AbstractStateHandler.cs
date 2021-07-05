using System;

namespace Library
{ 
    public abstract class AbstractStateHandler: IStateHandler
    {
        private IStateHandler _nextHandler;

        public IStateHandler SetNext(IStateHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }
        
        public virtual object Handle(IReader reader, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, ConversationData storage)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(reader,user,input, output,searcher,storage);
            }
            else
            {
                return null;
            }
        }
    }
}