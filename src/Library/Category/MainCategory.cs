using System;
using System.Collections.Generic;

namespace Library
{
    /*
    La clase MainCategory cumple con el principio SRP ya que no tiene más de una razón de cambio.
    La clase MainCategory cumple con al patrón Expert ya que es la clase experta en conocer la información
    necesaria para instanciar objetos MainCategory.
    */
    public class MainCategory
    {
        public string Question { get; }

        public Dictionary<string, string> AnswerOptions { get; private set; }

        public MainCategory(string question)
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
