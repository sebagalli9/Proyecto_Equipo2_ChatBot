using System;
using System.Collections.Generic;

namespace Library
{
    /*
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
