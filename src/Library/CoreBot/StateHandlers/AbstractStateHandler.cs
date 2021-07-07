using System;

namespace Library
{ 
    public abstract class AbstractStateHandler: IStateHandler
    {
        private IStateHandler _nextHandler;
        public IStateHandler prevHandler {get;private set;}

        public IStateHandler SetNext(IStateHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }

        public IStateHandler SetPrevious(IStateHandler handler)
        {
            this.prevHandler = handler;
            return handler;

        } 
        
        public virtual object Handle(Request request, IReader reader, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, ConversationData storage)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(request,reader,user,input, output,searcher,storage);
            }
            else
            {
                return null;
            }
        }
    }
}