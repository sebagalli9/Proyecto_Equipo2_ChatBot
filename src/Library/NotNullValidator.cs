using System;
using System.Collections.Generic;

namespace Library
{
     /*
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