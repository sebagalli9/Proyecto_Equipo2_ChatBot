using System;

namespace Library
{
    public class GetMixedCategoryStateHandler : AbstractStateHandler
    {
        public override object Handle(Request request, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, IStorage storage)
        {
            if (storage.AskMainCompleted)
            {
                foreach (MixedCategory category in CoreBot.Instance.Reader.MixedCategoryBank)
                {
                    if ((category.ParentCategoryName == user.SelectedCategory[0] && category.SecondParentCategoryName == user.SelectedCategory[1]) || (category.ParentCategoryName == user.SelectedCategory[1] && category.SecondParentCategoryName == user.SelectedCategory[0]))
                    {
                        storage.MixedCategoriesSelected.Add(category);
                    }
                }

                if (storage.MixedCategoriesSelected.Count > 0)
                {
                    storage.UpdateGetMixedCompleted(true);
                    output.SendMessage("Se ha finalizado la fase de seleccion de preguntas mixtas", request.RequestId);
                }

                return base.Handle(request, user, input, output, searcher, storage);
            }
            else
            {
                return null;
            }
        }
    }
}