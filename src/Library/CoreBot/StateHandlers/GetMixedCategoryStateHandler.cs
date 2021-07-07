using System;

namespace Library
{
    public class GetMixedCategoryStateHandler : AbstractStateHandler
    {
        public override object Handle(Request request, IReader reader, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, IStorage storage)
        {
            if (storage.AskMainCompleted)
            {
                foreach (MixedCategory category in reader.MixedCategoryBank)
                {
                    if ((category.ParentCategoryName == user.SelectedCategory[0] && category.SecondParentCategoryName == user.SelectedCategory[1]) || (category.ParentCategoryName == user.SelectedCategory[1] && category.SecondParentCategoryName == user.SelectedCategory[0]))
                    {
                        storage.MixedCategoriesSelected.Add(category);
                    }
                }

                if (storage.MixedCategoriesSelected.Count > 0)
                {
                    storage.UpdateGetMixedCompleted(true);
                    output.SendMessage("Se ha finalizado la fase de seleccion de preguntas mixtas");
                }

                return base.Handle(request, reader, user, input, output, searcher, storage);
            }
            else
            {
                return null;
            }
        }
    }
}