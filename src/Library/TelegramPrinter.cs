using System;
using System.Collections.Generic;

namespace Library
{
     /*
     La clase TelegramPrinter implementa la interfaz IMessageSender por lo que debe implementar las operaciones 
     polimórficas por lo tanto cumple con el patron de Polimorfismo.
     */
     public class TelegramPrinter : IMessageSender
     {
          public void SendMessage(string message)
          {
               
          }
     }
}
