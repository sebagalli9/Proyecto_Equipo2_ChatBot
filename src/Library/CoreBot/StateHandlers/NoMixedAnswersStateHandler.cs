using System;
using System.Collections.Generic;

namespace Library
{
    public class NoMixedAnswersStateHandler : AbstractStateHandler
    {
        public override object Handle(Request request, IReader reader, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, IStorage storage)
        {

            storage.MixedCategoriesSelected.Clear();
            for (int i = 0; i < 6; i++)
            {
                Random r = new Random();
                int randomNum = r.Next(reader.MixedCategoryBank.Count);
                MixedCategory randCat = reader.MixedCategoryBank[randomNum];
                storage.MixedCategoriesSelected.Add(randCat);
            }


            return base.Handle(request, reader, user, input, output, searcher, storage);



        }
    }
}