using System;

namespace Library
{ 
    abstract class AbstractStateHandler: IStateHandler
    {
        private IStateHandler _nextHandler;

        public IStateHandler SetNext(IStateHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }
        
        public virtual object Handle()
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle();
            }
            else
            {
                return null;
            }
        }
    }
}