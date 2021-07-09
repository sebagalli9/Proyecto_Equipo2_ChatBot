using System;
using System.Collections.Generic;

namespace Library
{
    /*
    Se cumple con el patrón de polimorfismo ya que las clases que implementan esta interfaz implementan
    sus operaciones polimórficas.
    */
    public interface IMessageSender
    {
        void SendMessage(string message, long requestId);

        void SendMessageAnswers(Dictionary<string,string> ans, long requestId);

    }
}
