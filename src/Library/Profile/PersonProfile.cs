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

        private List<string> pricePreferences = new List<string>();
        public List<string> PricePreferences 
        { 
            get
            {
                return this.pricePreferences;
            } 
            private set
            {
                this.pricePreferences = value;
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

        public void UpdatePricePreferences(string pricePref)
        {
            this.PricePreferences.Add(pricePref);
        }

        public void UpdateSelectedCategory(string category)
        {
            this.SelectedCategory.Add(category);
        }

        public void AddProductToSearch(string product)
        {
            this.ProductSearcherKeyWords.Add(product);
        }

        public void CleanPreferences()
        {
            this.Preferences.Clear();
            this.PricePreferences.Clear();
        }

        public void CleanSelections()
        {
            this.SelectedCategory.Clear();
            this.ProductSearcherKeyWords.Clear();
        }
    }
}
