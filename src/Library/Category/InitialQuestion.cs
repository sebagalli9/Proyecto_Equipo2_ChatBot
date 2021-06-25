using System;
using System.Collections.Generic;

namespace Library
{
    /*
    La clase InitialQuestion cumple con el principio SRP ya que no tiene más de una razón de cambio.
    La clase InitialQuestion cumple con al patrón Expert ya que es la clase experta en conocer la 
    información necesaria para crear objetos InitialQuestion. La clase también es experta en conocer las 
    respuestas predeterminadas posibles.
    */
    public class InitialQuestion
    {
        public string Question { get; }

        public Dictionary<string, string> AnswerOptions { get; private set; }

        public InitialQuestion(string question)
        {
            this.Question = question;
            this.AnswerOptions = new Dictionary<string, string>();
        }

        public void AddAnswerOption(String num, String option)
        {
            AnswerOptions.Add(num, option);
        }
    }
}
