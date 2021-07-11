using System;
using System.Collections.Generic;

namespace Library
{
    /*
        DIP: Se creó la interfaz IRequest para que la lógica interna 
        del core de nuestro bot (distribuida en los StateHandlers, que son clases de alto nivel) 
        se pueda abstraer de detalles. 

    */
    public interface IRequest
    {
        public string CurrentState { get;  }
        public long RequestId {get;}
        public void UpdateCurrentState(string state);
        
 
    }
}
