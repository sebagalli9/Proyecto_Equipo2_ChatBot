using System;
using System.Collections.Generic;

namespace Library
{
    /*

     
    Se cumple con el patrón de polimorfismo ya que las clases que implementan esta interfaz implementan
    sus operaciones polimórficas.

    */

    public interface IInputReceiver
    {
        string GetInput();
    }
}
