using System;
using System.Collections.Generic;

namespace Library
{
     /*
     La clase NotNullValidator implementa la interfaz IValidator por lo que debe implementar las operaciones 
     polimórficas, por lo tanto cumple con el patron de Polimorfismo.
     */
     public class NotNullValidator : IValidator<String>
     {
          private bool validation = false;
          public bool IsValid(String value)
          {
               return validation;
          }
     }
}
