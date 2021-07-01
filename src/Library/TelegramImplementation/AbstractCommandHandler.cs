using System;
using Library;
using LibraryAPI;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.IO;
using System.Text;


namespace Library
{ 
    abstract class AbstractCommandHandler: ICommandHandler
    {
        private ICommandHandler _nextHandler;

        public ICommandHandler SetNext(ICommandHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }
        
        public virtual object Handle(object sender, MessageEventArgs messageEventArgs)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(sender, messageEventArgs);
            }
            else
            {
                return null;
            }
        }
    }
}