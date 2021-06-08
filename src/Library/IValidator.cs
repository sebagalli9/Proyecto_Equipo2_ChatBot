using System;
using System.Collections.Generic;

namespace Library
{
    /*
    Las operaciones de la interfaz IValidator son polimórficas ya que tiene cuatro clases (NotNullValidator,
    NumberValidator, LocationValidator, StringValidator) que implementan esas operaciones. 
    Por esta razon se cumple con el patrón de polimorfismo.
    */
    public interface IValidator <T>
    {
        bool IsValid(T value);

    }
}
