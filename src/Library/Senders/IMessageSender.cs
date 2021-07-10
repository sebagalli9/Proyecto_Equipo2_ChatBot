using System;
using System.Collections.Generic;

namespace Library
{
    /*
        POLIMORFISMO: Se cumple con el patrón de polimorfismo ya que las clases 
        que implementan esta interfaz implementan sus operaciones polimórficas.

        LSP: Se cumple LSP ya que los objetos de las clases que implementan la 
        interfaz IMessageSender pueden ser asignados a una variable de tipo IMessageSendery 
        el comportamiento del programa no va a cambiar. Actualmente si utilizamos un ConsolePrinter 
        o otra  clase que implemente IMessageSender, el comportamiento del programa no cambia.

        OCP: La interfaz IMessageSender hace que el medio por el que se envian los mensajes 
        del usuario sea abierto a extensión.
    */
    
    public interface IMessageSender
    {
        void SendMessage(string message, long requestId);

        void SendMessageAnswers(Dictionary<string,string> ans, long requestId);

    }
}
