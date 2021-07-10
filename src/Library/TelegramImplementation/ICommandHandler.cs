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
        POLIMORFISMO: La interfaz ICommandHandler tiene la operación polimórfica Handler, 
        la cuál es implementada por todos los handlers que implementan esta interfaz.
    */
    
    public interface ICommandHandler
    {
        ICommandHandler SetNext(ICommandHandler handler);
        object Handle(string message, long chatInfoID);
    }
}