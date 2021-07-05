using System;
using System.Collections.Generic;

namespace Library
{ 
    public class AskSpecificQuestionStateHandler: AbstractStateHandler
    {
        public override object Handle(IReader reader, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, ConversationData storage)
        {
            if(storage.GetSpecificCompleted)
            {
                output.SendMessage("Responde marcando 1 para responder si o 2 para responder no a las siguientes preguntas.");

                foreach (SpecificCategory category in storage.SpecificCategoriesSelected)
                {
                    output.SendMessage(category.Question);
                    output.SendMessageAnswers(category.AnswerOptions);
                    string ans = input.GetInput();
                    storage.AnswersSpecificQuestions.Add(category.Question, category.AnswerOptions[ans]);
                }

                if(storage.SpecificCategoriesSelected.Count == storage.AnswersSpecificQuestions.Count)
                {
                    storage.UpdateAskSpecificCompleted(true);
                    output.SendMessage("Se ha finalizado la fase de preguntas especificas"); 
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