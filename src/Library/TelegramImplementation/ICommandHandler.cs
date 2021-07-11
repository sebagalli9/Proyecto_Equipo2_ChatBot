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
        POLIMORFISMO: La interfaz ICommandHandler tiene la operación polimórfica Handle, 
        la cuál es implementada por todos los handlers que implementan esta interfaz.

        OCP: La implementación de la interfaz en conjunto con una cadena de responsabilidad 
        favorecen la extensibilidad de los comandos.
    */
    
    public interface ICommandHandler
    {
        ICommandHandler SetNext(ICommandHandler handler);
        object Handle(string message, long chatInfoID);
    }
}