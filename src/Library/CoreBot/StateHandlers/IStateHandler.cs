using System;

namespace Library
{ 
    /*
        POLIMORFISMO: Se aplica el patrón polimorfismo ya que las clases que 
        implementan el tipo IStateHandler implementan sus operaciones polimórficas.

        OCP: La implementación de la interfaz en conjunto con una cadena de responsabilidad 
        favorecen la extensibilidad de las fases de preguntas.

        DIP: La interfaz cumple con el principio DIP ya que es de alto nivel y 
        no depende de clases de bajo nivel, sino de abstracciones. 
    */
    
    public interface IStateHandler
    {
        IStateHandler SetNext(IStateHandler handler);
        IStateHandler SetPrevious(IStateHandler handler);
        
        object Handle(IRequest request, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, IStorage storage);
    }
}