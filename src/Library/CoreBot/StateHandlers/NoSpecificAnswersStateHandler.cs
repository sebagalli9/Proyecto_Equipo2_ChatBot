using System;
using System.Collections.Generic;

namespace Library
{
    /*
        POLIMORFISMO: Se aplica el patrón polimorfismo ya que las clases 
        que implementan el tipo IStateHandler implementan sus operaciones polimórficas.

        SRP: La clase cumple con el principio SRP ya que no tiene más de una razón de cambio, 
        la cual sería modificar la forma en la que se gestiona la fase de obtener nuevas preguntas mixtas en caso de que se haya respondido a que “no” a todas las preguntas especificas.

        DIP:  La clase cumple con el principio DIP ya que la clase es de alto nivel 
        y no depende de clases de bajo nivel, sino de abstracciones. 
    */
    
    public class NoSpecificAnswersStateHandler : AbstractStateHandler
    {
        public override object Handle(Request request, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, IStorage storage)
        {

            storage.SpecificCategoriesSelected.Clear();
            for (int i = 0; i < 6; i++)
            {
                Random r = new Random();
                int randomNum = r.Next(CoreBot.Instance.Reader.SpecificCategoryBank.Count);
                SpecificCategory randCat = CoreBot.Instance.Reader.SpecificCategoryBank[randomNum];
                storage.SpecificCategoriesSelected.Add(randCat);
            }

            return base.Handle(request, user, input, output, searcher, storage);



        }
    }
}