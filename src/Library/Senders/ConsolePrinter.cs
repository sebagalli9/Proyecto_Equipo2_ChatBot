using System;
using System.Collections.Generic;

namespace Library
{
    /*
        POLIMORFISMO: La clase ConsolePrinter implementa la interfaz IMessageSender 
        por lo que debe implementar las operaciones polimórficas y por lo tanto cumple 
        con el patrón de Polimorfismo.

        EXPERT: La clase cumple con el patrón Expert ya que es la clase experta en enviar 
        mensajes a la consola.

        SRP: La clase cumple con el principio SRP ya que no tiene más de una razón de cambio.

        ISP: La clase cumple con el principio ISP ya que no depende de un tipo que no usa.
    */
    
    public class ConsolePrinter : IMessageSender
    {
        public void SendMessage(string message,long requestId)
        {
            Console.WriteLine(message);
        }

        public void SendMessageAnswers(Dictionary<string,string> ans, long requestId)
        {
            foreach (var option in ans)
            {
                SendMessage(option.Key + " - " + option.Value, 1);
            }
        }
    }
}
