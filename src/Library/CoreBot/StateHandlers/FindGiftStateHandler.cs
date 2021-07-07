using System;

namespace Library
{
    public class FindGiftStateHandler : AbstractStateHandler
    {
        public override object Handle(Request request, IReader reader, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, IStorage storage)
        {
            if (storage.GetProductCompleted && request.CurrentState == "product")
            {
                searcher.FindGift();
                request.UpdateCurrentState("initial");
                return null;
            }

            else
            {
                return null;
            }
        }
    }
}