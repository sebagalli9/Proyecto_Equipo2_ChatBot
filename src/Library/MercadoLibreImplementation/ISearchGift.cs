using System.Collections.Generic;
using System;
using LibraryAPI;
using PII_MLApi;
using System.Linq;

namespace Library
{
    /*
        LSP: Si en un futuro se desean agregar otros servicios para búsqueda 
        de productos, implementando ISearchGift se cumpliría con el principio LSP 
        ya que el comportamiento del programa no cambiaria si se sustituyera el 
        subtipo actual (SearchGiftML) por otro subtipo.

        POLIMORFISMO: Si en un futuro se desean agregar otras formas de utilizar 
        otro servicio de búsqueda de productos, implementando ISearchGift se usarían 
        operaciones polimórficas en los tipos cuyo comportamiento varía.

        OCP: La interfaz ISearchGift hace que el medio por el que se buscan 
        los productos sea abierto a extensión.
    */
    
    public interface ISearchGift
    {
        void FindGift(long requestId);

        List<MLApiSearchResult> Results { get; }
        List<MLApiSearchResult> ResultsFiltered { get; }
    }
}