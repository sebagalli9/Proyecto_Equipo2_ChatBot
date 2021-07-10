using System;
using System.Collections.Generic;

namespace Library
{
    public class NoMixedAnswersStateHandler : AbstractStateHandler
    {
        public override object Handle(Request request, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, IStorage storage)
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