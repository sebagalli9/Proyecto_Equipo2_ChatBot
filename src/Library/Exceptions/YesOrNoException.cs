using System;
using System.Collections.Generic;

namespace Library
{
    public class YesOrNoException : Exception
    {
        public YesOrNoException(string message) : base(message) {}
    }
}