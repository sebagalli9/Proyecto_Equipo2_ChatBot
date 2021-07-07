using System;
using System.Collections.Generic;

namespace Library
{
    /*
    Si en un futuro se agregaran nuevas clases que interpreten y que lean otros tipos de formato de archivo, las operaciones
    de esta interfaz cumplirian con el patron Polimorfismo ya que las operaciones serian operaciones polimorficas. 

    Se cumple LSP ya que los objetos de las clases que implementan la interfaz IReader pueden ser asignados a una variable de 
    tipo IReader y el coportamiento del programa no va a cambiar. Actualmente si utilizamos un FileReader o un CsvReader o otra 
    clase que implemente IReader, el comportamiento del programa no cambia.

    */
    public interface IReader
    {
        List<MixedCategory> MixedCategoryBank { get; }
        List<SpecificCategory> SpecificCategoryBank { get; }
        List<InitialQuestion> InitialQuestionsBank { get; }
        List<MainCategory> MainCategoryBank { get; }

        void ReadMainCategories(string path);
        void ReadMixedCategories(string path);
        void ReadSpecificCategories(string path);
        void ReadInitialQuestions(string path);
        void UploadFiles();
        string ReadPlainText(string path);

    }
}
