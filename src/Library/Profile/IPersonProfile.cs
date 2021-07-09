using System;
using System.Collections.Generic;

namespace Library
{

    /*
    Para cumplir con la inversión de dependencias en CoreBot creamos una abstracción implementada por la clase PersonProfile
    con el fin de evitar la rigidez del código.
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
