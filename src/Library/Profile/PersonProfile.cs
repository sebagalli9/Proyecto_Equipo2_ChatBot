using System;
using System.Collections.Generic;

namespace Library
{

    /*
        SRP: Actualmente la clase PersonProfile cumple con el principio SRP 
        ya que no existe más de una razón de cambio la cual sería modificar 
        la forma de hacer actualizaciones de la información en el perfil.
    
        EXPERT: La clase PersonProfile cumple con el patrón Expert ya que 
        es la clase experta en conocer la información necesaria para crear 
        instancias de la clase PersonProfile y actualizar dicha información.
    */

    public class PersonProfile : IPersonProfile
    {

        private List<string> selectedCategory = new List<string>();
        public List<string> SelectedCategory { 
            get
            {
                return this.selectedCategory;
            } 
            private set
            {
                this.selectedCategory = value;
            } 
        }

        private List<string> productSearcherKeyWords = new List<string>();
        public List<string> ProductSearcherKeyWords 
        { 
            get
            {
                return this.productSearcherKeyWords;
            } 
            private set
            {
                this.productSearcherKeyWords = value;
            } 
        }

        private List<string> preferences = new List<string>();
        public List<string> Preferences 
        { 
            get
            {
                return this.preferences;
            } 
            private set
            {
                this.preferences = value;
            } 
        }

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
