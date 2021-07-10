using System;

namespace Library
{
    /*
        POLIMORFISMO: Se aplica el patrón polimorfismo ya que las clases que 
        implementan el tipo IStateHandler implementan sus operaciones polimórficas.

        OCP: Se puede agregar nuevas responsabilidades en la cadena de responsabilidad 
        mediante herencia. 

        DIP: La clase cumple con el principio DIP ya que las abstracciones no 
        deben depender de detalles.
    */
    
    public abstract class AbstractStateHandler : IStateHandler
    {
        private IStateHandler _nextHandler;
        public IStateHandler PrevHandler { get; private set; }

        public IStateHandler SetNext(IStateHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }

        public IStateHandler SetPrevious(IStateHandler handler)
        {
            this.PrevHandler = handler;
            return handler;

        }

        public virtual object Handle(Request request, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, IStorage storage)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(request, user, input, output, searcher, storage);
            }
            else
            {
                return null;
            }
        }
    }
}