using System;
using System.Collections.Generic;

namespace Library
{
     /*
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
