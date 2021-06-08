using System;
using System.Collections.Generic;

namespace Library
{
     /*
     La clase LocationValidator implementa la interfaz IValidator por lo que debe implementar las operaciones 
     polimórficas, por lo tanto cumple con el patron de Polimorfismo.
     */
     public class LocationValidator : IValidator <String>
     {
          private bool boolean = false;

          public bool IsValid(String location)
          {
               return boolean;
          }
     }
}
