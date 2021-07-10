using System;
using System.Collections.Generic;

namespace Library
{
    /*
        SRP: La clase MainCategory cumple con el principio SRP ya que 
        no tiene más de una razón de cambio, la cual sería modificar la 
        forma en que se agregan opciones de respuesta al diccionario AnswerOptions.

        EXPERT: La clase MainCategory cumple con al patrón Expert ya que 
        al ser la clase experta en conocer la información necesaria para 
        crear objetos MainCategory, es su responsabilidad agregar las respuestas 
        predeterminadas a su respectivo diccionario.
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
