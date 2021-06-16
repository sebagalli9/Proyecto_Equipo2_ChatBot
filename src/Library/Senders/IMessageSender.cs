using System;
using System.Collections.Generic;

namespace Library
{
    /*
    Las operaciones de la interfaz IMesssageSender son polimórficas ya que tiene tres clases (ConsolePrinter,
    TelegramPrinter, WhatsappPrinter) que implementan esas operaciones. Se cumple con el patrón de polimorfismo.
    */
    public interface IMessageSender
    {
        void SendMessage(string message);

        string Text{get;}
        string Directory{get;}

    }
}
