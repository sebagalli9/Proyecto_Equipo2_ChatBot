using System;
using System.Collections.Generic;

namespace Library
{
    /*
    Actualmente la clase OptionsRound cumple con el principio SRP ya que la única razón de cambio es modificar
    la forma en la que se genera cada ronda nueva de opciones.

    La clase OptionsRound no cumple con el patrón Expert ya que para conocer la información necesaria para crear 
    cada nueva ronda de opciones va a tener que acudir a la clase Experta en conocer la lista de categorias 
    (la clase que implemente la interfaz IReader)
    */
    public class OptionsRound
    {
         
        public void GetNextRound()
        {

        }
    }
}
