using System;
using System.Collections.Generic;

namespace Library
{
    /*
    La clase MixedCategory cumple con el principio SRP ya que no tiene más de una razón de cambio.
    La clase MixedCategory cumple con al patrón Expert ya que es la clase experta en conocer la información
    necesaria para instanciar objetos MidexCategory.
    */
    public class MixedCategory
    {
        public string ParentCategoryName {get;}
        public string SecondParentCategoryName {get;}
        public string Question {get;}
        public string SubCategoryName {get;}


        public MixedCategory(string parentCategoryName, string secondParentCategoryName, string question,string subCategoryName)
        {
            this.ParentCategoryName = parentCategoryName;
            this.SecondParentCategoryName = secondParentCategoryName;
            this.Question = question;
            this.SubCategoryName = subCategoryName;
        }
    }
}
