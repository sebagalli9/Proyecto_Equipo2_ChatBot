using System;
using System.Collections.Generic;

namespace Library
{

    /*
    Actualmente la clase PersonProfile cumple con el principio SRP ya que no existe más de una razón de cambio la cual es:
    - Hacer actualizaciónes de información en el perfil.
    
    La clase PersonProfile cumple con el patrón Expert ya que es la clase experta en conocer la información necesaria
    para crear instancias de la clase PersonProfile y actualizar dicha información.

    La clase cumple con el principio ISP ya que no depende de un tipo que no usa.

    */

    public class PersonProfile : IPersonProfile
    {

        public List<string> SelectedCategory { get; private set; }
        public List<string> ProductSearcherKeyWords { get; private set; }
        public List<string> Preferences { get; private set; }

        public PersonProfile()
        {

            this.Preferences = new List<string>();
            this.SelectedCategory = new List<string>();
            this.ProductSearcherKeyWords = new List<string>();

        }

        public void UpdatePreferences(string pref)
        {
            this.Preferences.Add(pref);
        }

        public void UpdateSelectedCategory(string category)
        {
            this.SelectedCategory.Add(category);
        }

        public void AddProductToSearch(string product)
        {
            this.ProductSearcherKeyWords.Add(product);
        }
    }
}
