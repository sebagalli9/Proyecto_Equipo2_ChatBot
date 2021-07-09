using System;
using System.Collections.Generic;

namespace Library
{
    public class GetSpecifiCategoryStateHandler : AbstractStateHandler
    {
        public override object Handle(Request request, IReader reader, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, IStorage storage)
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

                    foreach (SpecificCategory category in reader.SpecificCategoryBank)
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

                    return base.Handle(request, reader, user, input, output, searcher, storage);

                }

                else
                {
                    output.SendMessage("¿No le gusta nada? ¡Bueno, intenemos de nuevo!", request.RequestId);
                    //return  null;
                    return this.prevHandler.Handle(request, reader, user, input, output, searcher, storage);

                }


            }
            else
            {
                return null;
            }
        }
    }
}