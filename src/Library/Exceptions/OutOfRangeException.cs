using System;
using System.Collections.Generic;

namespace Library
{
    public class OutOfRangeException : Exception
    {
        public OutOfRangeException(string message) : base(message) { }
    }
}