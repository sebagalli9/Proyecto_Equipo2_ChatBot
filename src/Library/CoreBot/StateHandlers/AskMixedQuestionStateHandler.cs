using System;
using System.Threading;


namespace Library
{ 
    public class AskMixedQuestionStateHandler: AbstractStateHandler
    {
        public override object Handle(IReader reader, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, ConversationData storage)
        {
            if(storage.GetMixedCompleted)
            {   
                //para probar en consola
                //output.SendMessage("Responde marcando 1 para responder si o 2 para responder no a las siguientes preguntas.");

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