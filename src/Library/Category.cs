using System;
using System.Collections.Generic;

namespace Library
{
    /*
    La clase Category cumple con el principio SRP ya que no tiene más de una razón de cambio.
    La clase Category cumple con al patrón Expert ya que es la clase experta en conocer la información
    necesaria para instanciar objetos Category.
    */
    public class Category
    {
        public string Name {get;}

        public string ParentCategory {get;}

        public string Option {get;}

        public Category(string name, string parentCategory, string option)
        {
             this.Name = name;
             this.ParentCategory = parentCategory;
             this.Option = option;
        }
    }
}
