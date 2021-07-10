using System;
using System.Collections.Generic;

namespace Library
{
    /*
        EXPERT: La clase Request cumple con el patrón Expert ya que al ser la clase 
        experta en conocer la información necesaria para crear un Request, es su 
        responsabilidad actualizar el valor de sus propiedades.

        SRP: La clase Request cumple con el principio SRP ya que no tiene más de 
        una razón de cambio, la cual sería modificar la forma en la que se actualiza 
        la propiedad CurrentState.

    */
    public class Request
    {
        public string CurrentState { get; private set; }
        public long RequestId {get;private set;}

        public Request(string state, long requestId)
        {
            this.CurrentState = state;
            this.RequestId = requestId;
           
        }

        public void UpdateCurrentState(string state)
        {
            this.CurrentState = state;
        }
 
    }
}
