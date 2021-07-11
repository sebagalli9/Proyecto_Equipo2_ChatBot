using System;
using System.Collections.Generic;

namespace Library
{
    /*
        POLIMORFISMO: Se aplica el patrón polimorfismo ya que las clases 
        que implementan el tipo IStateHandler implementan sus operaciones polimórficas.

        SRP: La clase cumple con el principio SRP ya que no tiene más de una razón de cambio, 
        la cual sería modificar la forma en la que se gestiona la fase de obtener preguntas específicas.

    */
    
    public class GetSpecifiCategoryStateHandler : AbstractStateHandler
    {
        public override object Handle(IRequest request, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, IStorage storage)
        {
            if (storage.AskMixedCompleted)
            {
                if (storage.AnswersMixedQuestions.ContainsValue("si"))
                {
                    foreach (KeyValuePair<string, string> category in storage.AnswersMixedQuestions)
                    {
                        if (category.Value == "si")
                        {
                            foreach (MixedCategory mixedCategory in storage.MixedCategoriesSelected)
                            {
                                if (mixedCategory.Question == category.Key)
                                {
                                    storage.SubCategory.Add(mixedCategory.SubCategoryName);
                                }
                            }
                        }
                    }

                    foreach (SpecificCategory category in CoreBot.Instance.Reader.SpecificCategoryBank)
                    {
                        foreach (string subCat in storage.SubCategory)
                        {
                            if (category.Name == subCat)
                            {
                                storage.SpecificCategoriesSelected.Add(category);
                            }
                        }
                    }

                    if (storage.SpecificCategoriesSelected.Count > 0)
                    {
                        storage.UpdateGetSpecificCompleted(true);
                        output.SendMessage("Se ha finalizado la fase de seleccion de preguntas especificas", request.RequestId);
                    }

                    return base.Handle(request, user, input, output, searcher, storage);

                }

                else
                {
                    output.SendMessage("¿No le gusta nada? ¡Bueno, intenemos de nuevo!", request.RequestId);
                    //return  null;
                    return this.PrevHandler.Handle(request, user, input, output, searcher, storage);

                }


            }
            else
            {
                return null;
            }
        }
    }
}