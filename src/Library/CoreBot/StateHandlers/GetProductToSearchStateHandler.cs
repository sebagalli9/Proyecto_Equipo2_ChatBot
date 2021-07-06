using System;
using System.Collections.Generic;

namespace Library
{ 
    public class GetProductToSearchStateHandler: AbstractStateHandler
    {
        public override object Handle(IReader reader, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, ConversationData storage)
        {
            if(storage.AskSpecificCompleted)
            {
                if (storage.AnswersSpecificQuestions.ContainsValue("si"))
                {
                    foreach (KeyValuePair<string, string> category in storage.AnswersSpecificQuestions)
                    {
                        if (category.Value == "si")
                        {
                            foreach (SpecificCategory specificCategory in storage.SpecificCategoriesSelected)
                            {
                                if (specificCategory.Question == category.Key)
                                {
                                    foreach (string prod in specificCategory.Products)
                                    {
                                        user.ProductSearcherKeyWords.Add(prod);
                                    }

                                }
                            }
                        }
                    }
                }
                /* else
                {
                    storage.SpecificCategoriesSelected.Clear();
                    for (int i = 0; i < 6; i++)
                    {
                        Random r = new Random();
                        int randomNum = r.Next(reader.SpecificCategoryBank.Count);
                        SpecificCategory randCat = reader.SpecificCategoryBank[randomNum];
                        storage.SpecificCategoriesSelected.Add(randCat);
                    }
                    Console.WriteLine("Has respondido a todo que no");
                    AskMixedQuestions();
                    GetProductToSearch();
                } */

                if(user.ProductSearcherKeyWords.Count > 0)
                {
                    storage.UpdateGetProductCompleted(true);
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