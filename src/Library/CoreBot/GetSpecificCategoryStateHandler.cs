using System;
using System.Collections.Generic;

namespace Library
{ 
    public class GetSpecifiCategoryStateHandler: AbstractStateHandler
    {
        public override object Handle(IReader reader, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, ConversationData storage)
        {
            if(storage.AskMixedCompleted)
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
                }
                /* else
                {
                    storage.MixedCategoriesSelected.Clear();
                    for (int i = 0; i < 6; i++)
                    {
                        Random r = new Random();
                        int randomNum = r.Next(reader.MixedCategoryBank.Count);
                        MixedCategory randCat = reader.MixedCategoryBank[randomNum];
                        storage.MixedCategoriesSelected.Add(randCat);
                    }
                    AskMixedQuestions();
                    GetSpecificCategoryQuestion();
                } */

                if(storage.SpecificCategoriesSelected.Count > 0)
                {
                    storage.UpdateGetSpecificCompleted(true);
                    output.SendMessage("Se ha finalizado la fase de seleccion de preguntas especificas");
                }

                return base.Handle(reader,user,input, output,searcher,storage);

            }       
            else
            {
                return null;
            }
        }
    }
}