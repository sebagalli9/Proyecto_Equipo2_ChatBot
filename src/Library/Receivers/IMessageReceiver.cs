using System;
using System.Collections.Generic;

namespace Library
{
    /*
        POLIMORFISMO: Se cumple con el patrón de polimorfismo ya que las clases 
        que implementan esta interfaz implementan sus operaciones polimórficas.

        LSP: Se cumple LSP ya que los objetos de las clases que implementan la interfaz 
        IMessageReceiver pueden ser asignados a una variable de tipo IMessageReceiver y 
        el comportamiento del programa no va a cambiar. Actualmente si utilizamos un 
        TestAnswerReceiver o otra  clase que implemente IMessageReceiver, el comportamiento 
        del programa no cambia.

        OCP: La interfaz IMessageReceiver hace que el medio por el que se reciben los mensajes 
        del usuario sea abierto a extensión.
    */

    public interface IMessageReceiver
    {
        string GetInput();
    }
}
