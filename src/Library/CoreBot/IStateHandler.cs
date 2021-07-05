using System;

namespace Library
{ 
    public interface IStateHandler
    {
        IStateHandler SetNext(IStateHandler handler);
        
        object Handle();
    }
}