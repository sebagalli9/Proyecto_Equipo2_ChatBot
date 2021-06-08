using System;
using System.Collections.Generic;

namespace Library
{
    /*
    La clase NumberValidator implementa la interfaz IValidator por lo que debe implementar las operaciones 
    polimórficas, por lo tanto cumple con el patron de Polimorfismo.
    */
    public class NumberValidator : IValidator<Int32>
    {
     private bool validation = false;
     public bool IsValid(Int32 value)
     {
          return validation;
     }
    }
}
