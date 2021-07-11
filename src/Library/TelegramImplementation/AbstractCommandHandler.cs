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
    /*
        POLIMORFISMO: La clase AbstractCommandHandler tiene el método Handle 
        que implementa una operación polimórfica.

        OCP: Se puede agregar nuevos comandos en la cadena de responsabilidad 
        mediante herencia. 
    */
    
    abstract public class AbstractCommandHandler: ICommandHandler
    {
        private ICommandHandler _nextHandler;

        public ICommandHandler SetNext(ICommandHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }
        
        public virtual object Handle(string message, long chatInfoID)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(message, chatInfoID);
            }
            else
            {
                return null;
            }
        }
    }
}