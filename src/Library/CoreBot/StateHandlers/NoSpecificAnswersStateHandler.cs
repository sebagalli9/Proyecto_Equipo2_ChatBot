using System;
using System.Collections.Generic;

namespace Library
{ 
    public class NoSpecificAnswersStateHandler: AbstractStateHandler
    {
        public override object Handle(Request request,IReader reader, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, ConversationData storage)
        {
                  
            storage.SpecificCategoriesSelected.Clear();
            for (int i = 0; i < 6; i++)
            {
                Random r = new Random();
                int randomNum = r.Next(reader.SpecificCategoryBank.Count);
                SpecificCategory randCat = reader.SpecificCategoryBank[randomNum];
                storage.SpecificCategoriesSelected.Add(randCat);
            }

            return base.Handle(request,reader,user,input, output,searcher,storage); 
                    
      

        }
    }
}