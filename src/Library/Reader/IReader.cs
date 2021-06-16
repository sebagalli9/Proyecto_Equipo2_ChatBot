using System;
using System.Collections.Generic;

namespace Library
{
    /*
    Si en un futuro se agregaran nuevas clases que interpreten y que lean otros tipos de formato de archivo, las operaciones
    de esta interfaz cumplirian con el patron Polimorfismo ya que las operaciones serian operaciones polimorficas. 

    Se cumple LSP ya que los objetos de las clases que implementan la interfaz IReader pueden ser asignados a una variable de 
    tipo IReader y el coportamiento del programa no va a cambiar.
    Actualmente si utilizamos un FileReader o un CsvReader o otra clase que implemente IReader, el comportamiento del programa
    no cambia.

    Se cumple ISP ya que las clases que implementan la interfaz IReader no estan forzadas a implenentar un tipo que no usan.

    Ocp: PENDIENTE JUSTIFICACION
    */
    public interface IReader
    {
        List<MixedCategory> MixedCategoryBank {get;}
        List<SpecificCategory> SpecificCategoryBank {get;}
        List<InitialQuestion> InitialQuestionsBank {get;}
        List<InitialQuestion> MainCategories {get;}
         
        void ReadMainCategories();
        void ReadMixedCategories();
        void ReadSpecificCategories();
        void ReadInitialQuestions(); 
        string ReadPlainText(string path);
        
    }
}
