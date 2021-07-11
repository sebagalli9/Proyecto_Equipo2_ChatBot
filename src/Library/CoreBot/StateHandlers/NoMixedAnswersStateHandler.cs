using System;
using System.Collections.Generic;

namespace Library
{
    /*
        POLIMORFISMO: Se aplica el patrón polimorfismo ya que las clases que implementan 
        el tipo IStateHandler implementan sus operaciones polimórficas.

        SRP: La clase cumple con el principio SRP ya que no tiene más de una razón de cambio, 
        la cual sería modificar la forma en la que se gestiona la fase de obtener nuevas 
        preguntas mixtas en caso de que se haya respondido a que “no” a todas las preguntas mixtas.

    */
    
    public class NoMixedAnswersStateHandler : AbstractStateHandler
    {
        public override object Handle(IRequest request, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, IStorage storage)
        {

            storage.MixedCategoriesSelected.Clear();
            for (int i = 0; i < 6; i++)
            {
                Random r = new Random();
                int randomNum = r.Next(CoreBot.Instance.Reader.MixedCategoryBank.Count);
                MixedCategory randCat = CoreBot.Instance.Reader.MixedCategoryBank[randomNum];
                storage.MixedCategoriesSelected.Add(randCat);
            }


            return base.Handle(request, user, input, output, searcher, storage);



        }
    }
}