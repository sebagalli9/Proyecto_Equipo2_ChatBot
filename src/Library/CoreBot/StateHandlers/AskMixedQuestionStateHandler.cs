using System;
using System.Threading;


namespace Library
{ 
    public class AskMixedQuestionStateHandler: AbstractStateHandler
    {
        public override object Handle(Request request, IReader reader, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, ConversationData storage)
        {
            if(request.CurrentState == "mixed")
            {
  
                if(storage.GetMixedCompleted)
                {   
                   
                    foreach (MixedCategory category in storage.MixedCategoriesSelected)
                    {   
                        Thread.Sleep(1000);
                        output.SendMessage(category.Question);
                        Thread.Sleep(1000);
                        output.SendMessageAnswers(category.AnswerOptions);
                        string aux = input.GetInput();
                        while (input.GetInput() == aux)
                        {
                        }
                        string ans = input.GetInput();
                        storage.AnswersMixedQuestions.Add(category.Question, category.AnswerOptions[ans]);
                    }

                    if(storage.MixedCategoriesSelected.Count == storage.AnswersMixedQuestions.Count)
                    {
                        storage.UpdateAskMixedCompleted(true);
                        output.SendMessage("Se ha finalizado la fase de preguntas mixtas"); 
                        request.UpdateCurrentState("specific");
                    }

                    return base.Handle(request,reader,user,input, output,searcher,storage);
                }      
                else
                {
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