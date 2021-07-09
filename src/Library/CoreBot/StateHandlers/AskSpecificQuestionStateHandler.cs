using System;
using System.Collections.Generic;
using System.Threading;

namespace Library
{
    public class AskSpecificQuestionStateHandler : AbstractStateHandler
    {
        public override object Handle(Request request, IReader reader, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, IStorage storage)
        {
            if (request.CurrentState == "specific")
            {
                if (storage.GetSpecificCompleted)
                {

                    foreach (SpecificCategory category in storage.SpecificCategoriesSelected)
                    {
                        Thread.Sleep(1000);
                        output.SendMessage(category.Question, request.RequestId);
                        //ESPERA
                        Thread.Sleep(3000);
                        //ESPERA
                        output.SendMessageAnswers(category.AnswerOptions, request.RequestId);
                        //espera
                        string aux = input.GetInput();
                        while (input.GetInput() == aux)
                        {
                        }
                        //espera
                        string ans = input.GetInput();

                        storage.AnswersSpecificQuestions.Add(category.Question, category.AnswerOptions[ans]);
                    }

                    if (storage.SpecificCategoriesSelected.Count == storage.AnswersSpecificQuestions.Count)
                    {
                        storage.UpdateAskSpecificCompleted(true);
                        output.SendMessage("Se ha finalizado la fase de preguntas especificas", request.RequestId);
                        request.UpdateCurrentState("product");
                    }

                    return base.Handle(request, reader, user, input, output, searcher, storage);
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