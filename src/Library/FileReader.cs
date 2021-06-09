using System;
using System.Collections.Generic;

namespace Library
{
     /*
     Actualmente la clase FileReader no cumple con el principio SRP ya que existe más de una razón de cambio, por ejemplo:
     - Modificar la forma en la que se extrae la información de un archivo txt.
     - Modificar la forma en la que se almacenan las categorias.

     Atualmente la clase FileReader cumple con el patrón Expert ya que es la clase experta en la información que se extrae 
     del archivo txt para poder cumplir con la responsabilidad de construir una lista de objetos Category.

     Actualmente la clase FileReader cumple con el patrón Creator ya que es la clase que agrega instancias de la clase Category 
     a una lista de Categorias, guarda instancias de la clase Category y tiene los datos que seran provistos al constructor para
     inicializar las instancias de Category.
     */
     public class FileReader : IReader
     {
          public List<Category> categoryBank {get;}

          public string ReadFile() 
          {
               return null;
          }

          public void AddToCategoryBank()
          {

          }
          public List<Category> GetData()
          {
            return null;
          }
     }
}
