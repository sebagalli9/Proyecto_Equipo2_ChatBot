using System;
using System.Collections.Generic;

namespace Library
{
    /*
        DIP: Se creó la interfaz IStorage para que la lógica interna del core 
        de nuestro bot (distribuida en los StateHandlers, que son clases de alto nivel) 
        se pueda abstraer de detalles. 

        LSP: Si en un futuro se desean agregar otras formas de almacenamiento, 
        implementando IStorage se cumpliría con el principio LSP ya que el comportamiento 
        del programa no cambiaria si se sustituyera el subtipo actual (ConversationData) 
        por otro subtipo.

        POLIMORFISMO: Si en un futuro se desean agregar otras formas de almacenamiento, 
        implementando IStorage se usarían operaciones polimórficas en los tipos cuyo 
        comportamiento varía.

        OCP: La interfaz IStorage hace que la forma de almacenamiento sea abierta a extensión.
    */
    public interface IStorage
    {
        List<MixedCategory> MixedCategoriesSelected { get; }
        List<SpecificCategory> SpecificCategoriesSelected { get; }
        List<String> SubCategory { get; }
        Dictionary<string, string> AnswersMainCategories { get; }
        Dictionary<string, string> AnswersMixedQuestions { get; }
        Dictionary<string, string> AnswersSpecificQuestions { get; }

        void UpdateAskInitialCompleted(bool b);
        void UpdateAskMainCompleted(bool b);
        void UpdateAskMixedCompleted(bool b);
        void UpdateAskSpecificCompleted(bool b);
        void UpdateGetMixedCompleted(bool b);
        void UpdateGetSpecificCompleted(bool b);
        void UpdateGetProductCompleted(bool b);

        bool AskInitialCompleted { get; }
        bool AskMainCompleted { get; }
        bool AskMixedCompleted { get; }
        bool AskSpecificCompleted { get; }
        bool GetMixedCompleted { get; }
        bool GetSpecificCompleted { get; }
        bool GetProductCompleted { get; }
    }
}