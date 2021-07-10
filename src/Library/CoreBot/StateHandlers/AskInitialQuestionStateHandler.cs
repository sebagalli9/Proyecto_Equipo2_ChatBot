using System;
using System.Threading;

namespace Library
{
    public class AskInitialQuestionStateHandler : AbstractStateHandler
    {
        public override object Handle(Request request, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, IStorage storage)
        {
            if (request.CurrentState == "initial")
            {
                foreach (InitialQuestion initialQ in CoreBot.Instance.Reader.InitialQuestionsBank)
                {
                    Thread.Sleep(100);
                    output.SendMessage(initialQ.Question, request.RequestId);
                    Thread.Sleep(100);
                    output.SendMessageAnswers(initialQ.AnswerOptions, request.RequestId);
                    //espera
                    string aux = input.GetInput();
                    while (input.GetInput() == aux)
                    {
                    }
                    //espera
                    string ans = input.GetInput();
                    user.UpdatePreferences(initialQ.AnswerOptions[ans]);
                }

                if (user.Preferences.Count == CoreBot.Instance.Reader.InitialQuestionsBank.Count)
                {
                    storage.UpdateAskInitialCompleted(true);
                    output.SendMessage("Se ha finalizado la fase de preguntas iniciales", request.RequestId);
                    request.UpdateCurrentState("main");
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