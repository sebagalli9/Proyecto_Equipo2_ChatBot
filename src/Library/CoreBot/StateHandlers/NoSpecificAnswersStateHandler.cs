using System;
using System.Collections.Generic;

namespace Library
{
    public class NoSpecificAnswersStateHandler : AbstractStateHandler
    {
        public override object Handle(Request request, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, IStorage storage)
        {

            storage.SpecificCategoriesSelected.Clear();
            for (int i = 0; i < 6; i++)
            {
                Random r = new Random();
                int randomNum = r.Next(CoreBot.Instance.Reader.SpecificCategoryBank.Count);
                SpecificCategory randCat = CoreBot.Instance.Reader.SpecificCategoryBank[randomNum];
                storage.SpecificCategoriesSelected.Add(randCat);
            }

            return base.Handle(request, user, input, output, searcher, storage);



        }
    }
}