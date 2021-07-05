using System;

namespace Library
{ 
    public class AskMainCategoryStateHandler: AbstractStateHandler
    {
        public override object Handle(IReader reader, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, ConversationData storage)
        {
            if(storage.AskInitialCompleted)
            {
                int contador = 1;
                output.SendMessage("Elije el número correspondiente a una de las afirmaciones. A la persona a la que quieres regalarle:");
                foreach (MainCategory mainQ in reader.MainCategoryBank)
                {
                    output.SendMessage(contador + "-" + mainQ.Question);
                    storage.AnswersMainCategories.Add(contador.ToString(), mainQ.AnswerOptions[contador.ToString()]);
                    contador += 1;
                }
                foreach (MainCategory mainQ in reader.MainCategoryBank)
                {
                    output.SendMessageAnswers(mainQ.AnswerOptions);
                }
                string ans = input.GetInput();
                user.UpdateSelectedCategory(storage.AnswersMainCategories[ans]);


                output.SendMessage("Elije una segunda opción adicional:");
                string ans2 = input.GetInput();
                user.UpdateSelectedCategory(storage.AnswersMainCategories[ans2]);

                if(user.SelectedCategory.Count == 2)
                {
                    storage.UpdateAskMainCompleted(true);
                    output.SendMessage("Se ha finalizado la fase de preguntas principales");    
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