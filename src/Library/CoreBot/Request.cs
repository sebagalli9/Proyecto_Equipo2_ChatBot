using System;
using System.Collections.Generic;

namespace Library
{

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
