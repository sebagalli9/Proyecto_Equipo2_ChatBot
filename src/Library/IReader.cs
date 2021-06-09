using System;
using System.Collections.Generic;

namespace Library
{
    /*
    Si en un futuro se agregaran nuevas clases que interpreten y que lean otros tipos de formato de archivo, las operaciones
    de esta interfaz cumplirian con el patron Polimorfismo ya que las operaciones serian operaciones polimorficas. 
    */
    public interface IReader
    {
        List<Category> categoryBank {get;}
        string ReadFile();
        void AddToCategoryBank();
        List<Category> GetData();
    }
}
