using System;
using System.Collections.Generic;

namespace Library
{
    /*
    Las operaciones de la interfaz IMesssageSender son polimórficas ya que tiene tres clases (ConsolePrinter,
    TelegramPrinter, WhatsappPrinter) que implementan esas operaciones. Por esta razon se cumple 
    con el patrón de polimorfismo.
    */
    public interface IMessageSender
    {
        void SendMessage(string message);

    }
}
