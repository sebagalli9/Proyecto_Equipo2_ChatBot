using System;
using System.Collections.Generic;

namespace Library
{
    /*
    La clase cumple con el patrón Expert ya que es la clase experta en conocer la información para crear una respuesta pre-hecha.

    La clase cumple con el principio SRP ya que existe una sola razón de cambio.
    */

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
