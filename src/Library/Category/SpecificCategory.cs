using System;
using System.Collections.Generic;

namespace Library
{
    /*
    La clase SpecificCategory cumple con el principio SRP ya que no tiene más de una razón de cambio.
    La clase SpecificCategory cumple con al patrón Expert ya que es la clase experta en conocer la información
    necesaria para instanciar objetos SpecificCategory.
    */
    public class SpecificCategory
    {
        public string Name {get;}
        public string Question {get;}
        public string Product {get;}
        public SpecificCategory(string name, string question, string product)
        {
             this.Name = name;
             this.Question = question;
             this.Product = product;
        }
    }
}
