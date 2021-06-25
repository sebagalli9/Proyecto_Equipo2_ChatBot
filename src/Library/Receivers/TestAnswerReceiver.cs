using System;
using System.Collections.Generic;

namespace Library
{

    public class TestAnswerReceiver : IInputReceiver
    {
        public string Text { get; private set; }

        public TestAnswerReceiver(string text)
        {
            this.Text = text;
        }
        public string GetInput()
        {
            return this.Text;
        }
    }
}
