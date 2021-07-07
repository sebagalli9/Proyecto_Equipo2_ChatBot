using System;
using System.Collections.Generic;

namespace Library
{

    public class Request
    {
        public string CurrentState { get; private set; }

        public Request(string state)
        {
            this.CurrentState = state;
           
        }

        public void UpdateCurrentState(string state)
        {
            this.CurrentState = state;
        }

      
    }
}
