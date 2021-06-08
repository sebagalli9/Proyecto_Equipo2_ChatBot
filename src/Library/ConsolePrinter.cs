using System;
using System.Collections.Generic;

namespace Library
{
     /*
     La clase ConsolePrinter implementa la interfaz IMessageSender por lo que debe implementar las operaciones 
     polimórficas por lo tanto cumple con el patron de Polimorfismo.
     */
     public class ConsolePrinter : IMessageSender
     {
          public void SendMessage(string message)
          {
               
          }
     }
}
