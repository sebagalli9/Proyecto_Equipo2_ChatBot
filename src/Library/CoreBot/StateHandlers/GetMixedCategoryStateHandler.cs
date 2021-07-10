using System;

namespace Library
{
    /*
        POLIMORFISMO: Se aplica el patrón polimorfismo ya que las clases que 
        implementan el tipo IStateHandler implementan sus operaciones polimórficas.

        SRP: La clase cumple con el principio SRP ya que no tiene más de una razón de cambio, 
        la cual sería modificar la forma en la que se gestiona la fase de obtener preguntas mixtas.

        DIP:  La clase cumple con el principio DIP ya que la clase es de alto nivel 
        y no depende de clases de bajo nivel, sino de abstracciones. 
    */
    
    public class GetMixedCategoryStateHandler : AbstractStateHandler
    {
        public override object Handle(Request request, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, IStorage storage)
        {
            if (storage.AskMainCompleted)
            {
                foreach (MixedCategory category in CoreBot.Instance.Reader.MixedCategoryBank)
                {
                    if ((category.ParentCategoryName == user.SelectedCategory[0] && category.SecondParentCategoryName == user.SelectedCategory[1]) || (category.ParentCategoryName == user.SelectedCategory[1] && category.SecondParentCategoryName == user.SelectedCategory[0]))
                    {
                        storage.MixedCategoriesSelected.Add(category);
                    }
                }

                if (storage.MixedCategoriesSelected.Count > 0)
                {
                    storage.UpdateGetMixedCompleted(true);
                    output.SendMessage("Se ha finalizado la fase de seleccion de preguntas mixtas", request.RequestId);
                }

                return base.Handle(request, user, input, output, searcher, storage);
            }
            else
            {
                return null;
            }
        }
    }
}