using System;
using System.Threading;


namespace Library
{
    /*
        POLIMORFISMO: Se aplica el patrón polimorfismo ya que las clases 
        que implementan el tipo IStateHandler implementan sus operaciones polimórficas.

        SRP: La clase cumple con el principio SRP ya que no tiene más de 
        una razón de cambio, la cual sería modificar la forma en la que se gestiona 
        la fase de preguntas mixtas.

    */
    public class AskMixedQuestionStateHandler : AbstractStateHandler
    {
        public override object Handle(IRequest request, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, IStorage storage)
        {
            if (request.CurrentState == "mixed")
            {

                if (storage.GetMixedCompleted)
                {

                    foreach (MixedCategory category in storage.MixedCategoriesSelected)
                    {
                        Thread.Sleep(1000);
                        output.SendMessage(category.Question, request.RequestId);
                        Thread.Sleep(1000);
                        output.SendMessageAnswers(category.AnswerOptions, request.RequestId);
                        string aux = input.GetInput();
                        while (input.GetInput() == aux)
                        {
                        }
                        string ans = input.GetInput();
                        storage.AnswersMixedQuestions.Add(category.Question, category.AnswerOptions[ans]);
                    }

                    if (storage.MixedCategoriesSelected.Count == storage.AnswersMixedQuestions.Count)
                    {
                        storage.UpdateAskMixedCompleted(true);
                        output.SendMessage("Se ha finalizado la fase de preguntas mixtas", request.RequestId);
                        request.UpdateCurrentState("specific");
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