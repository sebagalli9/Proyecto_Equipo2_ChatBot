using System;
using System.Collections.Generic;

namespace Library
{
    /*
    Actualmente la clase PersonProfile cumple con el principio SRP ya que no existe más de una razón de cambio.
    La única razon de cambio es modificar la forma en que se actualiza la categoría seleccionada.
    
    Atualmente la clase PersonProfile cumple con el patrón Expert ya que es la clase experta en conocer los datos
    para crear instancias de la clase PersonProfile.
    */
    
    public class PersonProfile
    {
        public string Name {get;}

        public int Price {get;}

        public string Location {get;}

        public Category selectedCategory {get;}

        public PersonProfile(string name, int price, string location)
        {
            this.Name = name;
            this.Price = price;
            this.Location = location;
        }

        public void UpdateSelectedCategory()
        {

        }
    }
}
