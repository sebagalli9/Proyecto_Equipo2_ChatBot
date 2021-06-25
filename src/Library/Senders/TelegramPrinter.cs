using System;
using System.Collections.Generic;

namespace Library
{
    /*
    La clase TelegramPrinter implementa la interfaz IMessageSender por lo que debe implementar las operaciones 
    polimórficas y por lo tanto cumple con el patron de Polimorfismo.

    La clase cumple con el patron Expert ya que es la clase experta en enviar mensajes a Telegram.

    La clase cumple con el principio SRP ya que no tiene más de una razón de cambio.
    */
    
    public class TelegramPrinter : IMessageSender
    {
        public string Text => throw new NotImplementedException();

        public string Directory => throw new NotImplementedException();

        public void SendMessage(string message)
        {

        }
    }
}
