using System;
using System.Threading;

namespace Library
{
    public class AskMainQuestionStateHandler : AbstractStateHandler
    {
        public override object Handle(Request request, IReader reader, IPersonProfile user, IMessageReceiver input, IMessageSender output, ISearchGift searcher, IStorage storage)
        {

            if (request.CurrentState == "main" && storage.AskInitialCompleted)
            {
                int contador = 1;
                output.SendMessage("Elije el número correspondiente a una de las afirmaciones. A la persona a la que quieres regalarle:");
                foreach (MainCategory mainQ in reader.MainCategoryBank)
                {
                    output.SendMessage(contador + "-" + mainQ.Question);
                    storage.AnswersMainCategories.Add(contador.ToString(), mainQ.AnswerOptions[contador.ToString()]);
                    contador += 1;
                    //espera
                    Thread.Sleep(700);
                    //espera
                }
                Thread.Sleep(2000);
                foreach (MainCategory mainQ in reader.MainCategoryBank)
                {
                    Thread.Sleep(200);
                    output.SendMessageAnswers(mainQ.AnswerOptions);
                    Thread.Sleep(500);
                }

                //espera
                string aux = input.GetInput();
                while (input.GetInput() == aux)
                {
                }
                //espera
                string ans = input.GetInput();
                user.UpdateSelectedCategory(storage.AnswersMainCategories[ans]);

                output.SendMessage("Elije una segunda opción adicional:");

                //espera
                string aux2 = input.GetInput();
                while (input.GetInput() == aux2)
                {
                }
                //espera

                string ans2 = input.GetInput();
                user.UpdateSelectedCategory(storage.AnswersMainCategories[ans2]);


                if (user.SelectedCategory.Count == 2)
                {
                    storage.UpdateAskMainCompleted(true);
                    output.SendMessage("Se ha finalizado la fase de preguntas principales");
                    request.UpdateCurrentState("mixed");
                }

                return base.Handle(request, reader, user, input, output, searcher, storage);
            }
            else
            {
                return null;
            }

        }
    }
}