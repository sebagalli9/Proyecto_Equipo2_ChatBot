using System;
using System.Collections.Generic;

namespace Library
{
     /*
     La clase WhatsappPrinter implementa la interfaz IMessageSender por lo que debe implementar las operaciones 
     polimórficas por lo tanto cumple con el patron de Polimorfismo.

     La clase cumple con DIP ya que al ser una clase de bajo nivel depende de una abstracción IMessageSender.
     */
     public class WhatsappPrinter : IMessageSender
     {
          public string Text => throw new NotImplementedException();

          public string Directory => throw new NotImplementedException();

          public void SendMessage(string message)
          {
        
          }
     }
}
