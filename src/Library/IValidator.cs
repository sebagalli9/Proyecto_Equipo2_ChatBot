using System;
using System.Collections.Generic;

namespace Library
{
    /*
    */
    public interface IValidator <T>
    {
        bool IsValid(T value);

    }
}
