using System;
using System.Collections.Generic;

namespace Library
{
    /*
        SRP: La clase MixedCategory cumple con el principio SRP ya que no 
        tiene más de una razón de cambio, la cual sería modificar la forma 
        en que se agregan opciones de respuesta al diccionario AnswerOptions.

        La clase MixedCategory cumple con al patrón Expert ya que al ser la 
        clase experta en conocer la información necesaria para crear objetos MixedCategory, 
        es su responsabilidad agregar las respuestas predeterminadas a su respectivo diccionario.
    */
    public class MixedCategory
    {
        public string ParentCategoryName { get; }
        public string SecondParentCategoryName { get; }
        public string Question { get; }
        public string SubCategoryName { get; }

        public Dictionary<string, string> AnswerOptions { get; private set; }


        public MixedCategory(string parentCategoryName, string secondParentCategoryName, string question, string subCategoryName)
        {
            this.ParentCategoryName = parentCategoryName;
            this.SecondParentCategoryName = secondParentCategoryName;
            this.Question = question;
            this.SubCategoryName = subCategoryName;
            this.AnswerOptions = new Dictionary<string, string>();
        }

        public void AddAnswerOption(String num, String option)
        {
            AnswerOptions.Add(num, option);
        }
    }
}
