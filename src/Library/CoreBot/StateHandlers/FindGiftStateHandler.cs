using System;

namespace Library
{
    /*
        POLIMORFISMO: Se aplica el patrón polimorfismo ya que las clases 
        que implementan el tipo IStateHandler implementan sus operaciones polimórficas.

        SRP: La clase cumple con el principio SRP ya que no tiene más de una razón de cambio, 
        la cual sería modificar la forma en la que se gestiona la fase de búsqueda de regalo.

    */
    
    public class FindGiftStateHandler : AbstractStateHandler
    {
        public override object Handle(IRequest request, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, IStorage storage)
        {
            if (storage.GetProductCompleted && request.CurrentState == "product")
            {
                searcher.FindGift(request.RequestId);
                request.UpdateCurrentState("initial");
                
                return null;
            }

            else
            {
                return null;
            }
        }
    }
}