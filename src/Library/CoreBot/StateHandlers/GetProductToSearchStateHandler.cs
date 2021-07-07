using System;
using System.Collections.Generic;

namespace Library
{ 
    public class GetProductToSearchStateHandler: AbstractStateHandler
    {
        public override object Handle(Request request,IReader reader, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, ConversationData storage)
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

                    if(user.ProductSearcherKeyWords.Count > 0)
                    {
                        storage.UpdateGetProductCompleted(true);
                    }

                    return base.Handle(request,reader,user,input, output,searcher,storage);
                }

                else
                {
                    output.SendMessage("¿No le gusta nada? ¡Bueno, intenemos de nuevo!");
                    //return this.PrevHandler.Handle(request,reader,user,input, output,searcher,storage);
                    return null;
                      
                } 

                
            }      
            else
            {
                return null;
            }
        }

        
    }
}