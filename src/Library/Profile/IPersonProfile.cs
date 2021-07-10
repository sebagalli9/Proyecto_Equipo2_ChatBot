using System;
using System.Collections.Generic;

namespace Library
{

    /*
        DIP: Se creó la interfaz IPersonProfile para que la lógica interna 
        del core de nuestro bot (distribuida en los StateHandlers, que son clases de alto nivel) 
        se pueda abstraer de detalles. 
    */

    public interface IPersonProfile
    {
        List<string> SelectedCategory { get; }
        List<string> ProductSearcherKeyWords { get; }
        List<string> Preferences { get; }
        
        void UpdatePreferences(string pref);
        void UpdateSelectedCategory(string category);
        void AddProductToSearch(string product);

    }
}
