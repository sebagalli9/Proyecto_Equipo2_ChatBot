using System;
using System.Collections.Generic;

namespace Library
{

    public class FakeAnswerReceiver : IInputReceiver
    {
        public string Text{get; private set;}

        public FakeAnswerReceiver(string text)
        {
            this.Text = text;
        }
        public string GetInput()
        {
            return this.Text;
        }
    }
}
