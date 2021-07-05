using System;

namespace Library
{ 
    public class FindGiftStateHandler: AbstractStateHandler
    {
        public override object Handle(IReader reader, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, ConversationData storage)
        {
            if(storage.GetProductCompleted)
            {
                searcher.FindGift();
                return base.Handle(reader,user,input, output,searcher,storage); //OJO ACA, ESTO YA DEBERIA TERMINAR NO PASAR A OTRO
            }

            else
            {
                return null;
            }
        }
    }
}