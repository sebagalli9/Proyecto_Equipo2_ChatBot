using System;
using System.Collections.Generic;

namespace Library
{
    /*
        La clase SpecificCategory cumple con el principio SRP ya que no 
        tiene más de una razón de cambio, la cual sería modificar la forma 
        en que se añade información a sus dos colecciones.

        La clase SpecificCategory cumple con al patrón Expert ya que al ser 
        la clase experta en conocer la información necesaria para crear objetos 
        SpecificCategory, es su responsabilidad agregar las respuestas predeterminadas 
        y sus productos asociados a su respectivas colecciones.

    */
    public class SpecificCategory
    {
        public string Name { get; }
        public string Question { get; }
        public List<string> Products { get; }
        public Dictionary<string, string> AnswerOptions { get; private set; }


        public SpecificCategory(string name, string question)
        {
            this.Name = name;
            this.Question = question;
            this.Products = new List<string>();
            this.AnswerOptions = new Dictionary<string, string>();
        }

        public void AddProduct(string prod)
        {
            this.Products.Add(prod);
        }

        public void AddAnswerOption(String num, String option)
        {
            AnswerOptions.Add(num, option);
        }
    }
}
