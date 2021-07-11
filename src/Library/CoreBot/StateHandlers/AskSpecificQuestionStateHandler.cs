using System;
using System.Collections.Generic;
using System.Threading;

namespace Library
{
    /*
        POLIMORFISMO: Se aplica el patrón polimorfismo ya que las clases 
        que implementan el tipo IStateHandler implementan sus operaciones polimórficas.

        SRP: La clase cumple con el principio SRP ya que no tiene más de una razón de cambio,
         la cual sería modificar la forma en la que se gestiona la fase de preguntas especificas.

    */
    
    public class AskSpecificQuestionStateHandler : AbstractStateHandler
    {
        public override object Handle(IRequest request, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, IStorage storage)
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

                    return base.Handle(request, user, input, output, searcher, storage);
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