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
    public interface ICommandHandler
    {
        ICommandHandler SetNext(ICommandHandler handler);
        
        object Handle(string message, Chat chatInfo);
    }
}