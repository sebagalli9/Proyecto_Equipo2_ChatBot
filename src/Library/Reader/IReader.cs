using System;
using System.Collections.Generic;

namespace Library
{
    /*
        POLIMORFISMO: Si en un futuro se agregaran nuevas clases que interpreten 
        y que lean otros tipos de formato de archivo, las operaciones de esta interfaz 
        cumplirían con el patrón Polimorfismo ya que las operaciones serían operaciones polimórficas. 

        LSP: Se cumple LSP ya que los objetos de las clases que implementan la interfaz 
        IReader pueden ser asignados a una variable de tipo IReader y el comportamiento 
        del programa no va a cambiar. Actualmente si utilizamos un FileReader o otra  
        clase que implemente IReader, el comportamiento del programa no cambia.

        OCP: La interfaz IReader  hace que el medio por el que se leen los archivos externos 
        sea abierto a extensión.

        COMPOSICIÓN: Existe una relación de composición entre las clases que implementen IReader y las 
        clases InitialQuestion, MainCategory, MixedCategory y SpecificCategory, ya que están compuestas 
        de bancos de preguntas de instancias de sus clases respectivas, las cuales no tienen un propósito
        independiente a las instancias de dichas clases. 
    */
    
    public interface IReader
    {
        IList<MixedCategory> MixedCategoryBank { get; }
        IList<SpecificCategory> SpecificCategoryBank { get; }
        IList<InitialQuestion> InitialQuestionsBank { get; }
        IList<MainCategory> MainCategoryBank { get; }

        void ReadMainCategories(string path);
        void ReadMixedCategories(string path);
        void ReadSpecificCategories(string path);
        void ReadInitialQuestions(string path);
        void UploadFiles();
        string ReadPlainText(string path);

    }
}
