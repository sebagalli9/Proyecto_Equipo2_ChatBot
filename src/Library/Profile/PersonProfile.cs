using System;
using System.Collections.Generic;

namespace Library
{

    /*
    Actualmente la clase PersonProfile no cumple con el principio SRP ya que existe más de una razón de cambio, por ejemplo:
    - Modificar la forma en que se actualiza el status.
    - Modificar la forma en que se actualiza la categoría seleccionada.
    
    La clase PersonProfile cumple con el patrón Expert ya que es la clase experta en conocer la información necesaria
    para crear instancias de la clase PersonProfile y actualizar dicha información.

    La clase no cumple con el patrón DIP ya que no depende solamente de la abstracción IValidator, sino que se requiere
    una instancia de uno de sus subtipos en cada metodo validador.
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
